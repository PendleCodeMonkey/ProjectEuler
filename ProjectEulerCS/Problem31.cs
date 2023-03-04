namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem31
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 31 - Coin sums


				In the United Kingdom the currency is made up of pound (£) and pence (p). There are eight coins in general circulation:

					1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).

				It is possible to make £2 in the following way:

					1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p

				How many different ways can £2 be made using any number of coins?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function to calculate the number of possible ways that the specified amount can be
			// made using the denominations of coins in circulation.
			static int GetTotalPossibleWaysToMake(int amount)
			{
				int[] denominations = { 1, 2, 5, 10, 20, 50, 100, 200 };
				int[] numPossibleWays = new int[amount + 1];
				numPossibleWays[0] = 1;

				foreach (int c in denominations)
				{
					foreach (int d in Enumerable.Range(c, amount + 1 - c))
					{
						numPossibleWays[d] += numPossibleWays[d - c];
					}
				}

				return numPossibleWays.Last();
			}

			return GetTotalPossibleWaysToMake(200);
		}
	}
}
