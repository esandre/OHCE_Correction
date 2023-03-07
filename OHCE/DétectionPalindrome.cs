namespace OHCE;

public class DétectionPalindrome
{
    private readonly ILangue _langue;
    private readonly PériodeJournée _période;

    public DétectionPalindrome(ILangue langue, PériodeJournée période)
    {
        _langue = langue;
        _période = période;
    }

    public string TraiterChaîne(string chaîne)
    {
        var miroir = new string(chaîne.Reverse().ToArray());

        if (miroir.Equals(chaîne))
            return _langue.Salutation(_période)
                   + miroir
                   + _langue.Félicitations
                   + _langue.Acquittance(_période);

        return _langue.Salutation(_période)
               + miroir
               + _langue.Acquittance(_période);
    }
}