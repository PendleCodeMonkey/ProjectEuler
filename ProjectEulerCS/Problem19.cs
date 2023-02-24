namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem19
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 19 - Counting Sundays


				You are given the following information, but you may prefer to do some research for yourself.

				*	1 Jan 1900 was a Monday.

				*	Thirty days has September,
					April, June and November.
					All the rest have thirty-one,
					Saving February alone,
					Which has twenty-eight, rain or shine.
					And on leap years, twenty-nine.

				*	A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

				How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		private static readonly int February = 2;
		private static readonly Dictionary<int, int> daysInMonth = new()
		{
			{ 1, 31 },
			{ 2, 28 },
			{ 3, 31 },
			{ 4, 30 },
			{ 5, 31 },
			{ 6, 30 },
			{ 7, 31 },
			{ 8, 31 },
			{ 9, 30 },
			{ 10, 31 },
			{ 11, 30 },
			{ 12, 31 }
		};

		static internal int Solve()
		{
			// Local function that returns the number of days in the specified month, adding one if the month is February (i.e month 2) and the specified year is a leap year.
			static int GetNumberOfDaysInMonth(int month, int year) => daysInMonth[month] + (month == February && IsLeapYear(year) ? 1 : 0);

			// Local function that determines if the specified year is a leap year.
			// If year is not divisible by 4 or is a century that is not divisible by 400 then it's not a leap year.
			static bool IsLeapYear(int year) => (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0)) ? false : true;

			// Starting on 1st January 1900 (which we are told was a Monday)
			int day = 1;
			int month = 1;
			int year = 1900;
			int dayOfWeek = (int)DayOfWeek.Monday;

			int numSundaysOnFirstOfMonth = 0;

			// Loop while the year is less than 2001 (i.e. year is before the 21st century)
			while (year < 2001)
			{
				// If the current day is the 1st, is in the 20th century (i.e. year is > 1900), and is a Sunday then
				// we have one more Sunday that fell on the first of the month.
				if (day == 1 && year > 1900 && dayOfWeek == (int)DayOfWeek.Sunday)
				{
					numSundaysOnFirstOfMonth++;
				}

				// Move on a day, advancing to the next month and year when required.
				day++;
				if (day > GetNumberOfDaysInMonth(month, year))
				{
					day = 1;
					month++;

					if (month > 12)
					{
						month = 1;
						year++;
					}
				}

				// Advance our record of the day of the week, keeping it within the range 0 -> 6
				dayOfWeek++;
				dayOfWeek %= 7;
			}

			return numSundaysOnFirstOfMonth;
		}
	}
}
