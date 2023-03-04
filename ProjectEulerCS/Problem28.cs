namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem28
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 28 - Number spiral diagonals


				Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

					(21)  22   23   24  (25)
					 20   (7)   8   (9)  10
					 19    6   (1)   2   11
					 18   (5)   4   (3)  12
					(17)  16   15   14  (13)

				It can be verified that the sum of the numbers on the diagonals is 101.

				What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			static int GetNumberSpiralDiagonalSum(int n)
			{
				// Initial value of the sum is 1 (accounting for the centre cell of the spiral, which contains the number 1)
				int sum = 1;

				// Work out from the centre of the spiral (in squares of increasing size)
				// For example, the first ieration (i == 1) will be a 3x3 square containing the numbers 2, 3, 4, 5, 6, 7, 8, and 9,
				// the second iteration (i == 2) will be a 5x5 square containing the numbers 10 to 25 inclusive, etc.
				foreach (int i in Enumerable.Range(1, n / 2))
				{
					// The values at each of the four corners of the current square are the values on the diagonals that we want to sum
					// (e.g. [7, 9, 5, and 3] for the first square; [21, 25, 17, and 13] for the second square).
					//
					// The value in the upper-right corner of the square at each iteration of i is (2i + 1)² - e.g. at iteration 1 (i == 1), the value in the upper-right corner is 3² (i.e. 9),
					// at iteration 2 (i == 2), the value in the upper-right corner is 5² (i.e. 25), etc.
					// So first we calculate (2i + 1)²
					int upperRightCornerValue = (2 * i + 1) * (2 * i + 1);

					// The values at the other three corners of the current square can be determined by subtracting multiples of i from the upperRightCornerValue
					// for example, for i == 1 (which has an upperRightCornerValue of 9), the upper-left corner value is 9 - 2i (i.e. 7); the lower-left corner value is 9 - 4i (i.e. 5), and
					// the lower-right corner value is 9 - 6i (i.e. 3)
					sum += upperRightCornerValue;				// Add the value of the upper-right corner cell to the sum
					sum += upperRightCornerValue - (2 * i);     // and add the value of the upper-left corner cell (i.e. upperRightCornerValue - 2i)
					sum += upperRightCornerValue - (4 * i);     // then the value of the lower-left corner cell (i.e. upperRightCornerValue - 4i)
					sum += upperRightCornerValue - (6 * i);     // and finally, the value of the lower-right corner cell (i.e. upperRightCornerValue - 6i)
				}
				return sum;
			}

			return GetNumberSpiralDiagonalSum(1001);
		}
	}
}
