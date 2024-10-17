//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for weapons
    /// </summary>
    class Weapon : Item
    {
        // NO additional fields or properties are permitted.
        private double weight;
        private int damage;

        /// <summary>
        /// Return how much damage this weapon can do.
        /// </summary>
        public int Damage { get { return damage; } }

        /// <summary>
        /// Item class's required abstract Weight property.
        /// </summary>
        public override double Weight {
            get
            {
                return weight; 
            }
        }

        /// <summary>
        /// Create a new Weapon item that contains a name,
        /// damage of the weapon, and its weight.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="weight"></param>
        public Weapon(string name, int damage, double weight) : base(name)
        {
            this.damage = damage;
            this.weight = weight;
        }

        /// <summary>
        /// Prints a basic Item summary and
        /// add on the damage value of the weapon.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}, {1} damage", base.ToString(), damage);
        }
    }
}
