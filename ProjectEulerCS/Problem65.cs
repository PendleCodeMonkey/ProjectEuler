using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem65
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 65 - Convergents of e

				See https://projecteuler.net/problem=65 for problem description.

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


			// The numerator for the first ten terms in the sequence of convergents for e are: 2, 3, 8, 11, 19, 87, 106, 193, 1264, 1457
			// This follows a pattern that can be represented by the equation nᵢ = mᵢ * nᵢ₋₁ + nᵢ₋₂ where the multiplier, m, evaluates
			// to the infinite sequence 1, 1, 2, 1, 1, 4, 1, 1, 6, 1, 1, 8, 1, 1, 10, ... (i.e. a series where every third value increments
			// by 2, and all other values are 1's)
			// So, for n₉, the value is the 9th multiplier (6) multiplied by the 8th value in the sequence (193) plus the 7th value in
			// the sequence (106) - i.e. 6 * 193 + 106, which is 1264 (which can be confirmed from above as the 9th numerator value in the
			// sequence of convergents for e)
			BigInteger x = 1;
			BigInteger y = 2;
			for (int i = 2; i <= 100; i++)
			{
				(y, x) = ((i % 3 == 0 ? 2 * i / 3 : 1) * y + x, y);
			}

			return Digits(y).Sum();
		}
	}
}
