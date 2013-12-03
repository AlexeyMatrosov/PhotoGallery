using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PhotoGallery.Domain.Abstract;
using PhotoGallery.WebUI.Models;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Concrete;
using PhotoGallery.WebUI.Infrastructure;

namespace PhotoGallery.WebUI.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        private IPhotoRepository repo;
        private IAuthProvider provider;
        public const int CountOfLoad = 9;

        public GalleryController(IPhotoRepository r, IAuthProvider p)
        {
            repo = r;
            provider = p;
        }

        public ActionResult Photos()
        {
            Session["category"] = "Gallery";
            Session["LastShowDate"] = DateTime.Now;
            return View();
        }
        public ActionResult LoadPhoto()
        {
            Session["category"] = "LoadPhoto";
            return View();
        }

        public PartialViewResult ShowPhoto(string photoName)
        {
            PhotoInfoModel model = PhotoInfoModel.GetInfoFromPhoto(repo.Photos.FirstOrDefault(x => x.Name == photoName));

            return PartialView(model);
        }


        [HttpPost]
        public ActionResult LoadPhoto(PhotoModel photo, HttpPostedFileBase image)
        {
            if(ModelState.IsValid && image != null)
            {
                string username = ((UserInfoModel)Session["UserInfo"]).Name;
                string newName = Path.Combine(username, (photo.Name + image.FileName.Substring(image.FileName.LastIndexOf("."))));

                if (repo.UploadPhoto(newName, username, photo.Description) == null)
                    ModelState.AddModelError("", "This name is already taken");
                else
                {
                    image.SaveAs(PathBuilder.GetCurrentPath(newName));
                    UserInfoModel user = provider.GetUserFromName(username);
                    Session["UserInfo"] = user;
                    return RedirectToAction("Photos");
                }
            }
            return View(photo);
        }

        public string JSLoadPhoto()
        {
            List<PhotoInfoModel> photos;
            UserInfoModel user = (UserInfoModel)Session["UserInfo"];
            DateTime lastTime;
            try
            {
                lastTime = (DateTime)Session["LastShowDate"];
            }
            catch {
                lastTime = DateTime.Now;
            }

            photos = repo.GetPhotos(CountOfLoad, lastTime, user.Name);
            List<string> res = new List<string>();
            foreach(var el in photos)
            {
                res.Add(Url.Action("GetImage", "Home", new { photo = el.Name }) + ";" + el.Name);
            }

            if (photos.Count == 0)
            {
                return null;
            }

            Session["LastShowDate"] = photos.Last().UploadedDate;
            return string.Join("|", res);
        }
    }
}
