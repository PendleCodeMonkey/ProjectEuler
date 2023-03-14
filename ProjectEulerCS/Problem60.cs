namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem60
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 60 - Prime pair sets


				The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them in any order the result will
				always be prime. For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest
				sum for a set of four primes with this property.

				Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			PerformCalc calc = new();
			long sumLimit = 100000;
			while (true)
			{
				long sum = calc.PrimeSetSum(Array.Empty<int>(), sumLimit - 1);
				// If no smaller sum has been found then we have our result, so return it.
				if (sum == -1)
				{
					return sumLimit;
				}
				// Update sumLimit with the value returned by PrimeSetSum (which is the smallest sum found so far)
				sumLimit = sum;
			}
		}
	}

	internal class PerformCalc
	{
		private readonly int NumPrimes = 10000;		// Set a limit on the number of prime numbers we are checking.
		private readonly HashSet<long> _primesHashSet;
		private readonly List<long> _primesList;
		private readonly Dictionary<int, bool> _isConcatNumberPrime;

		internal PerformCalc()
		{
			// Get a sequence containing prime numbers and convert it to a HashSet (to facilitate speedy element access)
			_primesHashSet = GetPrimeNumbers().ToHashSet();
			// and create a List version (to allow us to easily access these prime numbers by index)
			_primesList = _primesHashSet.ToList();

			// Create the dictionary that will be used to cache results (as an optimization)
			_isConcatNumberPrime = new Dictionary<int, bool>();
		}

		// Function that generates a sequence of prime numbers.
		private static IEnumerable<long> GetPrimeNumbers()
		{
			List<long> primes = new();
			long value = 1;
			int count = 0;

			// Keep generating prime numbers (until we reach a limit, which has been arbitrarily set at 2 million).
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
					count++;
					// and return it as the next prime number in the IEnumerable sequence.
					yield return value;
				}
			}
		}

		// Function to determine if the specified value is a prime number.
		private static bool IsPrime(long number)
		{
			if (number < 2)
			{
				return false;
			}
			if (number % 2 == 0)
			{
				return (number == 2);
			}
			long root = (long)Math.Sqrt(number);
			for (long i = 3; i <= root; i += 2)
			{
				if (number % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		// Concatenates the prime number at index x with the prime number at index y, and then checks
		// if the resulting number is prime.
		private bool IsConcatNumberPrime(int x, int y)
		{
			// If we have already cached the result for this combination of x and y, then just return the cached value.
			int index = x * NumPrimes + y;
			if (_isConcatNumberPrime.ContainsKey(index))
			{
				return _isConcatNumberPrime[index];
			}

			// Concatenate the prime number at index x with the prime number at index y.
			int multiplier = 1;
			for (long temp = _primesList[y]; temp != 0; temp /= 10)
			{
				multiplier *= 10;
			}
			long concatValue = _primesList[x] * multiplier + _primesList[y];

			// If the concatenated value is within the range of our pre-calculated list of primes then use this list to determine
			// if the value is prime; otherwise, call the IsPrime method to perform the check.
			bool result = concatValue > _primesList.Last() ? IsPrime(concatValue) : _primesHashSet.Contains(concatValue);

			// Cache the result for this combination of x and y.
			_isConcatNumberPrime.Add(index, result);

			// And finally, return the result.
			return result;
		}

		// Recursive method that searches for a list of primes that match the criteria set out in the problem description (i.e. a set
		// of five primes for which any two primes concatenate to produce another prime)
		internal long PrimeSetSum(int[] primeIndex, long sumLimit)
		{
			// If we have a set of 5 prime numbers that match the required criteria (i.e. any two primes concatenate to produce another prime)
			// then calculate the sum of those primes and return it.
			if (primeIndex.Length == 5)
			{
				long sum = 0;
				foreach (int index in primeIndex)
				{
					sum += _primesList[index];
				}
				return sum;
			}
			int i = primeIndex.Length == 0 ? 0 : primeIndex[^1] + 1;
			for (; i < NumPrimes && _primesList[i] <= sumLimit; i++)
			{
				bool skipIteration = false;
				foreach (int j in primeIndex)
				{
					// Check if both concatenated numbers are prime (i.e. i concatenated with j, and j concatenated with i)
					if (!IsConcatNumberPrime(i, j) || !IsConcatNumberPrime(j, i))
					{
						// At least one of the concatenated number is not prime, so break out of this loop (also set the
						// skipIteration flag so we know to skip to the next value of i)
						skipIteration = true;
						break;
					}
				}
				// If the skipIteration flag was set then skip this iteration (and proceed to the next value of i)
				if (skipIteration)
				{
					continue;
				}

				// At this point we know that the prime number at index i can be concatenated with the prime numbers at the
				// indexes in the primeIndex array to produce other prime numbers, so we want to add index i to our set being considered.
				// Create a new array of prime indexes (to hold the current set of values plus one additional element)
				int[] newPrimeIndex = new int[primeIndex.Length + 1];
				// copy the current values (if any) to the new array
				if (primeIndex.Length > 0)
				{
					Array.Copy(primeIndex, newPrimeIndex, primeIndex.Length);
				}
				// and append index i to the array.
				newPrimeIndex[^1] = i;

				// Recursive call to PrimeSetSum, passing this new array of prime index values.
				long sum = PrimeSetSum(newPrimeIndex, sumLimit - _primesList[i]);
				// If PrimeSetSum returned a meaningful sum value then return it.
				if (sum != -1)
				{
					return sum;
				}
			}
			return -1;
		}
	}
}
