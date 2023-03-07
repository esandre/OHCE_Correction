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

    public static IEnumerable<object[]> PériodesJournée => new[]
    {
        new object[] { PériodeJournée.Default },
        new object[] { PériodeJournée.Matin },
        new object[] { PériodeJournée.AprèsMidi },
        new object[] { PériodeJournée.Soir },
        new object[] { PériodeJournée.Nuit },
    };

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

    [Fact]
    public void AuRevoirTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment s'acquitter
        var félicitations = langue.Acquittance;

        // ALORS on obtient "Au revoir"
        Assert.Equal(Expressions.AuRevoir, félicitations);
    }
}