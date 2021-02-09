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

		protected DateTime Start;
		private string _left;
		public int Minutes { get; set; }
		public String TimeLeft {
			get
			{
				Debug.WriteLine("Get TimeLeft: " + _left);
				return _left; 
			}
			set
			{
				if (_left != value)
				{
					Debug.WriteLine("Left: " + value);

					_left = value;
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
			Start = DateTime.Now;
			TimeLeft = Minutes.ToString();
			Task count = new Task(Count);
			count.Start(); 
//			Count();
		}

		protected void Count()
		{
//			Stopwatch watch = new Stopwatch();
//			Debug.WriteLine("Diff: " + (DateTime.Now - Start).TotalMinutes);
			while ((DateTime.Now - Start).TotalMinutes < Minutes)
			{
//				Debug.WriteLine("Diff: " + (DateTime.Now - Start).TotalMinutes);
				if ((DateTime.Now - Start).TotalMinutes < Minutes)
				{
					TimeSpan span = DateTime.Now - Start;
					TimeSpan left = TimeSpan.FromMinutes(Minutes - span.TotalMinutes);
					TimeLeft = left.ToString("m':'s");

				}
				else
				{
					TimeLeft = "All";
					System.Media.SystemSounds.Asterisk.Play();
				}
				Thread.Sleep(5000);
			}
		}
	}
}
