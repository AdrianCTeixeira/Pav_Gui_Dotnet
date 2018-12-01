using Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Core
{
    public class Api
    {
        public List<MapSummary> GetInfo()
        {
            List<MapSummary> lstRetorno = new List<MapSummary>();
            string json = GetHtmlBody("https://bittrex.com/api/v1.1/public/getmarkets");
            JObject respostaJson = JObject.Parse(json);

            var newInfo = JsonConvert.DeserializeObject<JsonMapSummary>(respostaJson.ToString());
            return newInfo.Result.ToList();
        }
        public List<MapSummaryN> GetMarket()
        {
            List<MapSummaryN> lstRetorno = new List<MapSummaryN>();
            string json = GetHtmlBody("https://bittrex.com/api/v1.1/public/getmarketsummaries");
            JObject respostaJson = JObject.Parse(json);

            var newInfo = JsonConvert.DeserializeObject<JsonMapSummaryN>(respostaJson.ToString());
            return newInfo.Result.ToList();
        }
        private string GetHtmlBody(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                string data = readStream.ReadToEnd();
                return data;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
