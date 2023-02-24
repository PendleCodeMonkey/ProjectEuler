namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem14
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 14 - Longest Collatz sequence


				The following iterative sequence is defined for the set of positive integers:

				n → n/2 (n is even)
				n → 3n + 1 (n is odd)

				Using the rule above and starting with 13, we generate the following sequence:

				13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
				It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

				Which starting number, under one million, produces the longest chain?

				NOTE: Once the chain starts the terms are allowed to go above one million.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{

			static IEnumerable<long> CollatzChain(long value)
			{
				// Return the supplied value itself as the first number in the chain.
				yield return value;

				while (value > 1)
				{
					value = (value % 2 == 0) ? value / 2 : (value * 3) + 1;
					yield return value;
				}
			}

			int longestChainValue = 0;
			int longestChainLength = 0;
			var values = Enumerable.Range(1, 1000000);
			foreach (int value in values)
			{
				var chain = CollatzChain(value);
				int chainLength = chain.Count();
				if (chainLength > longestChainLength)
				{
					longestChainLength = chainLength;
					longestChainValue = value;
				}
			}

			return longestChainValue;
		}
	}
}
