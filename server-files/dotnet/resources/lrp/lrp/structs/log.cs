using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace lrp.structs
{
    public class log
    {
        public static void Log(string text, ConsoleColor cc = ConsoleColor.Red) {
            string format = $"[LOG] {DateTime.Now} : {text}";

            Console.BackgroundColor = cc;

            NAPI.Util.ConsoleOutput(format);

            Console.ResetColor();

        }
    }
}
