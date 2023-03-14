using System.Xml.XPath;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem52
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 52 - Permuted multiples


				It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

				Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
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

			int result = 0;
			int number = 1;
			while (result == 0)
			{
				// Get a list of the digits in the current number and order them by value.
				var orderedDigits = Digits(number).OrderBy(x => x);
				// Convert the ordered digits back to an integer value.
				int orderedNumber = Number(orderedDigits);
				int i;
				// Check each multiple 2x, 3x, 4x, 5x, and 6x
				for (i = 2; i <= 6; i++)
				{
					// Get a list of the digits in the current multiple and order them by value.
					var orderedMultipleDigits = Digits(number * i).OrderBy(x => x);
					// Convert the ordered digits back to an integer value.
					int orderedMultipleNumber = Number(orderedMultipleDigits);
					// Check if this ordered multiple is the same as the ordered number (i.e. it contains exactly the same digits)
					if (orderedNumber != orderedMultipleNumber)
					{
						// Not the same, so the current number is not the answer.
						break;
					}
				}
				// If all multiples matched (i.e. we didn't break out of the above for loop early) then we have our answer.
				if (i == 7)
				{
					result = number;
				}

				number++;
			}

			return result;
		}
	}
}
