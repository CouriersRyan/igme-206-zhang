/*
 * Ryan Zhang
 * PE - File IO with Classes
 * https://docs.google.com/document/d/1bdEwXtXEnyY2xfeDdS7XJ7FMqHUE0IzZn2OLopcwEwU/edit?usp=sharing
 */
namespace PE_FileIOWithClasses_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Console program that accesses an instance of PlayerManager and allows user input.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool isRunning = true;
            string input;

            PlayerManager playerManager = new PlayerManager();

            do
            {
                input = GetPromptedInput("Create. Print. Save. Load. Quit. >>", true);

                switch (input)
                {
                    // Create a whole new player from user inputs
                    case "create":
                        // Get inputs for the fields in player
                        string name = GetPromptedInput("\tWhat is the player's name?");
                        int strength = GetValidIntegerInput("\tPlayer's Strength?", 0, int.MaxValue);
                        int health = GetValidIntegerInput("\tPlayer's Health?", 0, int.MaxValue);

                        playerManager.CreatePlayer(name, strength, health);
                        break;

                    // print current players in the playerManager
                    case "print":
                        playerManager.Print();
                        break;

                    // save player data to file
                    case "save":
                        playerManager.Save();
                        break;

                    // load player data to file
                    case "load":
                        playerManager.Load();
                        break;

                    // quit the program
                    case "quit":
                        isRunning = false;
                        Console.WriteLine("\tGoodbye!");
                        break;
                }

                Console.WriteLine();
            } while (isRunning);
        }

        // Copied from Static Helper Methods PE
        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt, bool toLower = false)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Added extra functionality for convenience, functions like normal with default value.
            if (toLower)
            {
                response = response.ToLower();
            }

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        // Copied from Exception Handling and Try Parse PE
        /// <summary>
        /// Helper method to prompt the user to enter a number. If their
        /// response isn't a valid int or isn't in the desired range, reprompt
        /// </summary>
        /// <param name="prompt">The string to use in the initial prompt</param>
        /// <param name="min">The minimum accepted value (inclusive)</param>
        /// <param name="max">The maximum accepted value (inclusive)</param>
        /// <returns>The final, valid, user-entered value.</returns>
        public static int GetValidIntegerInput(string prompt, int min, int max)
        {
            int result;
            bool success = int.TryParse(GetPromptedInput(prompt), out result);

            while (!success || result < min || result > max)
            {
                success = int.TryParse(
                    GetPromptedInput(
                            String.Format("\tPlease enter a valid whole number between {0} and {1}:",
                            min,
                            max)
                        ), out result
                    );
            }
            return result;
        }
    }
}
