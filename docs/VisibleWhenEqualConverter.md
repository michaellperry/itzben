# VisibleWhenEqualConverter
_WPF SL4 WP7_
Returns Visible when the bound property is equal to a constant, and Collapsed otherwise.

Use this converter for elaboration panes. When a certain value is selected -- perhaps in a combo box or a radio button -- the elaboration pane displays additional properties that can be set. Bind Visibility to the enumeration property, and apply this value converter. Set the parameter to the enumeration value that makes the elaboration pane appear.

Put multiple elaboration panes in a StackPanel to have them share space. Changing the controlling enumeration will swap one pane out for another.