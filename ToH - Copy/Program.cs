using System;
using System.Threading;

internal class Program
{
    private static bool talkedToPrisoner = false;
    private static bool bobbyPinUsed = false;
    private static bool bobbyPinSuccess = false;

    private static void Main(string[] args)
    {
        Console.WriteLine("Cold, you awaken in a dungeon. Your hands are bound and you're behind bars. You hear a name repeat in your head...");
        Thread.Sleep(2000);
        ClearText();

        string playerName = SetPlayerName();

        Console.WriteLine($"When you focus, you hear '{playerName}' repeat clearly in your head.");
        Thread.Sleep(2000);
        ClearText();

        bool gameRunning = true;
        int shoutCount = 0;

        while (gameRunning)
        {
            Console.WriteLine("What would you like to do?");
            DisplayOptions();
            string choice = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(choice))
            {
                InvalidInput();
                continue;
            }

            ClearText();
            switch (choice)
            {
                case "1":
                    shoutCount++;
                    CallForHelp(ref gameRunning, shoutCount);
                    break;

                case "2":
                    InspectCell(ref gameRunning);
                    break;

                case "3":
                    WaitPatiently(ref gameRunning);
                    break;

                case "4":
                    ChangeTextColor(ConsoleColor.Red);
                    Console.WriteLine("You lose hope and decide to accept your fate. The game ends here.");
                    ResetTextColor();
                    gameRunning = false;
                    break;

                case "5":
                    TalkToPrisoner(ref gameRunning);
                    break;

                default:
                    InvalidInput();
                    break;
            }

            if (gameRunning)
            {
                Thread.Sleep(3000);
                ClearText();
            }
        }

        Console.WriteLine("Thank you for playing!");
    }

    private static void DisplayOptions()
    {
        ChangeTextColor(ConsoleColor.Cyan);
        Console.WriteLine("1. Call for help");
        Console.WriteLine("2. Inspect the cell for a way out");
        Console.WriteLine("3. Wait patiently for something to happen");
        Console.WriteLine("4. Give up");
        Console.WriteLine("5. Talk to the prisoner in the cell across");
        Console.Write("Choose an option (1-5): ");
        ResetTextColor();
    }

    private static void InvalidInput()
    {
        ChangeTextColor(ConsoleColor.Yellow);
        Console.WriteLine("Invalid choice. Please try again.");
        ResetTextColor();
    }

    private static string SetPlayerName()
    {
        while (true)
        {
            Console.Write("Enter your name: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Name cannot be empty. Please try again.");
                continue;
            }

            ClearText();
            Console.Write($"Is your name '{input}'? (yes/no): ");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "yes")
                return input;

            Console.WriteLine("That doesn't sound right. Try again...");
        }
    }

    private static void ClearText()
    {
        Console.Clear();
    }

    private static void ChangeTextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    private static void ResetTextColor()
    {
        Console.ResetColor();
    }

    // Other methods (CallForHelp, InspectCell, WaitPatiently, SubdueAndSteal, TalkToPrisoner) remain unchanged but should include the improvements above.
}
