using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using QuickType;
using System.Linq;

namespace emojiDump
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length != 1 || !File.Exists (args[0])) {
				Console.WriteLine ("mono emojiDump.exe emoji.json");
				System.Environment.Exit (1);
			}

			var emoji = Emoji.FromJson (File.ReadAllText (args[0]));

			Console.WriteLine ("static KeyValuePair<char, string>[] cannedPairs = new KeyValuePair<char, string>[] {");
			foreach (var e in emoji.Where (x => !string.IsNullOrWhiteSpace (x.EmojiEmoji)))
			{
				Console.WriteLine ($"new KeyValuePair<char, string> ('{e.EmojiEmoji}', \"{e.Description}\")");
			}
			Console.WriteLine ("};");
		}
	}
}
