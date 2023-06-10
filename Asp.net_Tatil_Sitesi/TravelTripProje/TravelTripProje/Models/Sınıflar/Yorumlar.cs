using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Yorumlar
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int BlogId { get; set; }
        public bool Onay { get; set; }
        public virtual Blog Blog { get; set; }
    }
}