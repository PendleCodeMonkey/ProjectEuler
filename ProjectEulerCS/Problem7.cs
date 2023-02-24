namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem7
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 7 - 10001st prime


				By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

				What is the 10001st prime number?

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that generates the sequence of prime numbers.
			// NOTE: this function will potentially generate a VERY large sequence, so the caller
			// should limit the number of values returned (for example, by using the LINQ Take function)
			static IEnumerable<long> GetPrimeNumbers()
			{
				List<long> primes = new();
				long value = 1;

				// Keep generating prime numbers (until we reach the limit of a long value).
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

			// To get the 10001st prime number, we simply skip the first 10000 and then return the first element from the remaining sequence.
			return GetPrimeNumbers().Skip(10000).First();
		}
	}
}
