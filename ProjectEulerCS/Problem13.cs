using PendleCodeMonkey.ProjectEulerCS.Data;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem13
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 13 - Large sum


				Work out the first ten digits of the sum of the specified one-hundred 50-digit numbers.

				(see https://projecteuler.net/problem=13)

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal string Solve()
		{
			// Get the problem data (which parses the 50-digit numbers into 100 BigInteger values).
			// Add the 100 BigInteger values together.
			// Then convert the result to a string and extract the first 10 digits (using the [..10] range operation).
			return Problem13Data.GetData()
				.Aggregate((x, y) => x + y)
				.ToString()[..10];
		}
	}
}
