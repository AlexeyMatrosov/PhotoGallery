using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoGallery.Domain;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Abstract
{
    public interface IAuthProvider
    {
        UserInfoModel AddUser(string name, string password, string email, string access);
        bool Validate(string name, string password);
        UserInfoModel GetUserFromName(string name);
    }
}
