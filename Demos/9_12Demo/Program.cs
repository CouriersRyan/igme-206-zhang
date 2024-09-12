namespace _9_12Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double value = 123.4567; // Already declared as a double
            String s = String.Format("Price is {0}.", value);
            Console.Write("Via Format: ");
            Console.WriteLine(s);
            Console.WriteLine();

            Console.Write("Via WL: ");
            Console.WriteLine("Price is {0}.", value);
            Console.WriteLine();

        }
    }
}
