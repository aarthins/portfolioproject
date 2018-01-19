using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Helper
    {

        public async Task<Dictionary<string,float>> GetpricefromapiAsync(string stocksymbol)
        {
            Dictionary<string,float> dictemp = new Dictionary<string, float>();
            HttpClient client = new HttpClient();
            //Uri uri = new Uri("http://date.jsontest.com/");
            Uri uri = new Uri("https://www.alphavantage.co/query?function=BATCH_STOCK_QUOTES&symbols="+stocksymbol+"&apikey=UNNS18E63Y4M7KA8");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var dObj = JsonConvert.DeserializeObject<RootObject>(result);


                foreach (var r in dObj.StockQuotes)
                {
                    dictemp.Add(r.symbol, Convert.ToSingle(r.__2price));
                }

                return dictemp;
            }
            else
            {
                return null;
            }
        }
        
    }

    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }
        [JsonProperty("2. Notes")]
        public string Notes { get; set; }
        [JsonProperty("3. Time Zone")]
        public string TimeZone { get; set; }
    }

    public class StockQuote
    {
        [JsonProperty("1. symbol")]
        public string symbol { get; set; }
        [JsonProperty("2. price")]
        public string __2price { get; set; }
        [JsonProperty("3. volume")]
        public string volume { get; set; }
        [JsonProperty("4. timestamp")]
        public string timestamp { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("Meta Data")]
        public MetaData _MetaData { get; set; }
        [JsonProperty("Stock Quotes") ]
        public List<StockQuote> StockQuotes { get; set; }
    }
   
}
