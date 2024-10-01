/*
 * Ryan Zhang
 * PE - Arrays of Objects
 * https://docs.google.com/document/d/1RuAfFYOzlZvX37DgXFVvGX3zMuygVVrpJn4Wg7Fvt-Q/edit?usp=sharing
 */
namespace PE_ArraysOfObjects_Zhang
{
    /// <summary>
    /// Class representing a card in a playing card deck.
    /// </summary>
    internal class Card
    {
        // value of card 1-13 (with 11, 12, 13 being Jack, Queen, King respectively)
        int value;
        // suit of the card
        string suit;

        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }

        /// <summary>
        /// Prints the name of the card in the form "value of suit"
        /// </summary>
        public void Print()
        {
            string name;

            // convert int value into the card's name
            if (value == 1)
            {
                name = "Ace";
            }
            else if (value == 11)
            {
                name = "Jack";
            }
            else if (value == 12)
            {
                name = "Queen";
            }
            else if (value == 13)
            {
                name = "King";
            }
            else 
            {
                name = value.ToString();
            }

            // Append suit to the name
            name += " of ";
            name += suit;

            // print
            Console.WriteLine(name);
        }
    }
}
