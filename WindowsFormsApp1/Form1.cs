using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ListProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dataGridView1.DataSource = context.Products.ToList();

            }
        }
        public void ListCategories()
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                comboBox1.DataSource = context.Categories.ToList();
                comboBox1.DisplayMember = "CategoryName"; //categoryname dekileri görüntüler
                comboBox1.ValueMember = "CategoryId"; //categoryId degerlerini alır
            }

        }
        public void ListCategoriesSec(int id)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                dataGridView1.DataSource = context.Products.Where(p => p.CategoryId == id).ToList();

            }
        }

        public void ListProductsSearch(string key)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                dataGridView1.DataSource = context.Products.Where(p => p.ProductName.Contains(key)).ToList();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListCategoriesSec(Convert.ToInt32(comboBox1.SelectedValue));
            }
            catch
            {
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string key = textBox2.Text;
            if(String.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsSearch(textBox2.Text);

            }
        }
    }
}
