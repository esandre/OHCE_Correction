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
}