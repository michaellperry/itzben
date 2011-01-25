using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Itzben
{
	public class VisibleWhenEqualConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(Visibility) && targetType != typeof(Visibility?))
				throw new InvalidOperationException("VisibleWhenEqualConverter can only be used with Visibility properties.");

			return value.ToString() == parameter.ToString() ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
