namespace MAS2_s24479_3;

public class Author
{
    public string Name { get; set; }
    public string Biography { get; set; }
    public Book Book;
    
    private List<Book> books;

    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
        books = new List<Book>();
    }

    public void setBook(Book book)
    {
        books.Add(book);
    }
    public IEnumerable<Book> GetBooks()
    {
        return books;
    }
}
