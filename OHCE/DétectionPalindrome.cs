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

        if(miroir.Equals(chaîne)) return _langue.Salutation(PériodeJournée.Default) + miroir + _langue.Félicitations + _langue.Acquittance;
        return _langue.Salutation(PériodeJournée.Default) + miroir + _langue.Acquittance;
    }
}