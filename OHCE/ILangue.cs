namespace OHCE;

public interface ILangue
{
    string Félicitations { get; }
    string Salutation(PériodeJournée période);
    string Acquittance { get; }
}