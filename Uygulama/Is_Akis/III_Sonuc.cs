using System;
using System.Collections.Generic;
using System.Linq;

namespace todo_uygulamasi;

abstract class Sonuc
{
    private static Board board;
    private List<Kart> bulunanlar;
    private Kart bulunan;

    static Sonuc()
    {
        board = new Board();
        board.todo.kartlar.Add(new Kart("Örnek Başlık - 1", "Örnek İçerik - 1", 1, Buyukluk.XS));
        board.todo.kartlar.Add(new Kart("Örnek Başlık - 2", "Örnek İçerik - 2", 2, Buyukluk.XS));
        board.inProgress.kartlar.Add(new Kart("Örnek Başlık - 3", "Örnek İçerik - 3", 3, Buyukluk.XS));
    }

    internal string KartEkle()
    {
        Kart kart = Kart.BilgiAl(out bool sonuc);
        if (sonuc)
        {
            board.todo.kartlar.Add(kart);
            return "Kart eklendi!";
        }

        return "Kart eklenemedi!";
    }

    internal string KartGuncelle()
    {
        if (KartVarMi())
        {
            bulunan = bulunanlar[0];
            Console.WriteLine("Bulunan Kart Bilgileri: ");
            Yardimci.Yazdir(Baslik.Yildizlar);
            bulunan.Yazdir();

            Console.WriteLine("Güncellenecek kart için:");
            Kart kart = Kart.BilgiAl(out bool sonuc);

            if (sonuc)
            {
                foreach (Line _line in board.linelar)
                {
                    int i = _line.kartlar.FindIndex(I => I.baslik == bulunan.baslik);
                    if (i >= 0)
                    {
                        _line.kartlar[i] = kart;
                        return "Kart güncellendi!";
                    }
                }
            }
        }
        return "Kart güncellenemedi!";
    }

    internal string KartSil()
    {
        if (KartVarMi())    // Kullanıcının aradığı kart varsa true yoksa false return eder
        {
            foreach (Line _line in board.linelar)
            {
                foreach (Kart _kart in bulunanlar)
                {
                    _line.kartlar.RemoveAll(I => I == _kart);
                }
            }
            return "Kart/Kartlar silindi!";
        }
        else
        {
            return "Silme işlemi başarısız.";
        }
    }

    internal string KartTasi()
    {
        bool sonuc = false;

        if (KartVarMi())
        {
            Console.WriteLine("Bulunan Kart Bilgileri: ");
            Yardimci.Yazdir(Baslik.Yildizlar);
            bulunanlar[0].Yazdir();

            sonuc = LineSec();
        }
        
        switch (sonuc)
        {
            case true:
                return "Kart taşıma başarılı!";
            case false:
                return "Kart taşıma başarısız!";
        }
    }

    internal static string BoardListele()
    {
        board.Yazdir();
        return "Board listelendi!";
    }

    private bool KartVarMi()
    {
        Tekrar:

        Console.Write("Kart başlığını yazınız: ");
        bulunanlar = board.KartBul(Console.ReadLine()); // Kart bulunursa listeye eklenecek

        if (bulunanlar == null || bulunanlar.Count < 1)
        {
            Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı! Yeniden denemek ister misiniz?");
            switch (Yardimci.Cevap())
            {
                case true:
                    goto Tekrar;
                case false:
                    Console.WriteLine("İşlem iptal edildi.");
                    return false; // Kart bulunamadı!
            }
        }
        else
            return true; // Kart bulundu!
    }

    private bool LineSec()
    {
        bulunan = bulunanlar[0];
        Console.WriteLine("Taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");

        // Kartı yeni Line içerisine ekleme
        Yardimci.Yazdir(Baslik.Cizgi);
            switch (Console.ReadLine())
            {
                case "1":
                    board.linelar[0].kartlar.Add(bulunanlar[0]);
                    break;
                case "2":
                    board.linelar[1].kartlar.Add(bulunanlar[0]);
                    break;
                case "3":
                    board.linelar[2].kartlar.Add(bulunanlar[0]);
                    break;
                default:
                    Yardimci.Yazdir(Baslik.Gecersiz);
                    return false;
            }

            // Kartı eski Line içerisinden silme
            int i = -1;
            foreach (Line _line in board.linelar)
            {
                i = _line.kartlar.FindIndex(I => I.baslik == bulunan.baslik);
                if (i >= 0)
                {
                    _line.kartlar.RemoveAt(i); // Eski kart siliniyor.
                    break;
                }
            }
            return true;
    }

}