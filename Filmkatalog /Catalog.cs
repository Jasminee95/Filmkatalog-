namespace Filmkatalog;

public class Catalog
{
    public List<Movie> Movies { get; private set; }
 
    public Catalog()
    {
        Movies = new List<Movie>();
    }

    public void AddMovie(Movie movie)
    {
        if (movie != null)
        {
            if (Movies.Any(m => m.Title.Equals(movie.Title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"The movie with the title {movie.Title} already exists!");
            }
            else
            {
                Movies.Add(movie);
                Console.WriteLine($"The movie with the title {movie.Title} has been added!");
            }
        }
        else
        {
            Console.WriteLine("Cannot add empty movie object!");
        }
    }

    public List<Movie> FindMovieOverLength(int minLength)
    {
        if (minLength < 0)
        {
            Console.WriteLine("Minimal length cannot be less than zero!");
            return new List<Movie>();
        }
        
        var foundMovies = Movies.Where(m => m.Length > minLength).ToList();

        if (foundMovies.Count == 0)
        {
            Console.WriteLine($"Could not find any movies longer then {minLength} minutes!");
        }
        else
        {
            Console.WriteLine($"\n**** Movies longer then {minLength} minutes ****");
            foreach (var movie in foundMovies)
            {
                movie.PrintMovieInfo();
            }
        }
        return foundMovies;
    }

    public List<Movie> FindMovieByGenre(string genre)
    {
        if (string.IsNullOrWhiteSpace(genre))
        {
            Console.WriteLine("Genre cannot be empty!");
            return new List<Movie>();
        }
        var foundMovies = Movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundMovies.Count == 0)
        {
            Console.WriteLine($"Could not find any movies with the genre {genre}!");
        }
        else
        {
            Console.WriteLine($"**** Movies found with the genre {genre} ****");
            foreach (var movie in foundMovies)
            {
                movie.PrintMovieInfo();
            }
        }
        return foundMovies;
    }

    public void PrintAllMoviesSortedByTitle()
    {
        if (!Movies.Any())
        {
            Console.WriteLine("The catalog contains no movies!");
            return;
        }
        
        Movies.Sort();

        Console.WriteLine("\n**** All movies (sorted by title) ****");
        foreach (var movie in Movies)
        {
            movie.PrintMovieInfo();
        }
    }

    public void SetMovieRating(string title, int rating)
    {
        Movie movieToRate = Movies.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (movieToRate != null)
        {
            movieToRate.Rating = rating;
            Console.WriteLine($"The movie '{movieToRate.Title}' has been rating to {movieToRate.Rating}/10");
        }
        else
        {
            Console.WriteLine($"Could not find any movie with the title {title}!");
        }
    }

    public List<Movie> FindTop3RatedMovies()
    {
        if (!Movies.Any(m => m.Rating > 0))
        {
            Console.WriteLine("No movies has been rated yet!");
            return new List<Movie>();
        }
        
        var topMovies = Movies
            .OrderByDescending(m => m.Rating)
            .ThenBy(m => m.Title)
            .Take(3)
            .ToList();

        Console.WriteLine("\n**** Top 3 rated movies ****");
        if (topMovies.Count == 0)
        {
            Console.WriteLine("No movies to show in top 3 rated movies!");
        }
        else
        {
            foreach (var movie in topMovies)
            {
                movie.PrintMovieInfo();
            }
        }
        return topMovies;
    }

    public void PrintAllMovies()
    {
        if (!Movies.Any())
        {
            Console.WriteLine("The catalog contains no movies!");
            return;
        }

        Console.WriteLine("\n**** All movies in the catalog ****");
        foreach (var movie in Movies)
        {
            movie.PrintMovieInfo();
        }
    }
}
