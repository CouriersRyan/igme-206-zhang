/*
 * Ryan Zhang
 * PE - Lists
 * https://docs.google.com/document/d/1yr-JcmbBOSWCzaoHlt7F1n6dnWku0ZKLwbX_2kfBm_w/edit?usp=sharing
 */
namespace PE_Lists_Zhang
{
    /// <summary>
    /// Player with a name and inventory of items
    /// </summary>
    internal class Player
    {
        // Fields
        private string name;
        private List<String> inventory;

        // Properties
        public string Name
        {
            get => name;
        }

        // Constructor
        public Player(string name)
        {
            this.name = name;
            inventory = new List<String>();
        }

        // Methods
        /// <summary>
        /// Adds an item to the inventory and prints a statement to the console.
        /// </summary>
        /// <param name="item"></param>
        public void AddToInventory(String item)
        {
            inventory.Add(item);
            Console.WriteLine("Item '{0}' added to {1}'s inventory.", item, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public String GetItemInSlot(int index)
        {
            // Exit early if index is not valid.
            if (index < 0 || index >= inventory.Count)
            {
                return null;
            }

            // Save item reference at index to a temp variable.
            String item = inventory[index];
            // Remove item from inventory
            inventory.RemoveAt(index);

            return item;
        }

        /// <summary>
        /// Prints a formatted list of all items in the inventory to console.
        /// </summary>
        public void PrintInventory()
        {
            string itemFormat = "\t- {0}";

            Console.WriteLine("{0}'s Inventory:", name);

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine(itemFormat, inventory[i]);
            }
        }
    }
}
