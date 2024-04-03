// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System.Security.Cryptography;


var context = new PubCOntext();

//GetAuthors();
//GetFilters();
//AddSomeMoreAuthors();
//SkipAndTakeAuthors();

//SortAuthors();

QueryAggregate();


void QueryAggregate()
{
    var name = "Lerman";
    var authors = context.Authors.FirstOrDefault(a => a.LastName == name);

    Console.WriteLine(authors.FirstName);
}

void SortAuthors()
{
    var authorsByLastName = context.Authors
        .OrderBy(a => a.LastName)
        .ThenBy(a => a.FirstName).ToList();
    authorsByLastName.ForEach(x => Console.WriteLine(x.LastName + ", " + x.FirstName));

    var authorsByDescending = context.Authors
        .OrderByDescending(a => a.LastName)
        .ThenByDescending(a => a.FirstName).ToList();
    //authorsByLastName.ForEach(x => Console.WriteLine(x.LastName + ", " + x.FirstName));

    Console.WriteLine("** Descending Last and First**");
    authorsByDescending.ForEach(x => Console.WriteLine(x.LastName + ", " + x.FirstName));
}

void AddSomeMoreAuthors()
{
    context.Authors.Add(new Author { FirstName = "Rhoda", LastName = "Lerman" });
    context.Authors.Add(new Author { FirstName = "Don", LastName = "Jones" });
    context.Authors.Add(new Author { FirstName = "Jim", LastName = "Christopher" });
    context.Authors.Add(new Author { FirstName = "Stephen", LastName = "Haunts" });
    context.SaveChanges();
}

void SkipAndTakeAuthors()
{
    var groupSize = 2;
    for(int i=0; i < 5; i++)
    {
        var authors = context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
        Console.WriteLine($"Group {i}:");
        foreach(var author in authors)
        {
            Console.WriteLine($"{author.FirstName} {author.LastName}");
        }
    }
}
void GetAuthors()
{
    var name = "Julie";
    var authors = context.Authors.Where(x => x.FirstName == name).ToList();

    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

void GetFilters()
{
    var filter = "J%";
    var authors = context.Authors.Where(x => EF.Functions.Like(x.FirstName,filter)).ToList();

    foreach (var author in authors)
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