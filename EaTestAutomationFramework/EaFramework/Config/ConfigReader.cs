using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EaFramework.Config;
/**
 * Class to read the configuration file
 */
public class ConfigReader
{
	private static readonly string FILE_NAME = "appsettings.json";

	public static TestSettings ReadConfig()
	{
		//Easy way to Read a JSON File
		Console.WriteLine("Reading the configuration file");
		var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" + FILE_NAME);
		var jsonSerializeOptions = new JsonSerializerOptions()
		{
			PropertyNameCaseInsensitive = true
		};

		jsonSerializeOptions.Converters.Add(new JsonStringEnumConverter());

		return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializeOptions);

	}
}

