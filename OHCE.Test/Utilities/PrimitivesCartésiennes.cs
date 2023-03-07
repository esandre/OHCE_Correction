namespace OHCE.Test.Utilities;

internal class PrimitivesCartésiennes
{
    public static IEnumerable<ILangue> Langues
        => new ILangue[] { new LangueAnglaise(), new LangueFrançaise() };

    public static IEnumerable<PériodeJournée> PériodesJournée
        => new[]
        {
            PériodeJournée.Default, PériodeJournée.Matin, PériodeJournée.AprèsMidi, PériodeJournée.Soir,
            PériodeJournée.Nuit
        };
}