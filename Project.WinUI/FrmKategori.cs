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
    public partial class FrmKategori : Form
    {
        CategoryRepository rep;
        public FrmKategori()
        {
            InitializeComponent();
            rep = new CategoryRepository();
        }

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            Goster();
        }

        private void Goster()
        {
            lstBox.DataSource = rep.GetAll();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Category category = new Category()
            {
                CategoryName = txtAd.Text
            };
            rep.Add(category);
            MessageBox.Show("İşlem başarılı");
            Goster();
        }
    }
}
