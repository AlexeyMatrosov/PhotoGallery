using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoGallery.Domain;

namespace PhotoGallery.Domain.Entities
{
    public class PhotoInfoModel
    {
        public static PhotoInfoModel GetInfoFromPhoto(Photo photo)
        {
            PhotoInfoModel model = new PhotoInfoModel()
            {
                Name = photo.Name,
                Description = photo.Description,
                UploadedDate = photo.UploadDate,
                Rating = (photo.NumberRating == 0) ? 0 : photo.AmountRating / photo.NumberRating,
            };
            return model;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadedDate { get; set; }
        public decimal Rating { get; set; }
    }
}
