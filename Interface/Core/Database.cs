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
using System.Threading.Tasks;

namespace Core
{
    public class Database
    {
        private int Cont = 0;
        public void SalvarLista(List<MapSummary> summarie, List<MapSummaryN> summarieN)
        {
            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = api; User Id = sa;Password = sqlserver;"))
            {
                connection.Open();
                int i = 0;
                var list = summarie;
                var list2 = summarieN;
                foreach (MapSummary objeto in summarie)
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
                        querySaveStaff.Connection = connection;
                        querySaveStaff.CommandType = CommandType.Text;
                        querySaveStaff.CommandText = saveStaff;
                        querySaveStaff.ExecuteNonQuery();
                    }
                    Console.WriteLine(i);
                    i++;
                    System.Threading.Thread.Sleep(100);
                    return;
                }
                connection.Close();

                Console.WriteLine("");
                //foreach (Object ob in list)
                //{
                //    var item = list2.FirstOrDefault(o => o.MarketName == list[i].MarketName);
                //    metroGrid1.Rows.Add(list[i].MarketCurrency, list[i].BaseCurrency, list[i].MarketCurrencyLong, list[i].BaseCurrencyLong,
                //list[i].MinTradeSize, list[i].MarketName, item.Ask, list[i].IsActive, list[i].IsRestricted, list[i].Created, list[i].Notice, list[i].IsSponsored, list[i].LogoUrl);
                //    i++;
                //}
            }
        }
        public int getCont()
        {
            return Cont;
        }
    }
}
