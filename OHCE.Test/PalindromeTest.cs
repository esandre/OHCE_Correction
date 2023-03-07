namespace OHCE.Test;

public class PalindromeTest
{
    [Theory]
    [InlineData("streaming")]
    [InlineData("epsi")]
    public void TestMiroir(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS celle-ci est renvoyée en miroir
        var résultatAttendu = new string(chaîne.Reverse().ToArray());
        Assert.Contains(résultatAttendu, résultat);
    }

    [Fact]
    public void BienDitTest()
    {
        // ETANT DONNE un utilisateur parlant une langue
        var langue = new LangueFrançaise();

        // QUAND on saisit un palindrome
        const string palindrome = "radar";
        var résultat = DétectionPalindrome.Traiter(palindrome);

        // ALORS celui-ci est renvoyé
        Assert.Contains(palindrome, résultat);

        var premièreOccurrence = résultat.IndexOf(palindrome, StringComparison.Ordinal);
        var finPalindrome = premièreOccurrence + palindrome.Length;
        var résultatAprèsPalindrome = résultat[finPalindrome..];

        // ET le « Bien dit »  de cette langue est envoyé ensuite
        Assert.StartsWith(langue.Félicitations, résultatAprèsPalindrome);
    }

    [Theory]
    [InlineData("epsi")]
    [InlineData("radar")]
    public void BonjourTest(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS « Bonjour » est envoyé avant toute réponse
        Assert.StartsWith(Expressions.Bonjour, résultat);
    }

    [Theory]
    [InlineData("epsi")]
    [InlineData("radar")]
    public void AuRevoirTest(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS « Au revoir » est envoyé en dernier
        Assert.EndsWith(Expressions.AuRevoir, résultat);
    }

    
    // ETANT DONNE un utilisateur parlant une langue QUAND on saisit une chaîne
    //    ALORS<bonjour> de cette langue est envoyé avant tout
    // ETANT DONNE un utilisateur parlant une langue QUAND
    //    on saisit une chaîne ALORS<auRevoir> dans cette langue est envoyé en dernier
}