using PendleCodeMonkey.ProjectEulerCS;

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
			long result2 = Problem3.Solve2();		// Uses an alternative algorithm for calculating the prime factors.

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
			string result2 = Problem24.Solve2();		// Uses an alternative approach to solving the problem.

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

	}
}