using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Itzben
{
	// Many thanks to Lars and Scott, whose answers I combined.
	// http://stackoverflow.com/questions/397556/wpf-how-to-bind-radiobuttons-to-an-enum
	public class EnumEqualsConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (targetType != typeof(bool) && targetType != typeof(bool?))
				throw new InvalidOperationException("EnumEqualsConverter can only be used with boolean properties.");

			return value.ToString() == parameter.ToString();
		}

        public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value.Equals(false))
				return DependencyProperty.UnsetValue;
			else
				return Enum.Parse(targetType, parameter.ToString(), false);
		}
	}
}
