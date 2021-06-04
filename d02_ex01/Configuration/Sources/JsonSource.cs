using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonSource : IConfigurationSource
{
    public int Priority { get; set; }
    public Dictionary<string, string> Params { get; set; }

    public JsonSource(string pathToJson, int priority)
    {
        Params = new Dictionary<string, string>();
        string jsonFile = File.ReadAllText(pathToJson);
        var temp = JsonSerializer.Deserialize<Dictionary<string, Object>>(jsonFile);
        foreach (var key in temp.Keys)
            Params.Add(key, temp[key].ToString());
        Priority = priority;
    }
}