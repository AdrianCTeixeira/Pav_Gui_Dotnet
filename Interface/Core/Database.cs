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
        public void SalvarLista(List<MapSummary> summarie, List<MapSummaryN> summarieN)
        {
            Console.WriteLine("------------" + DateTime.Now.ToString("h:mm:ss tt") + "------------");
            int i = 0;
            try
            {
                var list = summarie;
                var list2 = summarieN;
                int threadNumbers = 10;
                int eachThread = summarie.Count / threadNumbers;

                DeleteInfo();

                Thread thread1 = new Thread(() => SaveDB(summarie, i, eachThread * 0, eachThread * 1));
                Thread thread2 = new Thread(() => SaveDB(summarie, i, eachThread * 1, eachThread * 2));
                Thread thread3 = new Thread(() => SaveDB(summarie, i, eachThread * 2, eachThread * 3));
                Thread thread4 = new Thread(() => SaveDB(summarie, i, eachThread * 3, eachThread * 4));
                Thread thread5 = new Thread(() => SaveDB(summarie, i, eachThread * 4, eachThread * 5));
                Thread thread6 = new Thread(() => SaveDB(summarie, i, eachThread * 5, eachThread * 6));
                Thread thread7 = new Thread(() => SaveDB(summarie, i, eachThread * 6, eachThread * 7));
                Thread thread8 = new Thread(() => SaveDB(summarie, i, eachThread * 7, eachThread * 8));
                Thread thread9 = new Thread(() => SaveDB(summarie, i, eachThread * 8, eachThread * 9));
                Thread thread10 = new Thread(() => SaveDB(summarie, i, eachThread * 9, summarie.Count));

                thread1.Start();
                thread2.Start();
                thread3.Start();
                thread4.Start();
                thread5.Start();
                thread6.Start();
                thread7.Start();
                thread8.Start();
                thread9.Start();
                thread10.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public List<Row> GetList()
        {
            List<Row> listObjects = new List<Row>();

            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-SISBMK5;Database=api;Integrated Security=true"))
            {
                connection.Open();
                string query = "SELECT [MarketCurrency] ," +
                    "[BaseCurrency] ," +
                    "[MarketCurrencyLong] ," +
                    "[BaseCurrencyLong] ," +
                    "[MinTradeSize] ," +
                    "[MarketName] ," +
                    "[IsActive] ," +
                    "[IsRestricted] ," +
                    "[Created] ," +
                    "[Notice] ," +
                    "[IsSponsored]," +
                    "CAST('<![CDATA[' + CAST(LogoImage as nvarchar(max)) + ']]>' AS xml) " +
                    "FROM [api].[dbo].[MapSummary] " +
                    "ORDER BY MarketCurrencyLong ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Row row = new Row();
                            row.MarketCurrency = reader.GetString(0).ToString();
                            row.BaseCurrency = reader.GetString(1).ToString();
                            row.MarketCurrencyLong = reader.GetString(2).ToString();
                            row.BaseCurrencyLong = reader.GetString(3).ToString();
                            row.MinTradeSize = reader.GetDecimal(4);
                            row.MarketName = reader.GetString(5).ToString();
                            row.IsActive = reader.GetBoolean(6);
                            row.IsRestricted = reader.GetBoolean(7);
                            row.Created = reader.GetDateTime(8);
                            row.Notice = reader.GetString(9).ToString();
                            row.IsSponsored = reader.GetBoolean(10);
                            row.LogoImage = reader.GetString(11).ToString();
                            listObjects.Add(row);
                        }
                    }
                }
                return listObjects;
            }

        }
        private static void DeleteInfo()
        {
            string deleteRegister = "DELETE FROM MapSummary";
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-SISBMK5;Database=api;Integrated Security=true"))
            {
                conn.Open();
                using (SqlCommand queryDeleteRegister = new SqlCommand(deleteRegister))
                {
                    queryDeleteRegister.Connection = conn;
                    queryDeleteRegister.CommandType = CommandType.Text;
                    queryDeleteRegister.CommandText = deleteRegister;
                    queryDeleteRegister.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        private static int SaveDB(List<MapSummary> summarie, int i, int iniciarEm, int pararEm)
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
                    Console.WriteLine(contPositionList + "  " + pararEm);
                    contPositionList++;
                    i++;
                }
                Console.WriteLine("------------" + DateTime.Now.ToString("h:mm:ss tt") + "------------");
                conn.Close();
                return i;

            }

        }
    }
}

