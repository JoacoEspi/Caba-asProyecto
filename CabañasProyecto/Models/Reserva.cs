using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabañasProyecto.Models
{
    public class Reserva
    {

        [Key]
        public int Id { get; set; } 
        [Required]  
        public DateTime? FechaInicio { get; set; }

        [Required]  
        public DateTime? FechaFin { get; set; }

        [ForeignKey(nameof(Cabania))]
        public int IdCabania { get; set; }

        [ForeignKey(nameof(Cliente))]
        public int IdCliente { get; set; }

    }
}
