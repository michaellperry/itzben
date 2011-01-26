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

			return ObjectToString(value) == ObjectToString(parameter) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		private static string ObjectToString(object obj)
		{
			return obj == null ? string.Empty : obj.ToString();
		}
	}
}
