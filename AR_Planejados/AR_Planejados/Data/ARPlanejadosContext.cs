using System;
using System.Collections.Generic;
using AR_Planejados.Models;
using Microsoft.EntityFrameworkCore;

namespace AR_Planejados.Data;

public partial class ARPlanejadosContext : DbContext
{
    public ARPlanejadosContext(DbContextOptions<ARPlanejadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Orcamento> Orcamentos { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642D091D518");

            entity.ToTable("Cliente");

            entity.Property(e => e.DataCadastro).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.HasKey(e => e.IdOrcamento).HasName("PK__Orcament__F65796780AC70B73");

            entity.ToTable("Orcamento");

            entity.HasIndex(e => e.IdCliente, "IX_Orcamento_IdCliente");

            entity.HasIndex(e => e.Status, "IX_Orcamento_Status");

            entity.Property(e => e.DataSolicitacao).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendente");
            entity.Property(e => e.TipoAmbiente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValorEstimado).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Orcamentos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orcamento_Cliente");
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.IdProjeto).HasName("PK__Projeto__B9E1BB5CAA309F81");

            entity.ToTable("Projeto");

            entity.HasIndex(e => e.TipoAmbiente, "IX_Projeto_TipoAmbiente");

            entity.Property(e => e.Ativo).HasDefaultValue(true);
            entity.Property(e => e.DataCadastro).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FotoProjeto)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NomeProjeto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoAmbiente)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
