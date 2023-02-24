using System.Numerics;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem25
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 25 - 1000-digit Fibonacci number


				The Fibonacci sequence is defined by the recurrence relation:

				Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
				Hence the first 12 terms will be:

				F1 = 1
				F2 = 1
				F3 = 2
				F4 = 3
				F5 = 5
				F6 = 8
				F7 = 13
				F8 = 21
				F9 = 34
				F10 = 55
				F11 = 89
				F12 = 144
				The 12th term, F12, is the first term to contain three digits.

				What is the index of the first term in the Fibonacci sequence to contain 1000 digits?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// The target term in the Fibonacci sequence has 1000 digits; therefore, we need to work with BigInteger values.
			BigInteger currValue = 0;
			BigInteger prevValue = 1;

			int index = 0;

			// Keep looping while the length of the current value when converted to a string is not 1000 (i.e. the value has less than 1000 digits)
			while (currValue.ToString().Length != 1000)
			{
				BigInteger temp = currValue;
				currValue += prevValue;
				prevValue = temp;
				index++;
			}

			return index;
		}
	}
}
