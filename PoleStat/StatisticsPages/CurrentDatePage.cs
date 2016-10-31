using System;

namespace PoleStat.StatisticsPages
{
	internal class CurrentDatePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			const string top = "Today's date is";

			string bottom = DateTime.Now.Date.ToShortDateString();

			return new DisplayMessage(top, bottom);
		}
	}
}
