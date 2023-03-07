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
        // ET que la période de la journée est <période>
        var période = PériodeJournée.Matin;
        var ohce = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .AyantPourPériodeDeLaJournée(période)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = ohce.TraiterChaîne(chaîne);

        // ALORS le « Bonjour » de cette langue à cette période est envoyé avant toute réponse
        Assert.StartsWith(langue.Salutation(période), résultat);
    }

    public static IEnumerable<object[]> CasAuRevoirTest => new[]
    {
        new object[] { new LangueAnglaise(), "epsi" },
        new object[] { new LangueAnglaise(), "radar" },
        new object[] { new LangueFrançaise(), "epsi" },
        new object[] { new LangueFrançaise(), "radar" }
    };

    [Theory]
    [MemberData(nameof(CasAuRevoirTest))]
    public void AuRevoirTest(ILangue langue, string chaîne)
    {
        // ETANT DONNE un utilisateur parlant une langue
        var ohce = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = ohce.TraiterChaîne(chaîne);

        // ALORS le « Au revoir » de cette langue est envoyé en dernier
        Assert.EndsWith(langue.Acquittance, résultat);
    }

    //ETANT DONNE un utilisateur parlant une langue
    //ET que la période de la journée est <période>
    //QUAND on saisit une chaîne
    //ALORS <salutation> de cette langue à cette période est envoyé avant tout
    //CAS {‘matin’, ‘bonjour_am’}
    //CAS {‘après-midi’, ‘bonjour_pm’}
    //CAS {‘soirée’, ‘bonjour_soir’}
    //CAS {‘nuit’, ‘bonjour_nuit’}

    //ETANT DONNE un utilisateur parlant une langue
    //ET que la période de la journée est <période>
    //QUAND on saisit une chaîne
    //ALORS <auRevoir> dans cette langue à cette période est envoyé en dernier
    //CAS {‘matin’, ‘auRevoir_am’}
    //CAS {‘après-midi’, ‘auRevoir _pm’}
    //CAS {‘soirée’, ‘auRevoir _soir’}
    //CAS {‘nuit’, ‘auRevoir _nuit’}
}