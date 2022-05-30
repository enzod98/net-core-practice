using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones)
            :base(opciones)
        {

        }

        public DbSet<Especialidad> Especialidad {get; set; }
        public DbSet<Paciente> Paciente {get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definir manualmente los campos y propiedades de la tabla Especialidad
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad");//Indicamos el nombre de la tabla
                entidad.HasKey(e => e.IdEspecialidad);//Indicamos el PK
                entidad.Property(e => e.Descripcion)//Especificamos que se cree el atributo Descripcion
                    .IsRequired()//para que no sea null
                    .HasMaxLength(200)//máximo de caracteres
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>( entidad => {
                entidad.ToTable("Paciente");
                entidad.HasKey(e => e.IdPaciente);
                entidad.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entidad.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>( entidad => {
                entidad.ToTable("Medico");
                entidad.HasKey(e => e.IdMedico);
                entidad.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entidad.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionDesde)
                    .IsRequired()
                    .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionHasta)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicoEspecialidad>().HasKey( x => 
                new { x.IdMedico, x.IdEspecialidad }
            );

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(x => x.Medico)
                .WithMany(p => p.MedicoEspecialidad)//El tipo de relación entre Medico y MedicoEspecialidad
                .HasForeignKey( p => p.IdMedico);//Definimos el campo FK

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne( x => x.Especialidad)
                .WithMany( x => x.MedicoEspecialidad )
                .HasForeignKey( p => p.IdEspecialidad );

            modelBuilder.Entity<Turno>( entidad => {
                entidad.ToTable("Turno");
                entidad.HasKey(e => e.IdTurno);
                entidad.Property(e => e.IdPaciente)
                    .IsRequired()
                    .IsUnicode(false);

                entidad.Property(e => e.IdMedico)
                    .IsRequired()
                    .IsUnicode(false);

                entidad.Property(e => e.FechaHoraInicio)
                    .IsRequired()
                    .IsUnicode(false);

                entidad.Property(e => e.FechaHoraFin)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>()
                .HasOne(x => x.Paciente)
                .WithMany(p => p.Turno)
                .HasForeignKey( p => p.IdPaciente);

            modelBuilder.Entity<Turno>()
                .HasOne(x => x.Medico)
                .WithMany(p => p.Turno)
                .HasForeignKey( p => p.IdMedico);
        }


    }
}