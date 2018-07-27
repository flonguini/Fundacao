using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteelLibrary;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Steel steel = new Steel(10, 30, TipoBarra.Entalhada, Aderencia.Ruim, false);
            Console.WriteLine($"Valor de Lb: {steel.Lb}\nvalor de lbnec {steel.LbNec}");
            Console.ReadKey();
        }
    }
}
