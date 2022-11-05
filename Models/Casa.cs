using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Casa
    {
        [Key]
        public int casaID { get; set; }
        public string nombreCasa { get; set; }
        public string Domicilio { get; set; }
        public string nombreDueño { get; set; }
        public byte[] imagen { get; set; }
        public bool Estado { get; set; }
    }
}