using System;

namespace PoleStat
{
	internal static class FriendlyFileSizeFormatter
	{
		public static string Format(double input, string suffix)
		{
			string[] ordinals = { "", "k", "M", "G", "T", "P", "E" };

			decimal rate = (decimal)input;
			int ordinal = 0;

			while (rate > 1024)
			{
				rate /= 1024;
				ordinal++;
			}

			return string.Format("{0}{1}" + suffix, Math.Round(rate, 2, MidpointRounding.AwayFromZero), ordinals[ordinal]);
		}
	}
}
