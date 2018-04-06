using ByteSizeLib;
using Microsoft.VisualBasic.Devices;

namespace PoleStat.StatisticsPages
{
	internal class MemoryUsagePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			var computerInfo = new ComputerInfo();

			var phav = ByteSize.FromBytes(computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory);
			var tot = ByteSize.FromBytes(computerInfo.TotalPhysicalMemory);

			decimal percentFree = (decimal)(phav.Bytes * 100.0 /tot.Bytes);
			decimal percentOccupied = 100 - percentFree;
			string top = $"RAM: {percentOccupied:0}%";
			string bottom = $"{phav.ToString("#.#")}/{tot.ToString("#.#")}";

			return new DisplayMessage(top, bottom);
		}

		public override string ToString()
		{
			return "RAM Usage";
		}
	}
}
