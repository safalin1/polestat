using PoleStat.HardwareMonitor;

namespace PoleStat.StatisticsPages
{
	internal class GpuTemperaturePage : BaseGpuPage
	{
		public override DisplayMessage GetMessage()
		{
			base.GetMessage();

			return new DisplayMessage(
				topLine: "GPU Temperature",
				bottomLine: $"{TemperatureProvider.GpuTemperature}c");
		}

		public override string ToString()
		{
			return "GPU Temperature";
		}
	}
}
