using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Domain.Abstract
{
    public interface IPhotoRepository
    {
        IQueryable<Photo> Photos { get; }
        IQueryable<User> Users { get; }
        IQueryable<Upload> Uploads { get; }
        IQueryable<Role> Roles { get; }

        PhotoInfoModel UploadPhoto(string name, string username, string description);
        List<PhotoInfoModel> GetPhotos(int count, DateTime time, string user = null);

    }
}
