using PendleCodeMonkey.ProjectEulerCS.Data;

namespace PendleCodeMonkey.ProjectEulerCS
{
	internal class Problem59
	{


		/* -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			Problem 59 - XOR decryption


				Each character on a computer is assigned a unique code and the preferred standard is ASCII (American Standard Code for Information Interchange).
				For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.

				A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key.
				The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text;
				for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.

				For unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes. The user would keep
				the encrypted message and the encryption key in different locations, and without both "halves", it is impossible to decrypt the message.

				Unfortunately, this method is impractical for most users, so the modified method is to use a password as a key. If the password is shorter
				than the message, which is likely, the key is repeated cyclically throughout the message. The balance for this method is using a sufficiently
				long password key for security, but short enough to be memorable.

				Your task has been made easy, as the encryption key consists of three lower case characters. Using p059_cipher.txt, a file containing the
				encrypted ASCII codes, and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the
				ASCII values in the original text.

		----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- */

		static internal int Solve()
		{
			// Local function that applies the XOR decryption to the supplied data, using the specified 3 letter key string.
			static char[] XORDecrypt(char[] data, string key)
			{
				// Make a copy of the input data
				char[] dataCopy = data.ToArray();

				// XOR the characters in the data with those in the key (cycling through the characters in the key as required)
				for (int i = 0; i < data.Length; i++)
				{
					dataCopy[i] ^= key[i % key.Length];
				}

				// Return the decrypted data.
				return dataCopy;
			}

			// Local function that is called as an additional check of the decrypted data (to make sure it
			// does actually contain occurrences of some common English words)
			static bool ContainsCommonWords(char[] data)
			{
				string[] commonWords = new string[] { "a", "an", "and", "it", "the" };
				// Convert the data to lower case text.
				string sData = new string(data).ToLower();
				// Extract each individual word (by splitting on space characters)
				string[] strings = sData.Split(' ');

				// Check if any of the words extracted from the text are the common words
				int validStrCount = 0;
				foreach (string str in strings)
				{
					if (commonWords.Contains(str))
					{
						validStrCount++;
					}
				}

				// 20 is an arbitrarily chosen value - just assuming that the proper decrypted text will contain at least 20 occurrences
				// of five very common English words ("a", "an", "and", "it", and "the").
				return validStrCount > 20;
			}

			// read the data from the p059_cipher.txt file into a char array.
			var cipherData = Problem59Data.GetData();

			// Generate all 17576 combinations of 3 lower-case letters (which will be all the keys we will try to decrypt the data with)
			var lowerCaseAlpha = "abcdefghijklmnopqrstuvwxyz".ToArray();
			List<string> keys = (
				from ch1 in lowerCaseAlpha
				from ch2 in lowerCaseAlpha
				from ch3 in lowerCaseAlpha
				select new string(new char[] { ch1, ch2, ch3 })
			).ToList();

			// We will use the number of space characters in the decrypted data to decide which looks most likely to be valid text (as
			// valid English text contains a significant number of spaces)
			int maxNumSpaces = 0;
			string bestKey = "";

			// Try to decrypt the data using each key combination, searching for the one that looks most likely to be
			// the valid key to decrypt the data.
			foreach (string key in keys)
			{
				// Decrypt the data using this key
				var decrypted = XORDecrypt(cipherData, key);
				// Count the number of space characters in the decrypted data.
				var numSpaces = decrypted.Count(x => x == ' ');
				// If this exceeds the current maximum then we have a good candidate.
				if (numSpaces > maxNumSpaces)
				{
					// This key combination produces text with the most space characters (so far), so check for the
					// presence of some common English words as an additional validity check.
					if (ContainsCommonWords(decrypted))
					{
						maxNumSpaces = numSpaces;
						bestKey = key;
					}
				}
			}

			// Decrypt the data using the best key we have found.
			var decryptData = XORDecrypt(cipherData, bestKey);

			// Sum the ASCII codes in the decrypted text to give us our answer.
			return decryptData.Select(x => (int)x).Sum();
		}
	}
}
