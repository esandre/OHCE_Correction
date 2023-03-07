﻿using OHCE.Test.Utilities;

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

    public static IEnumerable<object[]> PériodesJournée
        => new CartesianData(PrimitivesCartésiennes.PériodesJournée);

    [Theory]
    [MemberData(nameof(PériodesJournée))]
    public void HelloTest(PériodeJournée période)
    {
        // ETANT DONNE la langue anglaise
        var langue = new LangueAnglaise();

        // QUAND demande comment saluer
        var félicitations = langue.Salutation(période);

        // ALORS on obtient "Hello"
        Assert.Equal(Expressions.Hello, félicitations);
    }

    [Theory]
    [MemberData(nameof(PériodesJournée))]
    public void GoodbyeTest(PériodeJournée période)
    {
        // ETANT DONNE la langue anglaise
        var langue = new LangueAnglaise();

        // QUAND demande comment s'acquitter
        var félicitations = langue.Acquittance(période);

        // ALORS on obtient "Au revoir"
        Assert.Equal(Expressions.Goodbye, félicitations);
    }
}