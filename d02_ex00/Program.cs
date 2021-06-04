using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

{
    string jsonbooks = File.ReadAllText("/Users/dquordle/RiderProjects/d02/d02_ex00/example_files/book_reviews.json");
    string jsonmovies = File.ReadAllText("/Users/dquordle/RiderProjects/d02/d02_ex00/example_files/movie_reviews.json");
    BookRoot DeserializedBooks = JsonSerializer.Deserialize<BookRoot>(jsonbooks);
    MovieRoot DeserializedMovies = JsonSerializer.Deserialize<MovieRoot>(jsonmovies);
    
    List<ISearchable> iSearchables = new List<ISearchable>();
    
    foreach (var bookResult in DeserializedBooks.results)
        iSearchables.Add(new Book(bookResult));

    foreach (var movieResult in DeserializedMovies.results)
        iSearchables.Add(new Movie(movieResult));

    Console.WriteLine("Input search text:");
    string searchText = Console.ReadLine();

    var filtered = ISearchable.Search(iSearchables, searchText);
    
    if (filtered.Count() == 0)
        Console.WriteLine($"\nThere are no \"{searchText}\" in media today.");
    else
        Console.WriteLine($"\nItems found: {countElements(filtered)}");
    
    foreach (var res in filtered)
    {
        Console.WriteLine($"\n{res.Key} search result [{res.Count()}]");
        foreach (var result in res)
        {
            Console.WriteLine(result.ToString());
        }
    }
}



int countElements(IEnumerable<IGrouping<Entertainment, ISearchable>> filtered)
{
    int ret = 0;
    foreach (var res in filtered)
        ret += res.Count();
    return ret;
}
public class BookDetail
{
    public string title { get; set; }
    public string description { get; set; }
    public string author { get; set; }
}

public class BookResult
{
    public string list_name { get; set; }
    public int rank { get; set; }
    public string amazon_product_url { get; set; }
    public List<BookDetail> book_details { get; set; }
}

public class BookRoot
{
    public List<BookResult> results { get; set; }
}

public class Link
{
    public string url { get; set; }
}

public class MovieResult
{
    public string title { get; set; }
    public string mpaa_rating { get; set; }
    public int critics_pick { get; set; }
    public string summary_short { get; set; }
    public Link link { get; set; }
}

public class MovieRoot
{
    public List<MovieResult> results { get; set; }
}