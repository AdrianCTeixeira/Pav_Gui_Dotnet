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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Model;
using MetroFramework.Controls;

namespace ApplicationFORM
{
    public partial class Form1 : Form
    {
        public List<Coin> Lista = new List<Coin>();
        public Form1()
        {
            InitializeComponent();
        }

        private bool DisableLoading(List<Thread> listThreads)
        {

            foreach (var t in listThreads)
            {
                if (t.IsAlive)
                {
                    return false;
                }
            }

            return true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Api api = new Api();
            Database database = new Database();
            Console.WriteLine("db deletado");
            database.DeleteBD();
            List<Thread> listThread = database.SalvarLista(api.GetInfo(), api.GetMarket());
            while (!DisableLoading(listThread))
            {
                Thread.Sleep(1000);
                Console.WriteLine("Carregando. " + listThread.Count + " / 10");
            }

            Console.WriteLine("Finalizado");

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
            var coin = (Coin)comboBox1.SelectedItem;
            if (coin != null)
            {
                Console.WriteLine(coin.MarketCurrencyLong);
                DefineLabels(coin);
            }
            foreach (Label lbl in metroPanel1.Controls.OfType<Label>())
            {
                //this.Controls.OfType<Label>()
                lbl.Visible = true;
            }
        }

        private void DefineLabels(Coin b)
        {
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
            labelPrice.Text = "Price: " + b.Price.ToString();
            pictureBox1.Image = Base64ToImage(b.LogoImage);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            Database database = new Database();
            Coin item = new Coin();

            Lista = database.SelectBD();
            comboBox1.DataSource = Lista;

            comboBox1.ValueMember = "MarketCurrency";
            comboBox1.DisplayMember = "MarketCurrency";
            //database.Close();
        }

        private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            string marketCurrencyLong = ((Coin)e.ListItem).MarketCurrencyLong;
            string baseCurrency = ((Coin)e.ListItem).BaseCurrency;
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
