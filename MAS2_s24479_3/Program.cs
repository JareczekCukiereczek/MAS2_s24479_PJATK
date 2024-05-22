using System;
using MAS2_s24479_3;

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie autorów
        Author author1 = new Author("J.K. Rowling", "Brytyjska autorka");
        Author author2 = new Author("J.R.R. Tolkien", "Brytyjski autor");

        // Tworzenie książek 
        
        Book book1 = new Book("Harry Potter i Kamień Filozoficzny");
        Book book2 = new Book("Hobbit");
        
        
        
        book1.setAuthor(author1);//asocjacja zwykła
        book2.setAuthor(author2);
        
        author1.setBook(book1);//asocjacja zwykła - poł.zwrotne
        

        // Tworzenie sekcji i dodawanie książek
        Section section1 = new Section("Fikcja");
        section1.AddBook(book1);
        section1.AddBook(book2);

        // Tworzenie biblioteki i dodawanie sekcji
        Library library = new Library("Biblioteka Miejska na Woli");
        library.AddSection(section1); // Kompozycja: Biblioteka składa się z Sekcji ale Sekcja jedna nie moze być w wielu bibliotekach
        
        // Weryfikacja przypisania sekcji do biblioteki
        Console.WriteLine($"Sekcja {section1.Name} jest częścią biblioteki: {section1.GetLibrary().Name}");


        // Tworzenie członków
        Member member1 = new Member("001", "Kuba");
        Member member2 = new Member("002", "Rafał");

        // Dodawanie członków do biblioteki
        library.AddMember(member1); // Kwalifikowana asocjacja: Członkowie są identyfikowani przez MembershipID
        library.AddMember(member2);
        
        Member foundMember1 = library.GetMemberByMembershipID("001");
        if (foundMember1 != null)
        {
            Console.WriteLine($"Znaleziono członka: {foundMember1.Name} z MembershipID: {foundMember1.MembershipID}");
        }

        Member foundMember2 = library.GetMemberByMembershipID("002");
        if (foundMember2 != null)
        {
            Console.WriteLine($"Znaleziono członka: {foundMember2.Name} z MembershipID: {foundMember2.MembershipID}");
        }

        Member notFoundMember = library.GetMemberByMembershipID("003");
        if (notFoundMember == null)
        {
            Console.WriteLine("Członek z MembershipID: 003 nie istnieje.");
        }

        // Tworzenie instancji wypożyczeń
        Borrow borrow1 = new Borrow(member1, book1, DateTime.Now); // Asocjacja z atrybutem: Wypożyczenie ma atrybut BorrowDate
        Borrow borrow2 = new Borrow(member2, book2, DateTime.Now);
        
        
        library.AddBorrow(borrow1);
        library.AddBorrow(borrow2);
        
        
        // Wyświetlanie informacji o wypożyczeniach
        Console.WriteLine($"{borrow1.Member.Name} wypożyczył(a) '{borrow1.Book.Title}' dnia {borrow1.BorrowDate}");
        Console.WriteLine($"{borrow2.Member.Name} wypożyczył(a) '{borrow2.Book.Title}' dnia {borrow2.BorrowDate}");
            
        Console.WriteLine("-------------------------------------------------------------------------");  
        // Wyświetlanie informacji o wypożyczeniach
        Console.WriteLine("\nWszystkie wypożyczenia w bibliotece:");
        library.ListAllBorrows();

        Console.WriteLine("\nWypożyczenia Kuby:");
        member1.ListBorrows();

        Console.WriteLine("\nWypożyczenia Rafała:");
        member2.ListBorrows();
        
        Console.WriteLine("-------------------------------------------------------------------------");  
        // Wypożyczenia w całej bibliotece
        Console.WriteLine("\nWypożyczenia w całej bibliotece:");
        library.ListAllBorrows();
        
    }
    
    
}
