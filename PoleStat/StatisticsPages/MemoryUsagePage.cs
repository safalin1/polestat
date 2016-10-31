using System.Diagnostics;

namespace PoleStat.StatisticsPages
{
	internal class MemoryUsagePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			const string top = "RAM";

			long phav = NativeMethods.GetPhysicalAvailableMemoryInMiB();
			long tot = NativeMethods.GetTotalMemoryInMiB();
			decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
			decimal percentOccupied = 100 - percentFree;

			string bottom = $"{percentOccupied:0}%";

			return new DisplayMessage(top, bottom);
		}
	}
}
