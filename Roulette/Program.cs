using System;
using System.Threading;

class Roulette
{
    static int saldo = 1000; // Spelaren börjar med 1000 $

    // Huvudmetod för spelet

    static void Main(string[] args)
    {
        Console.Title = "Sami's Roulette";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("|===================================================================================================|");
        Console.WriteLine("|                                                                                                   |");
        Console.WriteLine("|        :::::::::   ::::::::  :::    ::: :::        :::::::::: ::::::::::: ::::::::::: ::::::::::  |");
        Console.WriteLine("|       :+:    :+: :+:    :+: :+:    :+: :+:        :+:            :+:         :+:     :+:          |");
        Console.WriteLine("|      +:+    +:+ +:+    +:+ +:+    +:+ +:+        +:+            +:+         +:+     +:+           |");
        Console.WriteLine("|     +#++:++#:  +#+    +:+ +#+    +:+ +#+        +#++:++#       +#+         +#+     +#++:++#       |");
        Console.WriteLine("|    +#+    +#+ +#+    +#+ +#+    +#+ +#+        +#+            +#+         +#+     +#+             |");
        Console.WriteLine("|   #+#    #+# #+#    #+# #+#    #+# #+#        #+#            #+#         #+#     #+#              |");
        Console.WriteLine("|  ###    ###  ########   ########  ########## ##########     ###         ###     ##########        |");
        Console.WriteLine("|                                                                                                   |");
        Console.WriteLine("|===================================================================================================|");
        Console.ResetColor();
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("                                                                                                   ");
        Console.WriteLine($"** Ditt startsaldo är: {saldo} $ **");
        Random rand = new Random();
    
        // Loopa så att spelaren kan fortsätta spela tills de slutar eller förlorar allt
        while (saldo > 0)
        {
            Console.WriteLine("\n** Hur mycket vill du satsa? **");
            int insats = GetValidBet();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Vill du satsa på ett nummer (1-36) eller färg (röd/svart)?");
            Console.WriteLine("1. Nummer");
            Console.WriteLine("2. Färg");
            string val = Console.ReadLine();

            if (val == "1")
            {
                BetOnNumber(insats, rand);
            }
            else if (val == "2")
            {
                BetOnColor(insats, rand);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltigt val.");
                Console.ResetColor();
            }

            // Visa uppdaterat saldo
            Console.ForegroundColor = saldo > 0 ? ConsoleColor.Cyan : ConsoleColor.Red;
            Console.WriteLine($"\nDitt saldo är nu: {saldo} enheter");
            Console.ResetColor();

            // Fråga om spelaren vill fortsätta
            Console.WriteLine("Vill du spela igen? (ja/nej)");
            if (Console.ReadLine().ToLower() != "ja")
            {
                break;
            }
        }

        Console.ForegroundColor = saldo > 0 ? ConsoleColor.Yellow : ConsoleColor.Red;
        Console.WriteLine(saldo > 0 ? "Tack för att du spelade!" : "Du har slut på pengar. Kom tillbaks med mer pengar snart!");
        Console.ResetColor();
    }

    // Funktion för att kontrollera en giltig insats
    static int GetValidBet()
    {
        int insats;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out insats) && insats > 0 && insats <= saldo)
            {
                break; 
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ogiltig insats, försök igen.");
            Console.ResetColor();
        }
        return insats;
    }

    // Funktion för att satsa på ett nummer
    static void BetOnNumber(int insats, Random rand)
    {
        Console.WriteLine("Välj ett nummer mellan 1 och 36:");
        int spelarnummer;
        while (!int.TryParse(Console.ReadLine(), out spelarnummer) || spelarnummer < 1 || spelarnummer > 36)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ogiltigt nummer, försök igen.");
            Console.ResetColor();
        }

        // Class för Roulette animation
        Console.WriteLine("Roulette-hjulet snurrar...");
        SpinWheel();

        int rouletteNummer = rand.Next(1, 37);
        Console.WriteLine($"Nummer : {rouletteNummer}");

        if (spelarnummer == rouletteNummer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Grattis din turliga jävel! Ditt nummer vann!");
            saldo += insats * 35; 
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tyvärr, du förlorade. Spela gjärna igen!");
            saldo -= insats;
        }
        Console.ResetColor();
    }

    // Funktion för att satsa på färg
    static void BetOnColor(int insats, Random rand)
    {
        Console.WriteLine("Välj en färg: röd eller svart");
        string spelarfarg = Console.ReadLine().ToLower();

        Console.WriteLine("Roulette-hjulet snurrar...");
        SpinWheel();

        string rouletteFarg = rand.Next(0, 2) == 0 ? "röd" : "svart";
        Console.WriteLine("Roulette färg är: " + rouletteFarg);

        if (spelarfarg == rouletteFarg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Grattis! Du vann!");
            saldo += insats * 2; 
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tyvärr, du förlorade.");
            saldo -= insats;
        }
        Console.ResetColor();
    }

    static void SpinWheel()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < 10; i++)
        {
            Console.Write("*");
            Thread.Sleep(200);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}