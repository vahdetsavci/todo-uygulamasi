using System;

namespace todo_uygulamasi;

static class Yardimci
{
    internal static void Yazdir(Baslik baslik)
    {
        int i = (int)baslik;
        Console.WriteLine(Mesajlar.dizi[i]);
    }
    
    internal static void Yazdir(Baslik baslik1, Baslik baslik2)
    {
        int i = (int)baslik1,
            j = (int)baslik2;

        Console.WriteLine(Mesajlar.dizi[i]);
        Console.WriteLine(Mesajlar.dizi[j]);
    }

    internal static bool Cevap()
    {
        Tekrar:
        Console.WriteLine("(E) Evet / (H) Hayır");
        Yazdir(Baslik.Cizgi);
        switch (Console.ReadLine().ToLower())
        {
            case "e":
                return true;
            case "h":
                return false;
            default:
                Yazdir(Baslik.Tekrar);
                goto Tekrar;
        }
    }

}