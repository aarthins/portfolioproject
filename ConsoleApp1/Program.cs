using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string file =@"C:\Users\Family\source\repos\ConsoleApp1\ConsoleApp1\TextFile1.txt";
            
            List<Stockoptions> lstso;
            List<Portfolios> lstpf = new List<Portfolios>();
            Portfolios pf =new Portfolios();
            Dictionary<string, float> dicsymprice = new Dictionary<string, float>();
            
            try
            {
                if (File.Exists(file))
                {
                    StreamReader reader = new StreamReader(file);
                    while (!reader.EndOfStream)
                    {
                        string str;
                        string[] strline, strarray;
                        string[] separator;
                        str = reader.ReadToEnd();
                        strline = str.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var line in strline)
                        {

                            strarray = line.Split(',');
                            lstso = new List<Stockoptions>();
                            foreach (var item in strarray)
                            {

                                separator = item.Split('-');
                                lstso.Add(new Stockoptions(separator[0], Convert.ToInt32(separator[1])));
                                if (dicsymprice.ContainsKey(separator[0].Trim()) == false)
                                {
                                    dicsymprice.Add(separator[0].Trim(), 0);
                                }

                                pf = new Portfolios(lstso);
                            }

                            lstpf.Add(pf);
                        }

                        string temp = string.Empty;

                        foreach (var key in dicsymprice)
                        {
                            temp = temp + key.Key + ',';
                        }

                        Stockoptions s = new Stockoptions();
                        s.Getstockpriceusingstockname(temp.Remove(temp.LastIndexOf(',')), ref dicsymprice);

                        List<int> lstfinal = new List<int>();

                        foreach (var p in lstpf)
                        {
                            float i = 0;
                            foreach (Stockoptions so in p.getstockoption)
                            {
                                string symbol = so.Symbol.Trim();
                                if (dicsymprice.ContainsKey(symbol))
                                {
                                    i = i + (dicsymprice[symbol] * so.Volume);
                                }
                            }
                            p.Overallprice = i;
                            lstfinal.Add(Convert.ToInt32(i));
                        }

                        var lst = lstpf.OrderByDescending(p => p.Overallprice);

                        foreach (Portfolios p in lst)
                        {
                            Console.WriteLine(p.Overallprice);
                        }
                        //Console.WriteLine(lstpf);


                        Console.ReadLine();
                    }
                
                }
                else
                {
                    Console.WriteLine("File not found");
                    
                }

               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }

  

}
