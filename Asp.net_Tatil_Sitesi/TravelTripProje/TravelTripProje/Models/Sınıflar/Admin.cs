using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Kullanici { get; set; }
        public int Sifre { get; set; }



    }
}