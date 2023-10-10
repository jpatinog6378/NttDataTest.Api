using Microsoft.EntityFrameworkCore;
using NttDataTest.MODELS.Entities;

namespace NttDataTest.CONTEXT.Context
{
    public partial class NttDataTestContext : DbContext
    {
        public NttDataTestContext()
        {

        }

        public NttDataTestContext(DbContextOptions<NttDataTestContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=PC-SEBAS;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Author__3214EC27673281A3");

                entity.ToTable("Author");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Book__3214EC270F9296CB");

                entity.ToTable("Book");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AuthorId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
