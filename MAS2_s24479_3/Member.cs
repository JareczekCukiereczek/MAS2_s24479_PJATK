namespace MAS2_s24479_3;

using System;

public class Member
{
    public string Name { get; set; }
    public string MembershipID { get; set; }
    private List<Borrow> Borrows { get; set; } // Lista wypożyczeń borrows
    private List<Library> libraries { get; set; } = new List<Library>();
    

    public Member(string membershipID, string name)
    {
        MembershipID = membershipID;
        Name = name;
        Borrows = new List<Borrow>(); // Inicjalizacja listy wypożyczeń
    }
    
    public void AddBorrow(Borrow borrow)
    {
        Borrows.Add(borrow);
    }

    public IEnumerable<Borrow> GetBorrows()
    {
        return Borrows;
    }

    public void addLibrary(Library library)
    {
        libraries.Add(library);
    }

    public void ListBorrows()
    {
        foreach (var borrow in Borrows)
        {
            Console.WriteLine($"{Name} wypożyczył(a) '{borrow.Book.Title}' dnia {borrow.BorrowDate}");
        }
    }
}
