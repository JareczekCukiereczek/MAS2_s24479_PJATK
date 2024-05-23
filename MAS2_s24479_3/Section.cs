namespace MAS2_s24479_3;

public class Section
{
    public string Name { get; set; }
    private List<Book> Books { get; set; }
    
    private Library _library;
    private List<Library> libraries { get; set; } // Kompozycja - biblioteka składa się z wielu sekcji, a sekcje nie mogą istnieć bez biblioteki.
    
    
    private List<Book> books;
    
    
    private Section(string name)
    {
        Name = name;
        Books = new List<Book>();
    }

    
    public void AddBook(Book book)
    {
        if (!Books.Contains(book))
        {
            Books.Add(book);
            Console.WriteLine($"Książka '{book.Title}' została dodana do sekcji {Name}");
        }
    }
    public void RemoveBook(Book book)
    {
        if (Books.Contains(book))
        {
            Books.Remove(book);
            Console.WriteLine($"Książka '{book.Title}' została usunięta z sekcji {Name}");
        }
    }
    public void SetLibrary(Library library)
    {
        _library = library;
    }

    public static void createSection(Library library,string name)
    {
        if (library == null)
        {
            throw new Exception("The given whole doesn't exist");
        }

        Section section = new Section(name);
        library.AddSection(section);
        section.SetLibrary(library);
        
    }

    public Library GetLibrary()
    {
        return _library;
    }
    
    public IEnumerable<Book> GetBooks()
    {
        return books;
    }
    
}
