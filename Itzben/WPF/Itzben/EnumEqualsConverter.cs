using System;
using System.Globalization;
using System.Windows.Data;

namespace Itzben
{
	// Many thanks to Lars and Scott, whose answers I combined.
	// http://stackoverflow.com/questions/397556/wpf-how-to-bind-radiobuttons-to-an-enum
	public class EnumEqualsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(bool) && targetType != typeof(bool?))
				throw new InvalidOperationException("EnumEqualsConverter can only be used with boolean properties.");

			return ObjectToString(value) == ObjectToString(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.Equals(false))
				return Binding.DoNothing;
			else
				return Enum.Parse(targetType, parameter.ToString());
		}

		private static string ObjectToString(object obj)
		{
			return obj == null ? string.Empty : obj.ToString();
		}
	}
}
