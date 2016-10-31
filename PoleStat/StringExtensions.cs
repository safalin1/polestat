namespace PoleStat
{
	public static class StringExtensions
	{
		public static string CenterString(this string input, int totalLength)
		{
			int length = input.Length;

			return input
				.PadLeft((totalLength - length) / 2 + length)
				.PadRight(totalLength);
		}
	}
}
