using OHCE;
using OHCE.Console.Adapters;

var ohce = new DétectionPalindrome(new LangueSystème(), HorlogeSystèmePériodeJournéeAdapter.PériodeActuelle());

Console.WriteLine(ohce.TraiterChaîne(Console.ReadLine()!));