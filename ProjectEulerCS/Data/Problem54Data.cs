namespace PendleCodeMonkey.ProjectEulerCS.Data
{
	internal class Problem54Data
	{
		// Get the data for problem 54 as a list of strings.
		internal static List<string> GetData()
		{
			// Read the data into a string
			string data = File.ReadAllText(@"Resources\p054_poker.txt");

			// Split the data into its newline-separated values, removing any empty strings, returning them as a list of strings.
			return data.Split('\n')
				.Where(n => n.Length > 0)
				.ToList();
		}
	}
}
