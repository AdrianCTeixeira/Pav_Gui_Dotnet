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

        private SqlConnection _conn = null;

        public SqlConnection Connect()
        {
            if (_conn == null || _conn.State == ConnectionState.Closed)
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=api;User Id=sa; Password =sqlserver");
                connection.Open();
                _conn = connection;
                return _conn;

            }
            else if (_conn.State == ConnectionState.Open)
            {
                return _conn;
            }
            return null;
        }

        public void Close()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public List<Thread> SalvarLista(List<MapSummary> summarie, List<MapSummaryN> summarieN)
        {
            Console.WriteLine("------------" + DateTime.Now.ToString("h:mm:ss tt") + "------------");
            List<Thread> threads = new List<Thread>();
            try
            {
                int threadNumbers = 10;

                for (int index = 1; index <= threadNumbers; index++)
                {
                    Thread thread = new Thread(() => SaveDB(summarie, summarieN, index, threadNumbers));
                    thread.Start();
                    Thread.Sleep(10);
                    threads.Add(thread);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return threads;
        }
        public List<Coin> SelectBD()
        {
            List<Coin> listObjects = new List<Coin>();

            using (SqlConnection connection = Connect())
            {

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
                    "CAST('<![CDATA[' + CAST(LogoImage as nvarchar(max)) + ']]>' AS xml), " +
                    "[Price] " +
                    "FROM [api].[dbo].[MapSummary] " +
                    "ORDER BY MarketCurrencyLong ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listObjects.Add(CoinFromDBRow(listObjects, reader));
                        }
                    }
                }
                return listObjects;
            }

        }

        private Coin CoinFromDBRow(List<Coin> listObjects, SqlDataReader reader)
        {
            Coin coinRow = new Coin();
            coinRow.MarketCurrency = reader.GetString(0).ToString();
            coinRow.BaseCurrency = reader.GetString(1).ToString();
            coinRow.MarketCurrencyLong = reader.GetString(2).ToString();
            coinRow.BaseCurrencyLong = reader.GetString(3).ToString();
            coinRow.MinTradeSize = reader.GetDecimal(4);
            coinRow.MarketName = reader.GetString(5).ToString();
            coinRow.IsActive = reader.GetBoolean(6);
            coinRow.IsRestricted = reader.GetBoolean(7);
            coinRow.Created = reader.GetDateTime(8);
            coinRow.Notice = reader.GetString(9).ToString();
            coinRow.IsSponsored = reader.GetBoolean(10);
            coinRow.LogoImage = reader.GetString(11).ToString();
            coinRow.Price = reader.GetDecimal(12);
            return coinRow;
        }

        public void DeleteBD()
        {
            string deleteRegister = "DELETE FROM MapSummary";
            using (SqlConnection connection = this.Connect())
            {

                using (SqlCommand queryDeleteRegister = new SqlCommand(deleteRegister))
                {
                    queryDeleteRegister.Connection = connection;
                    queryDeleteRegister.CommandType = CommandType.Text;
                    queryDeleteRegister.CommandText = deleteRegister;
                    queryDeleteRegister.ExecuteNonQuery();
                }

            }
        }
        private int SaveDB(List<MapSummary> _summarieAll, List<MapSummaryN> summarieN, int index, int threadNumbers)
        {
            // _summarieAll.Count = 293
            // index = 10
            // threadNumbers = 10

            int cadaThreadTem = _summarieAll.Count / threadNumbers; //29,3

            int pararEm = (cadaThreadTem * index) - 1;// 29,3 * 9 = 
            int iniciarEm = (pararEm - cadaThreadTem) + 1; // 29,3 - 29,3 = 0
            if (cadaThreadTem * (index + 1) > _summarieAll.Count)
            {
                pararEm = _summarieAll.Count;
            }
            Console.WriteLine("Iniciar Em: " + iniciarEm + " pararEm: " + (decimal)pararEm);

            try
            {
                SqlConnection connection = new SqlConnection("Server=localhost;Database=api;User Id=sa; Password =sqlserver");
                connection.Open();

                List<Coin> coin = new List<Coin>();
                List<MapSummary> summarieAll = new List<MapSummary>();
                int countFinal = pararEm + 1;
                if (countFinal + 1 > _summarieAll.Count)
                {
                    countFinal = _summarieAll.Count;
                }
                for (int x = iniciarEm; x < countFinal; x++)
                {
                    summarieAll.Add(_summarieAll[x]);
                }

                foreach (MapSummary objeto in summarieAll)
                {
                    var item = summarieN.FirstOrDefault(o => o.MarketName == summarieAll.First().MarketName);
                    Coin newCoin = CreateCoin(objeto, item);
                    if (newCoin.Price == 0)
                    {
                        coin.Add(CreateCoin(objeto));
                        Console.WriteLine("null");
                    }
                    else
                    {
                        coin.Add(newCoin);
                    }
                }
                Console.WriteLine("--------------------" + coin.Count + "-----------------------");

                foreach (Coin objeto in coin)
                {
                    byte[] data = null;
                    WebClient webClient = new WebClient();

                    data = webClient.DownloadData(objeto.LogoImage);

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
                        + "'" + Convert.ToBase64String(data) + "'" + ","
                        + "'" + objeto.Price.ToString().Replace(",", ".") + "'" +
                        ")";
                    SqlCommand querySaveStaff = new SqlCommand(saveStaff);

                    querySaveStaff.Connection = connection;
                    querySaveStaff.CommandType = CommandType.Text;
                    querySaveStaff.CommandTimeout = 600;
                    querySaveStaff.CommandText = saveStaff;
                    querySaveStaff.ExecuteNonQuery();


                    int contPositionList = iniciarEm;
                    contPositionList++;

                }
                Console.WriteLine("--------------------*" + coin.Count + "-*----------------------");

                Console.WriteLine("------------" + DateTime.Now.ToString("h:mm:ss tt") + "------------");
                return 0;

            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO SAVEDB" + e.Message);
                return 0;
            }
        }

        private static Coin CreateCoin(MapSummary objeto, MapSummaryN item)
        {
            Coin coin = new Coin();
            coin.MarketCurrency = objeto.MarketCurrency;
            coin.BaseCurrency = objeto.BaseCurrency;
            coin.MarketCurrencyLong = objeto.MarketCurrencyLong;
            coin.BaseCurrencyLong = objeto.BaseCurrencyLong;
            coin.MinTradeSize = objeto.MinTradeSize;
            coin.MarketName = objeto.MarketName;
            coin.Price = item.Last;
            coin.IsActive = objeto.IsActive;
            coin.IsRestricted = objeto.IsRestricted;
            coin.Created = objeto.Created;
            coin.Notice = objeto.Notice;
            coin.IsSponsored = objeto.IsSponsored;
            coin.LogoImage = objeto.LogoUrl;
            return coin;
        }

        private static Coin CreateCoin(MapSummary objeto)
        {
            Coin coin = new Coin();
            coin.MarketCurrency = objeto.MarketCurrency;
            coin.BaseCurrency = objeto.BaseCurrency;
            coin.MarketCurrencyLong = objeto.MarketCurrencyLong;
            coin.BaseCurrencyLong = objeto.BaseCurrencyLong;
            coin.MinTradeSize = objeto.MinTradeSize;
            coin.MarketName = objeto.MarketName;
            coin.Price = 0;
            coin.IsActive = objeto.IsActive;
            coin.IsRestricted = objeto.IsRestricted;
            coin.Created = objeto.Created;
            coin.Notice = objeto.Notice;
            coin.IsSponsored = objeto.IsSponsored;
            coin.LogoImage = objeto.LogoUrl;
            return coin;
        }
    }
}

