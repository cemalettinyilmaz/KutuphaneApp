using KutuphaneApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneApp
{
    public partial class BagisForm : Form
    {
        public BagisForm(KutuphaneYoneticisi gelenYonetici)
        {
            InitializeComponent();
            yonetici = gelenYonetici;
        }

       

        KutuphaneYoneticisi yonetici;
        
        private void BagisForm_Load(object sender, EventArgs e)
        {
            cmbKitapTuru.DataSource = Enum.GetNames(typeof(KitapTur));

        }

        private void btnBagisYap_Click(object sender, EventArgs e)
        {
            string kitapAdi = txtKitapAdi.Text;
            DateTime basimTarihi = dtpBasimTarihi.Value;
            KitapTur kitapTur = (KitapTur)Enum.Parse(typeof(KitapTur), cmbKitapTuru.Text);

            string yazarAdi = txtYazarAd.Text;
            int sayfaSayisi = (int)nudSayfaSayisi.Value;
            int adet = (int)nudAdet.Value;
            string aciklama = txtAciklama.Text;
            DateTime? odunc = DateTime.Now;

            yonetici.KitapBagis(kitapAdi, basimTarihi, kitapTur, yazarAdi, sayfaSayisi, aciklama,odunc,adet);
            //Kitap yeniK = new Kitap()
            //{
            //    Ad = kitapAdi,
            //    BasimTarihi = basimTarihi,
            //    KitapTur = kitapTur,
            //    YazarAd=yazarAdi,
            //    SayfaSayisi=sayfaSayisi,
            //    Aciklama=aciklama,


            //};




            MessageBox.Show("Kitap bağışı yapıldı.");
            
            
        }

        private void BagisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
           
        }
    }
}
