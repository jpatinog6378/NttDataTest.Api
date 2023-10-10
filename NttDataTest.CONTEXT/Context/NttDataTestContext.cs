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
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KM5B0H7;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Author__3214EC275C74F23B");

                entity.ToTable("Author");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Book__3214EC27CE05DEA0");

                entity.ToTable("Book");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.IdNavigation).WithOne(p => p.Book)
                    .HasForeignKey<Book>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__ID__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
