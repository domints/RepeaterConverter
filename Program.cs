using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RepeaterConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream inputFile = new FileStream("przemienniki_pl.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Rxf));
            Rxf data = (Rxf)serializer.Deserialize(inputFile);
            var repeaters = data.Repeaters.Repeater
                .Where(r => 
                       r.Qth != "Dublin"
                    && r.Activation.Any(a => a == "CTCSS")
                    && r.Mode.Any(m => m == "FM")
                    && r.Ctcss.Count > 0
                    && r.Band.Count < 2
                    && r.Qrg.Count <= 2)
                .OrderBy(r => r.Qra.Substring(2))
                .GroupBy(r => int.Parse(r.Qra[2].ToString()))
                .ToList();
        }
    }
}
