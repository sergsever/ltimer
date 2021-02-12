using itidea;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Globalization;

namespace ltimer.ModelsViews
{
	class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		private MainWindow View { get; set; }
		protected DateTime Start;
		protected NotifyIcon NI { get; set; }
		private string _left = "";

		public void SetView(MainWindow view)
		{
			View = view;
		}

		protected void MinimizeToTray(Window view)
		{
			NI = new NotifyIcon();
			NI.Icon = new System.Drawing.Icon("ltimer.ico");
			NI.Text = "LTimer: " + TimeLeft;
			NI.Visible = true;
			NI.DoubleClick +=
			delegate (object sender, EventArgs args)
			{
				view.Show();
				view.WindowState = WindowState.Normal;
			};

			view.WindowState = WindowState.Minimized;
		}
		public int Minutes { get; set; }
		public String TimeLeft {
			get
			{
				return _left; 
			}
			set
			{
				if (_left != value)
				{

					_left = value;
					if (NI != null)
						NI.Text = "LTimer: " + _left;
					NotifyPropertyChanged("TimeLeft");
				}
			} }
		public ICommand WaitCommand { get; set; }

		public MainViewModel()
		{
			WaitCommand = new WPFCommand<object>(x => { return true; }, Wait);
			Minutes = 0;
			TimeLeft = "null";
		}
		protected void Wait(object arg)
		{
			Debug.WriteLine("Wait command");
			TimeLeft = Minutes.ToString();
			Task count = new Task(Count);
			count.Start();
			MinimizeToTray(View);
//			Count();
		}

		protected void Count()
		{
			Start = DateTime.Now;
			while ((DateTime.Now - Start).TotalMinutes < Minutes)
			{
				Debug.WriteLine("Diff: " + (DateTime.Now - Start).TotalMinutes);

				if ((DateTime.Now - Start).TotalMinutes < Minutes)
				{
					TimeSpan span = DateTime.Now - Start;
					TimeSpan left = TimeSpan.FromMinutes(Minutes - span.TotalMinutes);
					TimeLeft = left.ToString("m':'s");

				}
				else
				{
					TimeLeft = "All";
					System.Media.SystemSounds.Exclamation.Play();
					NI.Icon = new System.Drawing.Icon("ready.ico");
					break;
				}
				Thread.Sleep(5000);
			}
			Debug.WriteLine("After Loop");
			TimeLeft = "All";
			System.Media.SystemSounds.Exclamation.Play();
			NI.Icon = new System.Drawing.Icon("ready.ico");


		}

		
	}
}
