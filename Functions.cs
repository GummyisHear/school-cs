using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Functions
    {
        public static Logger Log = new Logger(nameof(Functions));

        public static float Kalkulaator(float arv1, float arv2)
        {
            var k = arv1 * arv2;
            return k;
        }

        public static string Kuu_nimetus(int kuu_number)
        {
            return kuu_number switch
            {
                1 => "Jaanuar",
                2 => "Veebruar",
                3 => "Märts",
                4 => "Aprill",
                5 => "Mai",
                6 => "Juuni",
                7 => "Juuli",
                8 => "August",
                9 => "September",
                10 => "Oktoober",
                11 => "November",
                12 => "Detsember",
                _ => "Vigane kuu number"
            };
        }

        public static string Hooaeg(int kuu_nr)
        {
            if (kuu_nr == 1 || kuu_nr == 2 || kuu_nr == 12)
            {
                return "Talv";
            }
            else if (kuu_nr >= 3 && kuu_nr <= 5)
            {
                return "Kevad";
            }
            else if (kuu_nr >= 6 && kuu_nr <= 8)
            {
                return "Suvi";
            }
            else if (kuu_nr >= 9 && kuu_nr <= 11)
            {
                return "Sügis";
            }

            return "Vigane kuu number";
        }

        public static void KusiKuu()
        {
            Console.WriteLine("Kas tahad dekodeerida arv->nimetusse?");
            var vastus = Console.ReadLine()?.ToLower() ?? "";
            if (vastus != "jah")
            {
                Console.WriteLine("Ei taha, siis ei taha");
            }
            else
            {
                Console.Write("Kuu nr: ");
                if (!int.TryParse(Console.ReadLine(), out var kuu))
                {
                    Log.Error("Sisesta ainult täisarv!");
                    return;
                }

                Console.WriteLine($"{Kuu_nimetus(kuu)}-{Hooaeg(kuu)}");
            }
        }

        public static void JukuPilet()
        {
            Console.Write("Mis on sinu nimi ? (Sisesta Juku)");
            if (Console.ReadLine()?.ToLower() != "juku")
            {
                Log.Error("Head aega!");
                return;
            }

            Console.Write("Kui vana sa oled ?");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var vanus))
            {
                Log.Error("Ainult täisarved!");
                return;
            }

            switch (vanus)
            {
                case < 0 or > 100:
                    Log.Error("Vigane vanus");
                    break;
                case < 6:
                    Console.WriteLine("Pilet on tasuta");
                    break;
                case <= 14:
                    Console.WriteLine("Saad lastepilet");
                    break;
                case <= 65:
                    Console.WriteLine("Saad täispileti");
                    break;
                case >= 65:
                    Console.WriteLine("Saad sooduspileti");
                    break;
            }
        }

        public static void Pinginaabrid()
        {
            Console.WriteLine("Sisesta pinginaabri nimed! ");

            var naabrid = new List<string>();
            for (var i = 0; i < 2; i++)
            {
                Console.Write($"{i + 1}: ");
                naabrid.Add(Console.ReadLine()?.ToLower() ?? "");
            }

            if (naabrid.Contains("roman") && naabrid.Contains("artjom"))
            {
                Console.WriteLine("Te olete pinginaabrid!");
            }
            else
            {
                Console.WriteLine("Te ei ole pinginaabrid!");
            }
        }

        public static void Pindala()
        {
            Console.Write("Sisesta toa pikkus meetrites: ");
            if (!float.TryParse(Console.ReadLine(), out var pikkus) || pikkus <= 0)
            {
                Log.Error("Vigane sisend");
                return;
            }
            Console.Write("Sisesta toa laius meetrites: ");
            if (!float.TryParse(Console.ReadLine(), out var laius) || laius <= 0)
            {
                Log.Error("Vigane sisend");
                return;
            }

            var pindala = pikkus * laius;
            Console.WriteLine($"Toa pindala on {pindala} m²");
            Console.Write("Kas soovid remonti teha? (jah/ei): ");
            var vastus = Console.ReadLine()?.ToLower() ?? "";
            if (vastus != "jah")
            {
                Console.WriteLine("Remonti ei tehta.");
                return;
            }

            Console.Write("Kui palju maksab ruutmeeter?: ");
            if (!float.TryParse(Console.ReadLine(), out var ruutmeeterHind) || ruutmeeterHind <= 0)
            {
                Log.Error("Vigane sisend");
                return;
            }

            var remontHind = pindala * ruutmeeterHind;
            Console.WriteLine($"Remondi hind on {remontHind} eurot.");
        }

        public static void Soodustus()
        {
            Console.Write("Sisesta toote soodushind: ");
            if (!float.TryParse(Console.ReadLine(), out var soodushind) || soodushind <= 0)
            {
                Log.Error("Vigane sisend");
                return;
            }

            var alghind = soodushind / 0.7f;
            Console.WriteLine($"Toote alghind on {alghind} eurot.");
        }

        public static void Temperatuur()
        {
            Console.Write("Sisesta ruumi temperatuur (C): ");
            if (!float.TryParse(Console.ReadLine(), out var celsius))
            {
                Log.Error("Vigane sisend");
                return;
            }
            
            if (celsius > 18)
            {
                Console.WriteLine("Temperatuur on üle soovitava temperatuuri talvel!");
                return;
            }

            if (celsius < 18)
            {
                Console.WriteLine("Temperatuur on alla soovitava temperatuuri talvel!");
                return;
            }

            Console.WriteLine("Temperatuur on täpselt soovitav talvel!");
        }

        public static void Pikkus()
        {
            Console.Write("Sisesta sinu pikkus (cm): ");
            if (!float.TryParse(Console.ReadLine(), out var pikkus))
            {
                Log.Error("Vigane sisend");
                return;
            }

            if (pikkus > 180)
            {
                Console.WriteLine("Te olete suur!");
                return;
            }

            if (pikkus > 165)
            {
                Console.WriteLine("Te olete keskmine!");
                return;
            }

            Console.WriteLine("Lühike...");
        }

        public static void PikkusSugu()
        {
            Console.Write("Sisesta sinu pikkus (cm): ");
            if (!float.TryParse(Console.ReadLine(), out var pikkus))
            {
                Log.Error("Vigane sisend");
                return;
            }

            Console.Write("Sisesta sugu (mees/naine): ");
            var sugu = Console.ReadLine()?.ToLower() ?? "";
            var mees = sugu == "mees";
            if (sugu != "mees" && sugu != "naine")
            {
                Log.Error("Vigane sisend");
                return;
            }

            if (mees)
            {
                if (pikkus > 180)
                {
                    Console.WriteLine("Te olete suur!");
                    return;
                }

                if (pikkus > 170)
                {
                    Console.WriteLine("Te olete keskmine!");
                    return;
                }

                Console.WriteLine("Lühike...");
                return;
            }

            if (pikkus > 170)
            {
                Console.WriteLine("Te olete suur!");
                return;
            }

            if (pikkus > 160)
            {
                Console.WriteLine("Te olete keskmine!");
                return;
            }

            Console.WriteLine("Lühike...");
        }

        public static void Pood()
        {
            Console.WriteLine("""
                Pood!
                1) Piim - 0.80 euro
                2) Sai - 1.00 euro
                3) Leib - 1.15 euro
                0) Kassa
                """);

            var valikud = new List<int>();
            while (true)
            {
                Console.Write("Mida soovid osta: ");
                var valik = Console.ReadLine();
                if (!int.TryParse(valik, out var arv))
                {
                    Log.Error("Vigane sisend!");
                    continue;
                }

                valikud.Add(arv);
                if (arv == 0)
                    break;
            }

            var hinnad = new Dictionary<int, float>()
            {
                {1, 0.80f},
                {2, 1.00f},
                {3, 1.15f}
            };

            var summa = valikud.Sum(i => hinnad.GetValueOrDefault(i, 0));
            Console.WriteLine($"Kokku: {summa} euro");
        }
    }
}
