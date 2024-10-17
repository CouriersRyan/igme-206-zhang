//****************************************************************
// DO NOT modify anything in this file!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// The Item class provides a foundation for all other classes
    /// you'll create for this practical.
    /// </summary>
    abstract class Item
    {
        /// <summary>
        /// All items have a name
        /// </summary>
        private string name;

        /// <summary>
        /// The name can always be read via a property
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// All items also have a weight, but Item doesn't
        /// know how to get it
        /// </summary>
        abstract public double Weight { get; }

        /// <summary>
        /// All items must be created with at least a name
        /// </summary>
        /// <param name="name">The name to give to this item</param>
        public Item(string name)
        {
            this.name = name.ToUpper();
        }

        /// <summary>
        /// All items can proide their name and weight as a 
        /// well formatted string.
        /// </summary>
        /// <returns>A string containing the item's name and weight</returns>
        public override string ToString()
        {
            return String.Format("{0}: {1:F2} lbs",
                name,
                Weight);
        }
    }
}
