using System.Collections.Generic;

public interface IConfigurationSource
{
    public int Priority { get; set; }
    public Dictionary<string, string> Params { get; set; }
}