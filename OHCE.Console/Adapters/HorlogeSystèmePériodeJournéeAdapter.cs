namespace OHCE.Console.Adapters;

internal class HorlogeSystèmePériodeJournéeAdapter
{
    public static PériodeJournée PériodeActuelle()
    {
        var heureActuelle = DateTime.Now.Hour;
        return heureActuelle switch
               {
                   < 8  => PériodeJournée.Nuit,
                   < 12 => PériodeJournée.Matin,
                   < 18 => PériodeJournée.AprèsMidi,
                   < 21 => PériodeJournée.Soir,
                   _    => PériodeJournée.Nuit
               };
    }
}