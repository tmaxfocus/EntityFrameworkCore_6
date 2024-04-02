// See https://aka.ms/new-console-template for more information
using PublisherData;
using PublisherDomain;

using (PubCOntext context = new PubCOntext())
{
    context.Database.EnsureCreated();
}

GetAuthors();
AddAuthor();
void GetAuthors()
{
    using var context = new PubCOntext();
    var authors = context.Authors.ToList();

    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

void AddAuthor()
{
    Author author = new() { FirstName = "Julie", LastName = "Lerman" };
    PubCOntext pubCOntext = new PubCOntext();

    pubCOntext.Authors.Add(author);
    pubCOntext.SaveChanges();
}