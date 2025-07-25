namespace Filmkatalog;

public class Movie : IComparable<Movie>
{
    private string _title;
    private string _genre;
    private int _length;
    private int _rating;

    public Movie(string title, string genre, int length)
    {
        _title = title;
        _genre = genre;
        _length = length;
        _rating = 0;
    }
    public string Title => _title;
    public string Genre => _genre;
    public int Length => _length;

    public int Rating
    {
        get { return _rating; }
        set
        {
            if (value >= 0 && value <= 10)
            {
                _rating = value;
            }
            else
            {
                Console.WriteLine("The rating value must be between 0 and 10.");
            }
        }
    }

    public void PrintMovieInfo()
    {
        Console.WriteLine($"Title: {_title}, Genre: {_genre}, Length: {_length} min,  Rating: {Rating}/10");
    }

    public int CompareTo(Movie? other)
    {
        return string.Compare(this.Title, other?.Title, StringComparison.OrdinalIgnoreCase);
    }
}
