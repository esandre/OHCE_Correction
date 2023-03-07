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
        Assert.EndsWith(résultatAttendu, résultat);
    }

    [Fact]
    public void BienDitTest()
    {
        // QUAND on saisit un palindrome
        const string palindrome = "radar";
        var résultat = DétectionPalindrome.Traiter(palindrome);

        // ALORS celui-ci est renvoyé
        Assert.StartsWith(palindrome, résultat);

        // ET « Bien dit » est envoyé ensuite
        Assert.EndsWith(Expressions.BienDit, résultat);
    }

    [Fact]
    public void BonjourTest()
    {
        // QUAND on saisit une chaîne
        const string chaîne = "epsi";
        var résultat = DétectionPalindrome.Traiter(chaîne);

        // ALORS « Bonjour » est envoyé avant toute réponse
        Assert.StartsWith(Expressions.Bonjour, résultat);
    }

    
    //    QUAND on saisit une chaîne ALORS « Au revoir » est envoyé en dernier

}