using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace RepeaterConverter
{
    public static class ICOM
    {
        private const string hdr = "CH No;Name;SEL;Frequency;Dup;Offset;Mode;DATA;Filter;TONE;Repeater Tone;TSQL Frequency;DTCS Code;DTCS Polarity;DV SQL;DV CSQL Code;Your Call Sign;RPT1 Call Sign;RPT2 Call Sign;Split;Frequency(2);Dup(2);Offset(2);Mode(2);DATA(2);Filter(2);TONE(2);Repeater Tone(2);TSQL Frequency(2);DTCS Code(2);DTCS Polarity(2);DV SQL(2);DV CSQL Code(2);Your Call Sign(2);RPT1 Call Sign(2);RPT2 Call Sign(2)\r\n";
        //                             {id};{znak};OFF;{tx};{dir};{offset} ;FM;OFF;2;TONE;{ctcss};88,5Hz;023;BOTH N;OFF;0;CQCQCQ;;;OFF;
        //                             01;SR9C;OFF;145,600000;DUP-;0,600000;FM;OFF;2;TONE;103,5Hz;88,5Hz;023;BOTH N;OFF;0;CQCQCQ;;;OFF;{tx};OFF;{offset};FM;OFF;2;OFF;88,5Hz;88,5Hz;023;BOTH N;OFF;0;CQCQCQ;;
        private const string baseRow = "{0:D2};{1};OFF;{2:0.000000};{3};{4:0.000000};FM;OFF;2;TONE;{5:0.0}Hz;88,5Hz;023;BOTH N;OFF;0;CQCQCQ;;;OFF;{2:#.######};OFF;{4:#.######};FM;OFF;2;OFF;88,5Hz;88,5Hz;023;BOTH N;OFF;0;CQCQCQ;;\r\n";
        private const string emptyRow = "{0};;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\r\n";
        public static void Generate(List<IGrouping<int, Repeater>> repeaters)
        {
            var groups = repeaters.GetMax100Groups();
            char letter = 'a';
            foreach(var group in groups)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(hdr);
                int currentRow = 1;
                foreach(var repeater in group)
                {
                    var ftx = decimal.Parse(repeater.Qrg.Find(q => q.Type == "tx").Text, CultureInfo.InvariantCulture);
                    var frx = decimal.Parse(repeater.Qrg.Find(q => q.Type == "rx").Text, CultureInfo.InvariantCulture);
                    var off = ftx - frx;
                    var ctcss = decimal.Parse(repeater.Ctcss.Find(c => c.Type == "rx").Text, CultureInfo.InvariantCulture);
                    sb.AppendFormat(baseRow, currentRow, repeater.Qra, ftx, off > 0 ? "DUP-" : "DUP+", off, ctcss);
                    currentRow++;
                }
                while (currentRow < 100)
                {
                    sb.AppendFormat(emptyRow, currentRow++);
                }

                File.WriteAllText($"./ICOM/data{letter++}.csv", sb.ToString());
            }
        }
    }
}