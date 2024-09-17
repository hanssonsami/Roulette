int PlaceBet(int currentMoney, string who)
{
    int betAmount;
    while (true)
    {
        Console.WriteLine($"{who} har {currentMoney} dollar. Hur mycket vill du satsa?");
        if (int.TryParse(Console.ReadLine(), out betAmount) && betAmount > 0 && betAmount <= currentMoney)
        {
            return betAmount;
        }
        Console.WriteLine("Ogiltigt belopp, försök igen.");
    }
}