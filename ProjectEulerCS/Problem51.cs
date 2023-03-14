namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem51
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 51 - Prime digit replacements


				By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.

				By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated
				numbers, yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the
				smallest prime with this property.

				Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that generates the sequence of prime numbers.
			static IEnumerable<int> GetPrimeNumbers()
			{
				List<int> primes = new();
				int value = 1;

				// Keep generating prime numbers (until we reach the limit of one million (i.e. up to and including 6 digit primes))
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

			// Local function that converts a specified number to a sequence containing its digits.
			static IEnumerable<int> Digits(int n)
			{
				static IEnumerable<int> GetDigits(int n)
				{
					while (n > 0)
					{
						yield return n % 10;
						n /= 10;
					}
				}

				// GetDigits obtains the digits in reverse order (lowest digit to highest), so reverse the sequence before returning it.
				return GetDigits(n).Reverse();
			}

			// Local function that converts a sequence of digits to the corresponding integer value.
			static int Number(IEnumerable<int> digits)
			{
				int result = 0;
				foreach (int digit in digits)
				{
					result = result * 10 + digit;
				}
				return result;
			}

			// Local function that generates the sequence of digit mask values corresponding to the specified mask value and number of digits.
			static IEnumerable<int> GenerateDigitMask(int mask, int numDigits)
			{
				for (int i = 0; i < numDigits; i++)
				{
					yield return (mask >> i & 1);
				}
			}

			// Local function that uses the supplied list of digit mask values to zero out the required digits in the supplied digits collection.
			static IEnumerable<int> ZeroOutMaskedDigits(IEnumerable<int> digits, IList<int> mask)
			{
				int i = 0;
				foreach (var digit in digits)
				{
					// Multiply digit by 1 minus the mask value (so digits with a mask of 1 will be zeroed, digits with
					// a mask of 0 will remain unaltered)
					yield return digit * (1 - mask[i]);
					i++;
				}
			}

			// Local function that uses the supplied list of digit mask values to increment the required digits in the supplied digits collection.
			static IEnumerable<int> IncrementMaskedDigits(IEnumerable<int> digits, IList<int> mask)
			{
				int i = 0;
				foreach (var digit in digits)
				{
					// Add the mask value to the digit (so digits with a mask of 1 will be incremented, digits with
					// a mask of 0 will remain unaltered)
					yield return digit + mask[i];
					i++;
				}
			}

			// Get a sequence containing the prime numbers and convert it to a HashSet (to facilitate speedy element access)
			var primes = GetPrimeNumbers().ToHashSet();

			foreach (var currPrime in primes)
			{
				// Inferred that the prime number that will yield the result has 6 digits, so we'll skip any prime that has fewer than 6 digits.
				if (currPrime < 100000)
				{
					continue;
				}

				// Generate a list containing the digits of the current prime number.
				var currPrimeDigits = Digits(currPrime);
				// Six digit primes only, so there are 2 to the power of 6 possible mask combinations (that is, 64)
				const int maskCount = 64;
				// Start mask value is 1 (not zero) because applying a zero mask does not alter any digits (and therefore always results in the same
				// number, i.e. the current prime number itself)
				for (int mask = 1; mask < maskCount; mask++)
				{
					// Generate the digit mask values (this creates a list consisting of 0 or 1 values that indicate which digits in the
					// current prime number we are replacing (the digits with a mask value of 1 are the ones being replaced)).
					IList<int> genMask = GenerateDigitMask(mask, currPrimeDigits.Count()).ToList();
					// Zero-out the digits we are replacing (leaving all other digits intact)
					IEnumerable<int> digits = ZeroOutMaskedDigits(currPrimeDigits, genMask);

					int firstOneFound = int.MinValue;
					int count = 0;

					// Loop that determines if the current digit configuration is prime and also increments each digit that we are replacing with values 0 through 9.
					for (int digitVal = 0; digitVal < 10; digitVal++)
					{
						// Convert the list of digits to its integer value.
						var number = Number(digits);

						// We're not interested in any values that begin with zero and then only values that are prime.
						if (digits.First() != 0 && primes.Contains(number))
						{
							// Keep a record of the first matching number in this family.
							if (firstOneFound == int.MinValue)
							{
								firstOneFound = number;
							}

							// Increment count to indicate that we have one more prime number in this family.
							count++;
						}

						// If we couldn't possibly reach a total count of 8 (even if all remaining numbers in this set happen to be prime) then
						// reject this set now as this combination can't be an 8 prime value family.
						if (count + (9 - digitVal) < 8)
						{
							break;
						}

						// Increment the digits we are replacing (leaving all other digits untouched) 
						digits = IncrementMaskedDigits(digits, genMask);
					}

					// If we've found an 8 prime value family then return the first value in the family (which we have previously stored in firstOneFound)
					// as this is our final answer.
					if (count == 8)
					{
						return firstOneFound;
					}
				}
			}

			return 0;
		}
	}
}