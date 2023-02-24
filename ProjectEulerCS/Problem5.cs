namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem5
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 5 - Smallest multiple


				2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

				What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{

			// There is no point testing for divisibility by 1 (as every number is divisible by 1) also, as the final result must be divisible by 2, then
			// we only need to bother checking even numbers; therefore, our range of divisors can exclude the values 1 and 2.
			int[] divisors = Enumerable.Range(3, 18).ToArray();     // Gives the range of values 3 -> 20

			// The final answer must be divisible by each of the prime numbers less than 20, so it's going to be at least as large as the product of those prime numbers; therefore
			// as an optimisation we will only start checking at the value of productOfPrimesBelow20.
			// The final result must be divisible by 2; therefore, it must be even (so we only need to check even numbers, hence we're incrementing n by 2 each time
			// around the following loop)
			int productOfPrimesBelow20 = 2 * 3 * 5 * 7 * 11 * 13 * 17 * 19;
			for (int n = productOfPrimesBelow20; ; n += 2)
			{
				bool found = true;

				foreach (int div in divisors)
				{
					if (n % div != 0)
					{
						found = false;
						break;
					}
				}

				if (found)
				{
					return n;
				}
			}
		}
	}
}
