namespace MAS2_s24479_3;

using System;
using System.Collections.Generic;

public class Library
{
    public string Name { get; set; }
    public Dictionary<string, Member> Members { get; set; } // Kwalifikowana asocjacja przez MembershipID
    private List<Section> Sections { get; set; } // Kompozycja - biblioteka składa się z wielu sekcji, a sekcje nie mogą istnieć bez biblioteki.

    private static List<Section> allSections { get; set; } = new List<Section>();//wszystkie nasze sekcje

    private List<Borrow> borrows;
    

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

    public void AddSection(Section section) //kompozycja i polaczenie zwrotne dla kompozycji
    {
        if (allSections.Contains(section))
        {
            throw new Exception("This section is assign to other library");
        }
        Sections.Add(section);
        allSections.Add(section);
        
    }
    public void RemoveSection(Section section)
    {
        Sections.Remove(section);
        allSections.Remove(section);
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
