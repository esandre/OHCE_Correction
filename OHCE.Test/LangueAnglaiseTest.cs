namespace OHCE.Test;

public class LangueAnglaiseTest
{
    [Fact]
    public void WellSaidTest()
    {
        // ETANT DONNE la langue anglaise
        var langue = new LangueAnglaise();

        // QUAND demande comment féliciter
        var félicitations = langue.Félicitations;

        // ALORS on obtient "Well said"
        Assert.Equal(Expressions.WellSaid, félicitations);
    }

    [Fact]
    public void HelloTest()
    {
        // ETANT DONNE la langue anglaise
        var langue = new LangueAnglaise();

        // QUAND demande comment saluer
        var félicitations = langue.Salutation;

        // ALORS on obtient "Hello"
        Assert.Equal(Expressions.Hello, félicitations);
    }

    [Fact]
    public void GoodbyeTest()
    {
        // ETANT DONNE la langue anglaise
        var langue = new LangueAnglaise();

        // QUAND demande comment s'acquitter
        var félicitations = langue.Acquittance;

        // ALORS on obtient "Au revoir"
        Assert.Equal(Expressions.Goodbye, félicitations);
    }
}