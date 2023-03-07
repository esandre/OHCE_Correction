namespace OHCE;

public class LangueFrançaise : ILangue
{
    public string Félicitations => Expressions.BienDit;
    public string Salutation => Expressions.Bonjour;
    public string Acquittance => Expressions.AuRevoir;
}