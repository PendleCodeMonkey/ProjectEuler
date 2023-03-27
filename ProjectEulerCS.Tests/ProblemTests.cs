namespace PendleCodeMonkey.ProjectEulerCS.Tests
{
	public class ProblemTests
	{
		[Fact]
		public void Problem1Test()
		{
			int result = Problem1.Solve();

			Assert.Equal(233168, result);
		}

		[Fact]
		public void Problem2Test()
		{
			int result = Problem2.Solve();

			Assert.Equal(4613732, result);
		}

		[Fact]
		public void Problem3Test()
		{
			long result = Problem3.Solve();
			long result2 = Problem3.Solve2();       // Uses an alternative algorithm for calculating the prime factors.

			Assert.Equal(6857, result);
			Assert.Equal(6857, result2);
		}

		[Fact]
		public void Problem4Test()
		{
			int result = Problem4.Solve();

			Assert.Equal(906609, result);
		}

		[Fact]
		public void Problem5Test()
		{
			int result = Problem5.Solve();

			Assert.Equal(232792560, result);
		}

		[Fact]
		public void Problem6Test()
		{
			int result = Problem6.Solve();

			Assert.Equal(25164150, result);
		}

		[Fact]
		public void Problem7Test()
		{
			long result = Problem7.Solve();

			Assert.Equal(104743, result);
		}

		[Fact]
		public void Problem8Test()
		{
			long result = Problem8.Solve();

			Assert.Equal(23514624000, result);
		}

		[Fact]
		public void Problem9Test()
		{
			long result = Problem9.Solve();

			Assert.Equal(31875000, result);
		}

		[Fact]
		public void Problem10Test()
		{
			long result = Problem10.Solve();

			Assert.Equal(142913828922, result);
		}

		[Fact]
		public void Problem11Test()
		{
			long result = Problem11.Solve();

			Assert.Equal(70600674, result);
		}

		[Fact]
		public void Problem12Test()
		{
			int result = Problem12.Solve();

			Assert.Equal(76576500, result);
		}

		[Fact]
		public void Problem13Test()
		{
			string result = Problem13.Solve();

			Assert.Equal("5537376230", result);
		}

		[Fact]
		public void Problem14Test()
		{
			int result = Problem14.Solve();

			Assert.Equal(837799, result);
		}

		[Fact]
		public void Problem15Test()
		{
			long result = Problem15.Solve();

			Assert.Equal(137846528820, result);
		}

		[Fact]
		public void Problem16Test()
		{
			int result = Problem16.Solve();

			Assert.Equal(1366, result);
		}

		[Fact]
		public void Problem17Test()
		{
			int result = Problem17.Solve();

			Assert.Equal(21124, result);
		}

		[Fact]
		public void Problem18Test()
		{
			int result = Problem18.Solve();

			Assert.Equal(1074, result);
		}

		[Fact]
		public void Problem19Test()
		{
			int result = Problem19.Solve();

			Assert.Equal(171, result);
		}

		[Fact]
		public void Problem20Test()
		{
			int result = Problem20.Solve();

			Assert.Equal(648, result);
		}

		[Fact]
		public void Problem21Test()
		{
			int result = Problem21.Solve();

			Assert.Equal(31626, result);
		}

		[Fact]
		public void Problem22Test()
		{
			int result = Problem22.Solve();

			Assert.Equal(871198282, result);
		}

		[Fact]
		public void Problem23Test()
		{
			int result = Problem23.Solve();

			Assert.Equal(4179871, result);
		}

		[Fact]
		public void Problem24Test()
		{
			string result = Problem24.Solve();
			string result2 = Problem24.Solve2();        // Uses an alternative approach to solving the problem.

			Assert.Equal("2783915460", result);
			Assert.Equal("2783915460", result2);
		}

		[Fact]
		public void Problem25Test()
		{
			int result = Problem25.Solve();

			Assert.Equal(4782, result);
		}

		[Fact]
		public void Problem26Test()
		{
			int result = Problem26.Solve();

			Assert.Equal(983, result);
		}

		[Fact]
		public void Problem27Test()
		{
			int result = Problem27.Solve();

			Assert.Equal(-59231, result);
		}

		[Fact]
		public void Problem28Test()
		{
			int result = Problem28.Solve();

			Assert.Equal(669171001, result);
		}

		[Fact]
		public void Problem29Test()
		{
			int result = Problem29.Solve();

			Assert.Equal(9183, result);
		}

		[Fact]
		public void Problem30Test()
		{
			int result = Problem30.Solve();

			Assert.Equal(443839, result);
		}

		[Fact]
		public void Problem31Test()
		{
			int result = Problem31.Solve();

			Assert.Equal(73682, result);
		}

		[Fact]
		public void Problem32Test()
		{
			int result = Problem32.Solve();

			Assert.Equal(45228, result);
		}

		[Fact]
		public void Problem33Test()
		{
			int result = Problem33.Solve();

			Assert.Equal(100, result);
		}

		[Fact]
		public void Problem34Test()
		{
			int result = Problem34.Solve();

			Assert.Equal(40730, result);
		}

		[Fact]
		public void Problem35Test()
		{
			int result = Problem35.Solve();

			Assert.Equal(55, result);
		}

		[Fact]
		public void Problem36Test()
		{
			int result = Problem36.Solve();

			Assert.Equal(872187, result);
		}

		[Fact]
		public void Problem37Test()
		{
			int result = Problem37.Solve();

			Assert.Equal(748317, result);
		}

		[Fact]
		public void Problem38Test()
		{
			int result = Problem38.Solve();

			Assert.Equal(932718654, result);
		}

		[Fact]
		public void Problem39Test()
		{
			int result = Problem39.Solve();

			Assert.Equal(840, result);
		}

		[Fact]
		public void Problem40Test()
		{
			int result = Problem40.Solve();

			Assert.Equal(210, result);
		}

		[Fact]
		public void Problem41Test()
		{
			int result = Problem41.Solve();

			Assert.Equal(7652413, result);
		}

		[Fact]
		public void Problem42Test()
		{
			int result = Problem42.Solve();

			Assert.Equal(162, result);
		}

		[Fact]
		public void Problem43Test()
		{
			long result = Problem43.Solve();        // Uses brute force method
			long result2 = Problem43.Solve2();      // Uses deductions to reduce the number of possibilities (to avoid using brute force)

			Assert.Equal(16695334890, result);
			Assert.Equal(16695334890, result2);
		}

		[Fact]
		public void Problem44Test()
		{
			long result = Problem44.Solve();        // Makes an assumption about the limit of the number of pentagonal numbers that need to be pre-calculated.
			long result2 = Problem44.Solve2();      // An alternative solution that makes no such assumption.

			Assert.Equal(5482660, result);
			Assert.Equal(5482660, result2);
		}

		[Fact]
		public void Problem45Test()
		{
			long result = Problem45.Solve();

			Assert.Equal(1533776805, result);
		}

		[Fact]
		public void Problem46Test()
		{
			long result = Problem46.Solve();

			Assert.Equal(5777, result);
		}

		[Fact]
		public void Problem47Test()
		{
			long result = Problem47.Solve();

			Assert.Equal(134043, result);
		}

		[Fact]
		public void Problem48Test()
		{
			string result = Problem48.Solve();

			Assert.Equal("9110846700", result);
		}

		[Fact]
		public void Problem49Test()
		{
			string result = Problem49.Solve();

			Assert.Equal("296962999629", result);
		}

		[Fact]
		public void Problem50Test()
		{
			long result = Problem50.Solve();

			Assert.Equal(997651, result);
		}

		[Fact]
		public void Problem51Test()
		{
			int result = Problem51.Solve();

			Assert.Equal(121313, result);
		}

		[Fact]
		public void Problem52Test()
		{
			long result = Problem52.Solve();

			Assert.Equal(142857, result);
		}

		[Fact]
		public void Problem53Test()
		{
			long result = Problem53.Solve();

			Assert.Equal(4075, result);
		}

		[Fact]
		public void Problem54Test()
		{
			int result = Problem54.Solve();

			Assert.Equal(376, result);
		}

		[Fact]
		public void Problem55Test()
		{
			int result = Problem55.Solve();

			Assert.Equal(249, result);
		}

		[Fact]
		public void Problem56Test()
		{
			int result = Problem56.Solve();

			Assert.Equal(972, result);
		}

		[Fact]
		public void Problem57Test()
		{
			int result = Problem57.Solve();

			Assert.Equal(153, result);
		}

		[Fact]
		public void Problem58Test()
		{
			int result = Problem58.Solve();

			Assert.Equal(26241, result);
		}

		[Fact]
		public void Problem59Test()
		{
			int result = Problem59.Solve();

			Assert.Equal(129448, result);
		}

		[Fact]
		public void Problem60Test()
		{
			long result = Problem60.Solve();

			Assert.Equal(26033, result);
		}

		[Fact]
		public void Problem61Test()
		{
			int result = Problem61.Solve();

			Assert.Equal(28684, result);
		}

		[Fact]
		public void Problem62Test()
		{
			long result = Problem62.Solve();

			Assert.Equal(127035954683, result);
		}

		[Fact]
		public void Problem63Test()
		{
			int result = Problem63.Solve();
			int result2 = Problem63.Solve2();		// Using an alternative solution

			Assert.Equal(49, result);
			Assert.Equal(49, result2);
		}

		[Fact]
		public void Problem64Test()
		{
			int result = Problem64.Solve();

			Assert.Equal(1322, result);
		}

		[Fact]
		public void Problem65Test()
		{
			int result = Problem65.Solve();

			Assert.Equal(272, result);
		}

		[Fact]
		public void Problem66Test()
		{
			int result = Problem66.Solve();

			Assert.Equal(661, result);
		}

		[Fact]
		public void Problem67Test()
		{
			int result = Problem67.Solve();

			Assert.Equal(7273, result);
		}

		[Fact]
		public void Problem68Test()
		{
			string result = Problem68.Solve();

			Assert.Equal("6531031914842725", result);
		}

		[Fact]
		public void Problem69Test()
		{
			int result = Problem69.Solve();

			Assert.Equal(510510, result);
		}

		[Fact]
		public void Problem70Test()
		{
			int result = Problem70.Solve();

			Assert.Equal(8319823, result);
		}

		[Fact]
		public void Problem71Test()
		{
			int result = Problem71.Solve();
			int result2 = Problem71.Solve2();		// An alternative solution

			Assert.Equal(428570, result);
			Assert.Equal(428570, result2);
		}

		[Fact]
		public void Problem72Test()
		{
			long result = Problem72.Solve();

			Assert.Equal(303963552391, result);
		}

		[Fact]
		public void Problem73Test()
		{
			int result = Problem73.Solve();

			Assert.Equal(7295372, result);
		}

		[Fact]
		public void Problem74Test()
		{
			int result = Problem74.Solve();

			Assert.Equal(402, result);
		}

		[Fact]
		public void Problem75Test()
		{
			int result = Problem75.Solve();

			Assert.Equal(161667, result);
		}

	}
}