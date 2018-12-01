using Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class Database
    {
        private int Cont = 0;
        public void SalvarLista(List<MapSummary> summarie, List<MapSummaryN> summarieN)
        {

            int i = 0;
            var list = summarie;
            var list2 = summarieN;
            int threadNumbers = 4;
            int eachThread = summarie.Count / (threadNumbers);
            Thread thread = new Thread(() => NewMethod(summarie, i, 0, (eachThread * 1)));
            Thread thread2 = new Thread(() => NewMethod(summarie, i, eachThread * 1, eachThread * 2));
            Thread thread3 = new Thread(() => NewMethod(summarie, i, eachThread * 2, eachThread * 3));
            Thread thread4 = new Thread(() => NewMethod(summarie, i, eachThread * 3, eachThread * 4));

            thread.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            //foreach (Object ob in list)
            //{
            //    var item = list2.FirstOrDefault(o => o.MarketName == list[i].MarketName);
            //    metroGrid1.Rows.Add(list[i].MarketCurrency, list[i].BaseCurrency, list[i].MarketCurrencyLong, list[i].BaseCurrencyLong,
            //list[i].MinTradeSize, list[i].MarketName, item.Ask, list[i].IsActive, list[i].IsRestricted, list[i].Created, list[i].Notice, list[i].IsSponsored, list[i].LogoUrl);
            //    i++;
            //}

        }

        private static int NewMethod(List<MapSummary> summarie, int i, int iniciarEm, int pararEm)
        {
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-SISBMK5;Database=api;Integrated Security=true"))
            {
                conn.Open();
                List<MapSummary> summarie2 = new List<MapSummary>();
                for (int x = iniciarEm; x < pararEm; x++)
                {
                    summarie2.Add(summarie[x]);
                }
                foreach (MapSummary objeto in summarie2)
                {
                    byte[] data = null;
                    using (WebClient webClient = new WebClient())
                    {
                        data = webClient.DownloadData(objeto.LogoUrl);
                    }

                    string saveStaff = "INSERT into MapSummary VALUES ("
                        + "'" + objeto.MarketCurrency + "'" + ","
                        + "'" + objeto.BaseCurrency + "'" + ","
                        + "'" + objeto.MarketCurrencyLong + "'" + ","
                        + "'" + objeto.BaseCurrencyLong + "'" + ","
                        + objeto.MinTradeSize.ToString().Replace(',', '.') + ","
                        + "'" + objeto.MarketName + "'" + ","
                        + "'" + objeto.IsActive + "'" + ","
                        + "'" + objeto.IsRestricted + "'" + ","
                        + "'" + objeto.Created + "'" + ","
                        + "'" + objeto.Notice + "'" + ","
                        + "'" + objeto.IsSponsored + "'" + ","
                        + "'" + Convert.ToBase64String(data) + "'" +
                        ")";
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = conn;
                        querySaveStaff.CommandType = CommandType.Text;
                        querySaveStaff.CommandText = saveStaff;
                        querySaveStaff.ExecuteNonQuery();
                    }
                    int contPositionList = iniciarEm;
                    Console.WriteLine(contPositionList);
                    contPositionList++;
                    i++;
                }
                return i;
            }
        }

        public int getCont()
        {
            return Cont;
        }
    }
}
