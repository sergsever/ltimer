using ltimer.ModelsViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ltimer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			if (this.DataContext != null )
			{
				((MainViewModel)this.DataContext).SetView(this);
			}
		}

		protected override void OnStateChanged(EventArgs e)
		{
			if (WindowState == WindowState.Minimized)
				this.Hide();
			base.OnStateChanged(e);
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
