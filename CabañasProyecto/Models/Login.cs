using System.ComponentModel.DataAnnotations;

namespace CabañasProyecto.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Required (ErrorMessage = "Debe ingresar un usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        public string Contrasenia { get; set; }
    }
}
//Query
//insert into[Login]
//values('Joaco', CONVERT(VARCHAR(100), HASHBYTES('SHA2_256', '1234'), 2))
