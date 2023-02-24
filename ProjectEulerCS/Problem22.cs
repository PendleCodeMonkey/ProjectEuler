using PendleCodeMonkey.ProjectEulerCS.Data;
using System.Text;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem22
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 22 - Names scores


				Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value
				for each name, multiply this value by its alphabetical position in the list to obtain a name score.

				For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would
				obtain a score of 938 × 53 = 49714.

				What is the total of all the name scores in the file?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Get the sorted list of names from the problem data.
			var names = Problem22Data.GetData();

			// byte value to be subtracted from an ASCII code to determine its 'worth' (i.e. subtracting worthAdjust from ASCII 'A' yields a value of 1,
			// subtracting worthAdjust from ASCII 'B' yields a value of 2, etc.)
			byte worthAdjust = 'A' - 1;

			int sum = 0;
			int pos = 1;
			foreach (string name in names)
			{
				// Convert the name to ASCII characters, calculate the 'worth' of each ASCII character, sum them, and then multiply by the name's position
				// in the sorted list, adding the calculated value to the overall sum. 
				sum += Encoding.ASCII.GetBytes(name).Select(x => x - worthAdjust).Sum() * pos;
				pos++;
			}

			return sum;
		}
	}
}
