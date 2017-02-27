using System;
using System.Net;

namespace PoleStat.StatisticsPages
{
	internal class ComputerDetailsExternal : IStatisticsPage
	{
		private readonly string _externalAddress;

		public ComputerDetailsExternal()
		{
			_externalAddress = new WebClient()
				.DownloadString("http://icanhazip.com")
				.Replace("\r", string.Empty)
				.Replace("\n", string.Empty);

			IPAddress temp;

			if (!IPAddress.TryParse(_externalAddress, out temp))
			{
				_externalAddress = "????";
			}
		}

		public DisplayMessage GetMessage()
		{
			return new DisplayMessage(
				topLine: Environment.MachineName,
				bottomLine: _externalAddress);
		}

		public override string ToString()
		{
			return "Computer Details + External IP";
		}
	}
}
