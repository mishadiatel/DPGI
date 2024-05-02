using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Lab5;

public partial class Lab5DbContext : DbContext
{
    public Lab5DbContext()
    {
    }

    public Lab5DbContext(DbContextOptions<Lab5DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;uid=root;pwd=password;database=dpgiproductsdb2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.Unitcode, "unitcode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Article)
                .HasMaxLength(255)
                .HasColumnName("article");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(255)
                .HasColumnName("quantity");
            entity.Property(e => e.Unitcode).HasColumnName("unitcode");

            entity.HasOne(d => d.UnitcodeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Unitcode)
                .HasConstraintName("products_ibfk_1");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("units");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Unit1)
                .HasMaxLength(255)
                .HasColumnName("unit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
