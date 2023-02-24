namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem17
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 17 - Number letter counts


				If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

				If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


				NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
				The use of "and" when writing out numbers is in compliance with British usage.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static readonly Dictionary<int, string> numToWords = new()
		{
			{ 1, "one" },
			{ 2, "two" },
			{ 3, "three" },
			{ 4, "four" },
			{ 5, "five" },
			{ 6, "six" },
			{ 7, "seven" },
			{ 8, "eight" },
			{ 9, "nine" },
			{ 10, "ten" },
			{ 11, "eleven" },
			{ 12, "twelve" },
			{ 13, "thirteen" },
			{ 14, "fourteen" },
			{ 15, "fifteen" },
			{ 16, "sixteen" },
			{ 17, "seventeen" },
			{ 18, "eighteen" },
			{ 19, "nineteen" },
			{ 20, "twenty" },
			{ 30, "thirty" },
			{ 40, "forty" },
			{ 50, "fifty" },
			{ 60, "sixty" },
			{ 70, "seventy" },
			{ 80, "eighty" },
			{ 90, "ninety" },
			{ 1000, "one thousand" }
		};

		static internal int Solve()
		{
			// Local function that returns an IEnumerable sequence containing the word equivalents of the numbers 1 to 1000 (inclusive).
			static IEnumerable<string> NumbersToNames()
			{
				var keys = numToWords.Keys.ToList();

				for (int i = 1; i <= 1000; i++)
				{
					// Is there an exact match for this value in the numToWords dictionary?
					if (numToWords.ContainsKey(i))
					{
						// Yes, so just return it.
						yield return numToWords[i];
						continue;
					}

					string numberAsWords = "";
					int numHundreds = i / 100;
					int tensAndUnits = i % 100;

					if (numHundreds > 0)
					{
						// Add the hundreds section of the word representation of the number, adding the string " and " if
						// anything follows the hundreds (i.e. there are tens and/or units)
						numberAsWords += numToWords[numHundreds] + " hundred" + (tensAndUnits > 0 ? " and " : "");
					}
					if (tensAndUnits > 0)
					{
						// If there is an exact match in the numToWords dictionary then use it. 
						if (numToWords.ContainsKey(tensAndUnits))
						{
							numberAsWords += numToWords[tensAndUnits];
						}
						else
						{
							// No exact match in the dictionary so we need to dissect the tensAndUnits value and
							// handle the tens and units separately.
							int numTens = tensAndUnits / 10;
							int units = tensAndUnits % 10;
							if (numTens > 0)
							{
								// Handle the tens portion (this will retrieve values such as "twenty", "thirty", "forty", etc.)
								numberAsWords += numToWords[numTens * 10] + (units > 0 ? " " : "");
							}
							if (units > 0)
							{
								numberAsWords += numToWords[units];
							}
						}
					}

					// Return the word string for this number.
					yield return numberAsWords;
				}
			}

			return NumbersToNames().Select(a => a.Replace(" ", "").Length).ToList().Sum();
		}
	}
}
