/*
 * Ryan L. Zhang
 * PE - Statements & Expressions
 * https://docs.google.com/document/d/1vl8WUygXAinknNA2v_4nWTg9IuH8rUOCzFjw5Y7y4tU/edit?usp=sharing
 */


namespace PE_StatementsAndExpressions_RZ
{
    /// <summary>
    /// Calculates stats for and prints out a character sheet to the console with the name and stats based off of calculations using a 50 point stat total.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Print the character's name.
            Console.WriteLine("Name: Rob Raccoon");

            // Writes a blank line to Console.
            Console.WriteLine();



            // Allocates 50 points to stats through calculations.

            // Stat 1: 20% of the total points.
            Console.WriteLine(0.2 * 50 + " Strength");

            // Stat 2: Half of the first stat.
            Console.WriteLine((0.2 * 50) / 2 + " Dexterity");

            // Stat 3: Always exactly 7 points.
            Console.WriteLine(7 + " Constitution");

            // Stat 4: Sum of the 2nd and 3rd stats minus 2.
            Console.WriteLine(
                ((0.2 * 50) / 2) +      // Stat 2
                7                       // Stat 3
                - 2 + " Health"
            );

            // Stat 5: All leftover points.
            Console.WriteLine(
                50 - (                          // Total Stat Points
                    (0.2 * 50) +                // Stat 1
                    ((0.2 * 50) / 2) +          // Stat 2
                    7 +                         // Stat 3
                    (((0.2 * 50) / 2) + 7 - 2)  // Stat 4
                ) + " Sanity"
            );

            // Writes a blank line to Console.
            Console.WriteLine();

            // Prints a line about the total number of stat points
            Console.WriteLine("TOTAL: 50");
        }
    }
}
