using System.Globalization;
using System.Windows.Data;

namespace Unimote.Server.WPF.Helpers
{
	internal class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolValue)
			{
				if (boolValue)
					return Visibility.Visible;
				return Visibility.Hidden;
			}

			throw new ArgumentException("ConverterExpectedABool");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is Visibility vis)
			{
				if (vis == Visibility.Visible)
					return true;
				return false;
			}

			throw new ArgumentException("ConverterExpectedAVisibility");
		}
	}
}
