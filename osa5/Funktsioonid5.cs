using Csharp.utils;
using System.Globalization;

namespace Csharp.osa5;

internal class Funktsioonid5
{
    private static readonly Logger Log = new(typeof(Funktsioonid5));

    public static bool LoeTootedFailist(string path, out List<Toode> tooted)
    {
        tooted = [];
        if (!File.Exists(path))
        {
            Log.Error($"Faili '{path}' ei leitud");
            return false;
        }

        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length != 2)
            {
                Log.Warn($"Vigane rida: '{line}'");
                continue;
            }
            var nimi = parts[0].Trim();
            if (string.IsNullOrEmpty(nimi))
            {
                Log.Warn($"Vigane rida: '{line}'");
                continue;
            }
            if (!float.TryParse(parts[1].Trim(), CultureInfo.InvariantCulture, out var kaloorid) || kaloorid < 0)
            {
                Log.Warn($"Vigane rida: '{line}'");
                continue;
            }

            tooted.Add(new Toode(nimi, kaloorid));
        }

        return true;
    }

    public static void ArvutaBMR(Inimene inimene, List<Toode> tooted)
    {
        var caloriesMult = inimene.Aktiivsustase switch
        {
            1 => 1.2f,
            2 => 1.375f,
            3 => 1.55f,
            4 => 1.725f,
            5 => 1.9f,
            _ => 1.0f
        };

        float tdee = 0;
        float bmr = 0;
        if (inimene.Sugu == Sugu.Mees)
        {
            bmr = 88.362f + (13.397f * inimene.KaalKg) + (4.799f * inimene.PikkusCm) - (5.677f * inimene.Vanus);
            tdee = bmr * caloriesMult;
            Console.WriteLine($"{inimene.Nimi}, sinu BMR on {bmr:F2} kcal ja TDEE on {tdee:F2} kcal.");
        }
        else
        {
            bmr = 447.593f + (9.247f * inimene.KaalKg) + (3.098f * inimene.PikkusCm) - (4.330f * inimene.Vanus);
            tdee = bmr * caloriesMult;
            Console.WriteLine($"{inimene.Nimi}, sinu BMR on {bmr:F2} kcal ja TDEE on {tdee:F2} kcal.");
        }

        Console.WriteLine("-------------------------------------------------------------------");

        foreach (var toode in tooted)
        {
            var grams = (tdee / toode.Kaloorid100g) * 100;
            Console.WriteLine($"Söö {grams:F2} g {toode.Nimi}, et saada {tdee:F2} kcal.");
        }
    }

    public static void Maakondid()
    {
        var maakondid = new Dictionary<string, string>
        {
            { "Harjumaa", "Tallinn" },
            { "Tartumaa", "Tartu" },
            { "Pärnumaa", "Pärnu" },
            { "Ida-Virumaa", "Jõhvi" },
            { "Lääne-Virumaa", "Rakvere" },
            { "Viljandimaa", "Viljandi" },
            { "Raplamaa", "Rapla" },
            { "Jõgevamaa", "Jõgeva" },
            { "Järvamaa", "Paide" },
            { "Valgamaa", "Valga" },
            { "Võrumaa", "Võru" },
            { "Saaremaa", "Kuressaare" },
            { "Läänemaa", "Haapsalu" },
            { "Hiiumaa", "Kärdla" },
            { "Põlvamaa", "Põlva" }
        };

        while (true)
        {
            Console.WriteLine("1 - Leia maakond");
            Console.WriteLine("2 - Leia pealinn");
            Console.WriteLine("3 - Lisa andmed");
            Console.WriteLine("4 - Mängurežiim");
            Console.WriteLine("0 - Välju");
            var choice = Utils.AskInt("Valik: ", min: 0, max: 4);

            Console.Clear();

            string maakond;
            string pealinn;

            switch (choice)
            {
                case 1:
                    pealinn = Utils.Ask("Sisesta pealinn: ");
                    var found = maakondid.FirstOrDefault(m => m.Value.Equals(pealinn, StringComparison.OrdinalIgnoreCase));
                    if (!string.IsNullOrEmpty(found.Key))
                        Console.WriteLine($"{pealinn} on {found.Key} pealinn.");
                    else
                        Console.WriteLine($"Pealinna '{pealinn}' ei leitud.");
                    break;
                case 2:
                    maakond = Utils.Ask("Sisesta maakond: ");
                    var found2 = maakondid.FirstOrDefault(m => m.Key.Equals(maakond, StringComparison.OrdinalIgnoreCase));
                    if (!string.IsNullOrEmpty(found2.Key))
                        Console.WriteLine($"{maakond} pealinn on {found2.Value}.");
                    else
                        Console.WriteLine($"Maakonda '{maakond}' ei leitud.");
                    break;
                case 3:
                    maakond = Utils.Ask("Sisesta maakond: ");
                    pealinn = Utils.Ask("Sisesta pealinn: ");
                    maakondid.Add(maakond, pealinn);
                    Console.WriteLine($"Lisatud: {maakond} - {pealinn}");
                    break;
                case 4:
                    MaakondideMang(maakondid);
                    break;
            }

            if (choice == 0)
            {
                Console.Clear();
                Console.WriteLine("Väljun...");
                break;
            }
        }
    }

    public static void MaakondideMang(Dictionary<string, string> maakondid)
    {
        var random = new Random();
        var maakondList = maakondid.ToList();
        int kokku = 0;
        for (int i = 0; i < 5; i++)
        {
            var maakond = maakondList[random.Next(maakondList.Count)];
            var oigeVastus = "";
            var kusimus = "";
            if (random.NextSingle() < 0.5)
            {
                oigeVastus = maakond.Key;
                kusimus = $"Mis maakonna pealinn on {maakond.Value}?";
            }
            else
            {
                oigeVastus = maakond.Value;
                kusimus = $"Mis on {maakond.Key} pealinn?";
            }

            var kasutajaVastus = Utils.Ask(kusimus);
            if (kasutajaVastus.Equals(oigeVastus, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Õige!");
                kokku++;
            }
            else
            {
                Console.WriteLine($"Vale! Õige vastus on {oigeVastus}.");
            }
        }

        Console.WriteLine($"Mäng läbi! Sinu tulemus on {kokku}/5 ({kokku/5.0:P2}).");
    }

    public static void ValuutaKalkulaator()
    {
        var valuutad = new List<Valuuta>()
        {
            new Valuuta(Currency.EUR, 1.0f),
            new Valuuta(Currency.USD, 1.1f),
            new Valuuta(Currency.GBP, 0.9f),
            new Valuuta(Currency.JPY, 130.0f),
            new Valuuta(Currency.CNY, 7.0f),
            new Valuuta(Currency.NOK, 11.56f)
        };
        var dict = valuutad.ToDictionary(v => v.Nimi.ToString().ToLower(), v => v.KurssEurodes);

        Console.WriteLine("Valuuta kalkulaator");
        while (true)
        {
            Console.WriteLine("Vali esimene valuuta või sisesta 0 et väljuda.");
            Console.WriteLine($"Olevad valuutad: {valuutad.Select(i => i.Nimi).ToCommaSepString()}");
            string valuuta1 = "";
            int summa1 = 0;
            string valuuta2 = "";
            while (true)
            {
                valuuta1 = Utils.Ask("Sisesta esimene valuuta: ");
                if (dict.ContainsKey(valuuta1.ToLower()) || valuuta1 == "0")
                    break;
                Console.WriteLine("Valuuta ei leitud, proovi uuesti.");
            }

            if (int.TryParse(valuuta1, out var exit) && exit == 0)
            {
                Console.WriteLine("Väljun...");
                break;
            }

            summa1 = Utils.AskInt("Sisesta summa: ", min: 0);

            while (true)
            {
                valuuta2 = Utils.Ask("Sisesta teine valuuta: ");
                if (dict.ContainsKey(valuuta1.ToLower()) || valuuta1 == "0")
                    break;
                Console.WriteLine("Valuuta ei leitud, proovi uuesti.");
            }

            if (int.TryParse(valuuta2, out var exit2) && exit2 == 0)
            {
                Console.WriteLine("Väljun...");
                break;
            }

            var esimeneKurss = dict[valuuta1.ToLower()];
            var teineKurss = dict[valuuta2.ToLower()];

            var tulemus = (summa1 / esimeneKurss) * teineKurss;
            Console.WriteLine($"{summa1} {valuuta1.ToUpper()} on {tulemus:F2} {valuuta2.ToUpper()}");
        }
    }
}

    
