namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem36
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 36 - Double-base palindromes


				The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

				Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

				(Please note that the palindromic number, in either base, may not include leading zeros.)

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that determines if the specified string is palindromic.
			static bool IsPalindrome(string text) => Enumerable.SequenceEqual(text.ToCharArray(), text.ToCharArray().Reverse());

			// Local function that determines if the specified number is palindromic in both base 2 and base 10.
			static bool IsPalindromicInBase2And10(int number) => IsPalindrome(Convert.ToString(number, 2)) && IsPalindrome(number.ToString());

			// Local function that Gets a sequence of numbers that are palindromic in both base 2 and base 10.
			// Note that, as we have a stipulation that no leading zeroes can be included in either base, we know that the binary representation
			// must end with a 1; therefore, we only need to check odd numbered values.
			static IEnumerable<int> NumbersThatArePalindromicInBase2And10()
			{
				// Start checking at 1
				int number = 1;
				while (number < 1000000)
				{
					if (IsPalindromicInBase2And10(number))
					{
						yield return number;
					}

					// Add 2 to the current value of number (which ensures that we only check odd numbers)
					number += 2;
				}
			}

			// get the sequence of numbers (less than one million) that are palindromic in both base 2 and base 10, and return their sum.
			return NumbersThatArePalindromicInBase2And10().Sum();
		}
	}
}
