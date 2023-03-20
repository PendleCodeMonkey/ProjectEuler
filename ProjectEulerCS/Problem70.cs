namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem70
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 70 - Totient permutation

				Euler's Totient function, φ(n) [sometimes called the phi function], is used to determine the number of positive numbers less than or equal
				to n which are relatively prime to n. For example, as 1, 2, 4, 5, 7, and 8, are all less than nine and relatively prime to nine, φ(9)=6.
				The number 1 is considered to be relatively prime to every positive number, so φ(1)=1.

				Interestingly, φ(87109)=79180, and it can be seen that 87109 is a permutation of 79180.

				Find the value of n, 1 < n < 10⁷, for which φ(n) is a permutation of n and the ratio n/φ(n) produces a minimum.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int[]? Phi { get; set; }

		static internal int Solve()
		{
			static void CalcPhi()
			{
				int limit = 10_000_000;
				Phi = Enumerable.Range(1, limit + 1).ToArray();
				for (int i = 2; i <= limit; i++)
				{
					if (Phi[i - 1] == i)
					{
						for (int j = i - 1; j <= limit; j += i)
						{
							Phi[j] = Phi[j] / i * (i - 1);
						}
					}
				}
			}

			// Local function that determines if the two specified numbers are permutations of one another (by converting each to a string, sorting
			// the characters in these strings, and then checking if both strings are the same)
			static bool IsPermutation(int num1, int num2)
			{
				string s1 = new(num1.ToString().OrderBy(c => c).ToArray());
				string s2 = new(num2.ToString().OrderBy(c => c).ToArray());

				return s1 == s2;
			}

			// Pre-calculate Phi for the values of n ≤ 10,000,000
			CalcPhi();

			int result = 0;
			if (Phi is not null)
			{
				double minNDivPhi = double.MaxValue;
				int n = 2;
				foreach (int phi in Phi.Skip(1))
				{
					double nDivPhi = (double)n / phi;
					if (nDivPhi < minNDivPhi && n % 3 == phi % 3 && IsPermutation(n, phi))
					{
						minNDivPhi = nDivPhi;
						result = n;
					}
					n++;
				}
			}

			return result;
		}
	}
}
