/*
 * Ryan Zhang 
 * HW 5 - Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */

namespace HW_Farmstead_Zhang
{
    /// <summary>
    /// Static class containing different console helper methods from
    /// previous exercises.
    /// </summary>
    internal static class ConsoleHelper
    {
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

        // Copied and reworked from GetValidIntegerInput
        /// <summary>
        /// Helper method to prompt the user to enter a double. If their
        /// response isn't a valid double or isn't in the desired range, reprompt
        /// </summary>
        /// <param name="prompt">The string to use in the initial prompt</param>
        /// <param name="min">The minimum accepted value (inclusive)</param>
        /// <param name="max">The maximum accepted value (inclusive)</param>
        /// <returns>The final, valid, user-entered value.</returns>
        public static double GetValidDoubleInput(string prompt, double min, double max)
        {
            double result;
            bool success = double.TryParse(GetPromptedInput(prompt), out result);

            while (!success || result < min || result > max)
            {
                success = double.TryParse(
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
