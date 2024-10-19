namespace HW6_CritterFarm
{
    /// <summary>
    /// Child of Critter class. Represents a Dog critter
    /// with its own starting hunger and boredom values.
    /// As well as it's own UpdateMood method.
    /// </summary>
    internal class Dog : Critter
    {
        // Constants
        // default hunger and boredom levels for the Dog specifically.
        private const int StartingHungerLevel = 5;
        private const int StartingBoredomLevel = 5;

        // Constructors
        /// <summary>
        /// Constructor that creates a Dog with its starting hunger and boredom
        /// and asks for a name value ONLY.
        /// </summary>
        /// <param name="name"></param>
        public Dog(string name) :
            base(name, CritterType.Dog, StartingHungerLevel, StartingBoredomLevel)
        {
        }

        /// <summary>
        /// Constructor that creates a Dog with a custom hunger and boredom
        /// and name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hungerLevel"></param>
        /// <param name="boredomLevel"></param>
        public Dog(string name, int hungerLevel, int boredomLevel) :
            base(name, CritterType.Dog, hungerLevel, boredomLevel)
        {
        }

        // Override Methods
        /// <summary>
        /// Override for the Critter class's UpdateMood method.
        /// Dog's "irritation" level is calculated with the formula:
        ///     irritation = Hunger + Boredom
        ///     
        /// Otherwise, Dog uses the same constants as other Critter classes
        /// for when Angry and Frustrated are triggered.
        /// </summary>
        protected override void UpdateMood()
        {
            // Formula for calculation irritation.
            int irritation = Hunger + Boredom;

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
    }
}
