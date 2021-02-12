using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ltimer.Behaviors
{
	class TextBoxCheck : Behavior<TextBox>
	{
		void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = IsValid(e.Text);
		}

		private bool IsValid(string text)
		{
			int res; 
			return int.TryParse(text, out res);
		}
	}
}
