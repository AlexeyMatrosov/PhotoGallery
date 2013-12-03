using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.WebUI.Email;
using PhotoGallery.WebUI.Models;

namespace PhotoGallery.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private IeMailService mailService;

        public AboutController(IeMailService r)
        {
            mailService = r;
        }

        [HttpPost]
        public ActionResult About(EMailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mailService.SentMessage(model);
                }
                catch
                {
                    TempData["message"] = "The letter is incorrect";
                }
            }
            return View(model);
        }
        public ActionResult About()
        {
            Session["category"] = "About";
            return View();
        }

    }
}
