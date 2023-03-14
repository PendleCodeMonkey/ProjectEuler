// See https://aka.ms/new-console-template for more information
using PendleCodeMonkey.ProjectEulerCS;
using System.Diagnostics;

Console.WriteLine("Project Euler problem solver.");
Console.WriteLine();

RunAndTimeOperation(Problem1.Solve, 1);
RunAndTimeOperation(Problem2.Solve, 2);
RunAndTimeOperation(Problem3.Solve, 3);
RunAndTimeOperation(Problem4.Solve, 4);
RunAndTimeOperation(Problem5.Solve, 5);
RunAndTimeOperation(Problem6.Solve, 6);
RunAndTimeOperation(Problem7.Solve, 7);
RunAndTimeOperation(Problem8.Solve, 8);
RunAndTimeOperation(Problem9.Solve, 9);
RunAndTimeOperation(Problem10.Solve, 10);
RunAndTimeOperation(Problem11.Solve, 11);
RunAndTimeOperation(Problem12.Solve, 12);
RunAndTimeOperation(Problem13.Solve, 13);
RunAndTimeOperation(Problem14.Solve, 14);
RunAndTimeOperation(Problem15.Solve, 15);
RunAndTimeOperation(Problem16.Solve, 16);
RunAndTimeOperation(Problem17.Solve, 17);
RunAndTimeOperation(Problem18.Solve, 18);
RunAndTimeOperation(Problem19.Solve, 19);
RunAndTimeOperation(Problem20.Solve, 20);
RunAndTimeOperation(Problem21.Solve, 21);
RunAndTimeOperation(Problem22.Solve, 22);
RunAndTimeOperation(Problem23.Solve, 23);
RunAndTimeOperation(Problem24.Solve, 24);
RunAndTimeOperation(Problem25.Solve, 25);
RunAndTimeOperation(Problem26.Solve, 26);
RunAndTimeOperation(Problem27.Solve, 27);
RunAndTimeOperation(Problem28.Solve, 28);
RunAndTimeOperation(Problem29.Solve, 29);
RunAndTimeOperation(Problem30.Solve, 30);
RunAndTimeOperation(Problem31.Solve, 31);
RunAndTimeOperation(Problem32.Solve, 32);
RunAndTimeOperation(Problem33.Solve, 33);
RunAndTimeOperation(Problem34.Solve, 34);
RunAndTimeOperation(Problem35.Solve, 35);
RunAndTimeOperation(Problem36.Solve, 36);
RunAndTimeOperation(Problem37.Solve, 37);
RunAndTimeOperation(Problem38.Solve, 38);
RunAndTimeOperation(Problem39.Solve, 39);
RunAndTimeOperation(Problem40.Solve, 40);
RunAndTimeOperation(Problem41.Solve, 41);
RunAndTimeOperation(Problem42.Solve, 42);
RunAndTimeOperation(Problem43.Solve, 43);
RunAndTimeOperation(Problem44.Solve, 44);
RunAndTimeOperation(Problem45.Solve, 45);
RunAndTimeOperation(Problem46.Solve, 46);
RunAndTimeOperation(Problem47.Solve, 47);
RunAndTimeOperation(Problem48.Solve, 48);
RunAndTimeOperation(Problem49.Solve, 49);
RunAndTimeOperation(Problem50.Solve, 50);
RunAndTimeOperation(Problem51.Solve, 51);
RunAndTimeOperation(Problem52.Solve, 52);
RunAndTimeOperation(Problem53.Solve, 53);
RunAndTimeOperation(Problem54.Solve, 54);
RunAndTimeOperation(Problem55.Solve, 55);
RunAndTimeOperation(Problem56.Solve, 56);
RunAndTimeOperation(Problem57.Solve, 57);
RunAndTimeOperation(Problem58.Solve, 58);
RunAndTimeOperation(Problem59.Solve, 59);
RunAndTimeOperation(Problem60.Solve, 60);


Console.WriteLine();
Console.WriteLine("All done!   Press any key.");

Console.ReadKey();


// Local method that runs the specified function and uses a Stopwatch to time its
// operation, outputting the results to the console window.
static void RunAndTimeOperation<T>(Func<T> op, int probNumber)
{
	// Create and start a stopwatch
	Stopwatch stopWatch = new();
	stopWatch.Start();
	// Run the specified function
	T result = op();
	// Stop the stopwatch
	stopWatch.Stop();
	// Obtain the number of milliseconds that elapsed whilst the function was executing.
	TimeSpan ts = stopWatch.Elapsed;
	double msTime = ts.TotalMilliseconds;
	// Output the results to the console.
	Console.WriteLine($"Problem {probNumber} - {result}  ({msTime} ms)");
}
