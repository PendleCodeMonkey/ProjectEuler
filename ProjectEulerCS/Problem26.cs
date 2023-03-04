namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem26
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 26 - Reciprocal cycles


				A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

				1/2		= 	0.5
				1/3		= 	0.(3)
				1/4		= 	0.25
				1/5		= 	0.2
				1/6		= 	0.1(6)
				1/7		= 	0.(142857)
				1/8		= 	0.125
				1/9		= 	0.(1)
				1/10	= 	0.1
				Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

				Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{

			// Local function to calculate the length of the recurring cycles in the decimal fraction part of 1/x for values of
			// x between 1 and 999 (i.e. values less than 1000). The cycle lengths are returned in an IEnumerable sequence.
			//
			// We calculate recurring cycle lengths as follows (using the unit fraction 1/13 as an example):
			//
			// 1) 	 1 / 13 = 0 (with a remainder of 1, which we multiply by 10 to give our next dividend of 10)
			// 2)    10 / 13 = 0 (with a remainder of 10, which we multiply by 10 to give our next dividend of 100)  <-----
			// 3)   100 / 13 = 7 (with a remainder of 9, which we multiply by 10 to give our next dividend of 90)         |
			// 4)    90 / 13 = 6 (with a remainder of 12, which we multiply by 10 to give our next dividend of 120)       |
			// 5)   120 / 13 = 9 (with a remainder of 3, which we multiply by 10 to give our next dividend of 30)         |
			// 6)    30 / 13 = 2 (with a remainder of 4, which we multiply by 10 to give our next dividend of 40)         |
			// 7)    40 / 13 = 3 (with a remainder of 1, which we multiply by 10 to give our next dividend of 10)   -------
			//
			// At step 7) we have encountered the remainder of 1 again, which takes us back to the same state as step 2)
			// therefore giving a recurring cycle of 076923 (which has a length of 6 digits)
			static IEnumerable<int> CycleLengths()
			{
				// Return zero as the first two values in the sequence (i.e. index 0 and index 1) as the denominator values we are
				// calculating with start at 2.
				yield return 0;
				yield return 0;

				const int notYetEncountered = -1;

				// Loop for each denominator less than 1000 (starting at 2 because we've already returned zero values required for 0 and 1)
				for (int d = 2; d < 1000; d++)
				{
					// The initial dividend is 1 (as we're calculating 1/x)
					int dividend = 1;
					// Starting decimal digit position is 1 (i.e. the first digit after the decimal point)
					int currDecDigitPos = 1;

					// Create a list to hold the positions at which each remainder value was last encountered (initializing
					// all values to notYetEncountered)
					List<int> lastRemainderPos = Enumerable.Repeat(notYetEncountered, d).ToList();

					while (true)
					{
						// Get remainder of dividing the current dividend by x
						int remainder = dividend % d;

						// If remainder becomes zero then the fraction doesn't have a recurring cycle, so we return zero.
						if (remainder == 0)
						{
							yield return 0;
							break;
						}

						// Check if this remainder value has occurred previously.
						if (lastRemainderPos[remainder] != notYetEncountered)
						{
							// It has, so get the number of steps taken between this occurrence of the remainder and the previous
							// occurrence (which is the length of the recurring cycle) and return it.
							yield return currDecDigitPos - lastRemainderPos[remainder];
							break;
						}

						// Store the position of the current remainder
						lastRemainderPos[remainder] = currDecDigitPos;

						// Determine the next dividend
						dividend = remainder * 10;
						// and advance to the position of next decimal digit
						currDecDigitPos++;
					}
				}
			}

			var max = CycleLengths().Select((cycleLen, denom) => new { cycleLen, denom })
								   .Aggregate(new { cycleLen = int.MinValue, denom = -1 }, (x, last) => x.cycleLen >= last.cycleLen ? x : last);

			return max.denom;
		}
	}
}
