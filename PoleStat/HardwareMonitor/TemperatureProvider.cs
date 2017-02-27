using OpenHardwareMonitor.Hardware;

namespace PoleStat.HardwareMonitor
{
	internal static class TemperatureProvider
	{
		private static readonly Computer _computer = new Computer();

		public static float? GpuFanSpeed { get; private set; }

		public static float? GpuTemperature { get; private set; }

		internal static void Poll()
		{
			lock (_computer)
			{
				_computer.GPUEnabled = true;
				_computer.Open();

				foreach (var hardwareItem in _computer.Hardware)
				{
					if (hardwareItem.HardwareType == HardwareType.GpuNvidia)
					{
						foreach (var sensor in hardwareItem.Sensors)
						{
							if (sensor.SensorType == SensorType.Temperature)
							{
								GpuTemperature = sensor.Value;
							}
							else if (sensor.SensorType == SensorType.Fan)
							{
								GpuFanSpeed = sensor.Value;
							}
						}
					}
				}

				_computer.Close();
			}
		}
	}
}
