using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.WebUI.Models;

namespace PhotoGallery.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        public PartialViewResult Menu()
        {
            NavigationModel model = new NavigationModel()
            {
                category = (string)Session["category"],
                IsAuthenticated = Request.IsAuthenticated
            };
            return PartialView(model);
        }
    }
}
