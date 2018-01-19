using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Portfolios
    {
        List<Stockoptions> lststockoptions;
        private float overallprice;
        public float Overallprice
        {
            get
            { return overallprice; }
            set { overallprice = value; }
        }
        public Portfolios()
        { }
        public Portfolios(List<Stockoptions> test)
        {
            this.lststockoptions = test;
        }
        public List<Stockoptions> getstockoption
        {
            get
            {
                return this.lststockoptions;
            }
            set
            {
                this.lststockoptions = value;
            }
        }
    }
    class Stockoptions
    {
        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        private int volume;
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        
       

        public Stockoptions()
        {
        }
        public void Getstockpriceusingstockname(string stockname,ref Dictionary<string,float> dicsymbolprice)
        {
            try
            {
                Helper hpclass = new Helper();
                Dictionary<string, float> temp = hpclass.GetpricefromapiAsync(stockname).Result;
                foreach (string key in dicsymbolprice.Keys.ToList())
                {
                    foreach (var str in temp)
                    {
                        if (key == str.Key)
                        {
                            dicsymbolprice[key] = str.Value;
                        }
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        

        public Stockoptions(string syname,int unit)
        {
            this.symbol = syname;
            this.volume = unit;
         }
                 
        
    }
    
}
