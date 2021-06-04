using System.Collections.Generic;
using System.IO;

public class YamlSource : IConfigurationSource
{
    public int Priority { get; set; }
    public Dictionary<string, string> Params { get; set; }

    public YamlSource(string pathToFile, int priority)
    {
        string yamlFile = File.ReadAllText(pathToFile);
        var yamlDeserializer = new YamlDotNet.Serialization.DeserializerBuilder().Build();
        Params = yamlDeserializer.Deserialize<Dictionary<string, string>>(yamlFile);
        Priority = priority;
    }
}