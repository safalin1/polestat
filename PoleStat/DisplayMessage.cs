namespace PoleStat
{
	internal class DisplayMessage
	{
		public string TopLine { get; }

		public string BottomLine { get; }

		public DisplayMessage(string topLine, string bottomLine)
		{
			TopLine = topLine.Trim().CenterString(20);
			BottomLine = bottomLine.Trim().CenterString(20);
		}
	}
}
