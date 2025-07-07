namespace Filmkatalog;

public class Catalog
{
    public List<Movie> Movies { get; private set; }
 
    public Catalog()
    {
        Movies = new List<Movie>();
    }
    
}


// Oppgave 5: Filmkatalog
// Lag et program som administrerer en katalog med filmer.
// Movie (tittel, sjanger, varighet i minutter)
// Catalog (liste over filmer)
// Legg til filmer i katalogen
// Finn filmer over en viss lengde
// Søk etter filmer i en bestemt sjanger
// Skriv ut alle filmene sortert etter tittel (bruk List.Sort() og IComparable)
// La brukeren rangere filmene (0–10) og vis topp 3.