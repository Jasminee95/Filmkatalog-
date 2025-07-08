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
        
    }

    private void FindMovieOverLengthPrompt()
    {
        
    }

    private void SearchMoviesByGenrePrompt()
    {
        
    }

    private void SetMovieRatingPrompt()
    {
        
    }
}
