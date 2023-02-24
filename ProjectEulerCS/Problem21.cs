namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem21
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 21 - Amicable numbers


				Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
				If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

				For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

				Evaluate the sum of all the amicable numbers under 10000.

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
				// 6 will not be added to the sum because, as described by the problem text above, a number is not a proper divisor of itself).
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

			var valueRange = Enumerable.Range(1, 9999);

			// Create a dictionary mapping each of the 10000 integer values (1 to 10000) to the sum of their divisors.
			Dictionary<int, int> divisorsMap = new();
			foreach (int val in valueRange)
			{
				divisorsMap.Add(val, SumOfDivisors(val));
			}

			return divisorsMap.Where(pair =>
					divisorsMap.ContainsKey(pair.Value) &&
					pair.Key == divisorsMap[pair.Value] &&
					divisorsMap[pair.Key] != divisorsMap[pair.Value])
				.Select(x => x.Key)
				.Sum();
		}
	}
}
