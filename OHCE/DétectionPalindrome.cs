namespace OHCE
{
    public static class DétectionPalindrome
    {
        public static string Traiter(string chaîne)
        {
            return new string(chaîne.Reverse().ToArray());
        }
    }
}