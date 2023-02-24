using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem16
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 16 - Power digit sum


				2¹⁵ [2 to the power of 15] = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

				What is the sum of the digits of the number 2¹⁰⁰⁰ [2 to the power of 1000] ?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Need to work with a BigInteger type to get 2 to the power of 1000.
			// Convert the BigInteger value to an array of chars, parse each char as an
			// integer, and sum the integer values.
			return BigInteger.Pow(2, 1000)
				.ToString().ToCharArray()
				.Select(i => int.Parse(i.ToString()))
				.Sum();
		}
	}
}
