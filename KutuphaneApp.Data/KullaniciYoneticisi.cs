using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneApp.Data
{
    public class KullaniciYoneticisi
    {
        public KullaniciYoneticisi()
        {
            Kullanicilar = new List<Kullanici>();
        }
        public List<Kullanici> Kullanicilar { get; set; }
        public bool KullaniciAdiVarMi(string kullaniciAdi)
        {
            return Kullanicilar.Any(x => x.KullaniciAdi == kullaniciAdi);
        }
        public bool KayitOl(string adSoyad, string kullaniciAdi, string parola)
        {
            if (KullaniciAdiVarMi(kullaniciAdi))
            {
                return false;
            }
            else
            {
                Kullanicilar.Add(new Kullanici()
                {
                    AdSoyad = adSoyad,
                    KullaniciAdi = kullaniciAdi,
                    Parola = parola
                });
                return true;
            }
        }
        public Kullanici OturumAc(string kullaniciAdi, string parola)
        {
            return Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Parola == parola);
        }
    }
}
