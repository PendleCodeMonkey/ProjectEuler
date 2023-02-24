namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem1
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 1 - Multiples of 3 and 5


				If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
				Find the sum of all the multiples of 3 or 5 below 1000.

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Using the range of numbers 1 to 999 (ignoring zero as it wouldn't contribute to the sum anyway!)
			// Filter out the ones that are exactly divisible by 3 or 5
			// and then compute the sum of the filtered values.
			return Enumerable.Range(1, 999)
				.Where(i => i % 3 == 0 || i % 5 == 0)
				.Sum();
		}
	}
}
