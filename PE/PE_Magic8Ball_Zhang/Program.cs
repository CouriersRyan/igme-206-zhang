/*
 * Ryan Zhang
 * PE - Magic 8 Ball
 * https://docs.google.com/document/d/13OBHKxRLnRKNiYijs119CSW9Y7kW77oRCd1uovYR-Hs/edit?usp=sharing
 */
namespace PE_Magic8Ball_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Runs the a MAgic 8 Ball simulator in console using the MagicEightBall class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string input;
            MagicEightBall magicEightBall;
            bool isRunning = true; // true until the user wants to 'quit'

            // Introduction and prompt for name.
            Console.WriteLine("Welcome to Magic 8 Ball Simulator!");
            Console.Write("  > Who owns this ball?  ");
            input = Console.ReadLine().Trim();
            Console.WriteLine();

            // Make instance of MagicEightBall using user input.
            magicEightBall = new MagicEightBall(input);

            // Loops for user inputs to use the Magic 8 Ball.
            while (isRunning)
            {
                // Ask for prompt
                Console.WriteLine("What would you like to do?");
                Console.Write("You can ‘shake’ the ball, get a ‘report’, or ‘quit’:  ");
                input = Console.ReadLine().Trim().ToLower();

                // shake
                // ask for a question and get a response
                if (input.Equals("shake"))
                {
                    Console.Write( "  > What is your question? ");
                    Console.ReadLine(); // don't actually need to use the input
                    Console.WriteLine("  > Magic 8 Ball says: {0}", magicEightBall.ShakeBall());
                }
                // report
                // print how many times the ball has been shaken
                else if (input.Equals("report"))
                {
                    Console.WriteLine("  > " + magicEightBall.Report());
                }
                // quit
                // set loop variable to false
                else if (input.Equals("quit"))
                {
                    isRunning = false;
                    Console.WriteLine("  > Goodbye!");
                } 
                else 
                { 
                    Console.WriteLine("  > I do not recognize that response.");
                }

                Console.WriteLine();
            }
        }
    }
}
