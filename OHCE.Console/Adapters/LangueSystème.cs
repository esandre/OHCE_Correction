using System.Globalization;

namespace OHCE.Console.Adapters;

internal class LangueSystème : ILangue
{
    private readonly ILangue _langueSystème;

    public LangueSystème()
    {
        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Equals("fr", StringComparison.CurrentCultureIgnoreCase))
            _langueSystème = new LangueFrançaise();
        else _langueSystème = new LangueAnglaise();
    }

    /// <inheritdoc />
    public string Félicitations => _langueSystème.Félicitations;

    /// <inheritdoc />
    public string Salutation(PériodeJournée période)
    {
        return _langueSystème.Salutation(période);
    }

    /// <inheritdoc />
    public string Acquittance(PériodeJournée période)
    {
        return _langueSystème.Acquittance(période);
    }
}
