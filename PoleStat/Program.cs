using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoleStat
{
	internal class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);

			DisplayManager.Initialise();
			ComputerSessionMonitor.Initialise();

			DisplayManager.Clear();

			Task.Run(() => DisplayStatistics());

			Application.Run(new UI.MainWindow());

			Application.ApplicationExit += OnAppExit;
		}

		private static void OnAppExit(object sender, EventArgs eventArgs)
		{
			UI.MainWindow.Instance.ExitApp(sender, eventArgs);
		}

		private static void DisplayStatistics()
		{
			new StatisticsPageRotator().Process();
		}
	}
}
