using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    class Helsinki2017
    {
        static List<Versenyzo> versenyzo = new List<Versenyzo>();
        static string vnev = "";
        static void Main(string[] args)
        {
            Console.WriteLine("A rövidprogram.csv beolvasása........");
            Beolvas("rovidprogram.csv");
            Console.WriteLine("A donto.csv beolvasása............");
            Beolvas2("donto.csv");
            feladat2();
            feladat3();
            feladat5();
            feladat6();
            feladat7();
            feladat8();
            Console.WriteLine("\nProgram Vége!");
            Console.ReadLine();
        }

        private static void feladat8()
        {
            using (StreamWriter iras=new StreamWriter("vegeredmeny.csv"))
            {
                int sorszam = 1;
                foreach (Versenyzo item in versenyzo.OrderByDescending(a => ÖsszPontszam(a.Nev)))
                {
                    iras.WriteLine(string.Join(";",sorszam++,item.Nev,item.Orszag,ÖsszPontszam(item.Nev)));
                }
                iras.Close();

            }
            
        }

        private static void feladat7()
        {
            Console.WriteLine("\n7.feladat");
            foreach (var item in versenyzo.FindAll(a =>a.Donto_technikai>0).GroupBy(b => b.Orszag).Select(c =>new { orszag=c.Key,db=c.Count()}).Where(d => d.db>1))
            {
                Console.WriteLine($"\t{item.orszag}:{item.db}versenyző");
            }
        }

        private static void feladat6()
        {
            Console.WriteLine("\n6.feladat:");
            Versenyzo v = versenyzo.Find(a => a.Nev.Equals(vnev));
            Console.WriteLine($"\tA versenyző összpontszáma:{ÖsszPontszam(vnev)}");
        }

        private static void feladat5()
        {
            Console.WriteLine("\n5.feladat:");
            Console.Write("\tKérem a versenyző nevét:");
            vnev = Console.ReadLine();
            Versenyzo v = versenyzo.Find(a =>a.Nev.Equals(vnev));
            if (v==null)
            {
                Console.WriteLine("\tIlyen nevű induló nem volt");
            }
            else
            {
                
            }
        }

        private static double ÖsszPontszam(string nev)
        {
            Versenyzo v = versenyzo.Find(a => a.Nev.Equals(nev));
            return v.Rovid_komponens + v.Rovid_technikai - v.Rovid_levonas+v.Donto_komponens+v.Donto_technikai-v.Donto_levonas;
        }
        private static void feladat3()
        {
            Console.WriteLine("\n3.feladat:");
            Versenyzo hun =(Versenyzo)versenyzo.Find(a => a.Orszag.Equals("HUN"));
            if (hun.Donto_technikai>0)
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kűrbe");
            }
            else
            {
                Console.WriteLine("\tA magyar versenyző nem jutott be a kűrbe");
            }
        }

        private static void feladat2()
        {
            Console.WriteLine("2.feladat:");
            Console.WriteLine($"\tA rövidprogramban {versenyzo.Count} induló volt.");
        }

        static void Beolvas(string filenev)
        {
            using (StreamReader sr=new StreamReader(filenev,Encoding.Default))
            {
                sr.ReadLine(); //fejléc beolvasása
                while (!sr.EndOfStream)
                {
                    versenyzo.Add(new Versenyzo(sr.ReadLine().Split(';')));
                }
            }
        }
        static void Beolvas2(string filenev)
        {
            using (StreamReader sr=new StreamReader(filenev))
            {
                sr.ReadLine(); //fejléc beolvasása
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    foreach (Versenyzo item in versenyzo)
                    {
                        if (item.Nev.Equals(sor[0]))
                        {
                            item.Donto_technikai = double.Parse(sor[2].Replace('.', ','));
                            item.Donto_komponens = double.Parse(sor[3].Replace('.', ','));
                            item.Donto_levonas = int.Parse(sor[4]);
                        }
                    }
                }
            }
        }
    }
}
