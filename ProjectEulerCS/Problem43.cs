namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem43
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 43 - Sub-string divisibility


				The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather
				interesting sub-string divisibility property.

				Let d₁ be the 1st digit, d₂ be the 2nd digit, and so on. In this way, we note the following:

				d₂d₃d₄=406 is divisible by 2
				d₃d₄d₅=063 is divisible by 3
				d₄d₅d₆=635 is divisible by 5
				d₅d₆d₇=357 is divisible by 7
				d₆d₇d₈=572 is divisible by 11
				d₇d₈d₉=728 is divisible by 13
				d₈d₉d₁₀=289 is divisible by 17

				Find the sum of all 0 to 9 pandigital numbers with this property.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */


		// First solution - using a brute force method of determining all possible permutations of a ten digit pandigital number and
		// then checking which ones match the sub-string divisibility criteria; summing the values that are found to match the criteria.
		static internal long Solve()
		{
			// Local function that returns a list of all permutations of the supplied array of elements.
			static List<char[]> GetPermutations(char[] input, int startIndex = 0)
			{
				var permutations = new List<char[]>();

				var len = input.Length - 1;

				if (len == startIndex)
				{
					permutations.Add(input);
				}
				else
				{
					for (int i = startIndex; i <= len; i++)
					{
						// Make a copy of the input
						var copy = input.ToArray();

						// Swap elements at index i and startIndex in the copy
						(copy[i], copy[startIndex]) = (copy[startIndex], copy[i]);

						// Make a recursive call to GetPermutations and add the returned elements to the list.
						permutations.AddRange(GetPermutations(copy, startIndex + 1));
					}
				}

				return permutations;
			}

			// Local function that checks if the specified number fits the criteria outlined in the problem text (i.e. the sub-string
			// divisibility property)
			static bool FitsDivisibilityCriteria(long value)
			{
				long[] divisibles = new long[] { 17, 13, 11, 7, 5, 3, 2 };

				foreach (var div in divisibles)
				{
					// Extract a 3-digit sub-value
					var num = value % 1000;

					// Check if it is divisible by the given value; if not, then it does not match the criteria.
					if (num % div != 0)
					{
						return false;
					}
					value /= 10;
				}

				// This number passes all the sub-string divisibility criteria, so return true.
				return true;
			}

			// Get all permutations of a string containing the digits 0 to 9 (i.e. all possible 0 to 9 pandigital numbers)
			string str = "1234567890";
			var permutations = GetPermutations(str.ToCharArray());

			// Check which permutations fit the divisibility criteria.
			List<long> matches = new();
			foreach (var elem in permutations)
			{
				string s = new(elem);
				long value = long.Parse(s);
				if (FitsDivisibilityCriteria(value))
				{
					// We have found a number that fits the criteria, so add its value to the list.
					matches.Add(value);
				}
			}

			// Return the sum of the values that were found to match the divisibility criteria.
			return matches.Sum();
		}


		// The following is an alternative (and MUCH faster) solution.
		//
		// There are several things we can deduce in order to dramatically reduce the possibilities for the location of certain digits (and ultimately allow
		// us to avoid doing any computation at all to determine all possible pandigital numbers that match our criteria)
		// All our code needs to do is sum the values determined by applying these deductions:
		// 
		// 1) d[4],d[5],d[6] is divisible by 5; therefore d[6] must be a 0 or a 5.
		// 2) d[6],d[7],d[8] is divisible by 11. We know that d[6] must be a 0 or a 5; however, it cannot be a zero because, to be divisible
		//		by 11, that would mean that d[7] and d[8] would need to be identical digits (i.e. 11, 22, 33, etc.), which is not allowed in a pandigital
		//		number. So d[6] must be 5; consequently d[6],d[7],d[8] could be 506, 517, 528, 539, 561, 572, 583, or 594 (which are all of the valid 3 digit numbers beginning
		//		with 5 that are divisible by 11)
		// 3) d[7],d[8],d[9] is divisible by 13. Step 2) tells us that d[7],d[8] can be 06, 17, 28, 39, 61, 72, 83, or 94. d[9] cannot be a 5 because that's already
		//		used for d[6]; therefore d[7],d[8],d[9] could be 286, 390, 728, or 832 (which are all the 3 digit numbers beginning with the possible values of
		//		d[7],d[8] that are divisible by 13)
		// 4) d[8],d[9],d[10] is divisible by 17. Step 3) tells us that d[8],d[9] can be 86, 90, 28, or 32. Again, d[10] cannot be a 5 because that's already used for d[6].
		//		This narrows d[8],d[9],d[10] to being 289, 867, or 901
		// 5) d[5],d[6],d[7] is divisible by 7. d[6] is 5 and step 3) tells us that d[7] can be 2, 3, 7, or 8 (so d[6],d[7] can be 52, 53, 57, or 58), allowing us to
		//		narrow d[5],d[6],d[7] to being 357, or 952 (the only 3 digit numbers ending in the possible d[6],d[7] values that is also divisible by 7), so d[5] is 3 or 9.
		// 6) All the above allows us to reduce the possibilities for d[5],d[6],d[7],d[8],d[9],d[10] to being 357289, or 952867
		// 7) d[3],d[4],d[5] is divisible by 3. We already know that d[5] can be 3 or 9. Neither d[3] nor d[4] can be any of 2, 5, 7, 8, or 9 (as those numbers
		//		have already been used - see step 6)). This leaves the possible values for d[3] and d[4] as 0, 1, 3, 4, or 6. Neither 1 nor 4 can be used because there
		//		are no three digit numbers ending in 3 or 9 that are divisible by 3 using only the digits 0, 1, 3, 4, 6, and 9 that include a 1 or a 4 anywhere in the number.
		//		This narrows the options for d[3],d[4],d[5] down to 063, 309, or 603
		// 8) We are now left with d[1],[d2] being composed of the only two unused digits, that is 1 and 4; so d[1],d[2] could be 14 or 41
		// 9) All of the above reduces the available options for the entire 10 digit number down to the following:
		//		1406357289, 1430952867, 1460357289, 4106357289, 4130952867, and 4160357289
		static internal long Solve2()
		{
			// Array containing the pandigital numbers that match our criteria (deduced by following the steps outlined in the above comment)
			long[] validPandigitalNumbers = new long[] { 1406357289, 1430952867, 1460357289, 4106357289, 4130952867, 4160357289 };

			// Return the sum of the values in the array. Simples! :-)
			return validPandigitalNumbers.Sum();
		}
	}
}
