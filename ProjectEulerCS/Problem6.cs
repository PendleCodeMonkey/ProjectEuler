namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem6
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 6 - Sum square difference


				The sum of the squares of the first ten natural numbers is,
					1² + 2² + ... + 10² = 385

				The square of the sum of the first ten natural numbers is,
					(1 + 2 + ... + 10)² = 55² = 3025

				Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 
					3025 - 385 = 2640

				Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			IEnumerable<int> naturalNumbers = Enumerable.Range(1, 100);
			int sum = naturalNumbers.Sum();
			return (sum * sum) - naturalNumbers.Select(i => i * i).Sum();
		}
	}
}
