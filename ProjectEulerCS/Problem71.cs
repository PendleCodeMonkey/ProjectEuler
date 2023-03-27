namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem71
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 71 - Ordered fractions

				Consider the fraction, n/d, where n and d are positive integers. If n<d and HCF(n,d)=1, it is called a reduced proper fraction.

				If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:

				1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8

				It can be seen that 2/5 is the fraction immediately to the left of 3/7.

				By listing the set of reduced proper fractions for d ≤ 1,000,000 in ascending order of size, find the numerator of the fraction immediately to the left of 3/7.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		// In a Farey sequence, two fractions a/b and c/d are neighbours if bc - ad = 1 (see https://en.wikipedia.org/wiki/Farey_sequence#Farey_neighbours)
		// where a/b < c/d.
		static internal int Solve()
		{
			// We're looking for the fraction that comes immediately before 3/7, therefore we'll use 3/7 for c/d (i.e. c = 3, d = 7)
			int c = 3;
			int d = 7;
			int a = 0;
			// Checking denominator values ≤ 1,000,000
			foreach (int b in Enumerable.Range(1, 1000000))
			{
				// To qualify as a Farey neighbour, we know that bc - ad = 1
				// Hence, ad = bc - 1
				// and therefore, a = (bc - 1) / d
				if ((b * c - 1) % d == 0)
				{
					a = (b * c - 1) / d;
				}
			}

			return a;
		}

		// An alternative solution.
		static internal int Solve2()
		{
			int maxNumerator = 0;
			int maxDenominator = 1;
			foreach (int denom in Enumerable.Range(1, 1000000))
			{
				int num = (denom * 3 / 7) - (denom % 7 == 0 ? 1 : 0);
				if (num * maxDenominator > denom * maxNumerator)
				{
					maxNumerator = num;
					maxDenominator = denom;
				}
			}
			return maxNumerator;
		}

	}
}
