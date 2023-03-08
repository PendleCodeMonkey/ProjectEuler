namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem49
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 49 - Prime permutations


				The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are
				prime, and, (ii) each of the 4-digit numbers are permutations of one another.

				There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.

				What 12-digit number do you form by concatenating the three terms in this sequence?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal string Solve()
		{
			// Local function to determine if the specified value is a prime number.
			static bool IsPrime(int num) => num > 1 && !Enumerable.Range(2, (int)Math.Sqrt(num) - 1).Any(i => num % i == 0);

			// Local function that determines if the three specified numbers are permutations of ome another (by converting each to a string, sorting
			// the characters in these strings, and then checking if all 3 strings are the same)
			static bool ArePermutations(int num1, int num2, int num3)
			{
				string s1 = new(num1.ToString().OrderBy(c => c).ToArray());
				string s2 = new(num2.ToString().OrderBy(c => c).ToArray());
				string s3 = new(num3.ToString().OrderBy(c => c).ToArray());

				return s1 == s2 && s2 == s3;
			}

			string result = "";

			// We're dealing with 4-digit numbers, so we can start searching from 1000.
			int term1 = 1000;
			while (true)
			{
				// Term1, Term2 and Term3 need to be 3330 apart.
				int term2 = term1 + 3330;
				int term3 = term2 + 3330;

				// First check if the three terms are all prime numbers.
				if (IsPrime(term1) && IsPrime(term2) && IsPrime(term3))
				{
					// They are all prime, so check if the terms are permutations of one another.
					if (ArePermutations(term1, term2, term3))
					{
						// Everything checks out so far; however, this will obviously also return the terms 1487, 4817, 8147 that are supplied in the problem
						// description, but we want to ignore that as it's the other 4-digit increasing sequence we're interested in.
						if (term1 != 1487)
						{
							// Create a string containing the three 4-digit numbers concatenated together, and we're done!
							result = term1.ToString() + term2.ToString() + term3.ToString();
							break;
						}
					}
				}

				// Move onto the next number.
				term1++;
			}

			return result;
		}
	}
}
