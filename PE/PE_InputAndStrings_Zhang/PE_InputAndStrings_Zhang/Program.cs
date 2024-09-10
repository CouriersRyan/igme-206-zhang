/* 
 * Ryan L. Zhang
 * PE - Input & Strings
 * https://docs.google.com/document/d/1jY5NojS8rVRq7ZhxB_5E4hoRj30y40zFMzAa1X0sBN0/edit
 */
using Microsoft.VisualBasic;

namespace PE_InputAndStrings_Zhang
{
    internal class Program
    {
        // Program that asks for multiple user inputs and analyzes them to print various statements.
        static void Main(string[] args)
        {
            // Variable declaration for user inputs.
            String name;
            String color;
            String petName;
            String band;

            // Prompt for user's name and response.
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.WriteLine("Welcome " + name + "!");

            // Asks for three other pieces of information on their favorites.
            Console.Write("What is your favorite color? ");
            color = Console.ReadLine();
            Console.Write("What is your pet's name? ");
            petName = Console.ReadLine();
            Console.Write("What is your favorite band? ");
            band = Console.ReadLine();
            Console.WriteLine();

            // Analysis of information and responses
            // 1. The length of the user’s name
            Console.WriteLine("Your name is " + name.Length + " letters long");

            // 2. How much longer the user’s name is than another piece of info(e.g.user name length - pet name length)
            Console.WriteLine("and " + (name.Length - petName.Length) + " letters longer than " + petName + "'s name.");
            Console.WriteLine();

            // 3. Some kind of statement that uses everything but the user’s name and shows the user-entered strings in uppercase.
            Console.WriteLine("I wonder if " + petName.ToUpper() + " and " + band.ToUpper() + " like " + color.ToUpper() + " as much as you do.");
            Console.WriteLine();

            // 4. A made-up name that is 7 characters long by combining:
            //      - The first character of the user’s name, uppercase. (i.e., name.ToUpper()[0])
            //      - The first 2 characters of each of the other strings(all made lowercase before getting the substrings)
            Console.WriteLine("Maybe I should just call you " + name.ToUpper()[0] + color.ToLower().Substring(0, 2)
                + petName.ToLower().Substring(0, 2) + band.ToLower().Substring(0, 2));
        }
    }
}
