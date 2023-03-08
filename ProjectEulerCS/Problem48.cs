using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem48
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 48 - Self powers


				The series, 1¹ + 2² + 3³ + ... + 10¹⁰ = 10405071317.

				Find the last ten digits of the series, 1¹ + 2² + 3³ + ... + 1000¹⁰⁰⁰.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal string Solve()
		{
			// Calculate the sum of the numbers 1 to 1000, each raised to a power of itself; convert the sum to a string and extract the last 10 characters (using the
			// C# range operator).
			// We must use BigIntegers because the numbers we are dealing with are so huge.
			return Enumerable.Range(1, 1000)
				.Select(x => BigInteger.Pow((BigInteger)x, x))
				.Aggregate((x, y) => x + y)
				.ToString()[^10..];
		}
	}
}
