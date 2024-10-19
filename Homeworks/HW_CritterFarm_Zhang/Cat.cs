namespace HW6_CritterFarm
{
    /// <summary>
    /// Child of Critter class. Represents a Cat critter
    /// with its own starting hunger and boredom values.
    /// As well as it's own UpdateMood method and 
    /// a specialized method for the class called CauseMischief.
    /// </summary>
    internal class Cat : Critter
    {
        // Constants
        // default hunger levels for the Cat specifically.
        private const int StartingHungerLevel = 2;
        // how much CauseMischief reduces the Cat's Boredom.
        private const int MischiefBoredomReduction = 10;

        // Constructors
        /// <summary>
        /// Constructor that creates a Cat with its starting hunger and boredom
        /// and asks for a name value ONLY.
        /// Cat starts with Critter default values for boredom.
        /// </summary>
        /// <param name="name"></param>
        public Cat(string name) :
            base(name, CritterType.Cat, hungerLevel: StartingHungerLevel)
        {
        }

        /// <summary>
        /// Constructor that creates a Cat with a custom hunger and boredom
        /// and name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hungerLevel"></param>
        /// <param name="boredomLevel"></param>
        public Cat(string name, int hungerLevel, int boredomLevel) :
            base(name, CritterType.Cat, hungerLevel, boredomLevel)
        {
        }

        // Override Methods
        /// <summary>
        /// Override for the Critter class's UpdateMood method.
        /// Cat's "irritation" level is calculated with the formula:
        ///     irritation = Hunger + 2*Boredom
        ///     
        /// Otherwise, Cat uses the same constants as other Critter classes
        /// for when Angry and Frustrated are triggered.
        /// </summary>
        protected override void UpdateMood()
        {
            // Formula for calculation irritation unique to Cat.
            int irritation = Hunger + 2*Boredom;

            // Check irritation against thresholds for each mood.
            // Thresholds defined as constants in Critter class.
            if (irritation > GenAngryLvl)
            {
                mood = CritterMood.Angry;
            }
            else if (irritation > GenFrustrationLvl)
            {
                mood = CritterMood.Frustrated;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }

        // Class Methods
        /// <summary>
        /// Method unique to Cat class. Lowers boredom level dramatically.
        /// </summary>
        public void CauseMischief()
        {
            Console.WriteLine("{0} also gets joy out of randomly causing trouble!", name);

            Boredom -= MischiefBoredomReduction;
        }
    }
}
