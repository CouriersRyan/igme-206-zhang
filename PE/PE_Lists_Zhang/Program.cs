/*
 * Ryan Zhang
 * PE - Lists
 * https://docs.google.com/document/d/1yr-JcmbBOSWCzaoHlt7F1n6dnWku0ZKLwbX_2kfBm_w/edit?usp=sharing
 */
namespace PE_Lists_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Creates two players with inventories
        /// and asks the user to populate their inventory with items.
        /// Then moves to a vendor's shop where the player can add items to the inventory and steal items.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random rng = new Random();
            Player player1;
            Player player2;
            string input;
            Player stealTarget;
            int stealIndex;
            string stolenItem;
            bool hasQuit = false;
            List<String> stolenItems = new List<String>();

            // Part 1 - Inventory Setup

            // Get player names and make Players
            input = GetPromptedInput("Enter Player 1's name:");
            player1 = new Player(input);

            input = GetPromptedInput("Enter Player 2's name:");
            player2 = new Player(input);
            Console.WriteLine();

            // Prompt for items
            // Add item randomly to a player's inventory.
            for (int i = 0; i < 5; i++)
            {
                input = GetPromptedInput("Enter an item:");
                if (rng.NextDouble() > 0.5)
                {
                    player1.AddToInventory(input);
                }
                else
                {
                    player2.AddToInventory(input);
                }
            }
            Console.WriteLine();

            // Print inventories
            player1.PrintInventory();
            Console.WriteLine();
            player2.PrintInventory();
            Console.WriteLine();


            // Part 2 - Vendor's Shop
            // Continues to loop while the user has not 'quit'
            // Asks for commands which are parsed from a list.
            while (!hasQuit)
            {
                input = GetPromptedInput("Enter a command (print, steal, or quit) or an item:", true);

                // All possible responses to user input
                switch (input)
                {

                    // Prints a list of items in each player's inventory
                    case "print":
                        player1.PrintInventory();
                        Console.WriteLine();
                        player2.PrintInventory();
                        break;

                    // Steal an item from a chosen player.
                    case "steal":
                        // Ask player to pick a player inventory to steal from.
                        if (GetValidIntegerInput(
                            "Which player would you like to steal from (1 or 2)?", 1, 2) == 1)
                        {
                            stealTarget = player1;
                        } else
                        {
                            stealTarget = player2;
                        }

                        // Ask for the index of the item to steal.
                        stealIndex = GetValidIntegerInput(String.Format(
                            "Which item # would you like to steal from {0}?", stealTarget.Name),
                            0, int.MaxValue);
                        
                        // Steal the item and validate something was stolen.
                        stolenItem = stealTarget.GetItemInSlot(stealIndex);
                        if(stolenItem != null)
                        {
                            Console.WriteLine("{0} stolen from slot {1} in {2}'s inventory!",
                                stolenItem, stealIndex, stealTarget.Name);
                            stolenItems.Add(stolenItem);
                        }
                        else
                        {
                            Console.WriteLine("{0} was not a valid item #!", stealIndex);
                        }

                        break;

                    // Exit the program
                    case "quit":
                        Console.WriteLine("You stole {0} item(s):", stolenItems.Count);
                        for(int i = 0; i < stolenItems.Count; i++)
                        {
                            Console.WriteLine("\t{0}", stolenItems[i]);
                        }
                        hasQuit = true;
                        break;

                    // Assume input was an item name and add it to random player's inventory.
                    default:
                        if (rng.NextDouble() > 0.5)
                        {
                            player1.AddToInventory(input);
                        }
                        else
                        {
                            player2.AddToInventory(input);
                        }
                        break;
                }
                Console.WriteLine();
            }
        }

        // Helper Methods
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
                            String.Format("Please enter a valid whole number between {0} and {1}:",
                            min,
                            max)
                        ), out result
                    );
            }
            return result;
        }
    }
}
