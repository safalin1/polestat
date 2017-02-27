namespace PoleStat.StatisticsPages
{
	internal class GpuRamPage : BaseGpuPage
	{
		public override DisplayMessage GetMessage()
		{
			base.GetMessage();

			long ram = long.Parse(ManagementObject["AdapterRAM"].ToString());

			return new DisplayMessage(
				topLine: GetGpuName(),
				bottomLine: $"VRAM: {FriendlyFileSizeFormatter.Format(ram, "B")}");
		}

		public override string ToString()
		{
			return "GPU RAM Details";
		}
	}
}
