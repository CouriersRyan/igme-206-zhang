namespace PE_IfsAndSwitches_Zhang
{
    internal class Program
    {
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
                Console.WriteLine("That's correct");
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

            }
            // Descending order
            else if(response2A > response2B && response2B > response2C)
            {

            }
            // other
            else
            {

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Question 3
            // Ask the question and prompt for response
            response3 = Console.ReadLine().Trim().ToLower();

            // switch statement
            // evaluate response for correct, incorrect, and invalid answers
            switch (response3)
            {
                // correct
                case "b":
                    break;

                // incorrect
                case "a":
                case "c":
                case "d":
                    break;
                
                // invalid
                default:
                    break;
            }
        }
    }
}
