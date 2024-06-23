using System;

class Program
{
    static void Main()
    {
        // Introductory text
        string title = "Tic Tac Toe";
        string description = "Standard Tic Tac Toe game. There are two options of game: bot or PvP.";

        // Define the menu options
        string[] menuOptions = { "Bot", "PvP" };
        int selectedOption = 0;

        // Main loop to keep the menu open until an option is selected
        while (true)
        {
            // Clear the console
            Console.Clear();

            // Center the title text
            int titleLeftPosition = (Console.WindowWidth - title.Length) / 2;
            Console.SetCursorPosition(titleLeftPosition, 3); // Positioning title 3 rows from the top
            Console.WriteLine(title);

            // Center the description text
            int descriptionLeftPosition = (Console.WindowWidth - description.Length) / 2;
            Console.SetCursorPosition(descriptionLeftPosition, 5); // Positioning description 2 rows below the title
            Console.WriteLine(description);

            // Display the menu options
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

                // Set the cursor position
                Console.SetCursorPosition(leftPosition, topPosition);

                // Write the menu option
                Console.WriteLine(menuOptions[i]);
            }

            // Reset colors
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
                // Execute the action for the selected option
                ExecuteAction(selectedOption);
                break;
            }
        }
    }

    static void ExecuteAction(int option)
    {
        // Perform actions based on the selected option
        switch (option)
        {
            case 0:
                Console.Clear();
                Console.WriteLine("You chose to play against a Bot.");
                // Add your code for playing against a bot here
                break;
            case 1:
                Console.Clear();
                Console.WriteLine("You chose to play PvP.");
                // Add your code for person vs bot here
                break;
            default:
                break;
        }

        // Wait for a key press before closing
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
