namespace _9_12Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Testing a new color scheme");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();

            // Reset back to reasonable colors
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("That's better!");

        }
    }
}
