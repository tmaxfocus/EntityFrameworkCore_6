using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    public class PubCOntext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=433571323T5SL; Initial Catalog = PubDatabase; User Id = tmaxnoda; Password=tmaxnoda123@")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);
                //.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author { AuthorId = 1, FirstName = "Rhoda", LastName = "Lerman" });

            var newAuthors = new Author[] {new Author{AuthorId=2, FirstName = "Tobi", LastName = "Adelabi" },
        new Author { AuthorId =3, FirstName = "Bolaji", LastName = "Kolade" },
        new Author {AuthorId=4, FirstName = "Olaogunwa", LastName = "Jolatito" },
        new Author {AuthorId=5, FirstName = "Felixo", LastName = "Idiagbongan" } };
            modelBuilder.Entity<Author>().HasData(newAuthors);

            var BookToAuthors = new Book[] {new Book{BookId = 1,AuthorId=1,Title ="In God's Ear", PublishDate = new DateTime(1989,3,1) },
        new Book{BookId = 2,AuthorId=2,Title ="A Tale For the Time Being", PublishDate = new DateTime(2013,12,31) },
        new Book{BookId = 3,AuthorId=3,Title ="Right Hand Of Godr", PublishDate = new DateTime(1996,3,1) }
        };

            modelBuilder.Entity<Book>().HasData(BookToAuthors);

        }
    }
}
