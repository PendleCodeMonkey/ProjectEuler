namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem75
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 75 - Singular integer right triangles

				It turns out that 12 cm is the smallest length of wire that can be bent to form an integer sided right angle triangle in exactly
				one way, but there are many more examples.

					12 cm: (3,4,5)
					24 cm: (6,8,10)
					30 cm: (5,12,13)
					36 cm: (9,12,15)
					40 cm: (8,15,17)
					48 cm: (12,16,20)

				In contrast, some lengths of wire, like 20 cm, cannot be bent to form an integer sided right angle triangle, and other lengths allow more
				than one solution to be found; for example, using 120 cm it is possible to form exactly three different integer sided right angle triangles.

				120 cm: (30,40,50), (20,48,52), (24,45,51)

				Given that L is the length of the wire, for how many values of L ≤ 1,500,000 can exactly one integer sided right angle triangle be formed?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that calculates the greatest common divisor of the specified numerator and denominator values.
			static int GetGCD(int numerator, int denominator)
			{
				int gcd = 1;
				for (int i = 2; i <= numerator && i <= denominator; i++)
				{
					// Is i a factor of both integers?
					if ((numerator % i == 0) && (denominator % i == 0))
					{
						// Yes, so i is a common divisor.
						gcd = i;
					}
				}
				return gcd;
			}

			int limit = 1_500_000;
			List<(int a, int b, int c)> triples = new();
			for (int s = 3; s * s <= limit; s += 2)
			{
				for (int t = s - 2; t > 0; t -= 2)
				{
					if (GetGCD(s, t) == 1)
					{
						int a = s * t;
						int b = (s * s - t * t) / 2;
						int c = (s * s + t * t) / 2;

						// Only interested in triples whose values sum to <= 1500000
						if (a + b + c <= limit)
						{
							triples.Add((a, b, c));
						}
					}
				}
			}

			// Determine the number of solutions that there are for each length of wire (L)
			short[] numSolutions = new short[limit + 1];
			foreach (var (a, b, c) in triples)
			{
				int sum = a + b + c;
				for (int i = sum; i <= limit; i += sum)
				{
					numSolutions[i]++;
				}
			}

			// Count the number of values of L that have exactly one solution
			return numSolutions.Where(x => x == 1).Count();
		}
	}
}
