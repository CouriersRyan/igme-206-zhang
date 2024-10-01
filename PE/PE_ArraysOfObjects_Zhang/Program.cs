/*
 * Ryan Zhang
 * PE - Arrays of Objects
 * https://docs.google.com/document/d/1RuAfFYOzlZvX37DgXFVvGX3zMuygVVrpJn4Wg7Fvt-Q/edit?usp=sharing
 */
namespace PE_ArraysOfObjects_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Creates a deck and prints it out, then asks for an amount of cards to deal and prints dealt cards.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Print out the deck.
            int amount;
            Deck deck = new Deck();
            deck.Print();

            // Prompt for a number of cards to deal.
            Console.WriteLine();
            Console.Write("Enter a number of cards to deal (1-52): ");
            amount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Deals cards out and print.
            deck.Deal(amount);
        }
    }
}
