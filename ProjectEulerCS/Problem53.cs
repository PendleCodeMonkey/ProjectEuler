using Microsoft.VisualBasic;
using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem53
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 53 - Combinatoric selections


				There are exactly ten ways of selecting three from five, 12345:

					123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

				In combinatorics, we use the notation, 5C3 = 10.
				In general, nCr = n! / r!(n−r)!, where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
				It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.
				How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that calculates the binomial coefficient (nCk) (choose k items out of n)
			// Using BigInteger because values can become very large (i.e. larger than long.MaxValue)
			static BigInteger BinomialCoeff(long n, long k)
			{
				if (k > n)
				{
					return 0;
				}
				if (n == k)
				{
					// When n == k there's only one way to choose.
					return 1;
				}
				// Symmetrical around n-k, so we only need to iterate across the smaller of k and n-k
				BigInteger result = 1;
				long iterations = Math.Min(k, n - k);
				for (long i = 0; i < iterations; i++)
				{
					result = result * (n - i) / (i + 1);
				}
				return result;
			}

			long result = 0;
			for (long n = 1; n <= 100; n++)
			{
				for (long k = 1; k <= n; k++)
				{
					// Calculate the binomial coefficient and check if it is greater than a million.
					if (BinomialCoeff(n, k) > 1000000)
					{
						// One more value of nCr that's greater than a million to add to our count.
						result++;
					}
				}
			}

			return result;
		}
	}
}
