using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemKasirOOPBased
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ListMinuman> DaftarMinuman = new List<ListMinuman>();
            DaftarMinuman.Add(new ListMinuman("Kopi",15000,0));
            DaftarMinuman.Add(new ListMinuman("Teh",5000,0));
            DaftarMinuman.Add(new ListMinuman("Jus",10000,0));
            //foreach (var List in DaftarMinuman)
            //{
            //    List.ShowMinuman();
            //}
            Menu(DaftarMinuman);
        }
        static void Menu(List<ListMinuman> listBeli)
        {
            int mainloop = 1;
            while (mainloop == 1)
            {
                Console.WriteLine("---SELAMAT DATANG DI SISTEM KASIR MINUMAN---");
                Console.WriteLine("");
                Console.WriteLine("Silahkan pilih menu yg tersedia");
                Console.WriteLine("1. BELI BARANG");
                Console.WriteLine("2. KELUAR");
                int choise;
                while (true)
                {
                    try
                    {
                        choise = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Terjadi kesalahan input\ninput anda bukan angka \nsilahkan input lagi");

                    }
                }
                switch (choise)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=====Daftar Minuman yg tersedia======");
                        int i = 1;
                        foreach (var List in listBeli)
                        {
                            Console.Write($"No. {i} ");
                            List.ShowMinuman();
                            i++;
                        }
                        int loop = 1;
                        
                        while (loop == 1)
                        {
                            Console.Write("Silahkan masukan nomor minuman yg ingin di beli ");
                            int numMinuman;
                            int temp = 0;

                            while (true)
                            {
                                try
                                {
                                    numMinuman = (Convert.ToInt32(Console.ReadLine()) - 1);
                                    if (numMinuman >= 0 && numMinuman <= 2)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        throw (new DiluarMenu("input anda diluar menu"));
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("maaf terjadi kesalaah {0}", e.Message);
                                    Console.WriteLine("silahkan input lagi");
                                }
                            }

                            Console.WriteLine("Berapa banyak minuman yg ingin di beli ");
                            while (true)
                            {
                                try
                                {
                                    temp = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("maaf terjadi kesalaah ketika input \nsilahkan input lagi");
                                }

                            }
                            listBeli[numMinuman].Jml = listBeli[numMinuman].Jml + temp;

                            Console.WriteLine("Apakah anda ingin membeli minuman lainnya? ");
                            Console.WriteLine("1. ya ");
                            Console.WriteLine("2. tidak");
                            while (true)
                            {
                                try
                                {
                                    loop = Convert.ToInt32(Console.ReadLine());
                                    if (loop > 0 && loop < 3)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        throw (new DiluarMenu("input anda diluar menu"));
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("maaf terjadi kesalaah {0}", e.Message);
                                    Console.WriteLine("terjadi kesalaan input\nsilahkan input lagi");
                                }
                            }
                        }
                        CetakNota(listBeli);
                        break;

                    case 2:
                        mainloop = 2;
                        break;
                    default:
                        Console.WriteLine("maaf inputan anda diluar cangkupan menu\npencet keyboard untuk melanjutkan");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }


        }
        public class DiluarMenu : Exception
        {

            public DiluarMenu(string message) : base(message)
            {

            }
        }
        static void CetakNota(List<ListMinuman> listBeli)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("||   Nota pembelian minuman  \t ||");
            int total = 0;
            foreach (var List in listBeli)
            {
                Console.WriteLine($"{List.Name}....x {List.Jml}");
                total = total + (List.Jml * List.Harga);
            }
            Console.WriteLine("||                        \t ||");
            Console.WriteLine("||       Total ...... Rp" + total + "\t ||");
            listBeli.Clear();
            Console.ReadKey();
            Console.Clear();

        }
    }
}
