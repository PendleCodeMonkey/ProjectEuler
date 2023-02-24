namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem18
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 18 - Power digit sum


				By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

				   3
				  7 4
				 2 4 6
				8 5 9 3

				That is, 3 + 7 + 4 + 9 = 23.

				Find the maximum total from top to bottom of the triangle below:

				                            75
				                          95  64
				                        17  47  82
				                      18  35  87  10
				                    20  04  82  47  65
				                  19  01  23  75  03  34
				                88  02  77  73  07  63  67
				              99  65  04  28  06  16  70  92
				            41  41  26  56  83  40  80  70  33
				          41  48  72  33  47  32  37  16  94  29
				        53  71  44  65  25  43  91  52  97  51  14
				      70  11  33  28  77  73  17  78  39  68  17  57
				    91  71  52  38  17  14  91  43  58  50  27  29  48
				  63  66  04  68  89  53  67  30  73  16  69  87  40  31
				04  62  98  27  23  09  70  98  73  93  38  53  60  04  23

				NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle containing
				one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			List<List<int>> triangleRows = new()
			{
				new List<int> { 75 },
				new List<int> { 95, 64 },
				new List<int> { 17, 47, 82 },
				new List<int> { 18, 35, 87, 10 },
				new List<int> { 20, 04, 82, 47, 65 },
				new List<int> { 19, 01, 23, 75, 03, 34 },
				new List<int> { 88, 02, 77, 73, 07, 63, 67 },
				new List<int> { 99, 65, 04, 28, 06, 16, 70, 92 },
				new List<int> { 41, 41, 26, 56, 83, 40, 80, 70, 33 },
				new List<int> { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 },
				new List<int> { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 },
				new List<int> { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 },
				new List<int> { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 },
				new List<int> { 63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 },
				new List<int> { 04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23 }
			};

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
