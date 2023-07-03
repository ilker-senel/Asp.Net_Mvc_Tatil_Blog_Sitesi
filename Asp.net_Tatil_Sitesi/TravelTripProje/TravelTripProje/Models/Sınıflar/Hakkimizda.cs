using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Hakkimizda
    {
        [Key]
        public int Id { get; set; }
        public string FotoUrl { get; set; }
        public string Aciklama { get; set; }
        //public string Aciklama2 { get; set; }
       


    }
}