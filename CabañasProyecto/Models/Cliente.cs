using System.ComponentModel.DataAnnotations;

namespace CabañasProyecto.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un DNI")]
        [Range(1000000, 900000000, ErrorMessage = "DNI fuera de rango")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido{ get; set; }

        [Required(ErrorMessage = "Debe ingresar una dirección ")]
        public string Direccion{ get; set; }

        [Required]
        public string Telefono{ get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "Formato de mail inválido")]
        public string Email{ get; set; }

    }
}
