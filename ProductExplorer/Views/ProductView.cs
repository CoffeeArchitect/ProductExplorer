using ProductExplorer.Presenters;
using ProductExplorer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductExplorer.Forms
{
    public partial class ProductView : Form, IProductView
    {
        

        public ProductView()
        {
            InitializeComponent();
            
        }
        public string ProductArticle
        {
            get { return articleTxtBox.Text; }
            set { articleTxtBox.Text = value; }
        }

        public string ProductName
        {
            get { return articleTxtBox.Text; }
            set { articleTxtBox.Text = value; }
        }

        public decimal ProductPrice
        {
            get { return decimal.Parse(priceTxtBox.Text); }
            set { priceTxtBox.Text = value.ToString(); }
        }

        public int ProductQuantity
        {
            get { return int.Parse(qtyTxtBox.Text); }
            set { qtyTxtBox.Text = value.ToString(); }
        }

        public Image ProductImage
        {
            get { return pbProductImage.Image; }
            set { pbProductImage.Image = value; }
        }

        public void ShowView()
        {
            Show();
        }

        public void CloseView()
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
