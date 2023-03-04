namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem32
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 32 - Pandigital products


				We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once;
				for example, the 5-digit number, 15234, is 1 through 5 pandigital.

				The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

				Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

				HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that checks if a multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
			static bool IsPandigital(int multiplicand, int multiplier)
			{
				// Construct a string containing the digits of the multiplicand, multipier, and the product of the two.
				string digits = multiplicand.ToString() + multiplier.ToString() + (multiplicand * multiplier).ToString();

				// In order to be "1 through 9 pandigital", the string must be exactly 9 characters long, so bail out now if it isn't.
				if (digits.Length != 9)
				{
					return false;
				}

				// Order the digits in the string, so we can easily check if it contains each digit (1 through 9) exactly once.
				string orderedDigits = new(digits.ToCharArray().OrderBy(x => x).ToArray());
				return orderedDigits == "123456789";
			}

			// Local function that returns an IEnumerable sequence containing all pandigital products (including duplicate values).
			//
			// The product (of multiplicand and multiplier) must have a maximum length of 4 digits because, in order to be 5 digits or more, the multiplicand
			// and multiplier themselves must have a combined digit length of 5 or more; consequently, the multiplicand/multiplier/product identity
			// could not possibly fit in a 9 digit string; therefore, every product must be less than 10000.
			// As the products are a maximum of 4 digits in length, the smaller of the multiplicand and multiplier must have a maximum 2 digit length (we can't
			// have both multiplicand and multiplier having 3+ digit lengths as this would result in a product with more than 4 digits); therefore we
			// only need to check multiplicand values lower than 100.
			static IEnumerable<int> GetPandigitalProducts()
			{
				int productLimit = 10000;
				for (int multiplicand = 1; multiplicand < 100; multiplicand++)
				{
					for (int multiplier = multiplicand; multiplicand * multiplier < productLimit; multiplier++)
					{
						if (IsPandigital(multiplicand, multiplier))
						{
							// Is pandigital so return the product as part of the IEnumerable sequence.
							yield return multiplicand * multiplier;
						}
					}
				}
			}

			// Get a list of pandigital products, remove any duplicate values, and calculate their sum.
			return GetPandigitalProducts()
				.ToList()
				.Distinct()
				.Sum();
		}
	}
}
