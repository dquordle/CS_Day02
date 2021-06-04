using System.Collections.Generic;

public class Configuration
{
    public Dictionary<string, string> Params { get; set; }

    public Configuration(List<IConfigurationSource> configs)
    {
        configs.Sort(delegate(IConfigurationSource X, IConfigurationSource Y)
        {
            if (X.Priority >= Y.Priority)
                return -1;
            return 1;
        });
        Params = new Dictionary<string, string>();
        foreach (var conf in configs)
        {
            foreach (var key in conf.Params.Keys)
            {
                if (!Params.ContainsKey(key))
                    Params.Add(key, conf.Params[key]);
            }
        }
    }
}