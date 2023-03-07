namespace OHCE;

public class LangueFrançaise : ILangue
{
    public string Félicitations => Expressions.BienDit;

    public string Salutation(PériodeJournée période) => 
        période == PériodeJournée.Soir || période == PériodeJournée.Nuit 
            ? Expressions.Bonsoir 
            : Expressions.Bonjour;

    public string Acquittance(PériodeJournée _) => Expressions.AuRevoir;
}