using PoleStat.HardwareMonitor;

namespace PoleStat.StatisticsPages
{
	internal class GpuFanSpeedPage : BaseGpuPage
	{
		public override DisplayMessage GetMessage()
		{
			base.GetMessage();

			return new DisplayMessage(
				topLine: "GPU Fan Speed",
				bottomLine: $"{TemperatureProvider.GpuFanSpeed}RPM");
		}

		public override string ToString()
		{
			return "GPU Fan Speed";
		}
	}
}
