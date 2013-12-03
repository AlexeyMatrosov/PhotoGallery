using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PhotoGallery.Domain.Abstract;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Concrete;
using PhotoGallery.WebUI.Infrastructure;

namespace PhotoGallery.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IPhotoRepository repo;
        public const int CountOfCarousel = 3; // количество элементов в карусели

        public HomeController(IPhotoRepository r)
        {
            repo = r;
        }

        public ActionResult Index()
        {
            Session["category"] = "Home";
            List<PhotoInfoModel> photos;
            UserInfoModel user = (UserInfoModel)Session["UserInfo"];
            if(user == null)
                photos = repo.GetPhotos(CountOfCarousel, DateTime.Now, "");
            else
                photos = repo.GetPhotos(CountOfCarousel, DateTime.Now, user.Name);
            if (photos.Count == 0)
            {
                photos.Add(new PhotoInfoModel() { Description = "", Name = PathBuilder.DefImage, Rating = 0, UploadedDate = DateTime.Now });
            }
            return View(photos);
        }

        [OutputCache(Duration = 15 * 60)]
        public FilePathResult GetImage(string photo)
        {
            var ph = repo.Photos.FirstOrDefault(x => x.Name == photo);
            if (ph != null)
                return File(PathBuilder.GetCurrentPath(photo), "image\\*");
            else
                return File(PathBuilder.GetDefaultImagePath(), "image\\*");
        }
    }
}
