namespace OHCE;

public static class DétectionPalindrome
{
    public static string Traiter(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        if(miroir.Equals(chaîne)) return Expressions.Bonjour + miroir + Expressions.BienDit;
        return Expressions.Bonjour + miroir;
    }
}