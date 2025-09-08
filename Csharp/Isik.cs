namespace Csharp;

internal class Isik
{
    public int Synniaasta;
    public string Nimi = "";
    public string Perenimi = "";

    public Isik() { }

    public Isik(string nimi, string perenimi, int synniaasta)
    {
        Nimi = nimi;
        Perenimi = perenimi;
        Synniaasta = synniaasta;
    }

    public void Tutvusta()
    {
        Console.WriteLine($"Tere! Minu nimi on {Nimi} ja ma olen sündinud {Synniaasta} aastas.");
    }
}
