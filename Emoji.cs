using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// Thanks https://app.quicktype.io/#l=cs&r=json2csharp
namespace QuickType
{
	public partial class Emoji
	{
		[JsonProperty ("emoji", NullValueHandling = NullValueHandling.Ignore)]
		public string EmojiEmoji { get; set; }

		[JsonProperty ("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty ("category", NullValueHandling = NullValueHandling.Ignore)]
		public Category? Category { get; set; }

		[JsonProperty ("aliases")]
		public string[] Aliases { get; set; }

		[JsonProperty ("tags")]
		public string[] Tags { get; set; }

		[JsonProperty ("unicode_version", NullValueHandling = NullValueHandling.Ignore)]
		public UnicodeVersion? UnicodeVersion { get; set; }

		[JsonProperty ("ios_version", NullValueHandling = NullValueHandling.Ignore)]
		public string IosVersion { get; set; }
	}

	public enum Category { Activity, Flags, Foods, Nature, Objects, People, Places, Symbols };

	public enum UnicodeVersion { Empty, The30, The32, The40, The41, The51, The52, The60, The61, The70, The80, The90 };

	public partial class Emoji
	{
		public static Emoji[] FromJson (string json) => JsonConvert.DeserializeObject<Emoji[]> (json, QuickType.Converter.Settings);
	}

	public static class Serialize
	{
		public static string ToJson (this Emoji[] self) => JsonConvert.SerializeObject (self, QuickType.Converter.Settings);
	}

	internal static class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters = {
				new CategoryConverter(),
				new UnicodeVersionConverter(),
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}

	internal class CategoryConverter : JsonConverter
	{
		public override bool CanConvert (Type t) => t == typeof (Category) || t == typeof (Category?);

		public override object ReadJson (JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string> (reader);
			switch (value) {
			case "Activity":
				return Category.Activity;
			case "Flags":
				return Category.Flags;
			case "Foods":
				return Category.Foods;
			case "Nature":
				return Category.Nature;
			case "Objects":
				return Category.Objects;
			case "People":
				return Category.People;
			case "Places":
				return Category.Places;
			case "Symbols":
				return Category.Symbols;
			}
			throw new Exception ("Cannot unmarshal type Category");
		}

		public override void WriteJson (JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			var value = (Category)untypedValue;
			switch (value) {
			case Category.Activity:
				serializer.Serialize (writer, "Activity"); return;
			case Category.Flags:
				serializer.Serialize (writer, "Flags"); return;
			case Category.Foods:
				serializer.Serialize (writer, "Foods"); return;
			case Category.Nature:
				serializer.Serialize (writer, "Nature"); return;
			case Category.Objects:
				serializer.Serialize (writer, "Objects"); return;
			case Category.People:
				serializer.Serialize (writer, "People"); return;
			case Category.Places:
				serializer.Serialize (writer, "Places"); return;
			case Category.Symbols:
				serializer.Serialize (writer, "Symbols"); return;
			}
			throw new Exception ("Cannot marshal type Category");
		}
	}

	internal class UnicodeVersionConverter : JsonConverter
	{
		public override bool CanConvert (Type t) => t == typeof (UnicodeVersion) || t == typeof (UnicodeVersion?);

		public override object ReadJson (JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string> (reader);
			switch (value) {
			case "":
				return UnicodeVersion.Empty;
			case "3.0":
				return UnicodeVersion.The30;
			case "3.2":
				return UnicodeVersion.The32;
			case "4.0":
				return UnicodeVersion.The40;
			case "4.1":
				return UnicodeVersion.The41;
			case "5.1":
				return UnicodeVersion.The51;
			case "5.2":
				return UnicodeVersion.The52;
			case "6.0":
				return UnicodeVersion.The60;
			case "6.1":
				return UnicodeVersion.The61;
			case "7.0":
				return UnicodeVersion.The70;
			case "8.0":
				return UnicodeVersion.The80;
			case "9.0":
				return UnicodeVersion.The90;
			}
			throw new Exception ("Cannot unmarshal type UnicodeVersion");
		}

		public override void WriteJson (JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			var value = (UnicodeVersion)untypedValue;
			switch (value) {
			case UnicodeVersion.Empty:
				serializer.Serialize (writer, ""); return;
			case UnicodeVersion.The30:
				serializer.Serialize (writer, "3.0"); return;
			case UnicodeVersion.The32:
				serializer.Serialize (writer, "3.2"); return;
			case UnicodeVersion.The40:
				serializer.Serialize (writer, "4.0"); return;
			case UnicodeVersion.The41:
				serializer.Serialize (writer, "4.1"); return;
			case UnicodeVersion.The51:
				serializer.Serialize (writer, "5.1"); return;
			case UnicodeVersion.The52:
				serializer.Serialize (writer, "5.2"); return;
			case UnicodeVersion.The60:
				serializer.Serialize (writer, "6.0"); return;
			case UnicodeVersion.The61:
				serializer.Serialize (writer, "6.1"); return;
			case UnicodeVersion.The70:
				serializer.Serialize (writer, "7.0"); return;
			case UnicodeVersion.The80:
				serializer.Serialize (writer, "8.0"); return;
			case UnicodeVersion.The90:
				serializer.Serialize (writer, "9.0"); return;
			}
			throw new Exception ("Cannot marshal type UnicodeVersion");
		}
	}
}