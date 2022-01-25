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
    public partial class KayitOlForm : Form
    {
        private readonly KullaniciYoneticisi kullaniciYoneticisi;

        public KayitOlForm(KullaniciYoneticisi kullaniciYoneticisi)
        {
            InitializeComponent();
            lblUyari.Text = "Parola Boş Bırakalamaz!";
            lblUyari.ForeColor = Color.Red;
            btnKayitOl.Enabled = false;
            this.kullaniciYoneticisi = kullaniciYoneticisi;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            //TODO kayit işlemi
            if (!string.IsNullOrEmpty(txtAdSoyad.Text) && !string.IsNullOrEmpty(txtKullaniciAdi.Text))
            {
                bool sonuc = kullaniciYoneticisi.KayitOl(txtAdSoyad.Text, txtKullaniciAdi.Text, txtParola.Text);
                if (sonuc)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Bulunmaktadır! Farklı bir kullanıcı adı seçiniz!");
                    //Textboxları temizlemek için kısayol.
                    foreach (var item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            ((TextBox)item).Clear();
                        }
                    }
                }
            }
            else if (string.IsNullOrEmpty(txtAdSoyad.Text))
            {
                MessageBox.Show("Ad Soyad boş geçilemez");
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı boş geçilemez");
            }
        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {
            string parola = txtParola.Text;
            string parolaTekrar = txtParolaTekrar.Text;
            if ((string.IsNullOrEmpty(parola) && string.IsNullOrEmpty(parolaTekrar)))
            {
                lblUyari.Text = "Parola Boş Bırakalamaz!";
                lblUyari.ForeColor = Color.Red;
                btnKayitOl.Enabled = false;
            }
            else if (parola == parolaTekrar)
            {
                lblUyari.Text = "Parola Uygun!";
                lblUyari.ForeColor = Color.Green;
                btnKayitOl.Enabled = true;
            }
            else
            {
                lblUyari.Text = "Parola Eşleşmiyor!";
                lblUyari.ForeColor = Color.Red;
                btnKayitOl.Enabled = false;
            }
        }
    }
}
