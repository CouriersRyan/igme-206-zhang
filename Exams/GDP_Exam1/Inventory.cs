//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            get 
            {
                return items.Count;
            }
        }

        /// <summary>
        /// Add a provided Item reference into the inventory list.
        /// </summary>
        /// <param name="itemToAdd"></param>
        public void AddItem(Item itemToAdd)
        {
            items.Add(itemToAdd);
        }

        /// <summary>
        /// Method to print the number of items
        /// in the inventory and then a summary of each item.
        /// </summary>
        public void PrintSummary()
        {
            // total item inventory count
            Console.WriteLine("Your inventory currently has {0} item(s):", items.Count);

            // summary of each item in inventory
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("\t{0}", items[i]);
            }

            // total weight
            Console.WriteLine("Total weight: {0}", CalculateTotalWeight());

            // total damage of weapons
            Console.WriteLine("Total damage from weapon(s): {0}", CalculateTotalDamage());
        }


        /// <summary>
        /// Return the total weight of all items in
        /// the inventory.
        /// </summary>
        private double CalculateTotalWeight()
        {
            double total = 0;
            // check all items in the inventory and add their weight.
            for (int i = 0; i < items.Count; i++)
            {
                total += items[i].Weight;
            }
            return total;
        }

        /// <summary>
        /// Return the total damage of all
        /// weapons in the inventory.
        /// </summary>
        private double CalculateTotalDamage()
        {
            double total = 0;
            // check for weapons across all items in the inventory and add their damage.
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is Weapon)
                {
                    total += ((Weapon)items[i]).Damage;
                }
            }

            Math.Round(total, 2); // Nearest 2 decimal places
            return total;
        }

        /// <summary>
        /// Loads items from a file line by line.
        /// </summary>
        /// <param name="filename"></param>
        public void LoadItems(string filename)
        {
            StreamReader input = null;

            try
            {
                // Read provided file name.
                input = new StreamReader(filename);
                string line = null;

                // Read lines until there is no more lines in the file.
                while ((line = input.ReadLine()) != null)
                {
                    // For each line, seperate the data and create
                    // new Food or Weapon objects appropriately
                    string[] data = line.Split('~');

                    // check if line is weapon data
                    if (data[0].Equals("Weapon"))
                    {
                        int damage = int.Parse(data[2]);
                        double weight = double.Parse(data[3]);
                        Weapon newWeapon = new Weapon(data[1], damage, weight);
                        AddItem(newWeapon);
                    }
                    // or food data
                    else if (data[0].Equals("Food"))
                    {
                        int numServings = int.Parse(data[2]);
                        double lbsPerServing = double.Parse(data[3]);
                        Food newFood = new Food(data[1], numServings, lbsPerServing);
                        AddItem(newFood);
                    }
                }
            }
            // Print out the error if there was issue reading the file.
            catch (IOException e)
            {
                Console.WriteLine("Uh oh: {0}", e.Message);
            }

            // Close file if it was opened properly.
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
