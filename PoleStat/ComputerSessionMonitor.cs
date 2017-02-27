using System;
using Microsoft.Win32;

namespace PoleStat
{
	internal static class ComputerSessionMonitor
	{
		public static bool IsLocked { get; private set; }

		public static void Initialise()
		{
			SystemEvents.SessionSwitch += OnSessionSwitch;
		}

		private static void OnSessionSwitch(object sender, SessionSwitchEventArgs e)
		{
			if (e.Reason == SessionSwitchReason.SessionLock)
			{
				IsLocked = true;
				DisplayManager.Clear();
			}
			else if (e.Reason == SessionSwitchReason.SessionUnlock)
			{
				IsLocked = false;
				DisplayManager.SendMessage(new DisplayMessage("WELCOME BACK", Environment.UserName));
			}
		}
	}
}
