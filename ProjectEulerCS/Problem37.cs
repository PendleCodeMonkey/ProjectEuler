namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem37
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 37 - Truncatable primes


				The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each
					stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

				Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

				NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that returns a sequence containing the "left to right" and "right to left" truncated versions of the specified number.
			static IEnumerable<int> TruncatedNumbers(int number)
			{
				int temp = number;
				while (temp > 0)
				{
					temp /= 10;
					if (temp > 0)
					{
						yield return temp;
					}
				}

				int mod = 10;
				while (true)
				{
					int value = number % mod;
					if (value != number)
					{
						yield return value;
					}
					else
					{
						break;
					}
					mod *= 10;
				}
			}

			// Local function that generates the sequence of the 11 truncatable prime numbers.
			static IEnumerable<int> TruncatablePrimeNumbers()
			{
				// A HashSet to store the prime numbers we have already calculated.
				HashSet<int> primes = new();

				int numTruncatablePrimes = 0;
				int value = 2;

				// Keep generating prime numbers (until we reach the target of 11 truncatable primes).
				while (numTruncatablePrimes < 11)
				{
					bool isPrime = true;
					double rootOfValue = Math.Sqrt(value);

					foreach (int prime in primes)
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
						// value is a prime number so add it to our collection of primes
						primes.Add(value);

						// Only checking for truncatable primes if value is 10 or more (as we don't consider the prime numbers 2, 3, 5, and 7 as being truncatable)
						if (value >= 10)
						{
							// Get the truncated versions of this prime number.
							var trunc = TruncatedNumbers(value);

							// Check if all of the truncated versions of this number are also prime numbers (i.e. they are all present in the primes HashSet)
							if (trunc.All(x => primes.Contains(x)))
							{
								// We have one more truncatable prime
								numTruncatablePrimes++;

								// Return this value as the next truncatable prime.
								yield return value;
							}
						}
					}
					value++;
				}
			}

			// Get the list of truncatable prime numbers and return their sum.
			return TruncatablePrimeNumbers().Sum();
		}
	}
}
