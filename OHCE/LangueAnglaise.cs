namespace OHCE;

public class LangueAnglaise : ILangue
{
    public string Félicitations => Expressions.WellSaid;

    /// <inheritdoc />
    public string Salutation => Expressions.Hello;

    /// <inheritdoc />
    public string Acquittance { get; }
}