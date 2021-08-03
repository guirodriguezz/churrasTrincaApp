using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace churrasTrincaApp.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;

            return new string(text.Where(char.IsDigit).ToArray());
        }

        public static ImageSource GetImageSourceFromBase64String(this string base64)
        {
            if (base64 == null)
            {
                return null;
            }

            byte[] Base64Stream = Convert.FromBase64String(base64);
            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        }
    }
}
