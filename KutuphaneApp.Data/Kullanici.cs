using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneApp.Data
{
    public class Kullanici
    {
        public Kullanici()
        {
            OduncAlinanKitaplar = new List<Kitap>();
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public List<Kitap> OduncAlinanKitaplar { get; set; }
    }
}
