using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Task2
{
    class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Book>().
                HasOptional(p => p.BookReview).
                WithOptionalPrincipal(p => p.Book);

            modelBuilder.Entity<Book>().Property(b => b.Title).
                IsRequired().
                HasMaxLength(512);

            modelBuilder.Entity<BookReview>().Property(r => r.ReviewerName).
                IsRequired();

            modelBuilder.Entity<Author>().Property(a => a.Name).
                IsRequired();
        }
    }
}
