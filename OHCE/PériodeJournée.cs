namespace OHCE;

public class PériodeJournée
{
    public static PériodeJournée Default { get; } = new ();
    public static PériodeJournée Matin { get; } = new ();
    public static PériodeJournée AprèsMidi { get; } = new ();
    public static PériodeJournée Soir { get; } = new ();
    public static PériodeJournée Nuit { get; } = new ();

    private PériodeJournée(){}
}