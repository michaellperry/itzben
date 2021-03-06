﻿using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Itzben
{
	// Created by Nigel Sampson http://compiledexperience.com/blog/posts/useful-calue-converters
	// Copyright 2011 Nigel Sampson. Used by permission.	
	public class SimpleTypeConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, string language)
		{
			return System.Convert.ChangeType(value, targetType, CultureInfo.CurrentCulture);
		}

        public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return System.Convert.ChangeType(value, targetType, CultureInfo.CurrentCulture);
		}
	}
}
