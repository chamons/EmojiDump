using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace emojiDump
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length != 1 || !File.Exists (args[0])) {
				Console.WriteLine ("mono emojiDump.exe en.xml");
				System.Environment.Exit (1);
			}

			XmlDocument doc = new XmlDocument ();
			doc.Load (args[0]);

			Console.WriteLine ("static KeyValuePair<char, string>[] cannedPairs = new KeyValuePair<char, string>[] {");

			foreach (XmlNode n in doc.SelectNodes ("/ldml/annotations/*"))
				Console.WriteLine ($"new KeyValuePair<char, string> ('{n.Attributes[0].Value}', \"{n.InnerText}\")");

			Console.WriteLine ("};");
		}
	}
}
