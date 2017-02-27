using System;
using System.Runtime.InteropServices;

namespace PoleStat
{
	public static class NativeMethods
	{
		[DllImport("psapi.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll")]
		public static extern IntPtr GetShellWindow();

		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		[StructLayout(LayoutKind.Sequential)]
		public struct PerformanceInformation
		{
			public int Size;
			public IntPtr CommitTotal;
			public IntPtr CommitLimit;
			public IntPtr CommitPeak;
			public IntPtr PhysicalTotal;
			public IntPtr PhysicalAvailable;
			public IntPtr SystemCache;
			public IntPtr KernelTotal;
			public IntPtr KernelPaged;
			public IntPtr KernelNonPaged;
			public IntPtr PageSize;
			public int HandlesCount;
			public int ProcessCount;
			public int ThreadCount;
		}

		public static long GetPhysicalAvailableMemoryInMiB()
		{
			var information = new PerformanceInformation();

			if (GetPerformanceInfo(out information, Marshal.SizeOf(information)))
			{
				return Convert.ToInt64(information.PhysicalAvailable.ToInt64() * information.PageSize.ToInt64() / 1048576);
			}

			return -1;
		}

		public static long GetTotalMemoryInMiB()
		{
			var information = new PerformanceInformation();

			if (GetPerformanceInfo(out information, Marshal.SizeOf(information)))
			{
				return Convert.ToInt64((information.PhysicalTotal.ToInt64() * information.PageSize.ToInt64() / 1048576));
			}

			return -1;
		}
	}
}
