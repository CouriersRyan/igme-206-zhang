// ------------------------------------------------------------------
// DO NOT MODIFY ANY CODE IN THIS FILE EXCEPT:
// - To implement file loading & saving
// - To change the critter types available
// ------------------------------------------------------------------

namespace HW6_CritterFarm
{
    /// <summary>
    /// The CritterManager class stores a list of Critters and allows the user to
    /// perform specific actions with them through this class.
    /// The class also allows the user to control the critters in the list,
    /// saving and loading them from file, or selecting which critter is active.
    /// 
    /// Users can use this class to get access to the list of Critters it contains,
    /// as well as get a summary of the Critters.
    /// </summary>
    class CritterManager
    {
        // ----------------------------------------------------------------------
        // Fields
        // ----------------------------------------------------------------------

        /// <summary>
        /// List to hold all of the critters by leveraging polymorphism
        /// </summary>
        private List<Critter> critterList;

        /// <summary>
        /// Reference to the current active critter
        /// </summary>
        private Critter activeCritter;

        /// <summary>
        /// The filename to use when loading/saving critters
        /// </summary>
        private string filename;

        /// <summary>
        /// Generator for any pseuod-random numbers needed
        /// </summary>
        private Random rng = new Random();

        // ----------------------------------------------------------------------
        // Properties
        // ----------------------------------------------------------------------

        /// <summary>
        /// Return the NAME of the current active critter or return null if
        /// one isn't active
        /// </summary>
        public String ActiveCritter 
        {
            get 
            {
                if (activeCritter != null)
                {
                    return activeCritter.Name;
                }
                else
                {
                    return null!; // The ! tells the compiler to ignore warnings about a possible null value.
                }
            } 
        }

        // ----------------------------------------------------------------------
        // Default Constructor
        // ----------------------------------------------------------------------

        /// <summary>
        /// Default constructor to initialize the list and active critter
        /// </summary>
        public CritterManager(string filename)
        {
            critterList = new List<Critter>();
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            this.filename = filename;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter setup via user input
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initial setup of critters. 
        /// Prompts a user for a number of critters, then their names,
        /// then adds newly instantiated critters to the critter list.
        /// All critters start with 0 hunger and 0 boredom.
        /// 
        /// THIS METHOD IS DONE FOR YOU so that you have examples of how to TryParse an enum type and
        /// use a switch statement with enums. You'll have to do both yourself when loading from a file!
        /// </summary>
        public void SetupCritters()
        {
            // Ask user for number of critters and their names
            int numberCritters = SmartConsole.GetValidNumericInput(
                "How many critters should your farm contain (1-5)?",
                1, 5);

            // Gather information about critter names from user,
            //   then create new Critter into the list
            for (int i = 0; i < numberCritters; i++)
            {
                string name = SmartConsole.GetPromptedInput("\nEnter critter " + (i + 1) + " name:");
                string typeString = SmartConsole.GetPromptedInput("What type of critter is "+name+" (Cat, Dog, or Horse)?");
                CritterType type = CritterType.Cat;

                // Enums work with a TryParse too! :)
                while (!Enum.TryParse<CritterType>(typeString, true, out type) // true as the middle param tells TryParse to ignore case
                    || !Enum.IsDefined(typeof(CritterType), type))
                        // TryParse accepts ints that aren't actually valid for this
                        // enum. Using IsDefined checks them before allowing the loop
                        // to proceed.
                {
                    SmartConsole.PrintWarning("Sorry, I don't know how to take care of a "+typeString+".\n");
                    typeString = SmartConsole.GetPromptedInput("What type of critter is " + name + " (Cat, Dog, or Horse)?");
                }

                // Create the correct type of critter
                // The switch statement cases and constructor calls below need to match YOUR critter types
                switch (type)
                {
                    case CritterType.Cat:
                        critterList.Add(new Cat(name));
                        break;

                    case CritterType.Dog:
                        critterList.Add(new Dog(name));
                        break;

                    case CritterType.Horse:
                        critterList.Add(new Horse(name));
                        break;

                    default:
                        // shouldn't happen
                        SmartConsole.PrintError(String.Format("Not sure how to create {0} with a type of {1}", name, typeString));
                        i--; // Didn't actually add a critter so go back 1 with our lcv and try again.
                        break;
                }

            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter file loading and saving
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Loads critter data from a file
        /// If there are no saved critters, calls SetupCritters() to allow user to
        /// enter their own critters.
        /// If file data exists, populates critterList with critters built from
        /// the file's data.
        /// </summary>
        public void LoadCrittersFromFile()
        {
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************

            critterList.Clear();

            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(filename);

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] data = line.Split('|');

                    // Parse the creature type, if it succeeds parse the rest
                    CritterType type;
                    if (Enum.TryParse<CritterType>(data[0], true, out type)
                        && Enum.IsDefined(typeof(CritterType), type))
                    {
                        string name = data[1];

                        // parse hunger and boredom data values
                        int hunger;
                        int boredom;
                        bool hungerParse = int.TryParse(data[2], out hunger);
                        bool boredomParse = int.TryParse(data[3], out boredom);
                        // create Critter object on success
                        if (hungerParse && boredomParse)
                        {
                            // create a critter based on the parsed type.
                            Critter newCritter;
                            switch (type)
                            {
                                case CritterType.Horse:
                                    newCritter = new Horse(name, hunger, boredom);
                                    critterList.Add(newCritter);
                                    break;
                                case CritterType.Cat:
                                    newCritter = new Cat(name, hunger, boredom);
                                    critterList.Add(newCritter);
                                    break;
                                case CritterType.Dog:
                                    newCritter = new Dog(name, hunger, boredom);
                                    critterList.Add(newCritter);
                                    break;
                                default:
                                    // should never happen
                                    SmartConsole.PrintError("Critter type invalid!");
                                    break;
                            }
                        }
                        // print a warning and skip the line otherwise
                        else
                        {
                            SmartConsole.PrintWarning(String.Format("Corrupt data. Skipping this line: {0}",
                            line));
                        }
                    }
                    // otherwise, skip the line and print a warning
                    else
                    {
                        SmartConsole.PrintWarning(String.Format("{0}s aren't supported yet. Skipping this line: {1}",
                            data[0], line));
                    }
                }
            }
            // Catch any problems with reading the file.
            catch (Exception e)
            {
                SmartConsole.PrintError(e.Message);
            }

            if(streamReader != null)
            {
                streamReader.Close();
                SmartConsole.PrintSuccess(String.Format("{0} critters loaded successfully",
                    critterList.Count));
            }
        }


