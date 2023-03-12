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
    public partial class FrmBook : Form
    {
        CategoryRepository catRep;
        AuthorRepository autRep;
        BookRepository bookRep;
        BookCategoryRepository bookCategoryRep;
        public FrmBook()
        {
            InitializeComponent();
            catRep = new CategoryRepository();
            autRep = new AuthorRepository();
            bookRep = new BookRepository();
            bookCategoryRep = new BookCategoryRepository();
        }

        private void FrmBook_Load(object sender, EventArgs e)
        {
            cmbCat.DataSource = catRep.GetActives();
            cmbAuthors.DataSource = autRep.GetActives();
            lstBox.DataSource = bookRep.GetAll();
        }
       
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                BookName=txtAd.Text,
                AuthorID=selectAuthor.ID,
                
                
                
            };
            bookRep.Add(book);
            lblID.Text = Convert.ToString(book.ID);
            BookCategory bookCat = new BookCategory()
            {
                BookID = book.ID,
                CategoryID = selectCategory.ID,
            };
       
            bookCategoryRep.Add(bookCat);

            MessageBox.Show("Başarılı");
            lstBox.DataSource = bookRep.GetAll();

        }
        Author selectAuthor;
        private void cmbAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAuthors.SelectedIndex>-1)
            {
                selectAuthor = cmbAuthors.SelectedItem as Author;
            }
            else
            {

            }
        }
        Category selectCategory;
      
        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCat.SelectedIndex>-1)
            {
                selectCategory = cmbCat.SelectedItem as Category;
            }
        }
    }
}
