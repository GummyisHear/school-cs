using Csharp.utils;

namespace Csharp.osa5;

public class Toode(string nimi, float kaloorid)
{
    public string Nimi = nimi;
    public float Kaloorid100g = kaloorid;
}

public class Inimene
{
    public string Nimi;
    public int Vanus;
    public Sugu Sugu;
    public float PikkusCm;
    public float KaalKg;
    public int Aktiivsustase;

    public Inimene(string nimi, int vanus, Sugu sugu, float pikkusCm, float kaalKg, int aktiivsustase)
    {
        Nimi = nimi;
        Vanus = vanus;
        Sugu = sugu;
        PikkusCm = pikkusCm;
        KaalKg = kaalKg;
        Aktiivsustase = aktiivsustase;
    }

    public static Inimene LooInimene()
    {
        var nimi = Utils.Ask("Nimi: ");
        var vanus = Utils.AskInt("Vanus: ", min: 0);
        var suguStr = Utils.Ask("Sugu (M/N): ").ToUpper();
        var sugu = suguStr == "M" ? Sugu.Mees : Sugu.Naine;
        var pikkusCm = Utils.AskFloat("Pikkus cm: ", min: 0);
        var kaalKg = Utils.AskFloat("Kaal kg: ", min: 0);

        Console.WriteLine("Vali aktiivsustase:");
        Console.WriteLine("1 - Istuv eluviis (vähe või üldse mitte liikumist)");
        Console.WriteLine("2 - Kergelt aktiivne (kerge treening/sport 1-3 päeva nädalas)");
        Console.WriteLine("3 - Mõõdukalt aktiivne (mõõdukas treening/sport 3-5 päeva nädalas)");
        Console.WriteLine("4 - Väga aktiivne (raske treening/sport 6-7 päeva nädalas)");
        Console.WriteLine("5 - Eriti aktiivne (väga raske treening/sport ja füüsiline töö)");
        var aktiivsustase = Utils.AskInt("Aktiivsustase (1-5): ", min: 1, max: 5);

        return new Inimene(nimi, vanus, sugu, pikkusCm, kaalKg, aktiivsustase);
    }
}

public enum Sugu
{
    Mees,
    Naine
}
