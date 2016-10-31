using System.Configuration;
using System.Diagnostics;

namespace PoleStat.StatisticsPages
{
	internal class NetworkUploadUsagePage : IStatisticsPage
	{
		private readonly PerformanceCounter _counter;

		public NetworkUploadUsagePage()
		{
			_counter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", ConfigurationManager.AppSettings["NetworkAdapter"]);
		}

		public DisplayMessage GetMessage()
		{
			const string top = "Upload usage";

			float v = _counter.NextValue();

			string bottom = $"{FriendlyFileSizeFormatter.Format(v, "b")}/sec";

			return new DisplayMessage(top, bottom);
		}
	}
}
