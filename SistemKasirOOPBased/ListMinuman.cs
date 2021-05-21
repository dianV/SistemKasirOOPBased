using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemKasirOOPBased
{
    class ListMinuman
    {
        public string Name { get; set; }
        public int Harga { get; set; }
        public int Jml { get; set; }

        public ListMinuman()
        {
        }

        public ListMinuman(string name, int harga, int jml)
        {
            Name = name;
            Harga = harga;
            Jml = jml;
        }

        public void ShowMinuman()
        {

            Console.Write(Name);
            Console.Write($"\t\t : Rp. ");
            Console.WriteLine(Harga);
        }
        
    }
}
