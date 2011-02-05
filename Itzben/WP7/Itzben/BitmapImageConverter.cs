using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Itzben
{
	// Created by Nigel Sampson http://compiledexperience.com/blog/posts/useful-calue-converters
	// Copyright 2011 Nigel Sampson. Used by permission.	
	public class BitmapImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string)
				return new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));

			if (value is Uri)
				return new BitmapImage((Uri)value);

			throw new NotSupportedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}

}
