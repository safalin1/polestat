using System.Configuration;
using System.Diagnostics;

namespace PoleStat.StatisticsPages
{
	internal class NetworkDownloadUsagePage : IStatisticsPage
	{
		private readonly PerformanceCounter _counter;

		public NetworkDownloadUsagePage()
		{
			_counter = new PerformanceCounter("Network Interface", "Bytes Received/sec", ConfigurationManager.AppSettings["NetworkAdapter"]);
		}

		public DisplayMessage GetMessage()
		{
			const string top = "Download Usage";

			float v = _counter.NextValue();

			string bottom = $"{FriendlyFileSizeFormatter.Format(v, "b")}/sec";

			return new DisplayMessage(top, bottom);
		}
	}
}
