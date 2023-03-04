using System.Text;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem38
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 38 - Pandigital multiples


				Take the number 192 and multiply it by each of 1, 2, and 3:

				192 × 1 = 192
				192 × 2 = 384
				192 × 3 = 576
				By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)

				The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated
					product of 9 and (1,2,3,4,5).

				What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that checks if the specified string contains digits that are 1 through 9 pandigital.
			static bool IsPandigital(string digits)
			{
				// Order the digits in the string, so we can easily check if it contains each digit (1 through 9) exactly once.
				string orderedDigits = new(digits.ToCharArray().OrderBy(x => x).ToArray());
				return orderedDigits == "123456789";
			}

			int largest = 0;

			// Because we're calculating the concatenated product of an integer with (1,2, ... , n) where n > 1, the numbers we're
			// considering cannot have 5 or more digits (otherwise the concatenated product will be guaranteed to exceed 9 digits, and therefore
			// could not possibly be pandigital); so, we only consider numbers less than 10000.
			for (int number = 1; number < 10000; number++)
			{
				StringBuilder sb = new();
				for (int n = 1; sb.Length < 9; n++)
				{
					sb.Append(number * n);
				}
				string s = sb.ToString();

				// Only interested in values that result in a 9 digit number and don't contain a zero.
				if (s.Length == 9 && !s.Contains('0'))
				{
					int value = int.Parse(s);
					if (value > largest && IsPandigital(s))
					{
						largest = value;
					}
				}
			}

			return largest;
		}
	}
}
