namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem50
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 50 - Consecutive prime sum


				The prime 41, can be written as the sum of six consecutive primes:

					41 = 2 + 3 + 5 + 7 + 11 + 13

				This is the longest sum of consecutive primes that adds to a prime below one-hundred.

				The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

				Which prime, below one-million, can be written as the sum of the most consecutive primes?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function to determine if the specified value is a prime number.
			static bool IsPrime(long num) => num > 1 && !Enumerable.Range(2, (int)Math.Sqrt(num) - 1).Any(i => num % i == 0);

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

			// Generate a list containing the cumulative sum of the prime numbers
			List<long> primeSums = new();
			long sum = 0;
			foreach (long prime in GetPrimeNumbers())
			{
				// Add this prime number to the cumulative sum
				sum += prime;
				// and add this cumulative sum to the list.
				primeSums.Add(sum);

				// If the cumulative sum exceeds our limit (one million) then terminate the prime number generation.
				if (sum > 1000000)
				{
					break;
				}
			}

			// Iterate through the list of sums to find the prime number that can be written as the sum of the most consecutive primes.
			long result = 0;
			int numTerms = 1;
			for (int i = 0; i < primeSums.Count; i++)
			{
				for (int j = primeSums.Count - 1; j > i + numTerms; j--)
				{
					// Calculate the difference between the sum values at elements i and j (giving us the number that would be yielded by summing
					// the i to j'th consecutive prime numbers)
					long diff = primeSums[j] - primeSums[i];
					// Check that this number is itself prime and, if so, that the number of terms (i.e. consecutive numbers) tah were summed to give
					// this value exceeds the current maximum.
					if (IsPrime(diff) && j - i > numTerms)
					{
						numTerms = j - i;
						result = diff;
						break;
					}

				}
			}

			return result;
		}
	}
}
