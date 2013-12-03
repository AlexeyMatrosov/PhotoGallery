using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using PhotoGallery.WebUI.Email;
using PhotoGallery.Domain.Abstract;
using PhotoGallery.Domain.Concrete;
using Ninject;

namespace PhotoGallery.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            else
            {
                return (IController)ninjectKernel.Get(controllerType);
            }
        }
        private void AddBindings()
        {
           ninjectKernel.Bind<IPhotoRepository>().To<EFPhotoRepository>();
           ninjectKernel.Bind<IAuthProvider>().To<AuthProvider>();

           EmailSettings emailSettings = new EmailSettings();
           ninjectKernel.Bind<IeMailService>().To<ConcreteMailService>().WithConstructorArgument("settings", emailSettings);           
        }
    
    }
}