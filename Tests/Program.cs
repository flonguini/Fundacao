using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundacao.Models;
using SteelLibrary;
using SapataLibrary.Model;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Steel steel = new Steel(10, 30, TipoBarra.Entalhada, Aderencia.Ruim, false);
            //Console.WriteLine($"Valor de Lb: {steel.Lb}\nvalor de lbnec {steel.LbNec}");

            //Foo foo = new Foo { A = 1, B = "abc" };
            //foreach (var prop in foo.GetType().GetProperties())
            //{
            //    Console.WriteLine("{0}", prop.Name);
            //}

        }
    }

    class Foo
    {
        public int A { get; set; }
        public string B { get; set; }
    }
}
