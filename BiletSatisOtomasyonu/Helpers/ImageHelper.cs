using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Resim dönü?türme yard?mc? s?n?f?
    /// </summary>
    public static class ImageHelper
    {
        public static string ConvertImageToBase64(Image image, string filePath)
        {
            using (var ms = new MemoryStream())
            {
                var format = GetImageFormat(filePath);
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static Image ConvertBase64ToImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return null;

            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        public static ImageFormat GetImageFormat(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            switch (extension)
            {
                case ".png": return ImageFormat.Png;
                case ".gif": return ImageFormat.Gif;
                case ".bmp": return ImageFormat.Bmp;
                default: return ImageFormat.Jpeg;
            }
        }

        public static Image LoadDefaultImage(string defaultImagePath)
        {
            if (File.Exists(defaultImagePath))
            {
                return Image.FromFile(defaultImagePath);
            }
            return null;
        }
    }
}