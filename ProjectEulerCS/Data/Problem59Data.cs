namespace PendleCodeMonkey.ProjectEulerCS.Data
{
	internal class Problem59Data
	{
		// Get the data for problem 59 as an array of chars.
		internal static char[] GetData()
		{
			// Read the data into a string
			string data = File.ReadAllText(@"Resources\p059_cipher.txt");

			// Split the data into its comma-separated values, returning as an array of chars.
			return data.Split(',')
				.Select(x => Convert.ToChar(int.Parse(x))).ToArray();
		}
	}
}
