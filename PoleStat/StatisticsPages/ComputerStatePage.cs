using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace PoleStat.StatisticsPages
{
	internal class ComputerStatePage : IStatisticsPage
	{
		public DisplayMessage GetMessage()
		{
			return new DisplayMessage(
				topLine: Environment.MachineName,
				bottomLine: ComputerSessionMonitor.IsLocked
					? "Locked."
					: $"{Environment.UserName} is logged in.");
		}

		public override string ToString()
		{
			return "Computer Details + Internal IP";
		}

		private static IPAddress GetLocalIpAddress()
		{
			if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
			{
				return null;
			}

			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

			return host
				.AddressList
				.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		}
	}
}
