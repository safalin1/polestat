using System;
using System.Net;

namespace PoleStat.StatisticsPages
{
	internal class ComputerDetailsExternal : IStatisticsPage
	{
		private const int _maxLength = 20;
		private readonly string _externalAddress;
		private int _startIdx = -1; 

		public ComputerDetailsExternal()
		{
			try
			{
				_externalAddress = new WebClient()
					.DownloadString("http://icanhazip.com")
					.Replace("\r", string.Empty)
					.Replace("\n", string.Empty);
			}
			catch (WebException)
			{
				_externalAddress = "No internet connection";
				return;
			}

			IPAddress address;

			if (!IPAddress.TryParse(_externalAddress, out address))
			{
				_externalAddress = "????";
			}
		}

		public DisplayMessage GetMessage()
		{
			if (_startIdx < 0 || _startIdx > (_externalAddress.Length - _maxLength) || _startIdx > _externalAddress.Length)
			{
				_startIdx = 0;
			}
			else
			{
				_startIdx++;
			}

			string message;

			try
			{
				message = _externalAddress.Substring(_startIdx, _maxLength);
			}
			catch (ArgumentOutOfRangeException)
			{
				_startIdx = 0;
				message = _externalAddress.Substring(_startIdx, _maxLength);
			}

			return new DisplayMessage(
				topLine: "External Network IP",
				bottomLine: message);
		}

		public override string ToString()
		{
			return "Computer Details + External IP";
		}
	}
}
