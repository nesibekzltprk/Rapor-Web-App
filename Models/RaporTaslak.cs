using System.ComponentModel.DataAnnotations;

namespace RaporFront.Models
{
    public class RaporTaslak
    {
        [Key]
        public int TaslakID { get; set; }
        public int? KullaniciID { get; set; }
        public string RaporAdi { get; set; }
        public string TaslakAdi { get; set; }
        public string Sutunlar { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }

    }
}
