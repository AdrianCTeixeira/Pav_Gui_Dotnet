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

namespace ApplicationFORM
{
    public partial class Form1 : Form
    {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem == null) return;
            //var b = (Row)comboBox1.SelectedItem;
            //if (b != null)
            //    Console.WriteLine(b.MarketCurrencyLong);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            Row item = new Row();
            var Lista = database.GetList();
            foreach (Row objeto in Lista)
            {
                comboBox1.Items.Add(objeto.MarketCurrencyLong + " ---- " + objeto.BaseCurrency);
            }            
        }
    }
}
