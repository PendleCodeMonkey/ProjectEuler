using System.Text;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem68
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 68 - Magic 5-gon ring

				See https://projecteuler.net/problem=68 for problem description.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal string Solve()
		{
			// Local function that returns a list of all permutations of the supplied array of elements.
			static List<int[]> GetPermutations(int[] input, int startIndex = 0)
			{
				var permutations = new List<int[]>();

				var len = input.Length - 1;

				if (len == startIndex)
				{
					permutations.Add(input);
				}
				else
				{
					for (int i = startIndex; i <= len; i++)
					{
						// Make a copy of the input
						var copy = input.ToArray();

						// Swap elements at index i and startIndex in the copy
						(copy[i], copy[startIndex]) = (copy[startIndex], copy[i]);

						// Make a recursive call to GetPermutations and add the returned elements to the list.
						permutations.AddRange(GetPermutations(copy, startIndex + 1));
					}
				}

				return permutations;
			}

			var permutationsInner = GetPermutations(Enumerable.Range(1, 5).ToArray(), 0);
			var permutationsOuter = GetPermutations(Enumerable.Range(6, 5).ToArray(), 0);

			string max = "";
			foreach (var inner in permutationsInner)
			{
				foreach (var outer in permutationsOuter)
				{
					int sum = outer[0] + inner[0] + inner[1];
					if (outer[1] + inner[1] + inner[2] != sum
						|| outer[2] + inner[2] + inner[3] != sum
						|| outer[3] + inner[3] + inner[4] != sum
						|| outer[4] + inner[4] + inner[0] != sum)
						continue;

					(int minOuter, int minOuterIndex) = outer.Select((x, i) => (x, i)).Min();

					StringBuilder sb = new();
					for (int i = 0; i < 5; i++)
					{
						sb.Append($"{outer[(minOuterIndex + i) % 5]}{inner[(minOuterIndex + i) % 5]}{inner[(minOuterIndex + i + 1) % 5]}");
					}
					string s = sb.ToString();
					if (s.Length == 16 && (s.CompareTo(max) > 0))
					{
						max = s;
					}
				}
			}

			return max;
		}
	}
}
