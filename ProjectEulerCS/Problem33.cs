namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem33
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 33 - Digit cancelling fractions


				The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which
				is correct, is obtained by cancelling the 9s.

				We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

				There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

				If the product of these four fractions is given in its lowest common terms, find the value of the denominator.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that calculates the greatest common divisor of the specified numerator and denominator values.
			static int GetGCD(int numerator, int denominator)
			{
				int gcd = 1;
				for (int i = 2; i <= numerator && i <= denominator; i++)
				{
					// Is i a factor of both integers?
					if ((numerator % i == 0) && (denominator % i == 0))
					{
						// Yes, so i is a common divisor.
						gcd = i;
					}
				}
				return gcd;
			}

			// Local function that calculates the non-trivial fractions that meet the criteria set out in the problem, returning the
			// fractions (in tuple form, containing the numerator and denominator values) as an IEnumerable sequence.
			static IEnumerable<(int numerator, int denominator)> GetFractions()
			{
				// Local function that determines if the specified fraction (numerator/denominator) is one of the trivial examples.
				// Returns true if the fraction is trivial; otherwise, false.
				static bool IsTrivial(int numerator, int denominator)
				{
					if (numerator % 10 == 0 && denominator % 10 == 0)
					{
						return true;
					}

					int[] concatNum = { numerator / 10, numerator % 10, denominator / 10, denominator % 10 };
					if (concatNum.Distinct().Count() == concatNum.Length || concatNum.Distinct().Count() == 2)
					{
						return true;
					}

					return false;
				}

				// Local function that removes common digits from the two specified 2-digit numbers, returning the digit that
				// is in the first number (num1) that isn't in the second (num2). If this does not yield a single digit then -1 is returned. 
				static int RemoveCommonDigits(int num1, int num2)
				{
					int[] splitNum1 = { num1 / 10, num1 % 10 };
					int[] splitNum2 = { num2 / 10, num2 % 10 };
					var uniqueDigits = splitNum1.Except(splitNum2).ToArray();

					return uniqueDigits.Length == 1 ? uniqueDigits[0] : -1;
				}

				// For loops of i and j variables (which are used as the numerators and denominators respectively) ensure that the values of both
				// are two digit numbers (i.e. in the range 10 to 99) as stated in the problem description. Also, j values must be greater than the
				// values of i to ensure that the fraction i/j is less than 1 (hence the values of j start at i + 1).
				for (int i = 10; i < 100; i++)
				{
					for (int j = i + 1; j < 100; j++)
					{
						if (!IsTrivial(i, j))
						{
							// Isn't a trivial fraction, so remove common digits and, if a suitable fraction can be made from the
							// reduced set of digits, make the reduced fraction and check if it is equal in value to the original.
							int x = RemoveCommonDigits(i, j);
							int y = RemoveCommonDigits(j, i);
							if (x > 0 && y > 0)
							{
								double originalFraction = (double)i / j;
								double reducedFraction = (double)x / y;
								if (originalFraction == reducedFraction)
								{
									yield return (i, j);
								}
							}
						}
					}
				}
			}

			// Get a collection of the fractions that meet our criteria (there should be 4 items in this collection).
			var fractions = GetFractions();

			// Multiply the returned fractions together (i.e. multiply the numerators and then the denominators)
			int numeratorProduct = fractions.Select(x => x.numerator).Aggregate((x, y) => x * y);
			int denominatorProduct = fractions.Select(x => x.denominator).Aggregate((x, y) => x * y);

			// Calculate the greatest common divisor of the two calculated products (and use it to calculate the denominator product
			// to its lowest value, which is then returned)
			return denominatorProduct / GetGCD(numeratorProduct, denominatorProduct);
		}
	}
}
