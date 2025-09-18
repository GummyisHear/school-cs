namespace Csharp.osa5;

internal class Valuuta
{
    public Currency Nimi;
    public float KurssEurodes;

    public Valuuta(Currency nimi, float kurssEurodes)
    {
        Nimi = nimi;
        KurssEurodes = kurssEurodes;
    }
}

public enum Currency
{
    EUR,
    USD,
    GBP,
    JPY,
    CNY,
    NOK
}
