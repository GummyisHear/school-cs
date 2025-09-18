using Csharp.osa3;
using Csharp.osa4;
using Csharp.osa5;
using Csharp.utils;
using Inimene = Csharp.osa5.Inimene;

namespace Csharp;

class Program
{
    public static Logger Log = new Logger(nameof(Program));
    public static Random Random = new Random(69);

    static void Main(string[] args)
    {
        Log.Info("Program started");
        Console.OutputEncoding = Encoding.UTF8;
        // ----------- 5.Osa Kollektsioonid

        // #1 Ülesanne Arvuta BMR

        //Console.WriteLine("Loeme tooted failist.");
        //Funktsioonid5.LoeTootedFailist(@"..\..\..\osa5\tooted.txt", out var tooted);
        //Console.WriteLine(tooted.Select(t => $"{t.Nimi} - {t.Kaloorid100g} kcal/100g").ToCommaSepString("\n"));

        //Console.WriteLine("Sisesta oma andmed:");
        //var inimene = Inimene.LooInimene();

        //Funktsioonid5.ArvutaBMR(inimene, tooted);

        // #2 Ülesanne Makoondid
        //Funktsioonid5.Maakondid();

        // ✅ Uus ülesanne 7 – Valuutakalkulaator
        Funktsioonid5.ValuutaKalkulaator();

        // ----------- 4.Osa Failid

        //var path = @"..\..\..\Kuud.txt";
        //var lines = Failid.LoeFail(path);
        //Log.Info(lines.ToCommaSepString());

        //if (lines.Count > 0)
        //    lines[0] = "Juuli";

        //Failid.KirjutaFail(path, string.Join(Environment.NewLine, lines));

        // ----------- 3.Osa Funktsioonid

        // #1
        //FunctionsOsa3.Ruudud();

        // #2
        //var analuus = FunctionsOsa3.AnaluusiArve([2.5, 3.5, 4.5, 7.7, 5.1, 3.7935]);
        //Console.WriteLine($"Summa: {analuus.Item1:F2} Kesk: {analuus.Item2:F2} Korrutis: {analuus.Item3:F2}");

        // #3
        //var inimesed = new List<Inimene>();
        //Console.WriteLine("Loo 5 inimesed");
        //for (int i = 0; i < 5; i++)
        //{
        //    var inimene = new Inimene(Utils.Ask("Nimi: "), Utils.AskInt("Vanus: "));
        //    inimesed.Add(inimene);
        //}
        //var stat = FunctionsOsa3.Statistika(inimesed);
        //Console.WriteLine($"Summa: {stat.Item1:F2} Kesk: {stat.Item2:F2} Vanim: {stat.Item3.Nimi} Noorim: {stat.Item4.Nimi}");

        // #4
        //FunctionsOsa3.KusiMarksonani("elevant", "Arvake loomi nimi: ");

        // #5
        //FunctionsOsa3.ArvaArv();

        // #6
        //Console.WriteLine("Suurim neljarv. Sisesta 4 täisarved: ");
        //var arved = new List<int>();
        //for (var i = 0; i < 4; i++)
        //{
        //    arved.Add(Utils.AskInt("Arv: ", 1));
        //}
        //Console.WriteLine($"Suurim neljarv on {FunctionsOsa3.SuurimNeljarv(arved.ToArray())}");

        // #7
        //var rida = Utils.AskInt("Kui palju ridad: ");
        //var veerg = Utils.AskInt("Kui palju veerud: ");
        //var tabel = FunctionsOsa3.GenereeriKorrutustabel(rida, veerg);
        //for (var r = 1; r < rida + 1; r++)
        //{
        //    var line = "";
        //    for (var v = 1; v < veerg + 1; v++)
        //        line += tabel[r, v].ToString().PadRight(5);

        //    Console.WriteLine(line);
        //}


        // #8
        //var opilased = new string[]
        //{
        //    "Artjom", "niKITA", "ROMAN", "Denis", "vova", "Vadim", "Vlad", "ANTON", "ELDAR"
        //};
        //FunctionsOsa3.Opilased(opilased);

        // #9
        //int[] arvud = [2, 4, 6, 8, 10, 12];
        //FunctionsOsa3.ArvudeRuudud(arvud);

        // #10
        //int[] arvud2 = [5, -3, 0, 8, -1, 4, -7, 2, 0, -5, 6, 9];
        //FunctionsOsa3.PositiivsedJaNegatiivset(arvud2);

        // #11
        //int[] arvud3 = new int[15];
        //for (var i = 0; i < arvud3.Length; i++)
        //    arvud3[i] = Random.Next(1, 101);
        //FunctionsOsa3.KeskmisestSuuremad(arvud3);

        // #12
        //int[] arvud4 = [12, 56, 78, 2, 90, 43, 88, 67];
        //FunctionsOsa3.KoigeSuuremOtsing(arvud4);

        // #13
        //int[] arvud5 = new int[20];
        //for (var i = 0; i < arvud5.Length; i++)
        //    arvud5[i] = Random.Next(1, 101);

        //FunctionsOsa3.PaaritudJaPaaritud(arvud5.ToList());
    }
}
