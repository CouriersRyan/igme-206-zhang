/***
 * Ryan Zhang
 * 
 * HW 6 - Critter Farm
 * Write-up: https://docs.google.com/document/d/1ZsWp7ulvxPUc5Zp6tg6tXJssbWw1BohEx_ip17m9y98/edit?usp=sharing
 *
 * Known Bugs:
 * 
 * Other notes:
 * 
 */
namespace HW6_CritterFarm
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch.
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Launches either the test code or game (depending on which helper method is uncommented).
        /// </summary>
        static void Main(string[] args)
        {
            // Start with a console color of white vs. gray so everything matches.
            Console.ForegroundColor = ConsoleColor.White;

            TestCritters();
            //RunCritterFarm();
        }

        /// <summary>
        /// Runs some simple tests on the Critter subclasses to test them before starting
        /// work on the CritterManager.
        /// </summary>
        static void TestCritters()
        {
            Console.WriteLine("**** Testing Critter sub-classes...");
            Console.WriteLine();

            List<Critter> critters = new List<Critter>();

            // Create test Critter classes
            Critter horse1 = new Horse("NEW HORSE");
            Critter horse2 = new Horse("Joey", 10, 10);

            Critter dog1 = new Dog("NEW DOG");
            Critter dog2 = new Dog("Barker", 10, 10);

            Critter cat1 = new Cat("NEW CAT");
            Critter cat2 = new Cat("Rob", 10, 10);

            // Add critters to list of critters
            critters.Add(horse1);
            critters.Add(horse2);
            critters.Add(dog1);
            critters.Add(dog2);
            critters.Add(cat1);
            critters.Add(cat2);

            // Print status of every critter
            foreach(Critter critter in critters)
            {
                Console.WriteLine(critter);
            }
            Console.WriteLine();

            // Test actions for each critter
            foreach(Critter critter in critters)
            {
                critter.Eat();
                critter.Play();
                critter.Talk();
                if(critter is Cat)
                {
                    ((Cat)critter).CauseMischief();
                }
                Console.WriteLine();
            }

            // Print updated status for every critter.
            foreach(Critter critter in critters)
            {
                Console.WriteLine(critter);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// The primary game loop. This is complete for you.
        /// DO NOT touch anything in this method except where marked with TODO
        /// (code you can adjust slightly if you want to change critter types).
        /// </summary>
        static void RunCritterFarm()
        {
            // Create a new critter manager
            char menuChoice;

            // TODO: Pass the correct filename to the critter manager constructor
            //       so that it will create a file "critter.txt" in the same folder as
            //       the source code
            CritterManager manager = new CritterManager("../../../critter.txt");

            // ------------------------------------------------------------------
            // Welcome the user
            // ------------------------------------------------------------------
            Console.WriteLine("\n\n--------------------------------------------------------\n");
            Console.WriteLine("Welcome to the Critter Farm!");
            Console.WriteLine();
            Console.WriteLine("Your job is to keep all of the critters happy.");
            Console.WriteLine("Critters become hungry when they are not fed,");
            Console.WriteLine("and bored when they are not entertained.");
            Console.WriteLine();

            // Load old save? Or new game? Grab user's preference and validate
           menuChoice = SmartConsole.GetPromptedChoice(
                "Choose '1' to start a new game,\nor '2' to continue from the last save.\n >",
                new char[] {'1', '2'});

            // Start the game with instantiated Critters
            switch (menuChoice)
            {
                case '1':
                    Console.WriteLine("Starting a new game...");
                    manager.SetupCritters();
                    break;

                case '2':
                    Console.WriteLine("Loading from the file...");
                    manager.LoadCrittersFromFile();
                    break;
            }

            // ------------------------------------------------------------------
            // Gameplay
            // ------------------------------------------------------------------
            do
            {
                // ************************************
                // Every "round" print the critters and then menu options
                // ************************************
                string prompt;
                char[] choices;

                Console.WriteLine();
                manager.PrintCritters();
                Console.WriteLine();

                // The menu is different depending on whether or not
                // there is an active critter
                if (manager.ActiveCritter == null)
                {
                    prompt = "You don't have a critter selected.\n" +
                        "\nChoose one of the following options:" +
                        "\n\t'1': Choose a critter"+
                        "\n\t'5': Quit"+
                        "\n>";
                    choices = new char[]{ '1', '5'};
                }
                else
                {
                    prompt = "Your current critter is: " + manager.ActiveCritter + "\n" +
                        "\nChoose one of the following options:" +
                        "\n\t'1': Choose a different critter" +
                        "\n\t'2': Feed your critter" +
                        "\n\t'3': Play with your critter" +
                        "\n\t'4': Talk to your critter" +
                        "\n\t'5': Quit"+
                        "\n>";
                    choices = new char[] { '1', '2', '3', '4', '5' };
                }
                menuChoice = SmartConsole.GetPromptedChoice(prompt, choices);

                // ************************************
                // Perform the user's chosen action
                // ************************************
                switch (menuChoice)
                {
                    // CASE 1 --> Active Critter
                    case '1':
                        // Display current critter names
                        List<string> critterNames = manager.GetCritterNames();
                        Console.Write("Choose from one of the following critters: ");
                        for (int i = 0; i < critterNames.Count; i++)
                        {
                            Console.Write(critterNames[i]);

                            // If 1 left, write an "or"
                            if (i == critterNames.Count - 2)
                            {
                                Console.Write(" or ");
                            }
                            // If not the last one, write a ","
                            else if (i != critterNames.Count - 1)
                            {
                                Console.Write(", ");
                            }
                        }
                        Console.WriteLine();

                        // Allow user to choose one of the critters
                        // Force re-entry if critter name is incorrect
                        bool critterExists = false;
                        while (!critterExists)
                        {
                            string userCritterChoice = SmartConsole.GetPromptedInput(">");
                            critterExists = manager.ChooseCritter(userCritterChoice);

                            if (!critterExists)
                            {
                                SmartConsole.PrintError("\nSorry, that critter does not exist. Try again.");
                            }
                        }

                        break;

                    // CASE 2 --> Feed Critter
                    case '2':
                        manager.FeedCritter();
                        manager.TimePassing();
                        break;

                    // CASE 3 --> Play with Critter
                    case '3':
                        manager.PlayWithCritter();
                        manager.TimePassing();
                        break;

                    // CASE 4 --> Talk to Critter
                    case '4':
                        manager.TalkToCritter();
                        manager.TimePassing();
                        break;

                    // CASE 5 --> Quit and save data
                    case '5':
                        Console.WriteLine("Ending program. Saving data.");
                        manager.SaveCrittersToFile();
                        break;
                }
            }
            while (menuChoice != '5');
        }
    }
}
