using System.ComponentModel.DataAnnotations;

namespace CabañasProyecto.Models
{
    public class Cabania
    {
        private const string MSG_CAPAC_RANGO = "Capacidad fuera de rango";
        private const string MSG_CAPAC = "Debe ingresar una capacidad";
        private const string MSG_PRECIO_RANGO = "Precio fuera de parámetro";
        private const string MSG_PRECIO = "Debe ingresar un precio";

        [Key]
        public int Id{ get; set; }

        [Required(ErrorMessage = MSG_PRECIO)]
        [Range(1, 500000, ErrorMessage = MSG_PRECIO_RANGO)]
        public double Precio { get; set; }

        [Required(ErrorMessage = MSG_CAPAC)]
        [Range(1, 10, ErrorMessage = MSG_CAPAC_RANGO)]
        public int Capacidad { get; set; }
        public bool Estado { get; set; }

    }
}
