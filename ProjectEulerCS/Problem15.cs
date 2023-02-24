namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem15
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 15 - Lattice paths


				Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

				How many such routes are there through a 20×20 grid?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal Dictionary<(int, int), long> cacheNumPaths;     // Cache of the number of paths for each x,y value pair.

		static Problem15()
		{
			cacheNumPaths = new();
		}

		static internal long Solve()
		{
			// Local (recursive) function that calculates the number of paths through the grid for the specified x,y value pair.
			static long NumberOfPaths(int x, int y)
			{
				// If x or y is equal to 20 then return a single path.
				if (x == 20 || y == 20)
				{
					return 1;
				}

				long numPaths = 0;

				// Determine the number of paths for the current x,y value pair (if we haven't already done so)
				if (!cacheNumPaths.ContainsKey((x, y)))
				{
					if (x < 20)
					{
						numPaths += NumberOfPaths(x + 1, y);        // moving right one grid position.
					}

					if (y < 20)
					{
						numPaths += NumberOfPaths(x, y + 1);        // moving down one grid position.
					}

					// Cache the number of paths for the current x,y value pair (so it's instantly available should we need it again)
					cacheNumPaths[(x, y)] = numPaths;
				}

				// Return the number of paths for the current x,y value pair.
				return cacheNumPaths[(x, y)];
			}

			// Calculate the number of paths through the 20x20 grid starting at x = 0, y = 0.
			return NumberOfPaths(0, 0);
		}
	}
}
