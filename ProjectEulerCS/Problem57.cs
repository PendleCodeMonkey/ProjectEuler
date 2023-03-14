using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem57
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 57 - Square root convergents


				It is possible to show that the square root of two can be expressed as an infinite continued fraction.

				√2 = 1 + 1/(2 + 1/(2 + 1/(2 + … ))) = 1.414213…

				By expanding this for the first four iterations, we get:

				1 + 1/2 = 3/2 = 1.5
				1 + 1/(2 + 1/2) = 7/5 = 1.4
				1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666…
				1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379…

				The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits
				in the numerator exceeds the number of digits in the denominator.

				In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?

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

			// The first fraction (3/2) has already been supplied in the problem description so initialize the
			// numerator to 3 and denominator to 2.
			// Using BigInteger because the numbers start to get very large.
			BigInteger numerator = new(3);
			BigInteger denominator = new(2);

			int count = 0;
			for (int i = 0; i < 1000; i++)
			{
				// Convert both the numerator and denominator to collections of their digits and use them to check if the numerator has more
				// digits than the denominator.
				if (Digits(numerator).Count() > Digits(denominator).Count())
				{
					count++;
				}

				// Next value of the numerator is the sum of the previous numerator and double the previous denominator.
				// Next value of the denominator is the sum of the previous numerator and previous denominator.
				(numerator, denominator) = (numerator + (denominator * 2), numerator + denominator);
			}
			return count;
		}
	}
}
