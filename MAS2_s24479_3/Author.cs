namespace MAS2_s24479_3;

public class Author
{
    public string Name { get; set; }
    public string Biography { get; set; }
    private Book Book;
    
    private List<Book> books;

    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
        books = new List<Book>();
    }

    public void setBook(Book book)
    {
        if (books.Contains(book))
        {
            return;
        }
        books.Add(book);
        book.setAuthor(this);
    }
    public IEnumerable<Book> GetBooks()
    {
        return books;
    }
}
