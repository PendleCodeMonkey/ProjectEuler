using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem20
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 20 - Factorial digit sum


				n! means n × (n − 1) × ... × 3 × 2 × 1

				For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
				and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

				Find the sum of the digits in the number 100!

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// We convert each number 1 to 100 to a BigInteger (we need to use BigInteger because 100! is a _very_ large number [9.3326e+157])
			// We then multiply the 100 BigInteger values together and then convert the result to an array of chars, parsing each char as an integer digit
			// which we then sum.
			return Enumerable.Range(1, 100)
				.Select(i => (BigInteger)i)
				.Aggregate(BigInteger.Multiply)
				.ToString().ToCharArray()
				.Select(x => int.Parse(x.ToString()))
				.Sum();
		}
	}
}
