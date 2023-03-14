using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem56
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 56 - Powerful digit sum


				A googol (10¹⁰⁰) is a massive number: one followed by one-hundred zeros; 100¹⁰⁰ is almost unimaginably large: one followed by two-hundred zeros.
				Despite their size, the sum of the digits in each number is only 1.

				Considering natural numbers of the form, aᵇ, where a, b < 100, what is the maximum digital sum?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that converts a specified (potentially large) number to a sequence containing its digits.
			static IEnumerable<int> Digits(BigInteger n)
			{
				static IEnumerable<int> GetDigits(BigInteger n)
				{
					while (n > 0)
					{
						yield return (int)(n % 10);
						n /= 10;
					}
				}

				// GetDigits obtains the digits in reverse order (lowest digit to highest), so reverse the sequence before returning it.
				return GetDigits(n).Reverse();
			}

			int maxDigitalSum = 0;

			// Calculate aᵇ, for all values of a and b < 100, then calculating the sum of the digits in aᵇ, keeping track of the
			// largest sum.
			for (int a = 1; a < 100; a++)
			{
				for (int b = 1; b < 100; b++)
				{
					// Calculate aᵇ using BigIntegers (because the values soon become very large!)
					BigInteger pow = BigInteger.Pow(new BigInteger(a), b);
					// Convert the result to a list of digits, sum their values, and update maxDigitalSum if the sum exceeds
					// the current maximum.
					maxDigitalSum = Math.Max(maxDigitalSum, Digits(pow).Sum());
				}
			}

			return maxDigitalSum;
		}
	}
}
