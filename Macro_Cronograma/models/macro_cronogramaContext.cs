using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Macro_Cronograma.models
{
    public partial class macro_cronogramaContext : DbContext
    {
        public virtual DbSet<tb_atividade> tb_atividade { get; set; }
        public virtual DbSet<tb_atribuicao> tb_atribuicao { get; set; }
        public virtual DbSet<tb_projeto> tb_projeto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=macro_cronograma;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_atividade>(entity =>
            {
                entity.HasKey(e => new { e.id_projeto, e.id_atividade });

                entity.ToTable("tb_atividade");

                entity.Property(e => e.id_projeto).HasColumnName("id_projeto");

                entity.Property(e => e.id_atividade)
                    .HasColumnName("id_atividade")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.cod_cor_grafico)
                    .HasColumnName("cod_cor_grafico")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.des_atividade)
                    .IsRequired()
                    .HasColumnName("des_atividade")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.dt_fim)
                    .HasColumnName("dt_fim")
                    .HasColumnType("date");

                entity.Property(e => e.dt_inicio)
                    .HasColumnName("dt_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.flag_deadline).HasColumnName("flag_deadline");

                entity.HasOne(d => d.IdProjetoNavigation)
                    .WithMany(p => p.tb_atividade)
                    .HasForeignKey(d => d.id_projeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_atividade_tb_projeto");
            });

            modelBuilder.Entity<tb_atribuicao>(entity =>
            {
                entity.HasKey(e => e.id_atribuicao);

                entity.ToTable("tb_atribuicao");

                entity.Property(e => e.id_atribuicao).HasColumnName("id_atribuicao");

                entity.Property(e => e.cod_cor_grafico)
                    .HasColumnName("cod_cor_grafico")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.des_atribuicao)
                    .HasColumnName("des_atribuicao")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tb_projeto>(entity =>
            {
                entity.HasKey(e => e.id_projeto);

                entity.ToTable("tb_projeto");

                entity.Property(e => e.id_projeto).HasColumnName("id_projeto");

                entity.Property(e => e.des_projeto)
                    .IsRequired()
                    .HasColumnName("des_projeto")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.dt_fim)
                    .HasColumnName("dt_fim")
                    .HasColumnType("date");

                entity.Property(e => e.dt_inicio)
                    .HasColumnName("dt_inicio")
                    .HasColumnType("date");
            });
        }
    }
}
