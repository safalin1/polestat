using System;

namespace PoleStat.StatisticsPages
{
	internal class CurrentDatePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			const string top = "DATE:";

			string bottom = $"{DateTime.Now:D}";

			return new DisplayMessage(top, bottom);
		}

		public override string ToString()
		{
			return "Current Date";
		}
	}
}
