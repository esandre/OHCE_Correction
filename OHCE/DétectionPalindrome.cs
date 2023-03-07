namespace OHCE;

public static class DétectionPalindrome
{
    public static string Traiter(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        if(miroir.Equals(chaîne)) return miroir + Expressions.BienDit;
        return "Bonjour" + miroir;
    }
}