namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem62
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 62 - Cubic permutations


				The cube, 41063625 (345³), can be permuted to produce two other cubes: 56623104 (384³) and 66430125 (405³). In fact, 41063625 is the smallest cube
				which has exactly three permutations of its digits which are also cube.

				Find the smallest cube for which exactly five permutations of its digits are cube.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			Dictionary<string, List<long>> cubes = new();

			// We're told that 41063625 (345³) is the smallest cube which has exactly three permutations of its digits which are also
			// cube, so the smallest cube for which exactly five permutations of its digits are cube must be greater than 41063625, so
			// we'll start generating cubes from 346.
			long num = 346;
			while (true)
			{
				// Calculate the cube of the current number.
				long cube = num * num * num;
				// Convert the cubed value to a string, ordering its digits numerically. 
				string orderedDigits = new(cube.ToString().OrderBy(x => x).ToArray());
				// If the cubes dictionary does not already contain this ordered digit string
				if (!cubes.ContainsKey(orderedDigits))
				{
					// Add an entry to the dictionary along with a new list to hold the actual cube values that
					// correspond to this set of ordered digits (adding the current cube value as the first element).
					cubes.Add(orderedDigits, new List<long>() { cube });
				}
				else
				{
					// An entry already exists in the dictionary for this set of ordered digits so add this cubed
					// value to the list corresponding to these ordered digits.
					cubes[orderedDigits].Add(cube);
					// If this set of ordered digits maps to five corresponding cube values then we've found the
					// cube for which five permutations of its digits are cube.
					if (cubes[orderedDigits].Count == 5)
					{
						// Return the smallest cube of the five permutations (which is our final answer)
						return cubes[orderedDigits].Min();
					}
				}

				// Move onto the next number.
				num++;
			}
		}
	}
}
