using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NobelDogalinq
{
    class Program
    {
        public class Dijas
        {
            int ev;
            string tipus;
            string knev;
            string vnev;

            public Dijas(string csvSor)
            {
                var adatok = csvSor.Split(';');
                ev = Convert.ToInt32(adatok[0]);
                tipus = adatok[1];
                knev = adatok[2];
                vnev = adatok[3];
            }

            public int Ev { get => ev;}
            public string Tipus { get => tipus;}
            public string Knev { get => knev;}
            public string Vnev { get => vnev;}
        }
        static void Main(string[] args)
        {
            List<Dijas> dijazottak = new List<Dijas>();
            foreach (string sor in File.ReadAllLines("nobel.csv").Skip(1))
            {
                Dijas ujDijas = new Dijas(sor);
                dijazottak.Add(ujDijas);
            }

            

            foreach (Dijas dijazott in dijazottak)
            {
                if(dijazott.Ev == 2017 && dijazott.Tipus == "irodalmi")
                {
                    Console.WriteLine($"4. feladat: {dijazott.Vnev} {dijazott.Knev}");
                }
            }

            var eredmeny6 = dijazottak.Select(x=>x).Where(x => x.Vnev.Contains("Curie")).ToList();
            Console.WriteLine("6. feladat:\n");
            foreach (var item in eredmeny6)
            {
                Console.WriteLine($"\t{item.Ev}: {item.Knev} {item.Vnev}({item.Tipus})");
            }

            var eredmeny7 = dijazottak.GroupBy(x => x.Tipus).ToList();
            Console.WriteLine("7.feladat:\n");
            foreach (var item in eredmeny7)
            {
                Console.WriteLine($"\t{item.Key}\t{item.Count()}");
            }

            var eredmeny8 = dijazottak.Select(x => x).Where(x => x.Tipus == "orvosi");
            List<string> lista = new List<string>();
            foreach (var item in eredmeny8)
            {
                lista.Add($"{item.Ev};{item.Knev};{item.Vnev};{item.Tipus}");
            }
            

            File.WriteAllLines("orvosi.txt", lista);
        }
    }
}
