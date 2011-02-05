using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Itzben
{
	public class UpdateOnTextChangedBehavior : Behavior<TextBox>
	{
		protected override void OnAttached()
		{
			AssociatedObject.TextChanged += AssociatedObject_TextChanged;
			base.OnAttached();
		}

		protected override void OnDetaching()
		{
			AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
			base.OnDetaching();
		}

		void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
		{
			AssociatedObject.GetBindingExpression(TextBox.TextProperty).UpdateSource();
		}
	}
}
