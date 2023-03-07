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

        // ET « Bien dit » est envoyé ensuite
        Assert.EndsWith(Expressions.BienDit, résultat);
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
    //[InlineData("radar")]
    public void AuRevoirTest(string chaîne)
    {
        // QUAND on saisit une chaîne
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS « Au revoir » est envoyé en dernier
        Assert.EndsWith(Expressions.AuRevoir, résultat);
    }

}