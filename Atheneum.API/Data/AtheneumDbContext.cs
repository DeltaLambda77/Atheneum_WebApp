using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atheneum.API.Data;

public partial class AtheneumDbContext : IdentityDbContext<APIUser>
{
    public AtheneumDbContext()
    {
    }

    public AtheneumDbContext(DbContextOptions<AtheneumDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC0707BA3CF6");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC078BFC90E0");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EADB47BAF7").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole 
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "62d7b28e-bed6-4e62-a79b-b2488ed748c8"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "2d77fdeb-1f38-4ea0-aaf7-f84352d68c33"
            }
        );

        var hasher = new PasswordHasher<APIUser>();

        modelBuilder.Entity<APIUser>().HasData(
           new APIUser
           {
               Id = "cb82080b-96e8-4839-8787-68b640eb095b",
               Email = "admin@bookstore.com",
               NormalizedEmail = "ADMIN@BOOKSTORE.COM",
               UserName = "admin@bookstore.com",
               NormalizedUserName = "ADMIN@BOOKSTORE.COM",
               FirstName = "System",
               LastName = "Admin",
               PasswordHash = hasher.HashPassword(null, "P@55word1")
           },
           new APIUser
           {
               Id = "90460ea3-c382-4346-9007-0a5e498ff971",
               Email = "user@bookstore.com",
               NormalizedEmail = "USER@BOOKSTORE.COM",
               UserName = "user@bookstore.com",
               NormalizedUserName = "USER@BOOKSTORE.COM",
               FirstName = "System",
               LastName = "User",
               PasswordHash = hasher.HashPassword(null, "P@55word1")
           }
       );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "62d7b28e-bed6-4e62-a79b-b2488ed748c8",
                UserId = "90460ea3-c382-4346-9007-0a5e498ff971",
            },
             new IdentityUserRole<string>
             {
                 RoleId = "2d77fdeb-1f38-4ea0-aaf7-f84352d68c33",
                 UserId = "cb82080b-96e8-4839-8787-68b640eb095b",
             }
            );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
