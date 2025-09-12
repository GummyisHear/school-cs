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
}

    
