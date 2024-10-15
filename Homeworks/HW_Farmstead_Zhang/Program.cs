/*
 * Ryan Zhang 
 * HW 5 - Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */
namespace HW_Farmstead_Zhang
{
    internal class Program
    {
        // Constants
        private const char Choice1 = '1';
        private const char Choice2 = '2';
        private const char Choice3 = '3';
        private const char Choice4 = '4';
        private static readonly char[] MenuChoices = {Choice1, Choice2, Choice3, Choice4};

        private const int MaxCropTypes = 5;
        private const double MaxCropCost = 500;
        private const int MaxGrowthDays = 10;
        private const int MaxPlots = 5;
        private const double MaxStartingMoney = 1000;
        private const double MaxFarmMaintenance = 50;

        // Main
        static void Main(string[] args)
        {
            Farm myFarm;
            Crop[] availableCrops;
            bool hasQuit = false;
            char choice;

            // Farm Setup
            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!");
            Console.WriteLine(" Start your farming journey by defining the crops available and naming your farm.");
            Console.WriteLine();

            // Define crops
            int cropTypes = SmartConsole.GetValidNumericInput("How many types of crops do want to define?\n", 1, MaxCropTypes);
            availableCrops = new Crop[cropTypes];
            for (int i = 0; i < cropTypes; i++)
            {
                Console.WriteLine("Define crop type #{0}", i + 1);
                string cropName = SmartConsole.GetPromptedInput("\tName:");
                double cropCost = SmartConsole.GetValidNumericInput("\tCost:", 1, MaxCropCost);
                int cropGrowthTime = SmartConsole.GetValidNumericInput("\tDays until harvest:", 1, MaxGrowthDays);

                availableCrops[i] = new Crop(cropName, cropCost, cropGrowthTime);
                Console.WriteLine();
            }

            // Define farm
            string farmName = SmartConsole.GetPromptedInput("Please name you farm:");
            Console.WriteLine();

            int farmPlots = SmartConsole.GetValidNumericInput("How many fields are available for planting?", 1, MaxPlots);
            Console.WriteLine();

            double farmMoney = SmartConsole.GetValidNumericInput("How much money are you starting with?", 1, MaxStartingMoney);
            Console.WriteLine();

            double farmMaintenance = SmartConsole.GetValidNumericInput("What is the daily maintenance cost?", 1, MaxFarmMaintenance);
            Console.WriteLine();

            myFarm = new Farm(farmName, availableCrops, farmPlots, farmMoney, farmMaintenance);



            // Main Game Loop
            Console.WriteLine("*** {0}, ready for a fruitful season! ***", myFarm.Name);

            while (!hasQuit)
            {
                // Main Menu
                myFarm.PrintStatus();
                choice = SmartConsole.GetPromptedChoice(
                    "\n  1. Plant crops" +
                    "\n  2. Harvest and sell produce" +
                    "\n  3. Do nothing today" +
                    "\n  4. Quit" +
                    "\n>", MenuChoices);
                Console.WriteLine();

                switch (choice)
                {
                    // Planting
                    case Choice1:
                        myFarm.Plant();
                        break;

                    // Harvesting
                    case Choice2:
                        myFarm.Harvest();
                        break;

                    // Do Nothing
                    case Choice3:
                        break;

                    // Quit
                    case Choice4:
                        SmartConsole.PrintSuccess(String.Format(
                            "You have quit with {0:C} in the bank!", myFarm.Money));
                        hasQuit = true;
                        break;
                }

                // Pass Time unless player quit.
                if (!hasQuit)
                {
                    myFarm.DayPassed();
                }

                // Check end conditions
                if(!hasQuit && myFarm.Money <= 0)
                {
                    SmartConsole.PrintError(String.Format("{0} ran out of money!", myFarm.Name));
                    hasQuit = true;
                }

                Console.WriteLine();
            }

        }
    }
}
