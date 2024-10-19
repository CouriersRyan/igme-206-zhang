namespace HW6_CritterFarm
{
    /// <summary>
    /// Child of Critter class. Represents a Horse critter
    /// with its own starting hunger and boredom values.
    /// As well as it's own UpdateMood method.
    /// </summary>
    internal class Horse : Critter
    {

        // Constructors
        /// <summary>
        /// Constructor that creates a Horse with its starting hunger and boredom
        /// and asks for a name value ONLY.
        /// Horse starts with Critter default values for hunger and boredom.
        /// </summary>
        /// <param name="name"></param>
        public Horse(string name) :
            base(name, CritterType.Horse)
        {
        }

        /// <summary>
        /// Constructor that creates a Horse with a custom hunger and boredom
        /// and name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hungerLevel"></param>
        /// <param name="boredomLevel"></param>
        public Horse(string name, int hungerLevel, int boredomLevel ) :
            base(name, CritterType.Horse, hungerLevel, boredomLevel)
        {
        }

        // Override Methods
        /// <summary>
        /// Override for the Critter class's UpdateMood method.
        /// Horse's "irritation" level is calculated with the formula:
        ///     irritation = 2*Hunger + Boredom
        ///     
        /// Otherwise, Horse uses the same constants as other Critter classes
        /// for when Angry and Frustrated are triggered.
        /// </summary>
        protected override void UpdateMood()
        {
            // Formula for calculation irritation unique to Horse.
            int irritation = 2*Hunger + Boredom;

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
