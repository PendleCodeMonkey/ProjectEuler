namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem47
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 47 - Distinct primes factors


				The first two consecutive numbers to have two distinct prime factors are:

					14 = 2 × 7
					15 = 3 × 5

				The first three consecutive numbers to have three distinct prime factors are:

					644 = 2² × 7 × 23
					645 = 3 × 5 × 43
					646 = 2 × 17 × 19.

				Find the first four consecutive integers to have four distinct prime factors each. What is the first of these numbers?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that generates a sequence containing the prime factors of the supplied value.
			static IEnumerable<long> PrimeFactors(long value)
			{
				if (value > 0)
				{
					// Return the number of 2's by which value can be divided (i.e. keep dividing by 2 until value becomes odd)
					while (value % 2 == 0)
					{
						yield return 2;
						value /= 2;
					}

					// At this point value must be odd.
					for (long l = 3; l <= Math.Sqrt(value); l += 2)
					{
						// While value divides exactly by l, return l and divide value
						while (value % l == 0)
						{
							yield return l;
							value /= l;
						}
					}

					// At this point, if value is still greater than 2 then it's a prime number, so we just return it.
					if (value > 2)
					{
						yield return value;
					}
				}
			}

			int chainLength = 0;
			int chainStart = 0;
			int number = 1;
			int result;
			while (true)
			{
				// Get the sequence of distinct prime factors of the specified number.
				var distinctPrimeFactors = PrimeFactors(number).Distinct();
				if (distinctPrimeFactors.Count() == 4)
				{
					// If we're starting a new chain of numbers having four distinct prime factors then
					// mark this number as the start of the chain.
					if (chainLength == 0)
					{
						chainStart = number;
					}

					// We have one more number in the chain.
					chainLength++;

					// If the chain length is 4 (i.e. we've had 4 consecutive numbers having four distinct prime factors) then
					// we have our answer. Set the result and break out of the infinite loop.
					if (chainLength == 4)
					{
						result = chainStart;
						break;
					}
				}
				else
				{
					// This number doesn't have four distinct prime factors, so reset the chain.
					chainLength = 0;
					chainStart = 0;
				}

				// move onto the next number.
				number++;
			}

			return result;
		}
	}
}
