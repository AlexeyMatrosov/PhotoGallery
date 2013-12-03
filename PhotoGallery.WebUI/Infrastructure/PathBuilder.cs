using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.WebUI.Infrastructure
{
    public abstract class PathBuilder
    {
        public const string UpFolder = "Uploads";
        public const string DefImage = "_\\default.jpg";

        public static string GetCurrentPath()
        {
            return string.Format("{0}\\{1}\\", AppDomain.CurrentDomain.BaseDirectory, UpFolder);
        }

        public static string GetCurrentPath(string filePath)
        {
            filePath = filePath.TrimStart('\\');
            return string.Format("{0}\\{1}\\{2}", AppDomain.CurrentDomain.BaseDirectory, UpFolder, filePath);
        }

        public static string GetDefaultImagePath()
        {
            return GetCurrentPath() + DefImage;
        }
    }
}