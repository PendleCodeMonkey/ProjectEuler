namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem46
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 46 - Goldbach's other conjecture


				It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

					9 = 7 + 2×1²
					15 = 7 + 2×2²
					21 = 3 + 2×3²
					25 = 7 + 2×3²
					27 = 19 + 2×2²
					33 = 31 + 2×1²

				It turns out that the conjecture was false.

				What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that generates the sequence of prime numbers.
			static IEnumerable<long> GetPrimeNumbers()
			{
				List<long> primes = new();
				long value = 1;

				// Keep generating prime numbers (until we reach the limit of a long value - Note that the code that
				// iterates the sequence returned by this function should terminate the generation of prime numbers way before
				// we reach this limit!)
				while (value++ < long.MaxValue)
				{
					bool isPrime = true;
					double rootOfValue = Math.Sqrt(value);

					foreach (long prime in primes)
					{
						if (prime > rootOfValue)
						{
							break;
						}

						// If value is exactly divisible by a prime number then it is a composite number (i.e. it is not itself a prime number)
						if (value % prime == 0)
						{
							isPrime = false;
							break;
						}
					}

					if (isPrime)
					{
						// value is a prime number so add it to our list of primes
						primes.Add(value);
						// and return it as the next prime number in the IEnumerable sequence.
						yield return value;
					}
				}
			}

			long result = 0;
			HashSet<long> primes = new();

			// We know that values up to (and including) 33 fit the conjecture, so we'll start our search at 35 (i.e. the next odd number)
			long value = 35;

			// Get each prime number in sequence
			foreach (long prime in GetPrimeNumbers())
			{
				// Add the current prime number to a HashSet (which we can easily access later when required)
				primes.Add(prime);

				// Iterate through the values until we reach the prime number we've just retrieved (this will give us the composite numbers
				// that lie between consecutive prime numbers)
				while (value < prime)
				{
					bool found = false;

					// We're only interested in composite numbers so check that the current value is not a prime number.
					if (!primes.Contains(value))
					{
						// We're going to check if this composite number can be written as the sum of a prime and twice a square, so
						// iterate through the prime numbers we currently have in the HashSet
						foreach (long currPrime in primes)
						{
							// We subtract the current prime number from value, divide by 2, and then the result should be a square for this
							// composite value to fit the conjecture.
							// First check that the value minus the current prime yields a value that is exactly divisible by 2.
							if (value > currPrime && ((value - currPrime) % 2 == 0))
							{
								// Calculate the value we get by subtracting the current prime number from value and dividing by 2.
								long halfDiff = (value - currPrime) / 2;
								// Calculate the square root of the resulting value
								long sqr = (long)Math.Sqrt(halfDiff);
								// The following checks that the halfDiff value is in fact an integer square.
								if (sqr * sqr == halfDiff)
								{
									// This composite number fits the conjecture when using the current prime.
									found = true;
									break;
								}
							}
						}

						if (!found)
						{
							// The current composite number does not fit the conjecture, so we have found our result.
							result = value;
							break;
						}
					}

					// Advance the value to the next odd number.
					value += 2;
				}

				// If we have found our result then break out of the loop.
				if (result > 0)
				{
					break;
				}
			}

			return result;
		}
	}
}
