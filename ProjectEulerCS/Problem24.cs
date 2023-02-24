namespace PendleCodeMonkey.ProjectEulerCS
{

	internal class Problem24
	{
		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 24 - Lexicographic permutations


				A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
				If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

					012   021   102   120   201   210

				What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal string Solve()
		{

			static IEnumerable<T[]> GetPermutations<T>(IEnumerable<T> remainder, IEnumerable<T> prefix) =>
				!remainder.Any() ? new[] { prefix.ToArray() } :
									remainder.SelectMany((c, i) =>
										GetPermutations(remainder.Take(i).Concat(remainder.Skip(i + 1)).ToArray(), prefix.Append(c)));


			string str = "0123456789";

			// Get a sequence containing the permutations of the string, skip the first 999999 of them, then return the first of the remaining sequence
			// (which will be the millionth permutation)
			return GetPermutations(str.AsEnumerable(), Enumerable.Empty<char>())
				.Select(a => new string(a))
				.Skip(999999)
				.First();
		}



		/*

		An alternative approach - using Factoradic method (see https://www.geeksforgeeks.org/find-the-n-th-lexicographic-permutation-of-string-using-factoradic-method/)

		The idea is to use the concept of factoradic representation.
		The main concept of factoradic method is to calculate the sequence of a number.
		The following are the steps to find the N-th lexicographic permutation using factoradic method: 

			1) Decrement N by 1 because this method considers sorted order as the 0th permutation.
			2) Divide N with 1 to the length of the string and each time store the remainder in a stack while updating the value of N as N/i.
			3) The calculated remainder in every step is the factoradic number. So, after calculating the final factoradic representation, start appending
			   the element in the result string which is present on the position.
			4) Remove the element from the stack on each iteration.
			5) Repeat the above three steps until the stack becomes empty.

		*/

		static internal string Solve2()
		{
			string str = "0123456789";  // String containing the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9.
			int n = 1000000;			// The permutation we want to obtain (i.e. the millionth)

			// Create an empty stack to work with.
			Stack<int> s = new();

			// Decrement n by 1 because this method considers the sorted order as the 0'th permutation.
			n--;

			// Divide N with 1 to the length of the string and each time store the remainder in a stack while updating the value of N as N/i.
			for (int i = 1; i < str.Length + 1; i++)
			{
				// Push the remainder of n/i to the stack
				s.Push(n % i);
				// and divide n by i.
				n /= i;
			}

			string res = string.Empty;

			// Repeat until the stack becomes empty (which will loop until the n'th permutation has been generated).
			while (s.Count > 0)
			{
				// Pop a remainder value from the stack
				int a = s.Pop();

				// Add the character at this position to the result string.
				res += str[a];

				int i;
				// Remove 1-element in each cycle
				for (i = a; i < str.Length - 1; i++)
				{
					str = str[..i] + str[i + 1] + str[(i + 1)..];
				}
				str = str[..(i + 1)];
			}

			// Return the result (which will be a string containing the millionth lexicographic permutation)
			return res;
		}
	}
}
