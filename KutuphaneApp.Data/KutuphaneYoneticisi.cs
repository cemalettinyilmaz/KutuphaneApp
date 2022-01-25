using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneApp.Data
{
    public class KutuphaneYoneticisi
    {
        public KutuphaneYoneticisi()
        {

            //Kitaplar =new BindingList<Kitap>();


        }
        public List<Kitap> Kitaplar { get; set; } 
        public void KitapBagis(string ad,DateTime basimTarihi,KitapTur tur,string yazarAd,int sayfaSayisi,string aciklama,DateTime? odunc,int adet)
        {
            Kitap yeniKitap = new Kitap()
            {
                Ad = ad,
                BasimTarihi = basimTarihi,
                KitapTur = tur,
                YazarAd = yazarAd,
                SayfaSayisi = sayfaSayisi,
                Aciklama=aciklama,
                OduncAlinmaTarihi=odunc,
               
            };

            for (int i = 1; i <= adet; i++)
            {
                Kitaplar.Add(yeniKitap);
            }
            


          
        }

       
        public void KitapImhaEt(Kitap silinecekKitap)
        {
            Kitaplar.Remove(silinecekKitap);
        }
    }
}
