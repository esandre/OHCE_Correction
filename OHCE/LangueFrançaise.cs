namespace OHCE;

public class LangueFrançaise : ILangue
{
    public string Félicitations => Expressions.BienDit;
    public string Salutation(PériodeJournée _) => Expressions.Bonjour;
    public string Acquittance(PériodeJournée _) => Expressions.AuRevoir;
}