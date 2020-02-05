using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA200205B
{
    class Program
    {
        static int osszPont = 0;
        static void Main()
        {
            Kiiras();
            Teszt();
            Ertekeles();
        }

        private static void Ertekeles()
        {
            Console.Clear();
            Console.WriteLine($"15/{osszPont} pont");
            if (15 == osszPont) Console.WriteLine("gratulálok!");
            Console.WriteLine("Folytatáshoz nyomjon ESC-t...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
                Console.Write("\b \b");
        }

        private static void Teszt()
        {
            var srt = new StreamReader(@"..\..\res\teszt.txt");
            var srm = new StreamReader(@"..\..\res\megoldas.txt");

            while (!srt.EndOfStream)
            {
                Console.Clear();
                Console.WriteLine(srt.ReadLine());
                for (int i = 0; i < 3; i++)
                    Console.WriteLine("\t" + srt.ReadLine());

                Console.Write("Helyes válasz betűjele: ");

                var v = Console.ReadKey();
                if(v.KeyChar == char.Parse(srm.ReadLine().ToLower()))
                {
                    Console.WriteLine("\n\n\tjó válasz");
                    osszPont++;
                }
                else
                {
                    Console.WriteLine("\n\n\trossz válasz");
                }

                Thread.Sleep(1000);
            }


            srt.Close();
            srm.Close();
        }

        private static void Kiiras()
        {
            Console.CursorVisible = false;
            var sr = new StreamReader(@"..\..\res\feladat.txt");
            Console.WriteLine(sr.ReadLine());
            sr.Close();
            Console.WriteLine("Folytatáshoz nyomjon ENTER-t...");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
                Console.Write("\b \b");
        }
    }
}
