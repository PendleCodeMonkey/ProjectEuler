namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem9
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 9 - Special Pythagorean triplet


				A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

				a² + b² = c²
				For example, 3² + 4² = 9 + 16 = 25 = 5².

				There exists exactly one Pythagorean triplet for which a + b + c = 1000.
				Find the product abc.

		----------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			for (int a = 1; a < 500; a++)
			{
				for (int b = a + 1; b < 500; b++)
				{
					// Determine the value of c that will ensure that a + b + c = 1000
					int c = 1000 - (b + a);
					if (b >= c)
					{
						// This value of c does not comply with a < b < c
						continue;
					}

					// Check if a² + b² = c²
					if (((a * a) + (b * b)) == c * c)
					{
						// Yep, it does, so return the product of the three values a, b, and c
						return a * b * c;
					}
				}
			}

			return 0;
		}
	}
}
