namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem39
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 39 - Integer right triangles


				If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

				{20,48,52}, {24,45,51}, {30,40,50}

				For which value of p ≤ 1000, is the number of solutions maximised?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			List<List<(int a, int b, int c)>> allSolutions = new();

			for (int p = 1; p <= 1000; p++)
			{
				List<(int a, int b, int c)> solutionsForP = new();

				for (int a = 1; a < p; a++)
				{
					for (int b = a + 1; b < p; b++)
					{
						int c = p - (a + b);

						if (c > b && ((a * a) + (b * b) == (c * c)))
						{
							// a² + b² = c², so add this trio of values to the list of solutions that have been found for this value of p.
							solutionsForP.Add((a, b, c));
						}
					}
				}
				// Add the solutions we have found for the current value of p to the list of all solutions.
				allSolutions.Add(solutionsForP);
			}

			// Sort the allSolutions list in ascending order by count (i.e. by the number of solutions found for each value of p) and take
			// the last set of solutions in the sorted list (i.e the element with the most solutions, i.e. the highest count).
			var maximisedSolutions = allSolutions.OrderBy(x => x.Count).Last();

			// Get the first solution from the retrieved maximised solution list (we could choose any one of them because they all correspond
			// to the same value of p, but it's easy to get the first).
			var firstMaxSolution = maximisedSolutions.First();

			// Calculate the final result (i.e. the value of p which has the maximum number of solutions) - we can easily do this by adding together
			// the values of the a, b, and c elements.
			int result = firstMaxSolution.a + firstMaxSolution.b + firstMaxSolution.c;

			return result;
		}
	}
}
