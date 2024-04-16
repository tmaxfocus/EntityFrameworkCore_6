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

//QueryAggregate();

//RetrieveAndUpdateAuthor();

//RetrieveAndUpdateMultipleAuthor();

//CoordinatedRetrieveAndUpdateAuthor();

//DeleteAnAuthor();
//InsertMultipleAuthors();
//BulkUpdates();

EagerLoadBooksWithAuthors();

void EagerLoadBooksWithAuthors()
{
    var pubDateStart = new DateTime(2010, 1, 1);
    var author = context.Authors.Include(x => x.Books
    .Where(b => b.PublishDate >= pubDateStart)
    .OrderBy(b => b.Title)).ToList();

    author.ForEach(a =>
    {
        Console.WriteLine($"{a.LastName} ({a.Books.Count})");
        a.Books.ForEach(b => Console.WriteLine("  " + b.Title));
    });
}


void BulkUpdates()
{
   var newAuthors =  new Author[] {new Author{ FirstName = "Tobi", LastName = "Adelabi" },
        new Author { FirstName = "Bolaji", LastName = "Kolade" },
        new Author { FirstName = "Olaogunwa", LastName = "Jolatito" },
        new Author { FirstName = "Felixo", LastName = "Idiagbongan" } };

    context.Authors.AddRange(newAuthors);

    var book = context.Books.Find(2);
    book.Title = "Programing Entity Framework 2nd Edition";

    context.SaveChanges();
}

void InsertMultipleAuthors()
{
    context.Authors.AddRange(new Author { FirstName = "Tobi", LastName = "Adeogun" },
        new Author { FirstName = "Bola", LastName = "Adeogun" },
        new Author { FirstName = "Sogunwa", LastName = "Bolatito" },
        new Author { FirstName = "Felix", LastName = "Idiagbon" });

    context.SaveChanges();
}

void DeleteAnAuthor(){
    var extraJL = context.Authors.Find(1);

    if(extraJL != null)
    {
        context.Authors.Remove(extraJL);
        context.SaveChanges();
    }
}

void CoordinatedRetrieveAndUpdateAuthor()
{
    var author = FindThatAuthor(6);

    if(author?.FirstName == "Julia")
    {
        author.FirstName = "Jolin";
        SaveAuthor(author);
    }
}
Author FindThatAuthor(int authorId)
{
    using var shortLivedContext = new PubCOntext();
    return shortLivedContext.Authors.Find(authorId);
}

void SaveAuthor(Author author)
{
    using var anotherShortLivedContext = new PubCOntext();
    anotherShortLivedContext.Authors.Update(author);
    anotherShortLivedContext.SaveChanges();
}

void RetrieveAndUpdateMultipleAuthor()
{
    var lermanAuthors = context.Authors.Where(a => a.LastName == "Lerman").ToList();

    foreach(var la in lermanAuthors)
    {
        la.FirstName = "Julia";
    }

    Console.WriteLine("Before" + context.ChangeTracker.DebugView.ShortView);
    context.ChangeTracker.DetectChanges();
    Console.WriteLine("After :" + context.ChangeTracker.DebugView.ShortView);

    context.SaveChanges();
}
void RetrieveAndUpdateAuthor()
{
    var author = context.Authors.FirstOrDefault(x => x.FirstName == "Julie" && x.LastName == "Lerman");

    if(author != null)
    {
        author.FirstName = "Julia";
        context.SaveChanges();
    }
}
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