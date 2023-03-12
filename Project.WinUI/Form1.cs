using Project.BLL.Generic_Repository.ConcRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI
{
    public partial class Form1 : Form
    {
        AuthorRepository authorRep;
        public Form1()
        {
            InitializeComponent();
            authorRep = new AuthorRepository();
        }
        Author selectedAuthor;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Author author = new Author
            {
                FirstName = txtAd.Text,
                LastName = txtSoyad.Text
            };
            authorRep.Add(author);
            Basarili();
            Goster();


        }

        private static void Basarili()
        {
            MessageBox.Show("İşlem başarılı");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Goster();
        }

        private void Goster()
        {
            lstAuthors.DataSource = authorRep.GetActives();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (selectedAuthor != null)
            {
                selectedAuthor.FirstName = txtAd.Text;
                selectedAuthor.LastName = txtSoyad.Text;
                authorRep.Update(selectedAuthor);
                Basarili();
                Goster();

            }
            else
            {
                Başarısız();
            }

        }

        private static void Başarısız()
        {
            MessageBox.Show("Başarısız");
        }

        private void btnBK_Click(object sender, EventArgs e)
        {
            if (txtSırala.Text!="")
            {
                int deger = Convert.ToInt32(txtSırala.Text);
                lstAuthors.DataSource = authorRep.GetLastDatas(deger);
            }
            else
            {
                MessageBox.Show("Sayı giriniz");
            }
            
        }

        private void kucuntenB_Click(object sender, EventArgs e)
        {
            if (txtSırala.Text != "")
            {
                int deger = Convert.ToInt32(txtSırala.Text);
                lstAuthors.DataSource = authorRep.GetFirstDatas(deger);
            }
            else
            {
                MessageBox.Show("Sayı giriniz");
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            lstAuthors.DataSource = authorRep.Where(x=>x.FirstName==txtAra.Text);
        }

        private void btnDeneme_Click(object sender, EventArgs e)
        {
            //if (authorRep.Any(x=>x.FirstName==txtAd.Text && x.LastName==txtSoyad.Text))
            //{
            //    MessageBox.Show("Giriş Başarılı");
            //}
            //else
            //{
            //    MessageBox.Show("Başarısız");
            //}

          
        }

        private void lstAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAuthors.SelectedIndex > -1)
            {
                selectedAuthor = lstAuthors.SelectedItem as Author;
                txtAd.Text = selectedAuthor.FirstName;
                txtSoyad.Text = selectedAuthor.LastName;
            }
            else
            {
                MessageBox.Show("Yazar Seçiniz");
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (selectedAuthor!=null)
            {
                authorRep.Remove(selectedAuthor);
                Basarili();
                Goster();
            }
            else
            {
                Başarısız();
            }
        }

        private void btnAktif_Click(object sender, EventArgs e)
        {
            lstAuthors.DataSource = authorRep.GetActives();
        }

        private void btnPasif_Click(object sender, EventArgs e)
        {
            lstAuthors.DataSource = authorRep.GetPassives();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            lstAuthors.DataSource = authorRep.GetModifieds();
        }
    }
}
