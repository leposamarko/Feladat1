using System;
using System.Collections.Generic;
using System.IO;

namespace Feladat1
{
    class Program
    {
        static List<Kartya> kartyak = new List<Kartya>();
        static void Main(string[] args)
        {
            Beolvasas();
            Eredmenyek();

        }
        static void Beolvasas()
        {
            string gyujto = "";
            using (StreamReader sr = new StreamReader("feladat1.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                   
                    if (!str.Equals(""))
                    {
                        gyujto += str + " ";
                    }
                    if (sr.Peek() == -1)
                    {
                        Kartya k = new Kartya(gyujto);
                        kartyak.Add(k);
                    }
                    
                    else if (str.Equals(""))
                    {
                        Kartya k = new Kartya(gyujto);
                        kartyak.Add(k);
                        gyujto = "";
                    }

                }
            }
        }

        static void Eredmenyek()
        {
            int elsokorrekt = 0;
            int masodikkorrekt = 0;
            foreach (Kartya item in kartyak)
            {
                if (item.OkesAKartya() == true)
                {
                    elsokorrekt++;
                }
                if (item.KorrektAdatok() == true)
                {
                    masodikkorrekt++;
                }

            }
            Console.WriteLine("Az elfogadható kártyák száma: " + elsokorrekt);
            Console.WriteLine("Az adatok ellenörzése utáni elfogadható kártyák száma: " + masodikkorrekt);
        }


    }
}
