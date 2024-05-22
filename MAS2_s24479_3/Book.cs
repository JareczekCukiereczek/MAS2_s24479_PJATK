namespace MAS2_s24479_3;

using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; } // Zwykła asocjacja
    public List<Borrow> Borrows { get; set; } // Lista wypożyczeń
    
    //dodać listę borrow 

    public Book(string title)
    {
        Title = title;
        Borrows = new List<Borrow>(); // Inicjalizacja listy wypożyczeń
        
    }

    public void setAuthor(Author author)
    {
        Author = author;
    }
}
