using PendleCodeMonkey.ProjectEulerCS.Data;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem67
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 67 - Maximum path sum II

				By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

				   3
				  7 4
				 2 4 6
				8 5 9 3

				That is, 3 + 7 + 4 + 9 = 23.

				Find the maximum total from top to bottom in p067_triangle.txt, a 15K text file containing a triangle with one-hundred rows.

				NOTE: This is a much more difficult version of Problem 18. It is not possible to try every route to solve this problem, as there are 299 altogether! If you could
				check one trillion (10¹²) routes every second it would take over twenty billion years to check them all. There is an efficient algorithm to solve it. ;o)

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			var triangleRows = Problem67Data.GetData();

			// Solve using precisely the same strategy as was used to solve Problem 18.
			// Start from the bottom row
			List<int> maxTotals = triangleRows[^1];

			// Working up each row towards the top
			for (int y = triangleRows.Count - 2; y >= 0; y--)
			{
				// Calculate the new maximum totals from the values on the current row and the maximum totals so far.
				maxTotals = Enumerable.Range(0, triangleRows[y].Count)
						.Select(x => Math.Max(triangleRows[y][x] + maxTotals[x], triangleRows[y][x] + maxTotals[x + 1]))
						.ToList();
			}

			// At this point, maxTotals should contain just a single element (the calculated maximum total), so return it.
			return maxTotals.First();
		}
	}
}
