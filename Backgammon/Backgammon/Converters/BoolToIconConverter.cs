using Backgammon.Models;
using System.Globalization;
namespace Backgammon.Converters
{
    public class BoolToIconConverter : IValueConverter
    {
        public string IconOn { get; set; } = string.Empty;
        public string IconOff { get; set; } = string.Empty;
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string icon = IconOff;
            if (value != null)
                icon = (bool)value ? IconOn : IconOff;
            return icon;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
