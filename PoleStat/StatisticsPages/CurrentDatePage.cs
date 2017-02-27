using System;

namespace PoleStat.StatisticsPages
{
	internal class CurrentDatePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			const string top = "Today's date is";

			string bottom = DateTime.Now.Date.ToLongDateString();

			return new DisplayMessage(top, bottom);
		}

		public override string ToString()
		{
			return "Current Date";
		}
	}
}
