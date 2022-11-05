using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class RentalCasa
    {
        [Key]

        public int RentalCasaId { get; set; }
        public DateTime FechaAlquiler { get; set;}
        public int ClienteId { get; set; }
        public int CasaID { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual Casa? Casa { get; set; }


        public virtual ICollection<RentalDetail>? RentalDetails { get; set; }
    }
}