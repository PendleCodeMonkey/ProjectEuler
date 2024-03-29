﻿namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem12
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 12 - Highly divisible triangular number


				The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

				1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

				Let us list the factors of the first seven triangle numbers:

				 1: 1
				 3: 1,3
				 6: 1,2,3,6
				10: 1,2,5,10
				15: 1,3,5,15
				21: 1,3,7,21
				28: 1,2,4,7,14,28
				We can see that 28 is the first triangle number to have over five divisors.

				What is the value of the first triangle number to have over five hundred divisors?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that gets a sequence containing the divisors for the supplied triangular number.
			static IEnumerable<int> GetDivisors(int triangleValue)
			{
				// We only need to check values up to the square root of the triangular number as this will give us the
				// smaller divisors and the code towards the end of this function (that uses triangleValue / f) will determine the
				// corresponding larger divisors. For example, for the triangular number 6, the values 1 and 2 will be determined as factors
				// and the code towards the end of this function will determine the other corresponding factors (6 and 3).
				int max = (int)Math.Sqrt(triangleValue);

				for (int f = 1; f <= max; f++)
				{
					if (triangleValue % f != 0)
					{
						// triangleValue is not exactly divisible by f; therefore f is not a factor.
						continue;
					}

					// f is a factor of triangleValue so return it as part of the IEnumerable sequence.
					yield return f;

					// f is a factor, so triangleValue / f must also be a factor; however, if f is the square root of
					// triangleValue then we don't want to add it again (otherwise we would end up with the same divisor
					// twice in the sequence). For example, for the triangular number 36, 6 is one of the factors but it is also
					// the square root of 36 and we only want the value 6 to appear once in the list of divisors, not twice.
					if (f != triangleValue / f)
					{
						yield return triangleValue / f;
					}
				}
			}

			int divisorCount = 0;
			int triangleValue = 0;
			int i = 1;
			while (divisorCount < 500)
			{
				triangleValue = Enumerable.Range(1, i).Sum();
				divisorCount = GetDivisors(triangleValue).Count();
				i++;
			}

			return triangleValue;
		}
	}
}
