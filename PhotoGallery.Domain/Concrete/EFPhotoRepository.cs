using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoGallery.Domain.Abstract;
using PhotoGallery.Domain.Entities;


namespace PhotoGallery.Domain.Concrete
{
    public class EFPhotoRepository : IPhotoRepository
    {
        private PhotoGalleryEntities context = new PhotoGalleryEntities();//доступ к бд

        public IQueryable<Photo> Photos
        {
            get { return context.Photos; }
        }
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }
        public IQueryable<Upload> Uploads
        {
            get { return context.Uploads; }
        }
        public IQueryable<Role> Roles
        {
            get { return context.Roles; }
        }


        public PhotoInfoModel UploadPhoto(string name, string username, string description)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Photos);

            Photo tempPhoto = context.Photos.FirstOrDefault(x => x.Name == name);
            if (tempPhoto != null)
                return null;

            Photo photo = new Photo()
            {
                Name = name,
                Description = description,
                AmountRating = 0,
                NumberRating = 0,
                UploadDate = DateTime.Now
            };
            context.AddToPhotos(photo);
            context.SaveChanges();
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Photos);

            Photo newPhoto = context.Photos.FirstOrDefault(x => x.Name == name);
            User user = context.Users.FirstOrDefault(x => x.UserName == username);

            if (newPhoto == null || user == null)
                throw new ArgumentException();

            Upload upload = new Upload()
            {
                UserID = user.UserID,
                PhotoID = newPhoto.PhotoID
            };
            context.AddToUploads(upload);
            context.SaveChanges();

            return PhotoInfoModel.GetInfoFromPhoto(newPhoto);
        }
        public List<PhotoInfoModel> GetPhotos(int count, DateTime time, string user)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Photos);
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Users);

            var us = context.Users.FirstOrDefault(x => x.UserName == user);
            if (us != null && us.Roles.Name != RoleNames.Admin)
                return GetPhotosByUser(count, time, user);

            var bdPhotos = context.Photos.Where(x => x.UploadDate < time)
                .OrderByDescending(x => x.UploadDate)
                .Take(count);
            List<PhotoInfoModel> photos = new List<PhotoInfoModel>();
            if (bdPhotos != null)
            {
                foreach (var ph in bdPhotos)
                {
                    photos.Add(PhotoInfoModel.GetInfoFromPhoto(ph));
                }
            }
            return photos;
        }
        private List<PhotoInfoModel> GetPhotosByUser(int count, DateTime time, string user)
        {
            context.Refresh(System.Data.Objects.RefreshMode.StoreWins, context.Uploads);
            //ищем юзера
            User dbUser = context.Users.FirstOrDefault(x=> x.UserName == user);
            //список загрузок юзера
            var uploadByUser = context.Uploads.Where(x=> x.UserID == dbUser.UserID);

            //загруженные фото
            var dbPhotosByUser = uploadByUser.Select(x => Photos.FirstOrDefault(y=> y.PhotoID == x.PhotoID));
            //необходимые фото
            var returnPhotos = dbPhotosByUser.Where(x=>x.UploadDate < time)
                .OrderByDescending(x=>x.UploadDate)
                .Take(count);

            List<PhotoInfoModel> photos = new List<PhotoInfoModel>();
            if (returnPhotos != null)
            {
                foreach (var ph in returnPhotos)
                {
                    photos.Add(PhotoInfoModel.GetInfoFromPhoto(ph));
                }
            }
            return photos;
        }
    }
}
