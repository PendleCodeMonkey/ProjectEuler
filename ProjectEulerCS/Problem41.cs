namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem41
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 41 - Pandigital prime


				We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once.
				For example, 2143 is a 4-digit pandigital and is also prime.

				What is the largest n-digit pandigital prime that exists?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function to determine if the specified value is a prime number.
			static bool IsPrime(int num) => num > 1 && !Enumerable.Range(2, (int)Math.Sqrt(num) - 1).Any(i => num % i == 0);

			// Local function that checks if the specified string contains digits that are 1 through n pandigital (where n is the length of the string).
			static bool IsPandigital(string digits)
			{
				// Order the digits in the string, so we can easily check if it contains each digit (1 through n) exactly once.
				string orderedDigits = new(digits.ToCharArray().OrderBy(x => x).ToArray());
				return orderedDigits == "123456789"[..digits.Length];
			}

			// The Divisibility Rule (see https://en.wikipedia.org/wiki/Divisibility_rule#Divisibility_by_3_or_9) can be used to determine
			// that no 8 or 9 digit number can possibly be a pandigital prime (because the sum of the digits in any 8 digit pandigital number is 36 and
			// the sum of the digits in any 9 digit pandigital number is 45) and as both 36 and 45 are divisible by 3, this means that all 8 and 9 digit
			// pandigital numbers must also themselves be divisible by 3, and therefore cannot be prime numbers.
			// This means we only need to bother checking numbers that have a maximum of 7 digits (i.e. numbers less than 10⁷)
			// As the largest 7 digit pandigital number is 7654321, we use this as the start value (and decrement down towards zero), checking if each
			// value is prime and, if so, if it is also pandigital. The first number we encounter that meets both criteria is the largest possible pandigital prime.
			int value = 7654321;
			while (value > 1)
			{
				if (IsPrime(value) && IsPandigital(value.ToString()))
				{
					// We have found a pandigital prime number, so return this as the largest pandigital prime.
					return value;
				}
				--value;
			}
			return 0;
		}
	}
}
