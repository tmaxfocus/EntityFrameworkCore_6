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
            optionsBuilder.UseSqlServer("Data Source=433571323T5SL; Initial Catalog = PubDatabase; User Id = tmaxnoda; Password=tmaxnoda123@");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, FirstName = "Rhoda", LastName = "Lerman" });

            var newAuthors = new Author[] {new Author{Id=2, FirstName = "Tobi", LastName = "Adelabi" },
        new Author { Id =3, FirstName = "Bolaji", LastName = "Kolade" },
        new Author {Id=4, FirstName = "Olaogunwa", LastName = "Jolatito" },
        new Author {Id=5, FirstName = "Felixo", LastName = "Idiagbongan" } };


            modelBuilder.Entity<Author>().HasData(newAuthors);
        }
    }
}
