namespace PendleCodeMonkey.ProjectEulerCS.Data
{
	internal class Problem67Data
	{
		// Get the data for problem 67 as a list of strings.
		internal static List<List<int>> GetData()
		{
			// Read the data into a string
			string data = File.ReadAllText(@"Resources\p067_triangle.txt");

			List<List<int>> rows = new();
			string[] lines = data.Split('\n');
			foreach (var line in lines)
			{
				if (line.Trim().Length == 0) continue;
				var rowData = line.Split(' ')
					.Select(x => int.Parse(x))
					.ToList();

				rows.Add(rowData);
			}

			return rows;
		}
	}
}
