/*
 * Ryan Zhang
 * PE - If's & Switches
 * https://docs.google.com/document/d/1uuSWGZ0ucs9T6YoB7kT1kYaL9xvL0Rvi3F2drohkIE0/edit
 */
namespace PE_IfsAndSwitches_Zhang
{
    internal class Program
    {
        // Asks a series of questions like a quiz and parses user inputs to evaluate against a correct answer.
        static void Main(string[] args)
        {
            // Setup - Initial variable declaration
            // Question 1
            const int CorrectAnswer1 = 42;
            int response1;

            // Question 2
            int response2A;
            int response2B;
            int response2C;

            // Question 3
            string response3;

            // Prompting, User Inputs & Evaluation
            // Question 1
            // Ask the question and prompt for response
            Console.Write("What is 6 * 7? ");
            response1 = int.Parse(Console.ReadLine());

            // simple if/else statement
            // compare to corrrect answer
            if (response1 == 42)
            {
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine("Nope :(");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Question 2
            // Ask the question and prompt for response
            Console.WriteLine("Enter 3 whole numbers in *ascending* order: ");
            Console.Write("1:   ");
            response2A = int.Parse(Console.ReadLine());
            Console.Write("2:   ");
            response2B = int.Parse(Console.ReadLine());
            Console.Write("3:   ");
            response2C = int.Parse(Console.ReadLine());

            // if/else if/else statement with BOTH relational and boolean operators used to form compound conditions
            // Ascending order
            if(response2A < response2B && response2B < response2C)
            {
                Console.WriteLine("That's correct!");
            }
            // Descending order
            else if(response2A > response2B && response2B > response2C)
            {
                Console.WriteLine("That's backwards!");
            }
            // other
            else
            {
                Console.WriteLine("What?!");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Question 3
            // Ask the question and prompt for response
            Console.WriteLine("Switches are best for...\n" +
                "        a. Checking the status of a combination of variables\n" +
                "        b. Checking for different discrete values of the same variable\n" +
                "        c. Checking if a variable's value is within a certain range\n" +
                "        d. All of the above");
            Console.Write("> ");
            response3 = Console.ReadLine().Trim().ToLower();

            // switch statement
            // evaluate response for correct, incorrect, and invalid answers
            switch (response3)
            {
                // correct
                case "b":
                    Console.WriteLine("Correct!");
                    break;

                // incorrect
                case "a":
                case "c":
                case "d":
                    Console.WriteLine("Sorry. That's incorrect. Switches are best for checking\n" +
                        "for different *discrete values* of the *same* variable.");
                    break;
                
                // invalid
                default:
                    Console.WriteLine("That wasn't even an option!");
                    break;
            }
        }
    }
}
