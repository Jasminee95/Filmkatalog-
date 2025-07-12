namespace Filmkatalog;

public class MovieApp
{
    public Catalog MovieCatalog { get; private set; }

    public MovieApp()
    {
        MovieCatalog = new Catalog();
        
        MovieCatalog.AddMovie(new Movie("The Matrix", "Science Fiction", 136));
        MovieCatalog.AddMovie(new Movie("Inception", "Science Fiction", 148));
        MovieCatalog.AddMovie(new Movie("Pulp Fiction", "Crime", 154));
        MovieCatalog.AddMovie(new Movie("The Shawshank Redemption", "Drama", 142));
        MovieCatalog.AddMovie(new Movie("Forrest Gump", "Drama", 142));
        Console.WriteLine("\nWelcome to Movie Catalog!");
        Console.WriteLine("Some movies has been added to get started.\n");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        Console.Clear();
    }

    public void Run()
    {
        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine() ?? String.Empty;

            switch (choice)
            {
                case "1":
                  AddMoviePrompt();
                    break;
                case "2":
                    FindMovieOverLengthPrompt();
                    break;
                case "3":
                    SearchMoviesByGenrePrompt();
                    break;
                case "4":
                    MovieCatalog.PrintAllMoviesSortedByTitle();
                    break;
                case "5":
                    MovieCatalog.FindTop3RatedMovies();
                    break;
                case "6":
                    SetMovieRatingPrompt();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\nMovie catalog");
        Console.WriteLine("1. Add a new movie");
        Console.WriteLine("2. Find a movie based on length (longer then) in minutes");
        Console.WriteLine("3. Find movie based on genre");
        Console.WriteLine("4. Print all movies");
        Console.WriteLine("5. Show top 3 movies based on rating");
        Console.WriteLine("6. Rate a movie 1-10");
        Console.WriteLine("7. Exit the movie app");
        Console.Write("Choose an option ");
    }

    private void AddMoviePrompt()
    {
        Console.WriteLine("Write the title of the movie.");
        string title = Console.ReadLine();
        Console.WriteLine("Write the genre of the movie.");
        string genre = Console.ReadLine();
        Console.WriteLine("Write the lenght of the movie in minutes.");

        if (int.TryParse(Console.ReadLine(), out int length))
        {
            MovieCatalog.AddMovie(new Movie(title, genre, length));
        }
        else
        {
            Console.WriteLine("Invalid input. Write a valid number for minutes.");
        }
    }

    private void FindMovieOverLengthPrompt()
    {
        Console.WriteLine("Enter the minimum length (in minutes) of the movie you want to find.");
        if (int.TryParse(Console.ReadLine(), out var minLength))
        {
            MovieCatalog.FindMovieOverLength(minLength);
        }
        else
        {
            Console.WriteLine("Invalid input. Write a valid number for minutes.");
        }
    }

    private void SearchMoviesByGenrePrompt()
    {
        Console.WriteLine("Write the genre you want to search for");
        string genre = Console.ReadLine();
        MovieCatalog.FindMovieByGenre(genre);
    }

    private void SetMovieRatingPrompt()
    {
        Console.WriteLine("Write the title of the movie you want to rate.");
        string title = Console.ReadLine() ?? String.Empty;
        Console.Write("Write the rating (1-10):");

        if (int.TryParse(Console.ReadLine(), out int rating))
        {
            MovieCatalog.SetMovieRating(title, rating);
        }
        else
        {
            Console.WriteLine("Invalid input. Please write a number between 1 and 10.");
        }
    }
}
