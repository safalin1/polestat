namespace PoleStat.StatisticsPages
{
	internal class GpuNamePage : BaseGpuPage
	{
		public override DisplayMessage GetMessage()
		{
			base.GetMessage();

			return new DisplayMessage(
				topLine: "Graphics Card",
				bottomLine: GetGpuName());
		}

		public override string ToString()
		{
			return "GPU Name";
		}
	}
}
