using System;
using System.Collections.Generic;

namespace todo_uygulamasi;

class Line : Kart
{
    internal List<Kart> kartlar;

    internal Line()
    {
        kartlar = new List<Kart>();
    }

    internal override void Yazdir()
    {
        Yardimci.Yazdir(Baslik.Yildizlar);
        if (kartlar != null && kartlar.Count > 0)
            kartlar.ForEach(I => I.Yazdir());
        else
            Console.WriteLine("~ Boş ~");
    }

    internal virtual List<Kart> KartBul(string Baslik)
    {
        return kartlar.FindAll(I => I.baslik == Baslik);
    }
}