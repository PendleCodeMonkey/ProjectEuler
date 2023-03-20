using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem63
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 63 - Powerful digit counts


				The 5-digit number, 16807=7⁵, is also a fifth power. Similarly, the 9-digit number, 134217728=8⁹, is a ninth power.

				How many n-digit positive integers exist which are also an nth power?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			int count = 0;
			// Only need to check numbers 1 to 9 because, for values of i >= 10, i^pow will have at least pow+1 digits and will therefore
			// never satisfy the "n-digit positive integer being an nth power" criteria.
			for (int i = 1; i <= 9; i++)
			{
				int numDigits;
				// Iterate through values for the power (starting at 1), raise i to the value of pow, and keep doing so until
				// i^pow has fewer than pow digits.
				for (int pow = 1; (numDigits = BigInteger.Pow(new BigInteger(i), pow).ToString().Length) >= pow; pow++)
				{
					// If the number of digits is equal to the power then increment the count (as we've found one more
					// n-digit integer than is also an n'th power)
					if (numDigits == pow)
					{
						count++;
					}
				}
			}

			return count;
		}

		// An alternative solution.
		// The formula int(log₁₀ n)+1 can be used to determine how many digits the number n has (e.g. for the n=654321, this yields the value 6).
		// We can use this to determine the upper limit of n as int(1/(1–log₁₀ n)) so, using values of n from 1 to 9, we get the following for
		// n -> int(1/(1–log₁₀ n)) :
		//
		// 1 -> 1	(i.e. 1ⁿ is n-digits long when n <= 1)
		// 2 -> 1	(i.e. 2ⁿ is n-digits long when n <= 1)
		// 3 -> 1	(i.e. 3ⁿ is n-digits long when n <= 1)
		// 4 -> 2	(i.e. 4ⁿ is n-digits long when n <= 2)
		// 5 -> 3	(i.e. 5ⁿ is n-digits long when n <= 3)
		// 6 -> 4	(i.e. 6ⁿ is n-digits long when n <= 4)
		// 7 -> 6	(i.e. 7ⁿ is n-digits long when n <= 6)
		// 8 -> 10  (i.e. 8ⁿ is n-digits long when n <= 10)
		// 9 -> 21  (i.e. 9ⁿ is n-digits long when n <= 21)
		//
		// Summing these values (i.e. 1 + 1 + 1 + 2 + 3 + 4 + 6 + 10 + 21) gives us the final answer (of 49)
		static internal int Solve2()
		{
			int sum = 0;
			// Only need to check values of n between 1 and 9 because 10ⁿ is always n+1 digits in length.
			for (int n = 1; n <= 9; n++)
			{
				// Perform the int(1/(1–log₁₀ n)) calculation for this value of n, adding the result to the sum.
				sum += (int)(1 / (1 - Math.Log10(n)));
			}

			return sum;
		}
	}
}
