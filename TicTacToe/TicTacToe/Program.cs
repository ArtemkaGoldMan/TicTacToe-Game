using TicTacToe;

public class Program
{
    public static void Main()
    {
        // Introductory text
        string title = "Tic Tac Toe";
        string description = "Standard Tic Tac Toe game. There are two options of game: bot or PvP.";


        string[] menuOptions = { "Bot", "PvP" };
        int selectedOption = 0;

        while (true)
        {
            Console.Clear();

            // Center text
            int titleLeftPosition = (Console.WindowWidth - title.Length) / 2;
            Console.SetCursorPosition(titleLeftPosition, 3);
            Console.WriteLine(title);

            int descriptionLeftPosition = (Console.WindowWidth - description.Length) / 2;
            Console.SetCursorPosition(descriptionLeftPosition, 5);
            Console.WriteLine(description);

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedOption)
                {
                    // Highlight the selected option
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    // Default option color
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // Calculate the position to center the menu options
                int leftPosition = (Console.WindowWidth - menuOptions[i].Length) / 2;
                int topPosition = (Console.WindowHeight / 2) - (menuOptions.Length / 2) + i;

                Console.SetCursorPosition(leftPosition, topPosition);
                Console.WriteLine(menuOptions[i]);
            }

            Console.ResetColor();

            // Handle keyboard input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (selectedOption == 0) ? menuOptions.Length - 1 : selectedOption - 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption == menuOptions.Length - 1) ? 0 : selectedOption + 1;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                ExecuteAction(selectedOption);
                break;
            }
        }
    }

    public static void ExecuteAction(int option)
    {
        switch (option)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("You chose to play against a Bot.");
                Console.WriteLine("The first player is 'X' (Bot), the second is 'O' (you). Enjoy your game!");
                Console.WriteLine("Press any key to start the game...");
                Console.ReadKey();

                BotGame botGame = new BotGame();
                botGame.botGame();
                break;

            case 1:
                Console.Clear();
                Console.WriteLine("You chose to play PvP.");
                Console.WriteLine("The first player is 'X', the second is 'O'. Enjoy your game!");
                Console.WriteLine("Press any key to start the game...");
                Console.ReadKey();

                PvPGame pvpGame = new PvPGame();
                pvpGame.pvpGame();
                break;

            default:
                break;
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

}
