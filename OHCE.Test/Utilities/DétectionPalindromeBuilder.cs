namespace OHCE.Test.Utilities;

internal class DétectionPalindromeBuilder
{
    public static DétectionPalindrome Default => new DétectionPalindromeBuilder().Build();

    private ILangue _langue = new LangueStub();

    public DétectionPalindromeBuilder AyantPourLangue(ILangue langue)
    {
        _langue = langue;
        return this;
    }

    public DétectionPalindrome Build()
    {
        return new DétectionPalindrome(_langue);
    }
}