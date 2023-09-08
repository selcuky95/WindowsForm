using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10.Gun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci takip Otomasyonu
            //-----------------------
            // 1- Öğrenci Ekle
            // 2- Öğrenci listele
            // 3- Öğrenci Sil
            // 4- Öğrencilerin Genel Not Ortalaması
            // 5- DateTime Yaş Ortalaması
            // 6- Toplam Öğrenci Sayısı
            // 0- Çıkış
            // Bir seçim yapınız:

            // Ad - Soyad - Not1 - Not2 - Doğum Tarihi
            // string-double-DateTime-int

            ConsoleKey cevap;
            do
            {
                Console.Clear();
                Console.WriteLine("ÖĞRENCİ KAYIT OTOMASYONU");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1- Öğrenci Ekle");
                Console.WriteLine("2- Öğrencileri Listele");
                Console.WriteLine("3- Öğrenci Sil");
                Console.WriteLine("4- Öğrencilerin Genel Not Ortalaması");
                Console.WriteLine("5- Yaş Ortalaması");
                Console.WriteLine("6- Toplam Öğrenci Sayısı");
                Console.WriteLine("0- Çıkış");
                Console.WriteLine();

                Console.Write("Bir işlem giriniz: ");
                cevap = Console.ReadKey().Key;
                Menu.Islemler(cevap);

            } while (cevap != ConsoleKey.NumPad0 && cevap != ConsoleKey.D0);

            Console.Clear();
            Console.WriteLine("Çıkış Yapılıyor. Bir tuşa basınız");
            Console.WriteLine("Kapatmak için bir tuşa basınız");


            Console.ReadKey();
        }
    }
}
