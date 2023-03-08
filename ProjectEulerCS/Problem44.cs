﻿namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem44
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 44 - Pentagon numbers


				Pentagonal numbers are generated by the formula, Pₙ=n(3n−1)/2. The first ten pentagonal numbers are:

				1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...

				It can be seen that P₄ + P₇ = 22 + 70 = 92 = P₈. However, their difference, 70 − 22 = 48, is not pentagonal.

				Find the pair of pentagonal numbers, Pⱼ and Pₖ, for which their sum and difference are pentagonal and D = |Pₖ − Pⱼ| is minimised; what is the value of D?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that calculates the D value for pentagonal pairs that match the criteria set out for this problem.
			// This function assumes that the values of j and k (i.e. the pair of pentagonal numbers, Pⱼ and Pₖ), their sum, and their difference are all
			// within the first 3000 pentagonal numbers (which happens to be the case).
			static IEnumerable<int> GetPentagonalPairDValues()
			{
				// Pre-calculate the first 3000 pentagonal numbers and store them in a HashSet (so we can quickly check if a number is one of
				// these pentagonal numbers)
				HashSet<int> pentagonals = new();
				for (int i = 1; i <= 3000; i++)
				{
					int pentagonal = i * (i * 3 - 1) / 2;
					pentagonals.Add(pentagonal);
				}

				// For each pair of pentagonal numbers, determine if they match the criteria set out in the problem text and, if so, return
				// the calculated D value as part of the sequence of result.
				foreach (int j in pentagonals)
				{
					foreach (int k in pentagonals)
					{
						int d = Math.Abs(k - j);
						if (pentagonals.Contains(j + k) && pentagonals.Contains(d))
						{
							yield return d;
						}
					}
				}
			}

			// Get the sequence containing the D value calculated for all matching pairs of pentagonal numbers and return the minimum
			// value in this sequence.
			return GetPentagonalPairDValues().Min();
		}


		// An alternative solution (that does not assume an upper limit and does not pre-calculate pentagonal numbers).
		// The pentagonal numbers are calculated by adding an increment value (which increases by 3 each iteration) to the previous pentagonal
		// number; as it can be seen that, to get from the first pentagonal number to the second, you add 4; to get from the second to the third, you
		// add 7; to get from the third to the fourth, you add 10; to get from the fourth to the fifth, you add 13; etc.
		static internal long Solve2()
		{
			// Local function that determines if the specified number is a pentagonal number.
			// Using a test outlined in https://en.wikipedia.org/wiki/Pentagonal_number
			static bool IsPentagonalNumber(long x)
			{
				long temp = x * 24 + 1;
				long sqRoot = (long)Math.Sqrt(temp);
				return (sqRoot * sqRoot == temp) && (sqRoot % 6 == 5);
			}

			HashSet<long> pentagonalNumbers = new();
			long j = 1;         // first pentagonal number is 1
			long increment = 4; // value to be aded to j to get the next pentagonal number
			while (true)        // Keep looping until we find our answer.
			{
				// At this point, we know that j is a pentagonal number, so add it to the HashSet to keep a record of it.
				pentagonalNumbers.Add(j);

				// iterate over each currently calculated pentagonal number, to make a pair of values j and k (both of which
				// we know are pentagonal)
				foreach (long k in pentagonalNumbers)
				{
					// Check if this pair of pentagonal numbers matches the criteria outlined in the problem description (i.e. that
					// the pair's sum and difference are both pentagonal).
					long d = Math.Abs(k - j);
					if (IsPentagonalNumber(j + k) && IsPentagonalNumber(d))
					{
						// First such pair of pentagonal numbers has been found, so return the calculated value of D as the result.
						return d;
					}
				}
				// Add the increment value to j to get the next pentagonal number.
				j += increment;

				// Add 3 to the increment value (that will be added during the next iteration), so we'll be adding 4, then 7, 10, 13, 16, 19, etc.
				increment += 3;
			}
		}
	}
}