using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryManagementSystem.Entites.Models
{
    public partial class LibraryManagementDbContext : DbContext
    {
        public LibraryManagementDbContext()
        {
        }

        public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookDetail> BookDetails { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<MainPage> MainPages { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-D9Q8RKEG\\SQLEXPRESS; Initial Catalog=LibraryManagementDb;Integrated Security=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RegisterDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Subtitle).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.İmageUrl)
                    .IsUnicode(false)
                    .HasColumnName("İmageURL");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DeathDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FullName).HasMaxLength(70);

                entity.Property(e => e.RegisterDate).HasColumnType("smalldatetime");

                entity.Property(e => e.İmageUrl)
                    .IsUnicode(false)
                    .HasColumnName("İmageURL");

                entity.HasMany(d => d.Books)
                    .WithMany(p => p.Authors)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthorBook",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AuthorBooks_Books"),
                        r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AuthorBooks_Authors"),
                        j =>
                        {
                            j.HasKey("AuthorId", "BookId");

                            j.ToTable("AuthorBooks");
                        });
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.İd);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISBN")
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PublishDate).HasColumnType("smalldatetime");

                entity.Property(e => e.RegisterDate).HasColumnType("smalldatetime");

                entity.Property(e => e.İmageUrl)
                    .IsUnicode(false)
                    .HasColumnName("İmageURL");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Books_Categories");
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BookDetail)
                    .HasForeignKey<BookDetail>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookDetails_Books");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RegisterDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegisterDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Subtitle).HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<MainPage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastSavedTitle).HasMaxLength(50);

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("RegisterDAte");

                entity.Property(e => e.ServiceDescription1).HasMaxLength(200);

                entity.Property(e => e.ServiceDescription2).HasMaxLength(200);

                entity.Property(e => e.ServiceDescription3).HasMaxLength(200);

                entity.Property(e => e.ServiceTitle1).HasMaxLength(30);

                entity.Property(e => e.ServiceTitle2).HasMaxLength(30);

                entity.Property(e => e.ServiceTitle3).HasMaxLength(30);

                entity.Property(e => e.SliderSubtitle1).HasMaxLength(100);

                entity.Property(e => e.SliderSubtitle2).HasMaxLength(100);

                entity.Property(e => e.SliderSubtitle3).HasMaxLength(100);

                entity.Property(e => e.SliderTite2).HasMaxLength(30);

                entity.Property(e => e.SliderTitle1).HasMaxLength(30);

                entity.Property(e => e.SliderTitle3).HasMaxLength(30);

                entity.Property(e => e.SliderİmageUrl1)
                    .IsUnicode(false)
                    .HasColumnName("SliderİmageURL1");

                entity.Property(e => e.SliderİmageUrl2).HasColumnName("SliderİmageURL2");

                entity.Property(e => e.SliderİmageUrl3).HasColumnName("SliderİmageURL3");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegisterDate)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Subject).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
