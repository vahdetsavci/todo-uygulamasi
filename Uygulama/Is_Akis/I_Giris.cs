using System;

namespace todo_uygulamasi;

sealed class Giris : Degerlendirme
{
    internal void SecimYap()
    {
        Tekrar:
        Yardimci.Yazdir(Baslik.Yildizlar);
        Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
        Yardimci.Yazdir(Baslik.Yildizlar);
        Console.WriteLine("\r (1) Kart Ekle \n (2) Kart Güncelle \n (3) Kart Sil \n (4) Kart Taşı \n (5) Board Listele \n (6) Çıkış Yap");
        Yardimci.Yazdir(Baslik.Cizgi);
        string secim = Console.ReadLine();
        Yardimci.Yazdir(Baslik.Cizgi);

        bool devamMi = Calistir(secim);
        switch (devamMi)
        {
            case true:
                goto Tekrar;
            default:
                break;
        }
    }
}