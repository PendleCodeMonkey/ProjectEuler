﻿namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem61
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 61 - Cyclical figurate numbers


				Triangle, square, pentagonal, hexagonal, heptagonal, and octagonal numbers are all figurate (polygonal) numbers and are generated by the following formulae:

				Triangle	 	P₃,ₙ = n(n+1)/2	 		1, 3, 6, 10, 15, ...
				Square	 		P₄,ₙ = n2	 			1, 4, 9, 16, 25, ...
				Pentagonal	 	P₅,ₙ = n(3n−1)/2	 		1, 5, 12, 22, 35, ...
				Hexagonal	 	P₆,ₙ = n(2n−1)	 		1, 6, 15, 28, 45, ...
				Heptagonal	 	P₇,ₙ = n(5n−3)/2	 		1, 7, 18, 34, 55, ...
				Octagonal	 	P₈,ₙ = n(3n−2)	 		1, 8, 21, 40, 65, ...
				The ordered set of three 4-digit numbers: 8128, 2882, 8281, has three interesting properties.

				The set is cyclic, in that the last two digits of each number is the first two digits of the next number (including the last number with the first).
				Each polygonal type: triangle (P₃,127=8128), square (P₄,91=8281), and pentagonal (P₅,44=2882), is represented by a different number in the set.
				This is the only set of 4-digit numbers with this property.
				Find the sum of the only ordered set of six cyclic 4-digit numbers for which each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal, and
				octagonal, is represented by a different number in the set.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that calculates the figurate (i.e. triangle, square, pentagonal, hexagonal, heptagonal, and octagonal) numbers
			// for the specified value of n. Returning the values as a sequence of tuples.
			static IEnumerable<(int type, int value)> CalculateFigurateNumbers(int n)
			{
				yield return (3, n * (n + 1) / 2);
				yield return (4, n * n);
				yield return (5, n * (3 * n - 1) / 2);
				yield return (6, n * (2 * n - 1));
				yield return (7, n * (5 * n - 3) / 2);
				yield return (8, n * (3 * n - 2));
			}

			// Local [recursive] function that searches through the specified dictionary, looking for a chain of 6 figurate numbers that fulfils the
			// criteria set out in the problem description (i.e. an ordered set of six cyclic 4-digit numbers)
			static int Search(IDictionary<(int type, int value), List<(int type, int value)>> dict, int[] types, int[] data)
			{
				// If we have a set of 6 numbers, check if the last two digits of the last number match the first two digits of the first number (i.e.
				// the set is properly cyclic) and, if so, return the sum of the set of 6 figurate numbers (which is our final result)
				if (types.Length == 6 && data[^1] % 100 == data[0] / 100)
				{
					return data.Sum();
				}

				// Get the type and value of the last figurate number in the arrays currently being considered. 
				(int type, int value) elem = (types[^1], data[^1]);

				// If the dictionary contains an entry for this type/value pair
				if (dict.ContainsKey(elem))
				{
					// Iterate through the figurate numbers in the corresponding list.
					foreach (var (type, value) in dict[elem])
					{
						// Only consider figurate numbers with polygonal type that we haven't already handled.
						if (!types.Contains(type))
						{
							// Create a copy of the types array with an additional element for this figurate number's type.
							int[] newTypes = new int[types.Length + 1];
							if (types.Length > 0)
							{
								Array.Copy(types, newTypes, types.Length);
							}
							newTypes[^1] = type;

							// Likewise for the data array with an additional element for this figurate number's value.
							int[] newData = new int[data.Length + 1];
							if (data.Length > 0)
							{
								Array.Copy(data, newData, data.Length);
							}
							newData[^1] = value;

							// Continue the search using the values in these new arrays [recursive call to Search]
							int retVal = Search(dict, newTypes, newData);
							// If the call returned a "proper" value (i.e. anything other than -1), then return it.
							if (retVal != -1)
							{
								return retVal;
							}
						}
					}
				}
				return -1;
			}


			// Determine the range of valid start and end values for n.
			// We're only interested in four digit figurate numbers, so we'll start at 19 because any values of n less than this will yield an octagonal number with
			// less than four digits and we'll end at 140 because values of n greater than this will yield triangle numbers with more than 4 digits. Therefore, values
			// of n outside the range 19 -> 140 (inclusive) are guaranteed to generate a set of figurate numbers, none of which have four digits.
			int start = 19;
			int end = 140;

			// Calculate the figurate numbers for each value in the specified range, constructing a list of all four digit figurate numbers that are calculated.
			List<(int type, int value)> figurateNumbers = new();
			for (int n = start; n <= end; n++)
			{
				var fig = CalculateFigurateNumbers(n).ToList();
				var valid = fig.Where(x => x.value >= 1000 && x.value <= 9999 && x.value % 100 >= 10);
				figurateNumbers.AddRange(valid);
			}

			// Construct a list joining together figurate numbers where the last two digits of the first number (f1)
			// match the first two digits of the second number (f2), where the two numbers don't have the same polygonal type.
			List<((int type, int value), (int type, int value))> figurateNumberPairs = (
				from f1 in figurateNumbers
				from f2 in figurateNumbers
				where f1.type != f2.type && f1.value % 100 == f2.value / 100
				select (f1, f2)
			).ToList();

			// Construct a dictionary mapping each figurate number with a list of its pair figurate numbers.
			Dictionary<(int type, int value), List<(int type, int value)>> dict = new();
			foreach (var (fig1, fig2) in figurateNumberPairs)
			{
				// If figurate number fig1 is already in the dictionary then add the figurate number fig2 to the
				// list that already exists in the dictionary element's value.
				if (dict.ContainsKey(fig1))
				{
					dict[fig1].Add(fig2);
				}
				else
				{
					// The figurate number fig1 is not already in the dictionary, so we need to add it and create a
					// new list to hold the matching pair numbers (using fig2 as the first element in this list)
					dict.Add(fig1, new List<(int type, int value)> { fig2 });
				}
			}

			// Iterate through each key in the dictionary
			foreach (var (type, value) in dict.Keys)
			{
				// Search for an ordered set of six cyclic 4-digit numbers, starting with the current figurate number's type/value.
				int result = Search(dict, new int[] { type }, new int[] { value });
				if (result != -1)
				{
					// This call to Search yielded our final answer, so return it.
					return result;
				}
			}

			return -1;
		}
	}
}