        /// <summary>
        /// Saves critter data to a file.
        /// If there are no saved critters, writes "No critters saved."
        /// If critters do exist, writes their data to the file.
        /// </summary>
        public void SaveCrittersToFile()
        {
            // ********************************
            // File name: critters.txt
            // File structure (sample line):
            // type|name|hunger #|boredom #
            // ********************************
            string saveFormat = "{0}|{1}|{2}|{3}";

            StreamWriter streamWriter = null;
            int count = 0;

            try
            {
                streamWriter = new StreamWriter(filename);

                // iterate through the critter list and save each critter as a line
                // in the specified file.
                foreach (Critter critter in critterList) {

                    streamWriter.WriteLine(saveFormat, critter.Type,
                        critter.Name, critter.Hunger, critter.Boredom);
                    count++;
                }
            }
            // Catch any problems with writing to the file.
            catch (Exception e)
            {
                SmartConsole.PrintError(e.Message);
            }

            if (streamWriter != null)
            {
                streamWriter.Close();
            }

            // Tell the player if nothing was saved.
            if(count == 0)
            {
                SmartConsole.PrintWarning("No critters saved.");
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Control Methods
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sets the active critter to one of the critters in the critter list.
        /// </summary>
        /// <param name="critterName">Name of critter to set the active critter to</param>
        /// <returns>Whether this operation was successful</returns>
        public bool ChooseCritter(string critterName)
        {
            // Determine if the Critter exists in the list
            // And set it as active
            activeCritter = null!; // The ! tells the compiler to ignore warnings about a possible null value.
            for (int i = 0; i < critterList.Count; i++)
            {
                if (critterList[i].Name == critterName)
                {
                    activeCritter = critterList[i];
                }
            }

            // Let Main know whether this was successful
            return activeCritter != null;
        }

        /// <summary>
        /// Retrieves a list of the names of all current critters
        /// </summary>
        /// <returns>List of names of all critters</returns>
        public List<string> GetCritterNames()
        {
            List<string> critterNames = new List<string>();
            for (int i = 0; i < critterList.Count; i++)
            {
                critterNames.Add(critterList[i].Name);
            }
            return critterNames;
        }

        // ---------------------------------------------------------------------------------------------------------------
        // Critter Actions
        // ---------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Feeds the active critter 4 units of food.
        /// </summary>
        public void FeedCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Feeding your critter...");
            activeCritter.Eat();
        }


        /// <summary>
        /// Plays with the active critter for 4 fun units.
        /// </summary>
        public void PlayWithCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Playing with your critter...");
            activeCritter.Play();
        }


        /// <summary>
        /// Talks with the active critter.
        /// </summary>
        public void TalkToCritter()
        {
            if (activeCritter == null)
            {
                return;
            }

            Console.WriteLine("Talking to your critter...");
            activeCritter.Talk();
        }


        /// <summary>
        /// Simulates time passing for every critter for every "round" of user actions.
        /// </summary>
        public void TimePassing()
        {
            foreach (Critter c in critterList)
            {
                c.PassTime();
                
                // Cause Mischief 25% percet of the time if critter is a Cat.
                if(c is Cat && rng.NextDouble() < 0.25)
                {
                    ((Cat)c).CauseMischief();
                }
            }
        }

        /// <summary>
        /// Prints critter data about every critter in the list.
        /// Helpful for testing. 
        /// </summary>
        public void PrintCritters()
        {
            // Get string representation of every Critter in the list
            for(int i = 0; i < critterList.Count; i++)
            {
                Console.WriteLine("{0} ({2}): {1}", 
                    i + 1,
                    critterList[i],
                    critterList[i].Type);
            }
        }
    }
}
