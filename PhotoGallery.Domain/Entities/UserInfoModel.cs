using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoGallery.Domain;

namespace PhotoGallery.Domain.Entities
{
    public class UserInfoModel
    {
        public static UserInfoModel GetInfoFromUser(User user)
        {
            UserInfoModel ui = new UserInfoModel() { Name = user.UserName,
                Access = user.Roles.Name, 
                Count = user.Uploads.Count(x => x.UserID == user.UserID) };
            return ui;
        }

        public string Name { get; set; }
        public string Access { get; set; }
        public int Count { get; set; }
    }
}
