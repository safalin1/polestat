using System.Diagnostics;

namespace PoleStat.StatisticsPages
{
	internal class CpuUsagePage : IStatisticsPage
	{
		private readonly PerformanceCounter _counter;

		public CpuUsagePage()
		{
			_counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
		}

		public DisplayMessage GetMessage()
		{
			const string top = "CPU";

			float v = _counter.NextValue();

			string bottom = $"{v:0}%";

			return new DisplayMessage(top, bottom);
		}
	}
}
