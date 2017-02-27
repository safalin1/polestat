using System;
using System.Configuration;
using System.IO.Ports;
using PoleStat.UI;

namespace PoleStat
{
	internal static class DisplayManager
	{
		private static readonly byte[] _clearBuffer = { 27, 64 };
		private static readonly byte[] _origBuffer = { 27, 116, 0 };

		private static readonly object _door = new object();
		private static readonly SerialPort _serialPort = new SerialPort();

		public static void Initialise()
		{
			_serialPort.PortName = ConfigurationManager.AppSettings["PoleDisplayCOMPort"];
			_serialPort.WriteTimeout = 5000;
		}

		public static void Clear()
		{
			lock (_door)
			{
				_serialPort.Open();
				_serialPort.Write(_clearBuffer, 0, 2);
				_serialPort.Close();
			}
		}

		public static void SendMessage(DisplayMessage message)
		{
			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}

			string topLine = message.TopLine;
			string bottomLine = message.BottomLine;

			if (topLine.Length > 20)
			{
				throw new ArgumentException("Top line is too long.", nameof(topLine));
			}

			if (bottomLine.Length > 20)
			{
				throw new ArgumentException("Bottom line is too long.", nameof(bottomLine));
			}

			lock (_door)
			{
				_serialPort.Open();
				//_serialPort.Write(_clearBuffer, 0, 2);
				_serialPort.Write(_origBuffer, 0, 3);

				_serialPort.Write(topLine + bottomLine);
				_serialPort.Close();
			}

			MainWindow.Instance.ActiveDisplayMessage = message;
		}
	}
}
