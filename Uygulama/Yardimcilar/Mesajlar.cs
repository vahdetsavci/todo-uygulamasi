namespace todo_uygulamasi;

enum Baslik
{
    Yildizlar,
    Cizgi,
    Gecersiz,
    Tekrar
}

static class Mesajlar
{
    internal static string[] dizi;

    static Mesajlar()
    {
        dizi = new string[]
        {
            "*******************************************",
            "-------------------------------------------",
            "Hatalı seçim yaptınız!",
            "Hatalı seçim yaptınız, Lütfen tekrar deneyin!"
        };
    }
}