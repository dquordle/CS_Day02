using System;
using System.Collections.Generic;
using System.Linq;

public interface ISearchable
{
    string title { get; set; }
    Entertainment EntertainmentType { get; set; }

    public static IEnumerable<IGrouping<Entertainment, ISearchable>> Search(List<ISearchable> iSearchables, string searchText)
    {
        IEnumerable<IGrouping<Entertainment, ISearchable>> filtered;
        if (string.IsNullOrEmpty(searchText))
        {
            filtered =
                from iSearchable in iSearchables
                group iSearchable by iSearchable.EntertainmentType;
        }
        else
        {
            filtered =
                from iSearchable in iSearchables
                where iSearchable.title.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                group iSearchable by iSearchable.EntertainmentType;
        }

        return filtered;
    }
}

public enum Entertainment
{
    Book,
    Movie
}