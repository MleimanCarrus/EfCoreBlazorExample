using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerEFCoreDemo.DBFirstModels;

public partial class EfcoreexampleContext : DbContext
{
    public EfcoreexampleContext()
    {
    }

    public EfcoreexampleContext(DbContextOptions<EfcoreexampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestTable> TestTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=EFCOREEXAMPLE;user=root;password=Password123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TestTable>(entity =>
        {
            entity.HasNoKey();
            entity.Property(e => e.Column3).HasColumnName("column3");
            entity.Property(e => e.Thing1).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
