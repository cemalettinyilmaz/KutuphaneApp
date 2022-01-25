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
    public partial class LoginForm : Form
    {
        KullaniciYoneticisi kullaniciYoneticisi;
        public LoginForm()
        {
            
            InitializeComponent();
            try
            {
                string json = File.ReadAllText("veri.json");
                kullaniciYoneticisi = JsonConvert.DeserializeObject<KullaniciYoneticisi>(json);
            }
            catch (Exception)
            {
                kullaniciYoneticisi = new KullaniciYoneticisi();
            }


        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Kullanici girisYapanKullanici = kullaniciYoneticisi.OturumAc(txtKullaniciAdi.Text, txtParola.Text);
            if (girisYapanKullanici != null)
            {
              
                KutuphaneForm kutuphaneForm = new KutuphaneForm(girisYapanKullanici);
                kutuphaneForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı yada şifre hatalı!");
            }
            txtTemizle();
        }

        private void lnklblKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitOlForm kayitOlForm = new KayitOlForm(kullaniciYoneticisi);
            kayitOlForm.ShowDialog();
        }

        private void chkParolaGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParolaGoster.Checked)
            {
                txtParola.PasswordChar = '\0';
                //txtParola.PasswordChar = default; 2. yöntem
            }
            else
            {
                txtParola.PasswordChar = '*';
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string json = JsonConvert.SerializeObject(kullaniciYoneticisi);
            File.WriteAllText("veri.json", json);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
        public void txtTemizle()
        {
            txtKullaniciAdi.Text = "";
            txtParola.Text = "";
        }
    }
}
