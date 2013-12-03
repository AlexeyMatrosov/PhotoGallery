using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using PhotoGallery.WebUI.Models.UsersModel;
using PhotoGallery.Domain.Abstract;
using PhotoGallery.Domain.Concrete;
using PhotoGallery.Domain.Entities;
using PhotoGallery.WebUI.Infrastructure;
using System.IO;

namespace PhotoGallery.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider provider;
        public AccountController(IAuthProvider prov)
        {
            provider = prov;
        }
        public PartialViewResult LogOn()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session["UserInfo"] = null;
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (provider.Validate(model.Name, model.Password))
                {
                    UserInfoModel user = provider.GetUserFromName(model.Name);
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    Session["UserInfo"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["message"] = "The user name or password provided is incorrect";
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["UserInfo"] = null;
            return RedirectToAction("Index", "Home");
        }
        public PartialViewResult Register()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session["UserInfo"] = null;
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserInfoModel user = provider.AddUser(model.Name, model.Password, model.Email, RoleNames.User);
                    if (user == null)
                        TempData["message"] = "This username is already taken";
                    else
                    {
                        Directory.CreateDirectory(PathBuilder.GetCurrentPath(user.Name));
                        return LogOn(new LogOnModel { Name = model.Name, Password = model.Password }, null);
                    }
                }
                catch
                {
                    TempData["message"] = "The user data provided is incorrect";
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
