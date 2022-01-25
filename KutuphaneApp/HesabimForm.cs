using KutuphaneApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneApp
{
    public partial class HesabimForm : Form
    {
        public HesabimForm(Kullanici girisYapanKullanici, KutuphaneYoneticisi gelenYonetici)
        {
            girisYapan = girisYapanKullanici;
            InitializeComponent();
            yonetici = gelenYonetici;
        }
        Kullanici girisYapan = new Kullanici();
        KutuphaneYoneticisi yonetici;
        private void HesabimForm_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text = girisYapan.AdSoyad;
            lblID.Text = girisYapan.Id.ToString();
            lblKullaniciAdi.Text = girisYapan.KullaniciAdi;
            lblParola.Text = girisYapan.Parola;
            Listele();

        }

        public void Listele()
        {
            dgvOduncKitaplar.DataSource = null;
            dgvOduncKitaplar.DataSource = girisYapan.OduncAlinanKitaplar;
            dgvOduncKitaplar.Columns[0].Visible = false;
            dgvOduncKitaplar.Columns[2].Visible = false;
            dgvOduncKitaplar.Columns[4].Visible = false;
            dgvOduncKitaplar.Columns[5].Visible = false;
            dgvOduncKitaplar.Columns[6].Visible = false;

        }
        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            

            if (dgvOduncKitaplar.SelectedRows.Count > 0)
            {
                Kitap teslim = (Kitap)dgvOduncKitaplar.SelectedRows[0].DataBoundItem;

                girisYapan.OduncAlinanKitaplar.Remove(teslim);
                yonetici.Kitaplar.Add(teslim);
                Listele();
            }
        }

        private void dgvOduncKitaplar_MouseClick(object sender, MouseEventArgs e)


        {
            ////Tıklama eventinede yapabiliriz.
            //if (e.Button == MouseButtons.Left)
            //{
            //    var position = dgvOduncKitaplar.HitTest(e.X, e.Y).RowIndex;
            //    if (position >= 0)
            //    {

            //        dgvOduncKitaplar.Rows[position].Selected = true;
            //        Kitap secilen = (Kitap)dgvOduncKitaplar.SelectedRows[0].DataBoundItem;
            //        DateTime tarih = secilen.OduncAlinmaTarihi.Value;
            //        dateTimePicker1.Value = tarih.AddDays(14);
            //    }
            //}



        }

        private void dgvOduncKitaplar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOduncKitaplar.SelectedRows.Count > 0)
            {
                Kitap secilen = (Kitap)dgvOduncKitaplar.SelectedRows[0].DataBoundItem;
                DateTime tarih = secilen.OduncAlinmaTarihi.Value;
                dateTimePicker1.Value = tarih.AddDays(14);
            }



        }
    }
}
