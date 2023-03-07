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
        var périodeJournée = PériodeJournée.Default;

        if (miroir.Equals(chaîne))
            return _langue.Salutation(périodeJournée)
                   + miroir
                   + _langue.Félicitations
                   + _langue.Acquittance(périodeJournée);

        return _langue.Salutation(périodeJournée)
               + miroir
               + _langue.Acquittance(périodeJournée);
    }
}