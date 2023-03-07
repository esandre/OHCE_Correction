using OHCE.Test.Utilities;

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

    public static IEnumerable<object[]> CasBienDitTest => new CartesianData(Langues);

    [Theory]
    [MemberData(nameof(CasBienDitTest))]
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

    private static IEnumerable<ILangue> Langues 
        => new ILangue[] { new LangueAnglaise(), new LangueFrançaise() };

    private static IEnumerable<string> ChaînesATester 
        => new[] { "epsi", "radar" };

    private static IEnumerable<PériodeJournée> PériodesJournée
        => new[] { PériodeJournée.Default, PériodeJournée.Matin, PériodeJournée.AprèsMidi, PériodeJournée.Soir, PériodeJournée.Nuit };

    public static IEnumerable<object[]> CasBonjourTest 
        => new CartesianData(Langues, PériodesJournée, ChaînesATester);

    [Theory]
    [MemberData(nameof(CasBonjourTest))]
    public void BonjourTest(ILangue langue, PériodeJournée période, string chaîne)
    {
        // ETANT DONNE un utilisateur parlant une langue
        // ET que la période de la journée est <période>
        var ohce = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .AyantPourPériodeDeLaJournée(période)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = ohce.TraiterChaîne(chaîne);

        // ALORS le « Bonjour » de cette langue à cette période est envoyé avant toute réponse
        Assert.StartsWith(langue.Salutation(période), résultat);
    }

    public static IEnumerable<object[]> CasAuRevoirTest
        => new CartesianData(Langues, ChaînesATester);

    [Theory]
    [MemberData(nameof(CasAuRevoirTest))]
    public void AuRevoirTest(ILangue langue, string chaîne)
    {
        // ETANT DONNE un utilisateur parlant une langue
        // ET que la période de la journée est<période>
        var période = PériodeJournée.Default;
        var ohce = new DétectionPalindromeBuilder()
            .AyantPourLangue(langue)
            .AyantPourPériodeDeLaJournée(période)
            .Build();

        // QUAND on saisit une chaîne
        var résultat = ohce.TraiterChaîne(chaîne);

        // ALORS le « Au revoir » de cette langue à cette période est envoyé en dernier
        Assert.EndsWith(langue.Acquittance(période), résultat);
    }
}