﻿namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem45
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 45 - Triangular, pentagonal, and hexagonal


				Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:

				Triangle	 	Tₙ=n(n+1)/2	 	1, 3, 6, 10, 15, ...
				Pentagonal	 	Pₙ=n(3n−1)/2	1, 5, 12, 22, 35, ...
				Hexagonal	 	Hₙ=n(2n−1)	 	1, 6, 15, 28, 45, ...
				It can be verified that T₂₈₅ = P₁₆₅ = H₁₄₃ = 40755.

				Find the next triangle number that is also pentagonal and hexagonal.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal long Solve()
		{
			// Local function that determines if the specified number is a pentagonal number.
			// Using a test outlined in https://en.wikipedia.org/wiki/Pentagonal_number
			static bool IsPentagonalNumber(long x)
			{
				long temp = x * 24 + 1;
				long sqRoot = (long)Math.Sqrt(temp);
				return (sqRoot * sqRoot == temp) && (sqRoot % 6 == 5);
			}

			// Hexagonal numbers are a subset of triangle numbers, so every hexagonal number is also a triangle number; therefore
			// we only need to search for hexagonal numbers that are also pentagonal.
			// We know that 40755 is the 143rd hexagonal number, and as we're looking for the next one, we can start
			// our search at 144.
			long n = 144;
			while (true)
			{
				// Calculate the next hexagonal number.
				long hexagonal = n * (n * 2 - 1);

				// If it is also pentagonal then we have found the number we are looking for.
				if (IsPentagonalNumber(hexagonal))
				{
					return hexagonal;
				}
				n++;
			}
		}
	}
}
