namespace MAS2_s24479_3;

using System;
using System.Collections.Generic;

public class Library
{
    public string Name { get; set; }
    public Dictionary<string, Member> Members { get; set; } // Kwalifikowana asocjacja przez MembershipID
    public List<Section> Sections { get; set; } // Kompozycja - biblioteka składa się z wielu sekcji, a sekcje nie mogą istnieć bez biblioteki.
    
    private List<Borrow> borrows;
    
    
    //zapewnić aby sekcje był dodana do jednej biblioteki i nie mogła być dodana do innych

    public Library(string name)
    {
        Name = name;
        Members = new Dictionary<string, Member>();
        Sections = new List<Section>();
        borrows = new List<Borrow>();
    }

    public void AddMember(Member member)
    {
        if (!Members.ContainsKey(member.MembershipID))
        {
            Members.Add(member.MembershipID, member);
        }
        else
        {
            Console.WriteLine("Taki member juz istnieje");
        }
    }
    
    public Member GetMemberByMembershipID(string membershipID)
    {
        if (Members.ContainsKey(membershipID))
        {
            return Members[membershipID];
        }
        else
        {
            Console.WriteLine($"Nie znaleziono członka z MembershipID: {membershipID}");
            return null;
        }
    }

    public void AddSection(Section section) //sprawdzanie czy sekcja nie jest juz w innej bibliotece
    {
        if (section.GetLibrary() != null)
        {
            Console.WriteLine($"Section {section.Name} is already associated with another library.");
            return;
        }

        if (!Sections.Contains(section))
        {
            Sections.Add(section);
            section.SetLibrary(this); // Setting the library for the section
            Console.WriteLine($"Section {section.Name} has been added to library {Name}");
        }
    }
    public void RemoveSection(Section section)
    {
        if (Sections.Contains(section))
        {
            Sections.Remove(section);
            section.SetLibrary(null); // Removing the reference to the library
            Console.WriteLine($"Section {section.Name} has been removed from library {Name}");
        }
    }
    public void AddBorrow(Borrow borrow)
    {
        borrows.Add(borrow);
    }

    public IEnumerable<Borrow> GetAllBorrows()
    {
        return borrows;
    }

    public void ListAllBorrows()
    {
        foreach (var borrow in borrows)
        {
            Console.WriteLine($"{borrow.Member.Name} wypożyczył(a) '{borrow.Book.Title}' dnia {borrow.BorrowDate}");
        }
    }
    
}
