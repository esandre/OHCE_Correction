﻿namespace OHCE;

public static class DétectionPalindrome
{
    public static string Traiter(string chaîne) 
        => new (chaîne.Reverse().ToArray());
}