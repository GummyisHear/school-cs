namespace Csharp.osa3;

public class ArvuTooltus
{
    public static float[] GenereeriRuudud(int min, int max)
    {
        var ret = new List<float>();
        for (var i = min; i <= max; i++)
        {
            ret.Add(MathF.Pow(i, 2));
        }

        return ret.ToArray();
    }
}
