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
}