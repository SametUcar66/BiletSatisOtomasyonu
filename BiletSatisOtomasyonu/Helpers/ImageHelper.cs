using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Resim işlemleri
    /// </summary>
    public static class ImageHelper
    {
        public static string ImageToBase64(Image image, string filePath)
        {
            using (var ms = new MemoryStream())
            {
                var format = Path.GetExtension(filePath).ToLower() == ".png" 
                    ? ImageFormat.Png 
                    : ImageFormat.Jpeg;
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static Image Base64ToImage(string base64)
        {
            if (string.IsNullOrEmpty(base64))
                return null;

            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}