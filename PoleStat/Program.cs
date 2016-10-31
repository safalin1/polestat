using System;
using System.Threading.Tasks;

namespace PoleStat
{
	internal class Program
	{
		private static void Main()
		{
			DisplayManager.Initialise();
			DisplayManager.Clear();

			Task.Run(() => DisplayStatistics());
			Console.ReadLine();
		}

		private static void DisplayStatistics()
		{
			new StatisticsPageRotator().Process();
		}
	}
}
