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
        Assert.Equal(résultatAttendu, résultat);
    }

        
    //QUAND on saisit un palindrome ALORS celui-ci est renvoyé ET « Bien dit » est envoyé ensuite
    //    QUAND on saisit une chaîne ALORS « Bonjour » est envoyé avant toute réponse
    //    QUAND on saisit une chaîne ALORS « Au revoir » est envoyé en dernier

}