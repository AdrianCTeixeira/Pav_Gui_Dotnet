using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Model;
using MetroFramework.Controls;

namespace ApplicationFORM
{
    public partial class Form1 : Form
    {
        public List<Row> Lista = new List<Row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Api api = new Api();
            Database database = new Database();
            database.SalvarLista(api.GetInfo(), api.GetMarket());
        }
        private Image Base64ToImage(string base64)
        {
            byte[] imageBytes = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(imageBytes);

            Image image = Image.FromStream(ms, true, true);

            return image;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            var b = (Row)comboBox1.SelectedItem;
            if (b != null)
                Console.WriteLine(b.MarketCurrencyLong);
            labelMarketCurrency.Text = "MarketCurrency: " + b.MarketCurrency;
            labelBaseCurrency.Text = "BaseCurrency: " + b.BaseCurrency;
            labelMarketCurrencyLong.Text = "MarketCurrencyLong: " + b.MarketCurrencyLong;
            labelBaseCurrencyLong.Text = "BaseCurrencyLong: " + b.BaseCurrencyLong;
            labelMinTradeSize.Text = "MinTradeSize: " + b.MinTradeSize.ToString();
            labelMarketName.Text = "MarketName: " + b.MarketName;
            labelIsActive.Text = "IsActive: " + b.IsActive.ToString();
            labelIsRestricted.Text = "IsRestricted: " + b.IsRestricted.ToString();
            labelCreated.Text = "Created: " + b.Created.ToString();
            labelNotice.Text = "Notice: " + b.Notice.ToString();
            labelIsSponsored.Text = "IsSponsored: " + b.IsSponsored.ToString();
            pictureBox1.Image = Base64ToImage(b.LogoImage);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            foreach (Label lbl in metroPanel1.Controls.OfType<Label>())
            {
                //this.Controls.OfType<Label>()
                lbl.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            Database database = new Database();
            Row item = new Row();
            Lista = database.GetList();
            comboBox1.DataSource = Lista;
            
            comboBox1.ValueMember = "MarketCurrency";
            comboBox1.DisplayMember = "MarketCurrency";
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string marketCurrencyLong = ((Row)e.ListItem).MarketCurrencyLong;
            string baseCurrency = ((Row)e.ListItem).BaseCurrency;
            e.Value = marketCurrencyLong + " " + baseCurrency;
        }

        private void labelIsSponsored_Click(object sender, EventArgs e)
        {

        }

        private void labelNotice_Click(object sender, EventArgs e)
        {

        }

        private void labelCreated_Click(object sender, EventArgs e)
        {

        }

        private void labelIsRestricted_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelIsActive_Click(object sender, EventArgs e)
        {

        }

        private void labelMarketName_Click(object sender, EventArgs e)
        {

        }

        private void labelMarketCurrency_Click(object sender, EventArgs e)
        {

        }

        private void labelMinTradeSize_Click(object sender, EventArgs e)
        {

        }

        private void labelBaseCurrency_Click(object sender, EventArgs e)
        {

        }

        private void labelBaseCurrencyLong_Click(object sender, EventArgs e)
        {

        }

        private void labelMarketCurrencyLong_Click(object sender, EventArgs e)
        {

        }
    }
}
