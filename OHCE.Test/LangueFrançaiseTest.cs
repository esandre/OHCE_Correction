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


    [Fact]
    public void BonjourTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment saluer en général
        var félicitations = langue.Salutation(PériodeJournée.Default);

        // ALORS on obtient "Bonjour"
        Assert.Equal(Expressions.Bonjour, félicitations);
    }

    [Fact]
    public void BonjourMatinTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment saluer le matin
        var félicitations = langue.Salutation(PériodeJournée.Matin);

        // ALORS on obtient "Bonjour"
        Assert.Equal(Expressions.Bonjour, félicitations);
    }

    [Fact]
    public void BonjourAprèsMidiTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment saluer l'après-midi
        var félicitations = langue.Salutation(PériodeJournée.AprèsMidi);

        // ALORS on obtient "Bonjour"
        Assert.Equal(Expressions.Bonjour, félicitations);
    }

    [Fact]
    public void BonjourSoirTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment saluer le soir
        var félicitations = langue.Salutation(PériodeJournée.Soir);

        // ALORS on obtient "Bonsoir"
        Assert.Equal(Expressions.Bonsoir, félicitations);
    }

    [Fact]
    public void BonjourNuitTest()
    {
        // ETANT DONNE la langue française
        var langue = new LangueFrançaise();

        // QUAND demande comment saluer la nuit
        var félicitations = langue.Salutation(PériodeJournée.Nuit);

        // ALORS on obtient "Bonsoir"
        Assert.Equal(Expressions.Bonsoir, félicitations);
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