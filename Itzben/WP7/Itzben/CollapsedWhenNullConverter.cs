using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Itzben
{
	public class CollapsedWhenNullConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(Visibility) && targetType != typeof(Visibility?))
				throw new InvalidOperationException("CollapsedWhenNullConverter can only be used with Visibility properties.");

			return value == null ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
