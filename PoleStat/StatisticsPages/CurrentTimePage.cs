using System;

namespace PoleStat.StatisticsPages
{
	internal class CurrentTimePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			const string top = "TIME:";

			string bottom = $"{DateTime.Now:h:mm:ss tt}";

			return new DisplayMessage(top, bottom);
		}

		public override string ToString()
		{
			return "Current Time";
		}
	}
}
