/*
 * Ryan L. Zhang
 * PE - Data Types & Variables
 * https://docs.google.com/document/d/1U91F590ypwhbyZGczKPR0nOnukeN886Zx_xY-AxTJSE/edit?usp=sharing
 */
using System.Threading.Channels;
using System.Xml.Linq;

namespace PE_DataTypesAndVariables_Zhang
{
    /// <summary>
    /// Calculates stats for and prints out a character sheet to the console using variables.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Name – The character’s name
            string name = "Tim Tanuki";
            // Starting points – The total starting points for a character (50 in this case).
            const float startPoints = 50;

            // Strength – 23% of the starting points.Use the starting point variable in the calculation.
            float strength = 50 * 0.23f;

            // Dexterity – Half of the strength value.Use your strength variable in the calculation.
            float dexterity = strength / 2.0f;

            // Intelligence – Always exactly 7.
            float intelligence = 7;

            // Health – The sum of the dexterity & intelligence variables, minus 2.
            float health = dexterity + intelligence - 2;

            // Charisma – The leftover points.Calculate this using all of the relevant variables listed above.
            float charisma = 50 - (strength + dexterity + intelligence + health);

            // Total points – Add all of the stat variables above to ensure the total truly is 50.
            float totalPoints = strength + dexterity + intelligence + health + charisma;

            // Prints the character's info to the console using variables with formatting and labels.
            Console.WriteLine("Name: " + name);
            Console.WriteLine();
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Charisma: " + charisma);
            Console.WriteLine();
            Console.WriteLine("TOTAL: " + totalPoints);
        }
    }
}
