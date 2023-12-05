using System;
using System.Collections.Generic;
using System.Linq;

namespace todo_uygulamasi;

sealed class Board : Line
{
    internal Line todo, inProgress, done;
    internal Line[] linelar;

    internal Board()
    {
        linelar = new Line[]
        {
            todo = new Line(),
            inProgress = new Line(),
            done = new Line()
        };
    }

    internal override void Yazdir()
    {
        for (int i = 0; i < linelar.Length; i++)
        {
            Console.WriteLine(i == 0  ? "TODO Line" : i == 1 ? "IN PROGRESS Line" : "DONE");
            linelar[i].Yazdir();
            Console.WriteLine();
        }
    }

    internal override List<Kart> KartBul(string Baslik)
    {
        List<Kart> bulunanlar = new List<Kart>();

        for (int i = 0; i < linelar.Length; i++)
        {
            bulunanlar.AddRange(linelar[i].KartBul(Baslik));
        }
        return bulunanlar;
    }
}