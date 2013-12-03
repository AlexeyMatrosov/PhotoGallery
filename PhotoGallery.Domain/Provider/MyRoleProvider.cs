using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Routing;
using PhotoGallery.Domain.Concrete;

namespace PhotoGallery.Domain.Provider
{
    public class MyRoleProvider:RoleProvider
    {
        private PhotoGalleryEntities context = new PhotoGalleryEntities();//доступ к бд

        public MyRoleProvider()
        {
            LoadRoles();
        }
        private void LoadRoles()
        {
            string[] roles = RoleNames.GetRoles();
            for (int i = 0; i < roles.Length; i++)
            {
                string newRole = roles[i];
                var uniq = context.Roles.FirstOrDefault(x => x.Name.Equals(newRole));
                if (uniq == null)
                {
                    Role r = new Role() { Name = roles[i] };
                    context.Roles.AddObject(r);
                }
                context.SaveChanges();
            } 
           context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Roles); 
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Users);
            if (RoleExists(roleNames[0]))
            {
                string name = usernames[0];
                string role = roleNames[0];
                var user = context.Users.FirstOrDefault(x => x.UserName == name);
                if (user != null)
                {
                    user.Access = context.Roles.FirstOrDefault(x => x.Name == role).RoleID;
                    context.SaveChanges();
                }
                else
                    throw new ArgumentException();
            }
            else
                throw new ArgumentException();
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void CreateRole(string roleName)
        {
            Role role = new Role { Name = roleName };
            context.AddToRoles(role);
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Roles);
            return context.Roles.Select(x=> x.Name)
                         .ToArray();
        }
        public override string[] GetRolesForUser(string username)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Users);
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Roles);
            return new string[1]{(context.Users.FirstOrDefault(x => x.UserName == username).Roles.Name)};
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Roles);
            var role = context.Roles.FirstOrDefault(x => x.Name == roleName);
            return (role==null)?false:true;
        }
    }
}