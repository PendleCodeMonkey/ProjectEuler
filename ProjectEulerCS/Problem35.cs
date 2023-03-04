namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem35
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 35 - Circular primes


				The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

				There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

				How many circular primes are there below one million?.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function to determine if the specified value is a prime number.
			static bool IsPrime(int num) => num > 1 && !Enumerable.Range(2, (int)Math.Sqrt(num) - 1).Any(i => num % i == 0);

			// Local function to determine if the specified number is a circular prime (note that, for this problem, this function
			// will only ever be called with a prime number passed as the num parameter).
			static bool IsCircularPrime(int num) => CircularNumbers(num).All(x => IsPrime(x));

			// Local function to calculate all of the circular numbers for the supplied value.
			// For the purposes of this problem, the value passed as the num parameter will always be a prime number.
			static IEnumerable<int> CircularNumbers(int num)
			{
				List<int> digits = new();

				// Extract the digits from the number (into a list)
				int temp = num;
				while (temp > 0)
				{
					// Add the least significant digit to the list of digits.
					digits.Add(temp % 10);
					// Divide by 10 to remove the least significant digit that we have just handled.
					temp /= 10;
				}

				// Return the supplied number itself as one of the values in the circular number sequence.
				yield return num;

				// Only need to attempt to rotate the digits (to create circular numbers) if there are two or more digits in the number.
				if (digits.Count >= 2)
				{
					// Reverse the order of the list elements (as the digits were added in reverse order, least significant -> most significant)
					digits.Reverse();

					// Generate the rotated versions of the number (so, if 197 is supplied as the value of num, then the values 971 and 719 will be returned.
					// Note that the value of num itself will have already been returned above and so it doesn't need to be returned here too.)
					for (int i = 1; i < digits.Count; i++)
					{
						int circularNum = 0;
						for (int j = i; j < i + digits.Count; j++)
						{
							circularNum *= 10;
							circularNum += digits[j % digits.Count];
						}
						yield return circularNum;
					}
				}
			}

			// Local function that generates the sequence of prime numbers below a million.
			static IEnumerable<int> PrimeNumbersBelowAMillion()
			{
				List<int> primes = new();
				int value = 1;

				// Keep generating prime numbers (until we reach the upper limit of a million).
				while (value++ < 1000000)
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
						// value is a prime number so add it to our list of primes
						primes.Add(value);
						// and return it as the next prime number in the IEnumerable sequence.
						yield return value;
					}
				}
			}

			// Get a list of all prime numbers below a million, filter out only the ones that are circular primes, and return the count of these elements.
			return PrimeNumbersBelowAMillion().Where(x => IsCircularPrime(x)).Count();
		}
	}
}
