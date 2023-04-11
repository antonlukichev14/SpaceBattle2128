using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceBattle2128
{
    static class Debug
    {
        private static string log = "";

        public static void AddLog(string text)
        {
            log += text + ";\n";
        }

        public static void CreateLogFile()
        {
            using (FileStream fs = File.Create("log.txt"))
            {
                byte[] log_byte = new UTF8Encoding(true).GetBytes(log);
                fs.Write(log_byte, 0, log.Length);
            }
        }
    }
}
