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
    public partial class KutuphaneForm : Form
    {
        KutuphaneYoneticisi yonetici = new KutuphaneYoneticisi();
        KitapTur turler = new KitapTur();
        public KutuphaneForm(Kullanici girisYapanKullanici)
        {
            InitializeComponent();

            girisYapan = girisYapanKullanici;
            try
            {

                string json = File.ReadAllText("yonetici.json");
                yonetici.Kitaplar = JsonConvert.DeserializeObject<List<Kitap>>(json);
            }
            catch (Exception)
            {

                yonetici.Kitaplar = new List<Kitap>();

            }
            Listele(yonetici.Kitaplar);
        }


        Kullanici girisYapan;
        private void KutuphaneForm_Load(object sender, EventArgs e)
        {
            cmbTurler.Items.Add("Hepsi");
            foreach (var item in Enum.GetNames(typeof(KitapTur)))
            {
                cmbTurler.Items.Add(item);
            }
            cmbTurler.SelectedIndex=0;
            

        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm girisSayfasi = new LoginForm();

            girisSayfasi.Show();

            this.Close();
        }

        private void hesabımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HesabimForm hesapFormu = new HesabimForm(girisYapan,yonetici);
            hesapFormu.ShowDialog();
            Listele(yonetici.Kitaplar);
        }

        private void bağışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BagisForm bagisFormu = new BagisForm(yonetici);
            bagisFormu.ShowDialog();
            Listele(yonetici.Kitaplar);
        }


        private void KutuphaneForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string json = JsonConvert.SerializeObject(yonetici.Kitaplar);
            File.WriteAllText("yonetici.json", json);
        }



        private void dgvKitaplar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = dgvKitaplar.HitTest(e.X, e.Y).RowIndex;
                if (position >= 0)
                {
                    contextMenuStrip1.Show(dgvKitaplar, e.X, e.Y);
                    dgvKitaplar.Rows[position].Selected = true;
                }
            }
        }

        private void kitapÖdünçAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Kitabı ödünç almak istiyor musun?", "Ödünç İşlemi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Kitap oduncKitap = new Kitap();
                oduncKitap = (Kitap)dgvKitaplar.SelectedRows[0].DataBoundItem;
                girisYapan.OduncAlinanKitaplar.Add(oduncKitap);
                yonetici.Kitaplar.Remove(oduncKitap);
                Listele(yonetici.Kitaplar);




            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
        }

        private void kitapİmhaEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Kitabı imha etmek istiyor musun?", "İmha İşlemi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Kitap imhaKitap = new Kitap();
                imhaKitap = (Kitap)dgvKitaplar.SelectedRows[0].DataBoundItem;
                yonetici.KitapImhaEt(imhaKitap);
                Listele(yonetici.Kitaplar);
               

            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            Arama();

        }

        private void Arama()
        {
            if (!string.IsNullOrEmpty(txtArama.Text))
            {
                Listele(yonetici.Kitaplar.Where(x => x.Ad.ToUpper().Contains(txtArama.Text.ToUpper()) || x.YazarAd.ToUpper().Contains(txtArama.Text.ToUpper())).ToList());

            }
           
            else
                Listele(yonetici.Kitaplar);
        }

        public void Listele(List<Kitap> liste)
        {

            dgvKitaplar.DataSource = null;
            dgvKitaplar.DataSource = liste;
            dgvKitaplar.Columns[0].Visible = false;
            dgvKitaplar.Columns[7].Visible = false;

        }

        private void cmbTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTurler.SelectedIndex != 0)
            {
                
                Listele(yonetici.Kitaplar.Where(x => x.KitapTur== (KitapTur)Enum.Parse(typeof(KitapTur), cmbTurler.Text)).ToList());
               
            }
            else
                Listele(yonetici.Kitaplar);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
