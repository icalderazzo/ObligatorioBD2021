
using System.Drawing;
using System.IO;

namespace Presentation.Utils
{
    public class ImageConverter : IImageConverter
    {
        public Image ConvertFromByteArray(byte[] bytes)
        {
            if (bytes.Length == 0)
                return null;

            Image image;
            using (var ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                return image;
            }
        }
    }
}
