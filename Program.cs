using System;
using System.Text;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.Write();
            Printer.Write(20);
            ImprimirCursosEscuela(engine.Escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine(escuela);
            Printer.Beep(10000, qty:10);
            Printer.WriteTitle("Cursos de la escuela");

            if ( escuela?.Cursos != null)
                foreach(Curso c in escuela.Cursos)
                    WriteLine($" Curso: {c.Nombre} - {c.UniqueId}");
        }
    }
}
