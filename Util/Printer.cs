using System;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void Write(int tam = 10)
        {
            var linea = "".PadLeft(tam, '=');
            WriteLine(linea);
        }

        public static void WriteTitle(string title)
        {
            var size = title.Length + 4;
            Write(size);
            WriteLine($"| {title} |");
            Write(size);
        }

        public static void Beep(int hz = 2000, int time = 500, int qty = 1) 
        {
            while(qty > 0) {
                Console.Beep(hz, time);
                qty--;
            }
        }
    }
}