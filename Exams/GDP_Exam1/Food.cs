//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
using static System.Net.Mime.MediaTypeNames;

namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for foods
    /// </summary>
    class Food : Item
    {
        // NO additional fields are permitted.
        private int numServings;
        private double lbsPerServing;

        /// <summary>
        /// The returned weight of a food is:
        ///     number of servings * weight per serving
        /// </summary>
        public override double Weight
        {
            get
            {
                return numServings * lbsPerServing;
            }
        }

        /// <summary>
        /// Creates a new Food object that contains a name,
        /// the number of servings, and how much each serving weighs.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numServings"></param>
        /// <param name="lbsPerServing"></param>
        public Food(string name, int numServings, double lbsPerServing) : base(name)
        {
            this.numServings = numServings;
            this.lbsPerServing = lbsPerServing;
        }

        /// <summary>
        /// Eats a serving of food
        /// </summary>
        public void Eat()
        {
            // Decrement servings and eat food so long as there are servings
            if(numServings > 0)
            {
                Console.WriteLine("Mmmm I ate a serving of " + this.Name);
                numServings--;
            }
            // Otherwise, tell the user there are no servings left.
            else
            {
                Console.WriteLine(":( There's no " + Name + " left to eat.");
            }
        }

        /// <summary>
        /// Leverage the base class ToString 
        /// and add on the number of servings.
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0} and has {1} servings", base.ToString(), numServings);
        }

    }
}
