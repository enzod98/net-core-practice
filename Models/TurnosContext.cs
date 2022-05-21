using Microsoft.EntityFrameworkCore;

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
        }
    }
}