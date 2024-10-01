using System;
using System.Collections.Generic;
using Book.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.DAL.DataContext;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BooksGit> BooksGits { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BooksGit>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__BooksGit__EC40107A1D2DBF50");

            entity.ToTable("BooksGit");

            entity.Property(e => e.BookName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
