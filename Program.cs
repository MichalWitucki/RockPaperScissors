namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Witaj w grze Kamień-Papier-Nożyce. ");
            int pointsToWin = IsCorrectMaxPointsInput();
            Console.WriteLine($"Gramy do {pointsToWin} punktów.");
            Console.WriteLine();
            GameTurn(pointsToWin);            
        }
        static void GameTurn(int pointsToWin)
        {
            int turn = 1, playerSymbol, cpuSymbol, playerPoints = 0, cpuPoints = 0;
            Random random = new Random();
            do
            {
                Console.WriteLine($"Tura numer: {turn}\tPunkty gracza: {playerPoints}\tPunkty komputera: {cpuPoints}");
                playerSymbol = IsCorrectSymbolInput();
                cpuSymbol = random.Next(1, 4);
                Console.Write($"Twój symbol to {MatchSymbol(playerSymbol)}, komputer wylosował {MatchSymbol(cpuSymbol)} --> ");
                if (playerSymbol == 1)
                {
                    if (cpuSymbol == 1)
                    {
                        Console.WriteLine("remis.");
                    }
                    else if (cpuSymbol == 2)
                    {
                        Console.WriteLine("papier owija kamień --> punkt dla komputera.");
                        cpuPoints += 1;
                    }
                    else if (cpuSymbol == 3)
                    {
                        Console.WriteLine("kamień tępi nożyce --> punkt dla gracza.");
                        playerPoints += 1;
                    }
                }
                else if (playerSymbol == 2)
                {
                    if (cpuSymbol == 1)
                    {
                        Console.WriteLine("papier owija kamień --> punkt dla gracza.");
                        playerPoints += 1;
                    }
                    else if (cpuSymbol == 2)
                    {
                        Console.WriteLine("remis.");
                    }
                    else if (cpuSymbol == 3)
                    {
                        Console.WriteLine("nożyce tną papier --> punkt dla komputera.");
                        cpuPoints += 1;
                    }
                }
                else if (playerSymbol == 3)
                {
                    if (cpuSymbol == 1)
                    {
                        Console.WriteLine("kamień tępi nożyce --> punkt dla komputera.");
                        cpuPoints += 1;
                    }
                    else if (cpuSymbol == 2)
                    {
                        Console.WriteLine("nożyce tną papier --> punkt dla gracza.");
                        playerPoints += 1;
                    }
                    else if (cpuSymbol == 3)
                    {
                        Console.WriteLine("remis.");
                    }
                }
                turn += 1;
                Console.WriteLine();
            }
            while (playerPoints != pointsToWin && cpuPoints != pointsToWin);
            WhoWon(playerPoints, cpuPoints);
        }
        static int IsCorrectMaxPointsInput()
        {
            int pointsToWin;
            do
            {
                Console.Write("Do ilu punktów chcesz zagrać?: ");
                string howManyPoints = Console.ReadLine();

                if (!int.TryParse(howManyPoints, out pointsToWin) || pointsToWin <= 0)
                {
                    Console.WriteLine("Nieprawidłowy wybór. Podaj dodatnią liczbę całkowitą.");
                    Console.WriteLine();
                    continue;
                }
            }
            while (pointsToWin <= 0);
            Console.WriteLine();
            return pointsToWin;
        }
        static int IsCorrectSymbolInput()
        {
            string playerChoice;
            int playerSymbol;
            do
            {
                Console.Write("Wybierz swój symbol (1 - Kamień, 2 - Papier, 3 - Nożyce): ");
                if ((!int.TryParse(playerChoice = Console.ReadLine(), out playerSymbol)) || playerSymbol < 1 || playerSymbol > 3)
                {
                    Console.WriteLine("Nieprawidłowy wybór. Masz do wyboru: (1 - Kamień, 2 - Papier, 3 - Nożyce).");
                    Console.WriteLine();
                    continue;
                }
                return playerSymbol;
            }
            while (true);
        }
        static string MatchSymbol(int Symbol)
        {
            if (Symbol == 1)
                return "kamień";
            else if (Symbol == 2)
                return "papier";
            else
                return "nożyce";
        }
        static void WhoWon(int playerPoints, int cpuPoints)
        {
            Console.WriteLine($"Punkty gracza {playerPoints}\t Punkty komputera {cpuPoints}.");
            Console.Write("Koniec gry. ");
            if (cpuPoints > playerPoints)
                Console.WriteLine("Wygrał komputer.");
            else Console.WriteLine("Wygrał gracz.");
        }

    }

}

 