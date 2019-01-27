using Microsoft.EntityFrameworkCore;


namespace LibraryManager.Model
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-2N0J4TUT;
                                            Initial Catalog=EFLibraryManager;
                                            Integrated Security=True;
                                            MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookStore>()
                .HasKey(bs => new { bs.BookId, bs.StoreId });
            modelBuilder.Entity<BookStore>()
                .HasOne(bs => bs.Book)
                .WithMany(b => b.BookStores)
                .HasForeignKey(bs => bs.BookId);
            modelBuilder.Entity<BookStore>()
                .HasOne(bs => bs.Store)
                .WithMany(s => s.BookStores)
                .HasForeignKey(bs => bs.StoreId);

            modelBuilder.Entity<AuthorConference>()
              .HasKey(ac => new { ac.AuthorId, ac.ConferenceId });
            modelBuilder.Entity<AuthorConference>()
                .HasOne(ac => ac.Author)
                .WithMany(a => a.AuthorConferences)
                .HasForeignKey(ac => ac.AuthorId);
            modelBuilder.Entity<AuthorConference>()
                .HasOne(ac => ac.Conference)
                .WithMany(c => c.AuthorConferences)
                .HasForeignKey(ac => ac.ConferenceId);
        }
    }
}
