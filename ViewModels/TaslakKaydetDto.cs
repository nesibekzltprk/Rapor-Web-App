using System.Text.Json.Serialization;

namespace RaporFront.ViewModels
{
    public class TaslakKaydetDto
    {
        
        public int? KullaniciID { get; set; }
        
        public string RaporAdi { get; set; }
        
        public string TaslakAdi { get; set; }
       
        public List<string> SecilenSutunlar { get; set; }

        // ✅ Yeni alanlar:
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
    }
}
