using System;
using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Iletisim
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }

    }
}