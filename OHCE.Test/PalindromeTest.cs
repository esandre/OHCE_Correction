using System.Threading.Channels;

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
        // QUAND on saisit un palindrome
        const string palindrome = "radar";
        var résultat = DétectionPalindrome.Traiter(palindrome);

        // ALORS celui-ci est renvoyé
        Assert.Contains(palindrome, résultat);

        var premièreOccurrence = résultat.IndexOf(palindrome, StringComparison.Ordinal);
        var finPalindrome = premièreOccurrence + palindrome.Length;
        var résultatAprèsPalindrome = résultat[finPalindrome..];

        // ET « Bien dit » est envoyé ensuite
        Assert.StartsWith(Expressions.BienDit, résultatAprèsPalindrome);
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

}