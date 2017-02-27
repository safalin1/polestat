using System.Management;

namespace PoleStat.StatisticsPages
{
	internal abstract class BaseGpuPage : IStatisticsPage
	{
		private readonly ManagementObjectSearcher _managementObjectSearcher;

		protected ManagementObject ManagementObject { get; private set; }

		protected BaseGpuPage()
		{
			_managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");
		}

		public virtual DisplayMessage GetMessage()
		{
			foreach (var o in _managementObjectSearcher.Get())
			{
				ManagementObject = (ManagementObject)o;
			}

			return null;
		}

		protected string GetGpuName()
		{
			string name = ManagementObject["Name"].ToString();

			name = name.Replace("NVIDIA ", string.Empty);

			return name;
		}
	}
}
