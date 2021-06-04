public class Book : ISearchable
{
    public string title { get; set; }
    public Entertainment EntertainmentType { get; set; }
    public string Author { get; set; }
    public string SummaryShort { get; set; }
    public int Rank { get; set; }
    public string ListName { get; set; }
    public string Url { get; set; }

    public Book(BookResult bookResult)
    {
        title = bookResult.book_details[0].title;
        EntertainmentType = Entertainment.Book;
        Author = bookResult.book_details[0].author;
        Rank = bookResult.rank;
        ListName = bookResult.list_name;
        SummaryShort = bookResult.book_details[0].description;
        Url = bookResult.amazon_product_url;
    }

    public override string ToString()
    {
        return $"{title} by {Author} [{Rank} on NYT's {ListName}]\n{SummaryShort}\n{Url}";
    }
}   