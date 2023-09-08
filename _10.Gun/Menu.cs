using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Gun
{
    public static class Menu
    {
        static List<Ogrenci>ogrenciler =new List<Ogrenci>();
        public static void Islemler(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ekle("EKLE");
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Listele("Öğrencileri Listele");
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Sil("Öğrenci Sil");
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    Ortalama("Genel Not Ortalaması");
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    YasOrtalamasi("Öğrencilerin yaş ortalaması");
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    BaslikYazdir("Toplam Öğrenci Sayısı");
                    AnaMenuyeDon(string.Format("Toplam {0} öğrenci kayıtlıdır", ogrenciler.Count));
                    break;

            }
        }

        private static void YasOrtalamasi(string v)
        {
            if (ogrenciler.Any())
            {
                BaslikYazdir(v);
                int toplamYas = 0;
                foreach (var item in ogrenciler)
                {
                    toplamYas += item.Yas;
                }
                double yasOrtalamasi = toplamYas / ogrenciler.Count;
                AnaMenuyeDon(string.Format("Toplam {0} öğrencinin yaş ortalaması {1}", ogrenciler.Count, Math.Round(yasOrtalamasi, 2)));
            }
            else
            {
                AnaMenuyeDon("Listede Öğrenci bulunamadı");
            }
        }

        private static void Ortalama(string v)
        {
            BaslikYazdir(v);
            if (ogrenciler.Any())
            {
                double genelToplam = 0;
                foreach (var item in ogrenciler)
                {
                    genelToplam += item.Ortalama;
                }
                double genelOrtalama = genelToplam / ogrenciler.Count;
                AnaMenuyeDon(string.Format("Toplam{0} öğrencinin ortalaması {1}", ogrenciler.Count, Math.Round(genelOrtalama, 2)));
            }
            else
            {
                AnaMenuyeDon("Listede öğrenci bulunamadı");
            }
        }

        private static void Sil(string v)
        {
            BaslikYazdir(v);
            if (ogrenciler.Any())
            {
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    ogrenciler[i].Yazdir(i + 1);
                }
                Console.WriteLine();
                int siraNo = Metodlar.GetInt("Silmek istediğiniz öğrencinin sıra numarasını giriniz\nAna menüye dönmek için 0'a basınız",ogrenciler.Count );
                if (siraNo == 0)
                {
                    AnaMenuyeDon("Silme işlemi iptal edildi");
                }
                else
                {
                    int indexNo = siraNo - 1;
                    Console.Write(ogrenciler[indexNo].TamAd+"Öğrencisini silmek istediğinize enin misiniz?(e)");
                    if (Console.ReadKey().Key==ConsoleKey.E)
                    {
                        string silinen = ogrenciler[indexNo].TamAd;
                        ogrenciler.RemoveAt(indexNo);
                        AnaMenuyeDon(string.Format("{0} öğrencisi başarıyla silinmiştir", silinen));
                    }
                    else
                    {
                        AnaMenuyeDon("Silme işlemi iptal edildi");
                    }
                }
            }
            else
            {
                AnaMenuyeDon("Listede öğrenci bulunamadı");
            }
        }

        private static void Listele(string v)
        {
            #region
            // Any metodu kontrol yaparak bool tipinde değer döndürür. koleksiyonlarda değer varsa true yoksa false döndürür 
            #endregion
            if (ogrenciler.Any()) // ogrenciler.Count>0
            {
                BaslikYazdir(v);
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    ogrenciler[i].Yazdir(i + 1);
                }
                AnaMenuyeDon(string.Format("{0} Öğrencisi listeye başarıyla eklenmiştir", ogrenciler.Count));    
            }
            else
            {
                AnaMenuyeDon("Listede öğrenci bulunamadı");
            }
        }

        private static void ekle(string v)
        {
            BaslikYazdir(v);
            Ogrenci O = new Ogrenci();
            O.Ad = Metodlar.GetString("Öğrenci Adı: ",2,15);
            O.Soyad = Metodlar.GetString("Soyadı: ", 2, 15);
            O.N1 = Metodlar.GetDouble("1. Notu: ", 0, 100);
            O.N2 = Metodlar.GetDouble("2. Notu: ", 0, 100);
            O.DogumTarihi = Metodlar.GetDateTime("Doğum Tarihi: ", 1998, 2006);
            ogrenciler.Add(O);
            AnaMenuyeDon(string.Format("{0}. Öğrenci listeye başarıyla eklendi", O.TamAd));
        }

        private static void AnaMenuyeDon(string v)
        {
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Ana Menüye dönmek için bir tuşa basınız");
            Console.ReadKey();
        }

        private static void BaslikYazdir(string v)
        {
            Console.WriteLine(v);
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }
    }
}
