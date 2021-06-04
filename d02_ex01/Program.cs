using System;
using System.Collections.Generic;
using System.IO;

if (args.Length != 4 || !int.TryParse(args[1], out int i) || !int.TryParse(args[3], out int j)
    || !File.Exists(args[0]) || !File.Exists(args[2]))
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return 1;
}

List<IConfigurationSource> configs = new List<IConfigurationSource>();

IConfigurationSource yaml;
try
{
    yaml = new YamlSource(args[2], int.Parse(args[3]));
}
catch
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return 1;
}

configs.Add(yaml);
IConfigurationSource json;
try
{
    json = new JsonSource(args[0], int.Parse(args[1]));
}
catch
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return 1;
}

configs.Add(json);
Configuration config = new Configuration(configs);
Console.WriteLine("Configuration");
foreach (var param in config.Params)
{
    Console.WriteLine($"{param.Key}: {param.Value}");
}
return 0;
