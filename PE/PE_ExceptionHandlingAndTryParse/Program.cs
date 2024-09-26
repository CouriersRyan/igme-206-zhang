/*
 * Ryan Zhang
 * PE - Exception Handling & TryParse
 * https://docs.google.com/document/d/11LMepW6kykCWswuNvuUasDxBAAnubMhmrTEC-O6FkUI/edit?usp=sharing
 */
namespace PE_ExceptionHandlingAndTryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            int a = 0;
            int b = 0;
            string[] validChoices = { "T", "Q" };

            do
            {
                // Activity 1: Add exception handling to detect potential run-time errors
                try
                {
                    // Get two numbers in different ranges:
                    a = GetValidIntegerInput("\nA [0,10] : ", 0, 10);
                    b = GetValidIntegerInput("\nB [20,30]:", 20, 30);

                    Console.WriteLine($"\n{a} + {b} = {a + b}");
                    Console.WriteLine($"{a} - {b} = {a - b}");
                    Console.WriteLine($"{a} * {b} = {a * b}");
                    Console.WriteLine($"{a} / {b} = {a / b}");

                    // checked() forces the runtime to detect
                    // issues instead of dealing with it by resulting in max int
                    Console.WriteLine($"{a} * {int.MaxValue} = {checked(a * int.MaxValue)}");
                }
                // If the user input cannot be parsed properly into an int
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input string was not in a correct format.");
                    Console.ForegroundColor= ConsoleColor.White;
                }
                // If a / b and b == 0
                catch (DivideByZeroException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} cannot be divided by 0!", a);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // If a > 1 and it is multiplied by int.MaxValue
                catch (OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} * {1} = A bad idea :)", a, int.MaxValue);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Catches any other exceptions
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                choice = GetPromptedChoice("\n[T]est again or [Q]uit?", validChoices);
            }
            while (choice.ToUpper() != "Q");
        }

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
            // Activity 2: Refactor this to use TryParse!
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

        /// <summary>
        /// Given a reference to an array of possible choices, keep prompting
        /// the user until they enter a valid option
        /// NOTE: Validation is case insensitive!
        /// </summary>
        /// <param name="prompt">The prompt to use</param>
        /// <param name="choices">The valid options</param>
        /// <returns>The final valid choice</returns>
        public static string GetPromptedChoice(string prompt, string[] choices)
        {
            string result = GetPromptedInput(prompt);

            // We haven't taught using Predicates in parameters. There are ways to implement
            // this with what you've learned so far, but I didn't feel like making you worry about
            // anything not related to exceptions or TryParse for this PE.
            // https://learn.microsoft.com/en-us/dotnet/api/system.array.exists?view=net-7.0
            while (!Array.Exists(choices, element => element.ToUpper() == result.ToUpper()))
            {
                result = GetPromptedInput(prompt);
            }
            return result;
        }

        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }
    }
}
