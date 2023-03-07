using OHCE.Test.Utilities;
using System;

namespace OHCE.Test;

public class PalindromeTest
{
    [Theory]
    [InlineData("streaming")]
    [InlineData("epsi")]
    public void TestMiroir(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindromeBuilder.Default.TraiterChaîne(chaîne);

        // ALORS celle-ci est renvoyée en miroir
        var résultatAttendu = new string(chaîne.Reverse().ToArray());
        Assert.Contains(résultatAttendu, résultat);
    }

    public static IEnumerable<object[]> Langues => new[]
    {
        new object[] { new LangueAnglaise() },
        new object[] { new LangueFrançaise() }
    };

    [Theory]
    [MemberData(nameof(Langues))]
    public void BienDitTest(ILangue langue)
    {
        // ETANT DONNE un utilisateur parlant <langue>
        var ohce = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND on saisit un palindrome
        const string palindrome = "radar";
        var résultat = ohce.TraiterChaîne(palindrome);

        // ALORS celui-ci est renvoyé
        Assert.Contains(palindrome, résultat);

        var premièreOccurrence = résultat.IndexOf(palindrome, StringComparison.Ordinal);
        var finPalindrome = premièreOccurrence + palindrome.Length;
        var résultatAprèsPalindrome = résultat[finPalindrome..];

        // ET le « Bien dit » de cette langue est envoyé ensuite
        Assert.StartsWith(langue.Félicitations, résultatAprèsPalindrome);
    }

    public static IEnumerable<object[]> CasBonjourTest => new[]
    {
        new object[] { new LangueAnglaise(), "epsi" },
        new object[] { new LangueAnglaise(), "radar" },
        new object[] { new LangueFrançaise(), "epsi" },
        new object[] { new LangueFrançaise(), "radar" }
    };

    [Theory]
    [MemberData(nameof(CasBonjourTest))]
    public void BonjourTest(ILangue langue, string chaîne)
    {
        // ETANT DONNE un utilisateur parlant une langue
        var ohce = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = ohce.TraiterChaîne(chaîne);

        // ALORS le « Bonjour » de cette langue est envoyé avant toute réponse
        Assert.StartsWith(langue.Salutation, résultat);
    }

    [Theory]
    [InlineData("epsi")]
    [InlineData("radar")]
    public void AuRevoirTest(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindromeBuilder.Default.TraiterChaîne(chaîne);

        // ALORS « Au revoir » est envoyé en dernier
        Assert.EndsWith(Expressions.AuRevoir, résultat);
    }

    
    
    // ETANT DONNE un utilisateur parlant une langue QUAND
    //    on saisit une chaîne ALORS<auRevoir> dans cette langue est envoyé en dernier
}