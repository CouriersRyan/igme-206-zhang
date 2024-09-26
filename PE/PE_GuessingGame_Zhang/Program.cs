/*
 * Ryan Zhang
 * PE - Guessing Game
 * https://docs.google.com/document/d/1_VNlxiE2SSDOxhRLTJtHTYpb7oMC5IXzam2HrVY9XHk/edit?usp=sharing
 */
namespace PE_GuessingGame_Zhang
{
    internal class Program
    {
        /// <summary>
        /// A guessing game in the console. Generates a random integer between 0 and 100 inclusive and prompts the user to guess the number.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Constants
            const int maxTurns = 8;
            const int minValue = 0;
            const int maxValue = 100; // inclusive

            // Generate a random number the player will guess
            Random rng = new Random();
            int targetNumber = rng.Next(minValue, maxValue + 1); // 0 to 100 inclusive

            // User variable declaration
            string userPrompt = "Turn #{0}: Guess a number between 0 and 100 (inclusive): ";
            int turn = 1;
            int guess;
            bool success; // for TryParse

            // Loop to reprompt user for multiple inputs,
            // if the guess is valid but wrong increment the turn number.
            // Otherwise, reprompt the user for the same turn.
            do
            {
                Console.Write(userPrompt, turn);
                success = int.TryParse(Console.ReadLine(), out guess);
                
                // Valid guesses are integers between 0 and 100 inclusive.
                if (success && guess >= minValue && guess <= maxValue)
                {
                    // Compare the guess if it is valid.
                    // Print 'Too high' or 'Too low' and increment turn if the target was not guessed
                    if(guess > targetNumber)
                    {
                        Console.WriteLine("Too high");
                        turn++;
                    }
                    else if(guess < targetNumber)
                    {
                        Console.WriteLine("Too low");
                        turn++;
                    }
                }
                else
                {
                    // Otherwise prompt the user to try again, without incrementing turn.
                    Console.WriteLine("Invalid guess - try again.");
                }
                Console.WriteLine();

            // Loop while number hasn't been guessed and max turns hasn't been exceeded.
            } while (guess != targetNumber && turn <= maxTurns);

            
            // Check if target was guessed
            if (guess == targetNumber)
            {
                Console.WriteLine("Correct! You won in {0} turns.", turn);
            }
            // otherwise assume turns ran out
            else
            {
                Console.WriteLine("\nYou ran out of turns. The number was {0}", targetNumber);
            }
        }
    }
}
