namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem34
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 34 - Digit factorials


				145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

				Find the sum of all numbers which are equal to the sum of the factorial of their digits.

				Note: As 1! = 1 and 2! = 2 are not sums they are not included.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that calculates all numbers which are equal to the sum of the factorial of
			// their digits (i.e. all factorions - see https://en.wikipedia.org/wiki/Factorion)
			static IEnumerable<int> GetFactoralSumMatch()
			{
				// Calculate the factorials of all single digit numbers (i.e. 0 to 9), which we will use later when summing the factorials
				// of each individual digit in a number.
				List<int> singleDigitFactorials = new(10)
				{
					1		// The first item in list corresponds to 0!, which is equal to 1
				};
				// Calculate (and store) the factorials of the remaining single-digit numbers, 1 to 9.
				for (int i = 1; i < 10; i++)
				{
					singleDigitFactorials.Add(Enumerable.Range(1, i).Aggregate(1, (x, y) => x * y));
				}

				// There is no 8 digit number that can be the sum of the factorial of its digits (because 8 x 9! is 2903040, which is a 7 digit number)
				// Therefore, we only need to check numbers containing up to 7 digits. The largest 7 digit number is 9,999,999 (which itself yields a summed digit
				// factorial value of 7 * 9!) so this will be used as our upper limit.
				int maxValue = 7 * singleDigitFactorials[9];

				int number = 10;
				while (number <= maxValue)
				{
					int sum = 0;
					int temp = number;
					while (temp > 0)
					{
						// Retrieve the factorial of the least significant digit of the number, adding it to the sum.
						sum += singleDigitFactorials[temp % 10];
						// Divide by 10 to remove the least significant digit that we have just handled.
						temp /= 10;
					}

					// If the sum of the factorials of the number's digits is equal to the number itself then
					// this is one of the values we're interested in, so return this number as part of the sequence.
					if (sum == number)
					{
						yield return number;
					}

					// Advance to the next number (and loop until we reach the upper limit)
					number++;
				}
			}

			return GetFactoralSumMatch().Sum();
		}
	}
}
