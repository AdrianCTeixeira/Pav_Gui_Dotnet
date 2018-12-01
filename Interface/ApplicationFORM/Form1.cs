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
        public void aumentarCont(int valor)
        {
            //label1.Text = valor.ToString();
        }
    }
}
