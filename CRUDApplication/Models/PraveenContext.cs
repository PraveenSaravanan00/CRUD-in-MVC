using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Models;

public partial class PraveenContext : DbContext
{
    public PraveenContext()
    {
    }

    public PraveenContext(DbContextOptions<PraveenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Userlistdatum> Userlistdata { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=192.168.1.111,1433;Database=praveen;User ID=sa; Password=sqlPwd@12#;Trusted_Connection=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Userlistdatum>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__userlist__CBA1B25728B86C09");

            entity.ToTable("userlistdata");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
