namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem58
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 58 - Spiral primes


				Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.

					(37) 36  35  34  33  32 (31)
					 38 (17) 16  15  14 (13) 30
					 39  18  (5)  4  (3) 12  29
					 40  19   6   1   2  11  28
					 41  20  (7)  8   9  10  27
					 42  21  22  23  24  25  26
					(43) 44  45  46  47  48  49

				It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting is that 8 out
				of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.

				If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed. If this process
				is continued, what is the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function to determine if the specified value is a prime number.
			static bool IsPrime(int num) => num > 1 && !Enumerable.Range(2, (int)Math.Sqrt(num) - 1).Any(i => num % i == 0);

			int sideLength = 1;
			int numberOfPrimes = 0;

			while (true)
			{
				// Each iteration adds 2 to the length of a side (so we go from a 1x1 square to 3x3 to 5x5 to 7x7, etc.)
				sideLength += 2;
				// Determine the value of the number at the bottom right corner of a square having the current side
				// length (so, for example, for a side length of 3, the value in the bottom right corner is 9).
				int value = sideLength * sideLength;
				// Determine the values in the other three corners of the square (i.e. bottom left, top left, and top right)
				// and check if these values are prime numbers. Note that we don't need to check the value in the bottom right
				// corner because this is always a square number (e.g. 9, 25, 49, etc.) and is therefore always a composite
				// number (i.e. not prime)
				for (int i = 0; i < 3; i++)
				{
					// Adjust value so that we get the number that is in one of the other corners.
					value -= (sideLength - 1);
					// Check if this value is a prime number.
					if (IsPrime(value))
					{
						// Yep, it is, so increment the count.
						numberOfPrimes++;
					}
				}
				// Calculate the total number of values that lie on both diagonals (which is twice the side length, minus 1)
				int numDiagonalNums = 2 * sideLength - 1;
				// Determine if the number of primes is less than 10% of the total number of values on both diagonals. If so, we're done!
				if (numberOfPrimes < numDiagonalNums * 0.1)
				{
					break;
				}
			}

			return sideLength;
		}
	}
}
