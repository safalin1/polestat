using System;

namespace PoleStat.StatisticsPages
{
	internal class CurrentTimePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			const string top = "The current time is";

			string bottom = DateTime.Now.ToShortTimeString();

			return new DisplayMessage(top, bottom);
		}

		public override string ToString()
		{
			return "Current Time";
		}
	}
}
