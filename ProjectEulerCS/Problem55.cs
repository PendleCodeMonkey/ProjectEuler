using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem55
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 55 - Lychrel numbers


				If we take 47, reverse and add, 47 + 74 = 121, which is palindromic.

				Not all numbers produce palindromes so quickly. For example,

					349 + 943 = 1292,
					1292 + 2921 = 4213
					4213 + 3124 = 7337

				That is, 349 took three iterations to arrive at a palindrome.

				Although no one has proved it yet, it is thought that some numbers, like 196, never produce a palindrome. A number that never forms a palindrome
				through the reverse and add process is called a Lychrel number. Due to the theoretical nature of these numbers, and for the purpose of this
				problem, we shall assume that a number is Lychrel until proven otherwise. In addition you are given that for every number below ten-thousand, it
				will either (i) become a palindrome in less than fifty iterations, or, (ii) no one, with all the computing power that exists, has managed so far
				to map it to a palindrome. In fact, 10677 is the first number to be shown to require over fifty iterations before producing a
				palindrome: 4668731596684224866951378664 (53 iterations, 28-digits).

				Surprisingly, there are palindromic numbers that are themselves Lychrel numbers; the first example is 4994.

				How many Lychrel numbers are there below ten-thousand?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that converts a specified (potentially large) number to a sequence containing its digits.
			static IEnumerable<int> Digits(BigInteger n)
			{
				static IEnumerable<int> GetDigits(BigInteger n)
				{
					while (n > 0)
					{
						yield return (int)(n % 10);
						n /= 10;
					}
				}

				// GetDigits obtains the digits in reverse order (lowest digit to highest), so reverse the sequence before returning it.
				return GetDigits(n).Reverse();
			}

			// Local function that converts a sequence of digits to the corresponding BigInteger value.
			static BigInteger Number(IEnumerable<int> digits)
			{
				BigInteger result = 0;
				foreach (int digit in digits)
				{
					result = result * 10 + digit;
				}
				return result;
			}

			// Local function that determines if the specified number is a Lychrel number.
			static bool IsLychrelNumber(int n)
			{
				// Create a BigInteger of the supplied value (using BigInteger because our calculations below could result in some
				// very large numbers)
				BigInteger value = new(n);

				// Checking if the number becomes a palindrome within the first 50 iterations.
				for (int i = 0; i < 50; i++)
				{
					// Convert the number to a list of its digits, reverse the digit list, and then convert these
					// reversed digits back to a BigNumber value (i.e. create a BigInteger that has the digits of the current
					// number reversed).
					var reversedNumber = Number(Digits(value).Reverse());

					// Add this reversed number to the current value.
					value += reversedNumber;

					// Convert the result to a list of its digits.
					var digits = Digits(value);

					// And check if the result is palindromic (i.e. the sequence of digits is the same as the reversed
					// sequence of digits)
					if (digits.SequenceEqual(digits.Reverse()))
					{
						// Number is palindromic so it isn't a Lychrel number.
						return false;
					}
				}

				// The number has not become palindromic within the first 50 iterations, making it a Lychrel number.
				return true;
			}

			int count = 0;

			// Checking all numbers below 10000
			for (int num = 1; num < 10000; num++)
			{
				if (IsLychrelNumber(num))
				{
					// Number was found to be a Lychrel number, so increment the count.
					count++;
				}
			}

			return count;
		}
	}
}
