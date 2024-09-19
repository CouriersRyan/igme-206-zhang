/*
 * Ryan Zhang
 * PE - 1d Arrays
 * https://docs.google.com/document/d/1tkjGUPDFXSEDYUME1cV0-89FkmgRUhNV0G_jRE-_u7E/edit
 */
namespace PE_1dArrays_Zhang
{
    internal class Program
    {
        // Practice with creting and using one-dimensional arrays.
        static void Main(string[] args)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ VARIABLES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Some local variables to support playing with different
            // types of arrays in different ways.
            double[] scores = { 1, 1.23, 2, 2.34, 3, 3.45, 4, 4.56, 5, 5.67, 6, 6.78, 7, 7.89, 8, 8.90, 9, 9.01, 10 };
            double sum;
            double average;
            string name; // Yes, this is an array too! Strings use a char[] under the hood.
            const int MaxNum = 50; // This will always be >5
            int[] fives;
            int sizeOfFives;



            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ FILL ARRAYS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Use a loop to prompt the user for a name that is at least 5 characters long
            Console.Write("Enter a name with at least 5 letters: ");
            name = Console.ReadLine().Trim();
            // Re-prompts the user so long as the name inputted is fewer than 5 characters
            while(name.Length < 5)
            {
                Console.WriteLine("That name has {0} letters.", name.Length);
                Console.Write("Please enter a name with at least 5 letters: ");
                name = Console.ReadLine().Trim();
            }
            Console.WriteLine();

            // Figure out how many multiples of 5 there are between 5 and MaxNum (inclusive),
            sizeOfFives = MaxNum / 5;
            // initialize fives to have an array that will hold that many numbers,
            fives = new int[sizeOfFives];
            // then use a loop to fill it
            for (int i = 0; i < sizeOfFives; i ++)
            {
                fives[i] = (i + 1) * 5;
            }


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ CALCS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Use a loop to calculate the sum of all values in the scores array.
            sum = 0;
            for(int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }

            // Use the sum and size of the scores array to calculate the average
            average = sum / scores.Length;



            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OUTPUT ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Without using Substring, print out every other character in the name
            //  (Use a loop and access the characters 1 by 1 instead)
            Console.Write("Nickname: ");
            for(int i = 0; i < name.Length; i++)
            {
                // Check for even number index.
                if(i % 2 == 0)
                {
                    Console.Write(name[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Print the fives array all on 1 line
            Console.Write("Fives: ");
            for (int i = 0; i < fives.Length; i++)
            {
                Console.Write(fives[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Print out the sum and average of the scores 
            Console.WriteLine("Total scpre: {0}", sum);
            Console.WriteLine("Average score: {0}", average);
            Console.WriteLine();

            // Print a list of all scores that are divisible by 2
            Console.Write("Scores divisible by 2: ");
            for(int i = 0; i < scores.Length; i++)
            {
                if (scores[i] % 2 == 0)
                {
                    Console.Write(scores[i] + " ");
                }
            }
        }
    }
}
