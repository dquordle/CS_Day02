public class Movie : ISearchable
{
    public string title { get; set; }
    public Entertainment EntertainmentType { get; set; }
    public string Rating { get; set; }
    public int IsCriticsPick { get; set; }
    public string SummaryShort { get; set; }
    public string Url { get; set; }

    public Movie(MovieResult movieResult)
    {
        title = movieResult.title;
        EntertainmentType = Entertainment.Movie;
        Rating = movieResult.mpaa_rating;
        Url = movieResult.link.url;
        SummaryShort = movieResult.summary_short;
        IsCriticsPick = movieResult.critics_pick;
    }

    public override string ToString()
    {
        string ret = $"{title}";
        if (IsCriticsPick == 1)
            ret += $"[NYT critic’s pick]";
        ret += $"\n{SummaryShort}\n{Url}";
        return ret;
    }
}