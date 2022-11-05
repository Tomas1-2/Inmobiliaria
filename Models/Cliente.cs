using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Cliente
    {
        [Key]
        public int clienteID { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public int Dni { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}