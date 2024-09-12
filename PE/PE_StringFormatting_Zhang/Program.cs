/*
 * Ryan Zhang
 * PE - String Formatting
 * https://docs.google.com/document/d/1cSjoItBB29vQMierRirOugLgHEsvWvopl3NMiyo79Yg/edit
 */
namespace PE_StringFormatting_Zhang
{
    internal class Program
    {
        // Takes in player text input and uses string formatting to output a story.
        static void Main(string[] args)
        {
            // template for string formatting
            const string StatusUpdateTemplate = "{0}, you now have {1} health and {2:C} remaining.";

            // initial player data
            string name;
            string title;
            string nameWithTitle;
            int health = 100;
            double wallet;

            // actions and buying
            string action;
            int actionHealthReq;
            string item;
            double itemCost;

            // Part 1:  Player Input & Greeting
            Console.Write("What is your name brave adventurer? ");
            name = Console.ReadLine();
            Console.Write("What is your title? ");
            title = Console.ReadLine();
            nameWithTitle = String.Format("{0} the {1}", name, title);
            Console.Write("How much money are you carrying? $");
            wallet = double.Parse(Console.ReadLine());
            Console.WriteLine("Welcome {0}!", nameWithTitle);
            Console.WriteLine();

            // Part 2: The player does something
            Console.Write("What do you want to do next? ");
            action = Console.ReadLine();
            Console.Write("How much health does it take to do this? ");
            health -= int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Okay, let's see you {0}!", action);
            Console.WriteLine(StatusUpdateTemplate, nameWithTitle, health, wallet);
            Console.WriteLine();

            // Part 3: The player buys something
            Console.Write("What do you want to buy? ");
            item = Console.ReadLine();
            Console.Write("How much does it normally cost? ");
            itemCost = double.Parse(Console.ReadLine()) * 1.1;
            wallet -= itemCost;
            Console.WriteLine();
            Console.WriteLine("You bought {0} for {1:C3}", item, itemCost);
            Console.WriteLine(StatusUpdateTemplate, nameWithTitle, health, wallet);
        }
    }
}
