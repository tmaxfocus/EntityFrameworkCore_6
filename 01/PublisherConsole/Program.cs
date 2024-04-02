// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubCOntext context = new PubCOntext())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthor();
//GetAuthors();
//AddAuthorWithBook();
GetAuthorsWithBooks();
void GetAuthors()
{
    using var context = new PubCOntext();
    var authors = context.Authors.ToList();

    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

void GetAuthorsWithBooks()
{
    using var context = new PubCOntext();
    var authors = context.Authors.Include(x => x.Books).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach(var book in author.Books)
        {
            Console.WriteLine(book.Title + " " + book.PublishDate);
        }
    }
}

void AddAuthor()
{
    Author author = new() { FirstName = "Julie", LastName = "Lerman" };
    PubCOntext pubCOntext = new PubCOntext();

    pubCOntext.Authors.Add(author);
    pubCOntext.SaveChanges();
}

void AddAuthorWithBook()
{
    Author author = new() { FirstName = "Julie", LastName = "Lermax" };
    author.Books.Add(new Book { Title = "Programing Entity Framework", PublishDate = new DateTime(2009, 1, 1) });

    author.Books.Add(new Book { Title = "Programing Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 1, 1) });
    PubCOntext pubCOntext = new PubCOntext();

    pubCOntext.Authors.Add(author);
    pubCOntext.SaveChanges();
}