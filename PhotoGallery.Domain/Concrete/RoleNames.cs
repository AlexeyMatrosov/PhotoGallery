using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoGallery.Domain.Concrete
{
    public static class RoleNames
    {
        public static string Admin = "Admin";
        public static string User = "User";

        public static string[] GetRoles()
        {
            string[] arr = new string[] { Admin, User };
            return arr;
        }
    }
}
