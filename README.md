Universally useful XAML behaviors, styles, and value converters. Developed in C# for WPF, Silverlight, and WP7.

Also available through NuGet:

```
install-package itzben
```

| Name                        | Description                                                           | WPF | SL4 | WP7 |
|-----------------------------|-----------------------------------------------------------------------|-----|-----|-----|
| BindVisualStateBehavior     | Data bind an enumeration or string-valued property to a visual state. | X   | X   |     |
| BitmapImageConverter        | Convert a string or Uri to a BitmapImage.                             | X   | X   | X   |
| CollapsedWhenNullConverter  | Convert an object reference to Visibility. Useful for details pane.   | X   | X   | X   |
| EnumEqualsConverter         |	Convert an enum to a boolean. and back Useful for radio buttons.      | X   | X   | X   |
| SimpleTypeConverter         | Perform basic casting operations.                                     | X   | X   | X   |
| StringFormatConverter       | Apply standard string.Format operations.                              | X   | X   | X   |
| UpdateOnTextChangedBehavior | Emulate UpdateSourceTrigger=PropertyChanged in Silverlight.           |     | X   | X   |
| VisibleWhenEqualConverter   | Compare bound property to a constant to set Visibility.               | X   | X   | X   |
| VisibleWhenFalseConverter   | Convert a boolean to Visibility.                                      | X   | X   | X   |
| VisibleWhenTrueConverter    | Convert a boolean to Visibility.                                      | X   | X   | X   |
| CollapsedWhenNull           | Apply this style to a container to collapse it when the DataContext is null. Useful for detail panes.   | X   |     |     |

More details in Documentation.

Patches, please

This project is unfinished. If you have written a universally useful XAML resource, post it in the Issue Tracker. One of the moderators will commit it.
