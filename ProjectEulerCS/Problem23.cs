namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem23
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 23 - Non-abundant sums


				A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28
				would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

				A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

				As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
				By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot
				be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

				Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that gets sum of the divisors for the supplied number.
			static int SumOfDivisors(int value)
			{
				int sum = 0;

				// We only need to check values up to the square root of the supplied number as this will give us the
				// smaller divisors and the code towards the end of this function (that uses value / f) will determine the
				// corresponding larger divisors. For example, for the number 6, the values 1 and 2 will be determined as factors
				// and the code towards the end of this function will determine the other corresponding factors (i.e. 3). NOTE: in this case
				// 6 will not be added to the sum because a number is not a proper divisor of itself).
				int max = (int)Math.Sqrt(value);

				for (int f = 1; f <= max; f++)
				{
					if (value % f != 0)
					{
						// value is not exactly divisible by f; therefore f is not a factor.
						continue;
					}

					// f is a factor of value so add it to the sum.
					sum += f;

					// f is a factor, so value/f must also be a factor; however, if f is the square root of
					// value then we don't want to add it again (otherwise we would end up with the same divisor added
					// twice to the sum). For example, for the number 36, 6 is one of the factors but it is also
					// the square root of 36 and we only want the value 6 to treat as a divisor once, not twice.
					if (f != 1 && f != value / f)
					{
						sum += value / f;
					}
				}

				return sum;
			}

			// All integers greater than 28123 can be written as the sum of two abundant numbers; therefore, we only
			// need to check numbers upto 28123.
			const int max = 28123;

			// Obtain a list of numbers (in the range 1 -> 28123) that are abundant numbers (i.e. where the sum of the number's divisors
			// is greater than the number itself)
			var abundant = Enumerable.Range(1, max)
				.Where(x => SumOfDivisors(x) > x)
				.ToList();

			// Determine which numbers (in the range 1 -> 28123) are a sum of two abundant numbers.
			var isAbundantSum = new bool[max + 1];
			foreach (int i1 in abundant)
			{
				foreach (int i2 in abundant)
				{
					// At this point, i1 and i2 are both abundant numbers. If their sum is less than or equal to 28123 then
					// flag this sum as one of the values that can be obtained by summing two abundant numbers.
					if (i1 + i2 <= max)
					{
						isAbundantSum[i1 + i2] = true;
					}
				}
			}

			// Get a list of all integers that cannot be obtained by summing two abundant numbers, sum them, and return the summed value.
			return Enumerable.Range(1, max)
				.Where(x => !isAbundantSum[x]).Sum();
		}
	}
}
