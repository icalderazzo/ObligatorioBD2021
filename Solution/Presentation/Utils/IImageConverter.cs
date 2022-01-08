
using System.Drawing;

namespace Presentation.Utils
{
    public interface IImageConverter
    {
        Image ConvertFromByteArray(byte[] bytes);
    }
}
