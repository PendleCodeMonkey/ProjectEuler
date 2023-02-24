namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem10
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 10 - Summation of primes


				The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

				Find the sum of all the primes below two million.

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that generates the sequence of prime numbers below two million.
			static IEnumerable<long> GetPrimeNumbers()
			{
				List<long> primes = new();
				long value = 1;

				// Keep generating prime numbers (until we reach the limit of a long value).
				while (value++ < 2000000)
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

			// Get the sequence of prime numbers below two million and sum them.
			return GetPrimeNumbers().Sum();
		}
	}
}
