using System.Text;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem40
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 40 - Champernowne's constant


				An irrational decimal fraction is created by concatenating the positive integers:

					0.123456789101112131415161718192021...

				It can be seen that the 12th digit of the fractional part is 1.

				If dₙ represents the nth digit of the fractional part, find the value of the following expression.

					d₁ × d₁₀ × d₁₀₀ × d₁₀₀₀ × d₁₀₀₀₀ × d₁₀₀₀₀₀ × d₁₀₀₀₀₀₀

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			StringBuilder sb = new();
			for (int num = 1; sb.Length < 1000000; num++)
			{
				sb.Append(num);
			}

			List<int> digitIndices = new() { 1, 10, 100, 1000, 10000, 100000, 1000000 };
			int result = 1;
			foreach (int index in digitIndices)
			{
				result *= sb[index - 1] - '0';
			}

			return result;
		}
	}
}
