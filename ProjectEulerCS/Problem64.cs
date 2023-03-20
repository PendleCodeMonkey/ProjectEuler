using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem64
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 64 - Odd period square roots

				See https://projecteuler.net/problem=64 for problem description.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// The negative Pell's equation is given by x² - ny² = -1. It can be solved by the same method of continued fractions and has solutions
			// if and only if the period of the continued fraction has odd length (which is what this problem is asking for)
			// See https://en.wikipedia.org/wiki/Pell%27s_equation
			static (bool, BigInteger, BigInteger) SolveNegativePell(int n)
			{
				static (BigInteger, BigInteger) Calc(BigInteger a, BigInteger b, int c) => (b, b * c + a);

				int x = (int)Math.Sqrt(n);
				int y = x;
				int z = 1;
				int r = x << 1;
				BigInteger e1 = 1;
				BigInteger e2 = 0;
				BigInteger f1 = 0;
				BigInteger f2 = 1;

				// Number of times to iterate around the following while loop until we decide that we cannot solve
				// the negative Pell's equation for this value of n (this is to avoid getting stuck in an infinite loop)
				int retry = 250;
				while (retry-- > 0)
				{
					y = r * z - y;
					z = (n - y * y) / z;
					r = (x + y) / z;
					(e1, e2) = Calc(e1, e2, r);
					(f1, f2) = Calc(f1, f2, r);
					BigInteger a = f2;
					BigInteger b = e2;
					(b, a) = Calc(b, a, x);
					// Check if the values of a and b satisfy the equation a² - nb² = -1  (negative Pell's equation)
					if (a * a - n * b * b == -1)
					{
						// Successfully solved.
						return (true, a, b);
					}
				}

				// Failed to solve for this value of n.
				return (false, -1, -1);
			}

			int count = 0;
			// Try each integer value from 1 to 10000 (inclusive)
			foreach (int n in Enumerable.Range(1, 10000))
			{
				// Only perform further checks if n is not a perfect square; otherwise we don't need to do anything else for this value of n because
				// it cannot possibly satisfy the criteria we require.
				int sqrt = (int)Math.Sqrt(n);
				if (sqrt * sqrt != n)
				{
					// Attempt to solve negative Pell's equation for this value of n.
					(bool solved, BigInteger x, BigInteger y) = SolveNegativePell(n);
					if (solved)
					{
						// Solved successfully, so we have one more continued fraction with an odd period.
						count++;
					}
				}
			}

			return count;
		}
	}
}
