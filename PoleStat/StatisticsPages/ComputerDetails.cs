using System;

namespace PoleStat.StatisticsPages
{
	internal class ComputerDetails : IStatisticsPage
	{
		private readonly DisplayMessage _message;

		public ComputerDetails()
		{
			_message = new DisplayMessage(
				topLine: "COMPUTER:",
				bottomLine: Environment.MachineName);
		}

		public DisplayMessage GetMessage()
		{
			return _message;
		}
	}
}
