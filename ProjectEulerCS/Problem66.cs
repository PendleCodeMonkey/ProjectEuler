using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem66
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 66 - Diophantine equation

				Consider quadratic Diophantine equations of the form:

				x² – Dy² = 1

				For example, when D=13, the minimal solution in x is 649² – 13×180² = 1.

				It can be assumed that there are no solutions in positive integers when D is square.

				By finding minimal solutions in x for D = {2, 3, 5, 6, 7}, we obtain the following:

				3² – 2×2² = 1
				2² – 3×1² = 1
				9² – 5×4² = 1
				5² – 6×2² = 1
				8² – 7×3² = 1

				Hence, by considering minimal solutions in x for D ≤ 7, the largest x is obtained when D=5.

				Find the value of D ≤ 1000 in minimal solutions of x for which the largest value of x is obtained.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// x² - dy² = 1 is Pell's equation (See https://en.wikipedia.org/wiki/Pell%27s_equation)
			static (bool, BigInteger, BigInteger) SolvePell(int d)
			{
				static (BigInteger, BigInteger) Calc(BigInteger a, BigInteger b, int c) => (b, b * c + a);

				int x = (int)Math.Sqrt(d);
				int y = x;
				int z = 1;
				int r = x << 1;
				BigInteger e1 = 1;
				BigInteger e2 = 0;
				BigInteger f1 = 0;
				BigInteger f2 = 1;

				// Number of times to iterate around the following while loop until we decide that we cannot solve
				// Pell's equation for this value of d (this is to avoid getting stuck in an infinite loop)
				int retry = 250;
				while (retry-- > 0)
				{
					y = r * z - y;
					z = (d - y * y) / z;
					r = (x + y) / z;
					(e1, e2) = Calc(e1, e2, r);
					(f1, f2) = Calc(f1, f2, r);
					BigInteger a = f2;
					BigInteger b = e2;
					(b, a) = Calc(b, a, x);
					// Check if the values of a and b satisfy the equation a² - nb² = 1  (Pell's equation)
					if (a * a - d * b * b == 1)
					{
						// Successfully solved.
						return (true, a, b);
					}
				}

				// Failed to solve for this value of d.
				return (false, -1, -1);
			}

			BigInteger largestX = 0;
			int dForLargestX = 0;
			// Try each integer value for D from 1 to 1000 (inclusive)
			foreach (int d in Enumerable.Range(1, 1000))
			{
				// No solutions when d is square;
				int sqrt = (int)Math.Sqrt(d);
				if (sqrt * sqrt != d)
				{
					// Attempt to solve Pell's equation for this value of d.
					(bool solved, BigInteger x, BigInteger y) = SolvePell(d);
					if (solved)
					{
						// Solved successfully, so check if this has yielded the new largest value for x.
						if (x > largestX)
						{
							largestX = x;
							dForLargestX = d;
						}
					}
				}
			}

			return dForLargestX;
		}
	}
}
