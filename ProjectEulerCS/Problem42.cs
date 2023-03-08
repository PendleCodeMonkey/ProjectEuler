using PendleCodeMonkey.ProjectEulerCS.Data;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem42
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 42 - Coded triangle numbers


				The nᵗʰ term of the sequence of triangle numbers is given by, tₙ = ½n(n+1); so the first ten triangle numbers are:

				1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

				By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value.
				For example, the word value for SKY is 19 + 11 + 25 = 55 = t₁₀. If the word value is a triangle number then we shall call the word a triangle word.

				Using p042_words.txt, a 16K text file containing nearly two-thousand common English words, how many are triangle words?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			static int WordValue(string word)
			{
				return word.ToCharArray().Select(x => x - ('A' - 1)).Sum();
			}

			var data = Problem42Data.GetData();

			// Get the length of the longest word in the data.
			var maxLen = data.Max(s => s.Length);

			// Determine the maximum word value - i.e. if the longest word happened to be composed entirely of letter Z's then
			// the maximum word value would be the length of the longest string multiplied by 26 (the value for the letter Z)
			// There's no point generating triangle numbers beyond that because none of the words in the data could possibly have word values exceeding this maximum.
			int maxWordValue = maxLen * 26;

			// Generate all triangle numbers up to this maximum value.
			HashSet<int> triangleNumbers = new();
			int triangleNumber = 0;
			for (int i = 1; triangleNumber <= maxWordValue; i++)
			{
				triangleNumber = i * (i + 1) / 2;
				triangleNumbers.Add(triangleNumber);
			}

			return data.Where(x => triangleNumbers.Contains(WordValue(x))).Count();
		}
	}
}
