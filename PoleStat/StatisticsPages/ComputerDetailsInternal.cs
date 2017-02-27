using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace PoleStat.StatisticsPages
{
	internal class ComputerDetailsInternal : IStatisticsPage
	{
		private readonly string _localAddress;

		public ComputerDetailsInternal()
		{
			_localAddress = GetLocalIpAddress().ToString();
		}

		public DisplayMessage GetMessage()
		{
			return new DisplayMessage(
				topLine: Environment.MachineName,
				bottomLine: _localAddress);
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
