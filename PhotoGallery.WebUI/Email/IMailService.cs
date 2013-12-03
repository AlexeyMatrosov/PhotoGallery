using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoGallery.WebUI.Models;

namespace PhotoGallery.WebUI.Email
{
    public interface IeMailService
    {
        void SentMessage(EMailModel info);
    }
}
