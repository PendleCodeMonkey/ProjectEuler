namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem74
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 74 - Digit factorial chains

				The number 145 is well known for the property that the sum of the factorial of its digits is equal to 145:

					1! + 4! + 5! = 1 + 24 + 120 = 145

				Perhaps less well known is 169, in that it produces the longest chain of numbers that link back to 169; it turns out that there are only
				three such loops that exist:

					169 → 363601 → 1454 → 169
					871 → 45361 → 871
					872 → 45362 → 872

				It is not difficult to prove that EVERY starting number will eventually get stuck in a loop. For example,

					69 → 363600 → 1454 → 169 → 363601 (→ 1454)
					78 → 45360 → 871 → 45361 (→ 871)
					540 → 145 (→ 145)

				Starting with 69 produces a chain of five non-repeating terms, but the longest non-repeating chain with a starting number below one million
				is sixty terms.

				How many chains, with a starting number below one million, contain exactly sixty non-repeating terms?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that calculates the calculates the length of the chain of non-repeating terms that the supplied number yields.
			// Note: This function has been optimized so that, if it determines that the number will not yield a 60-length chain, it gives up
			// early in the calculation (and returns -1 instead)
			static int ChainLength(int n)
			{
				// Local function that sums the factorials of the digits in the specified number
				static int SummedDigitFactorials(int n)
				{
					// Factorials for the digits 0 to 9 (inclusive)
					int[] Factorials = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

					int sum = 0;
					for (int i = n; i != 0; i /= 10)
					{
						sum += Factorials[i % 10];
					}
					return sum;
				}

				HashSet<int> chain = new();
				while (true)
				{
					// If we have already added this value of n to the chain then we have reached the end of our chain of non-repeating terms
					// so return the current chain length.
					if (chain.Contains(n))
					{
						return chain.Count;
					}

					// It turns out that every number less than 1000000 that yields a chain of exactly 60 non-repeating terms contains either
					// 367945 or 367954 in the first couple of entries in the chain; therefore, if the chain length so far is two
					// and it does not contain either of these values then we know that this number will not yield a 60-length chain, meaning we
					// can bail out early as there is no point wasting time building any more of this chain.
					if (chain.Count == 2 && !chain.Contains(367945) && !chain.Contains(367954))
					{
						return -1;
					}

					// Add the current value of n to the chain
					chain.Add(n);

					// Calculate the next value of n (by summing the factorials of the digits of the current value of n).
					n = SummedDigitFactorials(n);
				}
			}

			int count = 0;
			for (int i = 1; i < 1_000_000; i++)
			{
				if (ChainLength(i) == 60)
				{
					count++;
				}
			}

			return count;
		}
	}
}
