namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem73
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 73 - Counting fractions in a range

				Consider the fraction, n/d, where n and d are positive integers. If n<d and HCF(n,d)=1, it is called a reduced proper fraction.

				If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:

				1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8
												   ‾‾‾  ‾‾‾  ‾‾‾
				It can be seen that there are 3 fractions between 1/3 and 1/2.

				How many fractions lie between 1/3 and 1/2 in the sorted set of reduced proper fractions for d ≤ 12,000?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local [recursive] function - Uses a Stern-Brocot tree (see https://en.wikipedia.org/wiki/Stern%E2%80%93Brocot_tree) to count the
			// number of reduced fractions between the specified left and right fractions, i.e. where (left.num/left.denom) < (n/d) < (right.num/right.denom)
			static int SternBrocot((int num, int denom) left, (int num, int denom) right)
			{
				(int n, int d) = (left.num + right.num, left.denom + right.denom);
				return d > 12000 ? 0 : 1 + SternBrocot((left.num, left.denom), (n, d)) + SternBrocot((n, d), (right.num, right.denom));
			}

			// Use a Stern-Brocot tree to determine the number of reduced fractions between 1/3 and 1/2, returning the result.
			return SternBrocot((1, 3), (1, 2));
		}
	}
}
