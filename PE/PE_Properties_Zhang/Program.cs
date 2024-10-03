/*
 * Ryan Zhang
 * PE - Properties
 * https://docs.google.com/document/d/1z9HVMUdQWjPEswC2UwoDFwaoHdpaLT1Yvo7KtKBBaYs/edit?usp=sharing
 */
namespace PE_Properties_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Book Simulator 2020 - simulates a book using OOP, allows the user to access properties of the book, change the owner, and read the book.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Book book;
            string input;
            string title;
            string author;
            int numberOfPages;
            string owner;
            bool done = false;

            // Print intro
            Console.WriteLine("Welcome to Book Simulator 2020");
            Console.WriteLine();

            // Prompt for values to create initial book
            title = GetPromptedInput("What is the book's title?");
            author = GetPromptedInput("Who is the book's author?");
            numberOfPages = GetValidIntegerInput("How many pages does it have?", 0, int.MaxValue);
            owner = GetPromptedInput("Who is the book's current owner?");

            book = new Book(title, author, numberOfPages, owner);

            Console.WriteLine();

            // Continues to loop while the user is not 'done'
            // Asks for commands which are parsed from a list.
            while (!done)
            {
                input = GetPromptedInput("What would you like to do?", true);

                // All possible responses to player input
                switch (input)
                {
                    // Print the title of the book
                    case "title":
                        Console.WriteLine("The title is {0}.", book.Title);
                        break;

                    // Print the author of the book
                    case "author":
                        Console.WriteLine("The author is {0}.", book.Author);
                        break;

                    // Print the number of pages
                    case "pages":
                        Console.WriteLine("The book has {0} pages", book.NumberOfPages);
                        break;

                    // Asks the player whether they want to change the owner of the book
                    // otherwise, print the old owner again.
                    case "owner":
                        input = GetPromptedInput("Would you like to change the owner (yes/no)?", true);
                        switch (input)
                        {
                            case "yes":
                                input = GetPromptedInput("Who is the new owner?");
                                book.Owner = input;
                                Console.WriteLine("The new owner is {0}.", book.Owner);
                                break;

                            case "no":
                                Console.WriteLine("Ok. {0} is still the owner.", book.Owner);
                                break;

                            default:
                                Console.WriteLine("Invalid input, please try again.");
                                break;
                        }
                        break;

                    // Increases times read by one and print total times read.
                    case "read":
                        book.TimesRead++;
                        Console.WriteLine("The total times read is now {0}.", book.TimesRead);
                        break;

                    // Prints info on the book using the Book's Print method
                    case "print":
                        book.Print();
                        break;

                    // Exit the program
                    case "done":
                        Console.WriteLine("Goodbye");
                        done = true;
                        break;

                    // Invalid case, reprompt
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
                Console.WriteLine();
            }
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
