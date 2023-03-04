namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem27
	{

		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 27 - Quadratic primes


				Euler discovered the remarkable quadratic formula:
						n² + n + 41

				It turns out that the formula will produce 40 primes for the consecutive integer values 0 <= n <= 39
				However, when n = 40, 40² + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.

				The incredible formula n² - 79n + 1601 was discovered, which produces 80 primes for the consecutive values 0 <= n <= 79
				The product of the coefficients, −79 and 1601, is −126479.

				Considering quadratics of the form:
					n² + an + b, where |a| < 1000 and |b| <= 1000
						where |n| is the modulus/absolute value of n
						e.g. |11| = 11 and |-4| = 4
				Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that determines the number of consecutive prime number results that the quadratic expression n² + an + b evaluates to.
			static int NumberOfConsecutivePrimes(int a, int b)
			{
				// Local function to determine if the specified value is a prime number.
				static bool IsPrime(int num) => num > 1 && !Enumerable.Range(2, (int)Math.Sqrt(num) - 1).Any(i => num % i == 0);

				// Local function to calculate n² + an + b and return the result.
				static int SolveQuadratic(int n, int a, int b) => (n * n) + (a * n) + b;

				int n = 0;

				// Keep looping while the result of the quadratic expression n² + an + b yields a result that is a prime number.
				while (IsPrime(SolveQuadratic(n, a, b)))
				{
					n++;
				}

				return n;
			}

			int coeffProduct = 0;
			int maxPrimes = 0;

			// |a| < 1000 (i.e. a in range -999 to 999)
			for (int a = -999; a < 1000; a++)
			{
				// |b| <= 1000 (i.e. b in range -1000 to 1000)
				for (int b = -1000; b <= 1000; b++)
				{
					int numPrimes = NumberOfConsecutivePrimes(a, b);
					if (numPrimes > maxPrimes)
					{
						// New maximum number of consecutive primes
						maxPrimes = numPrimes;
						// Calculate the product of the coefficients a and b
						coeffProduct = a * b;
					}
				}
			}

			return coeffProduct;
		}
	}
}
