using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimeoneCRUD.Models;

public partial class ClasseContext : DbContext
{
    public ClasseContext()
    {
    }

    public ClasseContext(DbContextOptions<ClasseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allievi> Allievis { get; set; }

    public virtual DbSet<Lezioni> Lezionis { get; set; }

    public virtual DbSet<Professori> Professoris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseMySQL("server=localhost; port=3306; user=root; password=Hisense91point; database=classe;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allievi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("allievi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cognome)
                .HasMaxLength(25)
                .HasColumnName("cognome");
            entity.Property(e => e.Idlezione).HasColumnName("idlezione");
            entity.Property(e => e.Nome)
                .HasMaxLength(25)
                .HasColumnName("nome");

            entity.HasMany(d => d.IdLeziones).WithMany(p => p.IdAllievos)
                .UsingEntity<Dictionary<string, object>>(
                    "AllieviLezione",
                    r => r.HasOne<Lezioni>().WithMany()
                        .HasForeignKey("IdLezione")
                        .HasConstraintName("allievi_lezione_ibfk_2"),
                    l => l.HasOne<Allievi>().WithMany()
                        .HasForeignKey("IdAllievo")
                        .HasConstraintName("allievi_lezione_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdAllievo", "IdLezione").HasName("PRIMARY");
                        j.ToTable("allievi_lezione");
                        j.HasIndex(new[] { "IdLezione" }, "id_lezione");
                        j.IndexerProperty<int>("IdAllievo").HasColumnName("id_allievo");
                        j.IndexerProperty<int>("IdLezione").HasColumnName("id_lezione");
                    });
        });

        modelBuilder.Entity<Lezioni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lezioni");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lezione)
                .HasMaxLength(50)
                .HasColumnName("lezione");
        });

        modelBuilder.Entity<Professori>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("professori");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Materia)
                .HasMaxLength(50)
                .HasColumnName("materia");
            entity.Property(e => e.Professore)
                .HasMaxLength(25)
                .HasColumnName("professore");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
