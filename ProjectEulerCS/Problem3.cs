namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem3
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 3 - Largest prime factor


				The prime factors of 13195 are 5, 7, 13 and 29.

				What is the largest prime factor of the number 600851475143?

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

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

			// Get the prime factors of 600851475143 and return the largest (the last one in the returned sequence)
			return PrimeFactors(600851475143).Last();
		}


		static internal long Solve2()
		{
			// Local function that generates a sequence containing the prime factors of the supplied value.
			// For this specific problem we know that the supplied value is a composite number (i.e. isn't a prime number)
			// which makes it possible for us to use a simpler algorithm than the one used in the Solve() method above.
			static IEnumerable<long> PrimeFactors(long value)
			{
				long l = 2;
				while (value > 1)
				{
					if (value % l == 0)
					{
						yield return l;
						value /= l;
					}
					else
					{
						l++;
					}
				}
			}

			// Get the prime factors of 600851475143 and return the largest (the last one in the returned sequence)
			return PrimeFactors(600851475143).Last();
		}
	}
}
