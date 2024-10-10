namespace DynamicMenus
{
    /// <summary>
    /// Inherits core behavior from MenuItem
    /// Represents a menu choice that prints out a lucky color
    /// when called.
    /// </summary>
    class LuckyColorItem : MenuItem
    {
        // Constants
        private const int MaxConsoleColor = 14; // Highest enum value for ConsoleColor enum.

        // Fields
        private Random rng;

        // Constructors
        public LuckyColorItem() : base("COLOR", "Get your luck color at the moment",
            "Your lucky color at this moment is: ")
        {
            rng = new Random();
        }

        // Methods
        /// <summary>
        /// Randomly chooses and prints out the luck color.
        /// </summary>
        public override void Run()
        {
            Console.Write(base.actionText);

            // Set background color to a random lucky color, excluding black.
            Console.BackgroundColor = (ConsoleColor)rng.Next(1, MaxConsoleColor + 1);
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
    }
}
