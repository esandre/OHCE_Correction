namespace OHCE;

public class DétectionPalindrome
{
    private readonly ILangue _langue;

    public DétectionPalindrome(ILangue langue)
    {
        _langue = langue;
    }

    public string TraiterChaîne(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        if(miroir.Equals(chaîne)) return Expressions.Bonjour + miroir + _langue.Félicitations + Expressions.AuRevoir;
        return Expressions.Bonjour + miroir + Expressions.AuRevoir;
    }
}