/*
 * Ryan Zhang
 * PE - If Statements
 * https://docs.google.com/document/d/1r6n9DdOHQMa6qZYm-9p6EaWF_Dfp6S4q8QvW-igVvYQ/edit
 */
namespace PE_IfStatements_Zhang
{
    internal class Program
    {
        // A simple AI that responds to the player's input(s) using if statements
        static void Main(string[] args)
        {
            /*
             *  Scenario    | Input         | Response
             *  1           | Unity         | The NPC makes a new Unity project and starts fiercly coding away!
             *  2           | Fridge        | The NPC grabs random ingredients and tosses them all into a boiling pot.
             *  3           | Front Door    | Does the NPC go outside or stay inside?
             *              |   -> Outide   | The NPC is much healthier after going out for a walk.
             *              |   -> Inside   | The NPC becomes sad, depressed, and socially isolated.
             *              |   -> Other    | The NPC picked an imaginary space and the dimensions of the world fold over.
             * Unexpected   | ANY OTHER     | The NPC freezes up and does not know what to do.
             */
            
            // Stores the player input after ToLower() and Trim() methods
            string input;

            Console.Write("What does the NPC in your game sense? ");
            input = Console.ReadLine().ToLower().Trim();

            if (input.Equals("unity")) // scenario 1
            {
                Console.WriteLine("The NPC makes a new Unity project and starts fiercly coding away!");
            }
            else if (input.Equals("fridge")) // scenario 2
            {
                Console.WriteLine("The NPC grabs random ingredients and tosses them all into a boiling pot.");
            }
            else if (input.Equals("front door")) // scenario 3
            {
                Console.Write("Does the NPC go outside or stay inside? ");
                input = Console.ReadLine().ToLower().Trim();

                if (input.Equals("outside") || input.Equals("go outside")) // option 1
                {
                    Console.WriteLine("The NPC is much healthier after going out for a walk.");
                }
                else if (input.Equals("inside") || input.Equals("stay inside")) // option 2
                {
                    Console.WriteLine("The NPC becomes sad, depressed, and socially isolated.");
                }
                else // other
                {
                    Console.WriteLine("The NPC picked an imaginary space and the dimensions of the world fold over.");
                }
            }
            else // unexpected
            {
                Console.WriteLine("The NPC freezes up and does not know what to do.");
            }

        }
    }
}
