using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class RentalDetailTemp
    {
        [Key]
        public int RentalDetailTempID { get; set; }

        public int casaID {get; set;}

        public string? nombreCasa {get; set;}

    }
}