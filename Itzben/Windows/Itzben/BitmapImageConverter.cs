using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Itzben
{
	// Created by Nigel Sampson http://compiledexperience.com/blog/posts/useful-calue-converters
	// Copyright 2011 Nigel Sampson. Used by permission.	
	public class BitmapImageConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is string)
				return new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));

			if (value is Uri)
				return new BitmapImage((Uri)value);

			throw new NotSupportedException();
		}

        public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotSupportedException();
		}
	}

}
