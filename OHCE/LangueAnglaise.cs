namespace OHCE;

public class LangueAnglaise : ILangue
{
    public string Félicitations => Expressions.WellSaid;

    /// <inheritdoc />
    public string Salutation(PériodeJournée _) => Expressions.Hello;

    /// <inheritdoc />
    public string Acquittance(PériodeJournée _) => Expressions.Goodbye;
}