using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Inputfileexits()
        {
            //arrange
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleApp1.GenerateData data = new GenerateData();
                string file = @"C:\Users\Family\source\repos\ConsoleApp1\ConsoleApp1\TextFile1.txt";
                data.Calculatendisplay(file);
                string expected = @"C:\Users\Family\source\repos\ConsoleApp1\UnitTestProject1\testexpected1.txt";
                string expected1 = File.ReadAllText(expected);
                Assert.AreEqual<string>(expected1, sw.ToString());
            }
         

        }
        [TestMethod]
        public void Inputfiledoesnotexit()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleApp1.GenerateData data = new GenerateData();
                string file = @"C:\Users\Family\source\repos\ConsoleApp1\ConsoleApp1\TextFile2.txt";
                data.Calculatendisplay(file);
                string expected = "Entering calculateanddisplay  \nFile not found" + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString());
            }
        }
        [TestMethod]
        public void testtogetpricefromapi()
        {
            string stockname = "GOOG";
            Helper hpclass = new Helper();
            Dictionary<string, float> result = hpclass.GetpricefromapiAsync(stockname).Result;
            Dictionary<string, float> dictemp = new Dictionary<string, float>();
            dictemp.Add("GOOG", Convert.ToSingle(1137.7000));
            Assert.AreEqual(dictemp.ToString(), result.ToString());
        }

       


    }
}
