/*
 * Ryan Zhang
 * PE - Arrays of Objects
 * https://docs.google.com/document/d/1RuAfFYOzlZvX37DgXFVvGX3zMuygVVrpJn4Wg7Fvt-Q/edit?usp=sharing
 */
namespace PE_ArraysOfObjects_Zhang
{
    /// <summary>
    /// Represents a deck of 52 playing cards of the Card class
    /// </summary>
    internal class Deck
    {
        Random rng;
        Card[] cards;

        /// <summary>
        /// Instantiate a new 52 card playing card deck filled with appropriate cards.
        /// </summary>
        public Deck()
        {
            rng = new Random();
            cards = new Card[52];

            string[] suits = { "Hearts", "Spades", "Diamonds", "Clubs" };

            // fills the cards array with cards
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    cards[i * 13 + j] = new Card(j + 1, suits[i]);
                }
            }
        }

        /// <summary>
        /// Iterates over the entire deck to print every card in the deck.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Your deck:");
            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write(" - ");
                cards[i].Print();
            }
        }

        /// <summary>
        /// Deals a specified number of cards from hand, randomly chosen from deck.
        /// </summary>
        /// <param name="amount"></param>
        public void Deal(int amount)
        {
            Console.WriteLine("Your hand:");
            for (int i = 0; i < amount; i++)
            {
                Console.Write(" - ");
                cards[rng.Next(0, cards.Length)].Print();
            }
        }
    }
}
