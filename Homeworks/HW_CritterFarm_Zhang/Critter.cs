// ------------------------------------------------------------------
// DO NOT MODIFY ANY CODE IN THIS FILE EXCEPT:
// - To add comments where marked with TODO questions
// - To change the critter types available
// ------------------------------------------------------------------
namespace HW6_CritterFarm
{

    /// <summary>
    /// The Critter class defines the core data tracked and behavior for any
    /// critter, but there can be any number of critter types. You'll be required
    /// to implement at least 3 (you can change these to something different if you
    /// wish).
    /// 
    /// This is called an enumeration. You've seen them before (ConsoleColor
    /// is an enum). You use them like constants by providing the type
    /// and the value - e.g. CritterMood myMood = CritterType.Cat 
    /// </summary>
    // TODO: Add THREE new classes that inherit from the Critter base class
    //       Make sure your critter child class names match the enum values below.
    //       You may change these if you want. At least ONE class must have a method
    //       that exists only in the child class. (Cat has CauseMischief in the demo)
    public enum CritterType
    {
        Cat,
        Dog,
        Horse
    }

    /// <summary>
    /// At any given time, a critter can be in one of these moods. It's
    /// behavior will depend on this.
    /// 
    /// This is called an enumeration. You've seen them before (ConsoleColor
    /// is an enum). You use them like constants by providing the type
    /// and the value - e.g. CritterMood myMood = CritterMood.Happy 
    /// </summary>
    public enum CritterMood
    {
        Happy,
        Frustrated,
        Angry
    }

    /// <summary>
    /// Parent class that represents a generic Critter in our Critter Farm game.
    /// The Critter class contains basic statistics and behaviors that it can perform
    /// when the program is run.
    /// 
    /// These basic behaviors include Eat, Play, Talk, and PassTime.
    /// Any other class can access a critter's Hunger and Boredom.
    /// 
    /// Children of this class need to create their own UpdateMood logic for that
    /// critter's specific behavior.
    /// </summary>
    abstract class Critter
    {
        // ----------------------------------------------------------------------
        // CONSTANTS
        // You may change the values ONLY.
        // ----------------------------------------------------------------------

        // Some constants to make quickly changing the default
        // behavior/game balance a bit simpler.
        protected const int FoodAmount = 4;
        protected const int FunAmount = 4;
        protected const int GenAngryLvl = 25;
        protected const int GenFrustrationLvl = 15;

        // ----------------------------------------------------------------------
        // Fields
        // ----------------------------------------------------------------------

        // The data that all critters have.
        protected string name;
        protected CritterMood mood;
        protected CritterType type;
        private int hungerLevel;
        private int boredomLevel;

        // ----------------------------------------------------------------------
        // Properties
        // ----------------------------------------------------------------------

        /// <summary>
        /// Read-only public access to the critter type
        /// </summary>
        public CritterType Type { get { return type; } }

        /// <summary>
        /// Read-only public access to the critter's name
        /// </summary>
        public String Name { get { return name; } }

        /// <summary>
        /// Read-only public access to the critter's hunger level, but
        /// let child classes set the value (but not below 0)
        /// </summary>
        public int Hunger 
        { 
            get { return hungerLevel; } 
            protected set
            {
                hungerLevel = value;

                // Never go below 0
                if(hungerLevel < 0)
                {
                    hungerLevel = 0;
                }
            }
        }

        /// <summary>
        /// Read-only public access to the critter's boredom level, but
        /// let child classes set the value (but not below 0)
        /// </summary>
        public int Boredom
        {
            get { return boredomLevel; }
            protected set
            {
                boredomLevel = value;

                // Never go below 0
                if (boredomLevel < 0)
                {
                    boredomLevel = 0;
                }
            }
        }

        // ----------------------------------------------------------------------
        // Constructor
        // ----------------------------------------------------------------------

        /// <summary>
        /// The Critter class defines only 1 constructor. It is defined as protected so that
        /// it can only be used via a child class (calling it via base(...))
        /// Do NOT add a default constructor and do NOT change this to public
        /// </summary>
        /// <param name="name">All critters must be created with a name</param>
        /// <param name="type">All critters must be created with a type</param>
        /// <param name="hungerLevel">This is defined as an optional parameter. 
        /// If not provided, the hunger level of the new critter defaults to 0</param>
        /// <param name="boredonLevel">This is defined as an optional parameter. 
        /// If not provided, the boredom level of the new critter defaults to 0</param>
        protected Critter(string name, CritterType type, int hungerLevel = 0, int boredomLevel = 0)
        {
            this.name = name;
            this.type = type;
            this.hungerLevel = hungerLevel;
            this.boredomLevel = boredomLevel;
            UpdateMood();
        }

        // ----------------------------------------------------------------------
        // Methods
        // ----------------------------------------------------------------------

        /// <summary>
        /// Updates mood variable based on current happiness level.
        /// Called whenever time passes.
        /// 
        /// All critters need to be able to update their mood variable and this
        /// should be universal across all critters.
        /// However, the specific logic for how a critter's mood changes depends
        /// on the specific critter, hence the children should be the ones to decide
        /// the logic.
        /// </summary>
        protected abstract void UpdateMood();

        /// <summary>
        /// Feeds a critter so its hunger level will reduce.
        /// Lower levels indicate a happier critter.
        /// </summary>
        public void Eat()
        {
            Console.WriteLine("{0} eats a bit. Brrrp!", name);

            // Decrease hunger level, but never beyond 0
            hungerLevel -= FoodAmount;
            if(hungerLevel < 0)
            {
                hungerLevel = 0;
            }
        }


        /// <summary>
        /// Plays with critter so its boredom level will reduce.
        /// Lower levels indicate a happier critter.
        /// </summary>
        public void Play()
        {
            Console.WriteLine("{0} loves playing. Wheee!", name);

            // Decrease boredom level, but never beyond 0
            boredomLevel -= FunAmount;
            
            if (boredomLevel < 0)
            {
                boredomLevel = 0;
            }
        }

        /// <summary>
        /// Get a visual indication of how this critter feels.
        /// Prints a verbal statement of feelings with an emoticon.
        /// </summary>
        public void Talk()
        {
            // Print this critter's feelings based on the set enum variable.
            Console.Write("{0} feels ", name);
            switch(mood)
            {
                case CritterMood.Happy:
                    Console.WriteLine("happy with a full belly and an engaged mind! :)");
                    break;
                case CritterMood.Frustrated:
                    Console.WriteLine("frustrated; being hungry and bored is not fun. :|");
                    break;
                case CritterMood.Angry:
                    Console.WriteLine("angry! Critter smash! Please feed and play with the critter! >:(");
                    break;
            }
        }


        /// <summary>
        /// Simulates passing of time.
        /// As time progresses, critters become slightly more hungry
        /// and bored. 
        /// </summary>
        public void PassTime()
        {
            hungerLevel++;
            boredomLevel++;
            UpdateMood();
        }

        /// <summary>
        /// Provides a string representation of the critter's current stats
        /// </summary>
        public override string ToString()
        {
            // Make sure the mood is up to date
            UpdateMood();

            // Build a string summarizing this critter
            return String.Format(
                "{0} is {3} (Hunger: {1}, Boredom {2})",
                name.ToUpper(),
                hungerLevel,
                boredomLevel,
                mood.ToString().ToLower()); // Converts the enum to an all lowercase string
        }

    }
}
