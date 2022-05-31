using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Debe ingresar un usuario")]
        [StringLength(50)]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}