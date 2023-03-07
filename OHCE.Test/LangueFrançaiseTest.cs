using OHCE.Test.Utilities;

namespace OHCE.Test;

public class LangueFrançaiseTest
{
    [Fact]
    public void BienDitTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment féliciter
        var félicitations = langue.Félicitations;

        // ALORS on obtient "Bien dit"
        Assert.Equal(Expressions.BienDit, félicitations);
    }

    public static IEnumerable<object[]> PériodesJournée 
        => new CartesianData(PrimitivesCartésiennes.PériodesJournée);

    [Theory]
    [MemberData(nameof(PériodesJournée))]
    public void BonjourTest(PériodeJournée période)
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment saluer
        var félicitations = langue.Salutation(période);

        // ALORS on obtient "Bonjour"
        Assert.Equal(Expressions.Bonjour, félicitations);
    }

    [Theory]
    [MemberData(nameof(PériodesJournée))]
    public void AuRevoirTest(PériodeJournée période)
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment s'acquitter
        var félicitations = langue.Acquittance(période);

        // ALORS on obtient "Au revoir"
        Assert.Equal(Expressions.AuRevoir, félicitations);
    }
}