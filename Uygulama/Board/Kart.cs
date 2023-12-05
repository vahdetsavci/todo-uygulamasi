using System;
using System.Collections.Generic;

namespace todo_uygulamasi;

class Kart
{
    // Kişiler
    private static Dictionary<int, string> kisiler;
    internal static Dictionary<int, string> Kisiler { get => kisiler; private set => kisiler = value; }

    // Static Constructor
    static Kart()
    {
        Kisiler = new Dictionary<int, string>()
        {
            {1, "Alexandre Dumas"}, {2, "Victor Hugo"}, {3, "Vladimir Bartol"}, {4, "Paulo Coelho"}, {5, "Franz Kafka"}, {6, "Cengiz Aytmatov"}, {7, "Nazım Hikmet"}, {8, "Anthony Burgess"}, {9, "Jack London"}, {10, "Andrej Sapkowski"}
        };
    }

    // Fieldlar
    internal string baslik, icerik;
    internal KeyValuePair<int, string> kisi;
    internal Buyukluk kartBuyukluk;

    // Standart Constructorlar
    internal Kart (){}

    internal Kart(string baslik, string icerik, int kisiID, Buyukluk kartBuyukluk)
    {
        this.baslik = baslik;
        this.icerik = icerik;
        this.kisi = KisiBul(kisiID);
        this.kartBuyukluk = kartBuyukluk;
    }

    // Metotlar

    // 1.Static Metotlar
    private static KeyValuePair<int, string> KisiBul(int kisiID)    // Sadece bu sınıf için
    {
        foreach (KeyValuePair<int, string> kisi in Kisiler)
        {
            if (kisi.Key == kisiID)
                return kisi;
        }
        return default;
    }

    internal static KeyValuePair<int, string> KisiBul(out bool sonuc) // Global kullanım için
    {
        sonuc = false; 
        KeyValuePair<int, string> _kisi = default;

        int.TryParse(Console.ReadLine(), out int id);

        if (id > 0 && id < 11)
        {
            foreach (KeyValuePair<int, string> item in Kisiler)
            {
                if (item.Key == id)
                {
                    _kisi = item;
                    sonuc = true;
                }
            }
        }
        else
            Yardimci.Yazdir(Baslik.Cizgi, Baslik.Gecersiz);

        return _kisi;
    }

    internal static Buyukluk BuyuklukSec()
    {
        switch (Console.ReadLine())
        {
            case "1":
                return Buyukluk.XS;
            case "2":
                return Buyukluk.S;
            case "3":
                return Buyukluk.M;
            case "4":
                return Buyukluk.L;
            case "5":
                return Buyukluk.XL;
            default:
                Yardimci.Yazdir(Baslik.Cizgi, Baslik.Gecersiz);
                return 0;
        }
    }

    internal static Kart BilgiAl(out bool sonuc)
    {
        sonuc = false;

        Kart kart = new Kart();
        Console.Write("Başlık Giriniz                                       : ");
        kart.baslik = Console.ReadLine();
        Console.Write("İçerik Giriniz                                       : ");
        kart.icerik = Console.ReadLine();
        Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5)   : ");
        kart.kartBuyukluk = BuyuklukSec();

        if(kart.kartBuyukluk != 0)
        {
            Console.Write("Kişi Seçiniz                                         : ");
            kart.kisi = KisiBul(out bool bulunduMu);
            
            if (bulunduMu)
            {
                sonuc = true;
            }
        }

        return kart;
    }

    // 2.Sanal Metotlar
    internal virtual void Yazdir()
    {
        Yardimci.Yazdir(Baslik.Cizgi);
        Console.WriteLine($"Başlık      : {baslik}");
        Console.WriteLine($"İçerik      : {icerik}");
        Console.WriteLine($"Atanan Kişi : {kisi.Value}");
        Console.WriteLine($"Büyüklük    : {kartBuyukluk}");
        Yardimci.Yazdir(Baslik.Cizgi);
    }
}