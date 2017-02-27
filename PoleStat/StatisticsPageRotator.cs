using System.Configuration;
using System.Threading.Tasks;
using PoleStat.HardwareMonitor;
using PoleStat.StatisticsPages;
using PoleStat.UI;

namespace PoleStat
{
	internal class StatisticsPageRotator
	{
		private readonly int _rotationDrawCount;
		private readonly int _updateTimeMilliseconds;

		public StatisticsPageRotator()
		{
			_rotationDrawCount = int.Parse(ConfigurationManager.AppSettings["StatisticsRotationUpdateCount"]);
			_updateTimeMilliseconds = int.Parse(ConfigurationManager.AppSettings["StatisticsUpdateTime"]);
		}

		public async void Process()
		{
			IStatisticsPage[] pages = GetPages();

			MainWindow.Instance.UpdateStatisticPages(pages);

			while (true)
			{
				if (ComputerSessionMonitor.IsLocked)
				{
					await Task.Delay(3000);
					continue;
				}

				foreach (IStatisticsPage page in pages)
				{
					MainWindow.Instance.SetActivePage(page);

					if (ComputerSessionMonitor.IsLocked)
					{
						break;
					}

					int drawCount = 0;

					while (drawCount < _rotationDrawCount)
					{
						if (ComputerSessionMonitor.IsLocked)
						{
							break;
						}

						if (page is GpuTemperaturePage || page is GpuFanSpeedPage)
						{
							TemperatureProvider.Poll();
						}

						DisplayManager.SendMessage(page.GetMessage());

						await Task.Delay(_updateTimeMilliseconds);
						drawCount++;
					}
				}
			}
		}

		private static IStatisticsPage[] GetPages()
		{
			return new IStatisticsPage[]
			{
				new ComputerDetailsInternal(),
				new ComputerDetailsExternal(),
				new CurrentDatePage(),
				new CurrentTimePage(),
				new CpuUsagePage(),
				new MemoryUsagePage(),
				new GpuNamePage(), 
				new GpuRamPage(), 
				new GpuTemperaturePage(),
				new GpuFanSpeedPage(), 
				new NetworkDownloadUsagePage(),
				new NetworkUploadUsagePage(),
			};
		}
	}
}
