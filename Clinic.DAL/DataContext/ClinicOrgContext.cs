using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DAL.DataContext;

public partial class ClinicOrgContext : DbContext
{
    public ClinicOrgContext()
    {
    }

    public ClinicOrgContext(DbContextOptions<ClinicOrgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ClinicOrg ;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Citas__3213E83F7C352742");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__Citas__MedicoId__3E52440B");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Citas__PacienteI__3D5E1FD2");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3213E83FEDB06E67");

            entity.ToTable("HistorialMedico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.Medico).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__Historial__Medic__45F365D3");

            entity.HasOne(d => d.Paciente).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Historial__Medic__440B1D61");

            entity.HasOne(d => d.Tratamiento).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.TratamientoId)
                .HasConstraintName("FK__Historial__Trata__44FF419A");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicos__3213E83FDC1F7574");

            entity.HasIndex(e => e.Email, "UQ__Medicos__A9D105349CAAF0C5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Personid).HasName("PK__Paciente__AA2CFFDD8F565AC3");

            entity.HasIndex(e => e.Email, "UQ__Paciente__A9D10534202F66DC").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tratamie__3213E83F5431E8A5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Paciente).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Tratamien__Pacie__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
