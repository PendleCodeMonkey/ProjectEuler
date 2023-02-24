namespace PendleCodeMonkey.ProjectEulerCS.Data
{
	internal class Problem22Data
	{
		// Get the data for problem 22 as a list of strings.
		internal static List<string> GetData()
		{
			// Read the data into a string
			string data = File.ReadAllText(@"Resources\p022_names.txt");

			// Split the data into its comma-separated values, remove the quotes around the names, then order alphabetically.
			return data.Split(',')
				.Select(n => n.Replace("\"", ""))
				.OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
				.ToList();
		}
	}
}
