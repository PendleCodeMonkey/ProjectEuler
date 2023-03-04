namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem30
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 30 - Digit fifth powers


				Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

					1634 = 1⁴ + 6⁴ + 3⁴ + 4⁴
					8208 = 8⁴ + 2⁴ + 0⁴ + 8⁴
					9474 = 9⁴ + 4⁴ + 7⁴ + 4⁴

				As 1 = 1⁴ is not a sum it is not included.

				The sum of these numbers is 1634 + 8208 + 9474 = 19316.

				Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{

			static IEnumerable<int> Digits(int n)
			{
				while (n > 0)
				{
					yield return n % 10;
					n /= 10;
				}
			}

			int sum = 0;

			// Largest digit is 9, thus limit is 5(9^5)
			int limit = (int)Math.Pow(9, 5) * 5;

			for (int i = 2; i <= limit; i++)
			{
				var digits = Digits(i);
				var temp = digits.Select(x => (int)Math.Pow(x, 5)).Sum();
				if (i == temp)
				{
					sum += i;
				}
			}

			return sum;
		}
	}
}
