using System;

namespace todo_uygulamasi;

abstract class Degerlendirme : Sonuc
{
    internal bool Calistir(string secim)
    {
        string sonuc = string.Empty;

        switch (secim)
        {
            case "1":
                sonuc = KartEkle();
                break;
            case "2":
                sonuc = KartGuncelle();
                break;
            case "3":
                sonuc = KartSil();
                break;
            case "4":
                sonuc = KartTasi();
                break;
            case "5":
                sonuc = BoardListele();
                break;
            case "6":
                return false;
            default:
                sonuc = Mesajlar.dizi[(int)Baslik.Tekrar];
                break;
        }
        Console.WriteLine("\n" + sonuc);
        return true;
    }
}