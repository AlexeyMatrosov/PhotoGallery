using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using PhotoGallery.Domain.Abstract;
using System.Web.Configuration;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using PhotoGallery.Domain.Entities;


namespace PhotoGallery.Domain.Concrete
{
    public class AuthProvider : IAuthProvider
    {
        private PhotoGalleryEntities context = new PhotoGalleryEntities();//доступ к бд

        public UserInfoModel AddUser(string name, string password, string email, string access)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Users);

            User user = context.Users.FirstOrDefault(x => x.UserName == name);
            if (user != null)
                return null;
            User dbUser = new User()
            {
                UserName = name,
                Password = password,
                Email = email,
                Access = getRolesFromName(RoleNames.User)
            };
            context.Users.AddObject(dbUser);
            context.SaveChanges();
            
            Roles.Provider.AddUsersToRoles(new string[] { name }, new string[] { access });

            return GetUserFromName(name);
        }
        public bool Validate(string name, string password)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Users);
            var user = context.Users.FirstOrDefault(x => x.UserName == name && x.Password == password);
            return (user == null) ? false : true;
        }
        public UserInfoModel GetUserFromName(string name)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Users);

            User user = context.Users.FirstOrDefault(x=> x.UserName == name);
            if (user != null)
            {
                return UserInfoModel.GetInfoFromUser(user);
            }
            else
                throw new ArgumentException();
        }
        private int getRolesFromName(string name)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Roles);
            return context.Roles.FirstOrDefault(x => x.Name == name).RoleID;
        }
    }
}
