
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Display(
            Name = "Nombre", 
            Prompt = "Ingrese un Nombre"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(200, ErrorMessage = "Este campo debe tener un máximo de 200 caracteres")]
        public string Nombre { get; set; }
        [Display(
            Name = "Apellido", 
            Prompt = "Ingrese un Apellido"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(200, ErrorMessage = "Este campo debe tener un máximo de 200 caracteres")]
        public string Apellido { get; set; }
        [Display(
            Name = "Dirección", 
            Prompt = "Ingrese una Dirección"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(250, ErrorMessage = "Este campo debe tener un máximo de 250 caracteres")]
        public string Direccion { get; set; }
        [Display(
            Name = "Teléfono", 
            Prompt = "Ingrese un Teléfono"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20, ErrorMessage = "Este campo debe tener un máximo de 20 caracteres")]
        public string Telefono { get; set; }
        [Display(
            Name = "Email", 
            Prompt = "Ingrese un Email"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100, ErrorMessage = "Este campo debe tener un máximo de 100 caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección válida")]
        public string Email { get; set; }
        [Display(
            Name = "Horario de Entrada", 
            Prompt = "Ingrese un Horario de Entrada"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }
        [Display(
            Name = "Horario de Salida", 
            Prompt = "Ingrese un Horario de Salida"
        )]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public List<Turno> Turno { get; set; }
    }
}