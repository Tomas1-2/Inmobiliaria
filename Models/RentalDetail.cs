using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class RentalDetail
    {
        [Key]
        public int RentalDetailID { get; set; }

        public int RentalCasaId { get; set; }
        public virtual RentalCasa? RentalCasa { get; set; }

        public int casaID { get; set; }
        public virtual Casa? Casa { get; set; }

        public string? nombreCasa { get; set; }
    }
}