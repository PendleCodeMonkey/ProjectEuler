namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem4
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 4 - Largest palindrome product


				A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

				Find the largest palindrome made from the product of two 3-digit numbers.

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that determines if the supplied integer value is palindromic.
			static bool IsPalindrome(long value)
			{
				string text = value.ToString();
				return Enumerable.SequenceEqual(text.ToCharArray(), text.ToCharArray().Reverse());
			}

			IEnumerable<int> values = Enumerable.Range(100, 900).Reverse();
			int largest = 0;
			foreach (int val1 in values)
			{
				foreach (int val2 in values)
				{
					int product = val1 * val2;
					if (IsPalindrome(product) && product > largest)
					{
						largest = product;
					}
				}
			}

			return largest;
		}
	}
}
