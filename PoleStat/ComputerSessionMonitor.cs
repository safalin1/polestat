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
			}
			else if (e.Reason == SessionSwitchReason.SessionUnlock)
			{
				IsLocked = false;
			}
		}
	}
}
