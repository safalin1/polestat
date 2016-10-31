using System.Configuration;
using System.Threading.Tasks;
using PoleStat.StatisticsPages;

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

			while (true)
			{
				foreach (IStatisticsPage page in pages)
				{
					int drawCount = 0;

					while (drawCount < 5)
					{
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
				new ComputerDetails(),
				new CurrentDatePage(),
				new CurrentTimePage(),
				new CpuUsagePage(),
				new MemoryUsagePage(),
				new NetworkDownloadUsagePage(),
				new NetworkUploadUsagePage(),
			};
		}
	}
}
