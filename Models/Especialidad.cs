using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad {get; set;}
        [Display(
            Name = "Descripción", 
            Prompt = "Ingrese una descripción"
        )]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [StringLength(200, ErrorMessage = "El campo descripción debe tener un máximo de 200 caracteres")]
        public string Descripcion { get; set;}
        public List<MedicoEspecialidad> MedicoEspecialidad {get;set;}
    }
}