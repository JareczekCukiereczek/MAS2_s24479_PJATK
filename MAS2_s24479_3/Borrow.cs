namespace MAS2_s24479_3;

using System;

public class Borrow
{
    public Member Member { get; set; }
    public Book Book { get; set; }
    public DateTime BorrowDate { get; set; } // Asocjacja z atrybutem - asocjacja pomiędzy Member a Book
    //klasa pośrednicząca pomiędzy nimi to Borrow która dodaje atrybut borrowDate

    public Borrow(Member member, Book book, DateTime borrowDate)
    {
        Member = member;
        Book = book;
        BorrowDate = borrowDate;
        member.Borrows.Add(this); // Dodanie wypożyczenia do listy wypożyczeń membera
        book.Borrows.Add(this); // Dodanie wypożyczenia do listy wypożyczeń books

    }
}
