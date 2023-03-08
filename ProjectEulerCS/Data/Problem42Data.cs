namespace PendleCodeMonkey.ProjectEulerCS.Data
{
	internal class Problem42Data
	{
		// Get the data for problem 42 as a list of strings.
		internal static List<string> GetData()
		{
			// Read the data into a string
			string data = File.ReadAllText(@"Resources\p042_words.txt");

			// Split the data into its comma-separated values, remove the quotes around the words, then return them as a list of strings.
			return data.Split(',')
				.Select(n => n.Replace("\"", ""))
				.ToList();
		}
	}
}
