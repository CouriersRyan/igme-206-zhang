/*
 * Ryan Zhang 
 * HW 5 - Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */

using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace HW_Farmstead_Zhang
{
    /// <summary>
    /// Represents a farm with crops that can be bought and planted in plots.
    /// </summary>
    internal class Farm
    {
        //fields
        private int daysPassed;
        private double maintenanceCost;
        private double money;
        private string name;
        private Crop[] availableCrops;
        private Crop[] currentCrops;
        private Random rng;

        // constants
        private const double BlightChance = 0.05;
        private const double rainChance = 0.2;
        private readonly string CropCostFormat = "{0} (Cost: {1:C})";
        private readonly string CropStatusFormat = " - Field {0}: {1}";

        //properties
        public double Money
        {
            get => money;
            set => money = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        //constructor
        /// <summary>
        /// Creates a Farm object with a name, a list of crops that can be bought,
        /// the number of plots for crops, starting money, and cost to maintain the farm.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="availableCrops"></param>
        /// <param name="numPlots"></param>
        /// <param name="startingMoney"></param>
        /// <param name="maintenanceCost"></param>
        public Farm(string name, Crop[] availableCrops, int numPlots, double startingMoney, double maintenanceCost)
        {
            this.name = name;
            this.availableCrops = availableCrops;
            this.maintenanceCost = maintenanceCost;
            this.money = startingMoney;

            currentCrops = new Crop[numPlots];
            rng = new Random();
            daysPassed = 1;
        }

        //methods
        /// <summary>
        /// Pass a day of time for the Farm, updating crops and money.
        /// </summary>
        public void DayPassed()
        {
            // pay farm maintenance
            money -= maintenanceCost;

            // Get random chance for weather effect to occur.
            double weatherValue = rng.NextDouble();

            // Determine what happens as a result of weahter.
            // 5% chance of blight
            if (weatherValue < BlightChance)
            {
                // destroy all crops
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    currentCrops[i] = null;
                }
                // print statement about weather
                SmartConsole.PrintError("Blight has struck the farm!\n" +
                    "All our crops are dead! :(");
            }
            // 20% chance of rain
            else if(weatherValue < BlightChance + rainChance)
            {
                // stops growth (do nothing with crops)
                SmartConsole.PrintWarning("It rained. Nothing grew today.\n" +
                    "Hopefully, tomorrow will be better");
            }
            // otherwise
            else
            {
                // grow plants in plots
                for (int i = 0; i < currentCrops.Length; i++)
                {
                    if (currentCrops[i] != null)
                    {
                        currentCrops[i].DayPassed();
                    }
                }
            }
        }

        /// <summary>
        /// Buy a plant and plant in the first empty plot.
        /// </summary>
        public void Plant()
        {
            // Make sure plots aren't full first.
            bool availablePlots = false;
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] == null)
                {
                    availablePlots = true;
                    break;
                }
            }

            if (availablePlots)
            {
                // Prompt the player for which crop to plant
                string cropShop = "Select a crop to plant:";
                for (int i = 0; i < availableCrops.Length; i++)
                {
                    cropShop += String.Format("\n{0}. ", i + 1) + String.Format(CropCostFormat,
                        availableCrops[i].Name, availableCrops[i].Cost);
                }
                cropShop += "\n> ";

                int cropToPlant = SmartConsole.GetValidNumericInput(cropShop, 1,
                    availableCrops.Length) - 1;

                // If we have enough money to plant that crop:
                if (money > availableCrops[cropToPlant].Cost)
                {
                    // Create a NEW instance of the chosen crop using the Crop copy constructor
                    Crop newCrop = new Crop(availableCrops[cropToPlant]);

                    // Assign the first open field element(null reference) in the
                    // current crops array to the new crop reference.
                    for (int i = 0; i < currentCrops.Length; i++)
                    {
                        if (currentCrops[i] == null)
                        {
                            currentCrops[i] = newCrop;
                            SmartConsole.PrintSuccess(String.Format("{0} planted in field #{1}",
                                newCrop.Name, i+1));
                            break;
                        }
                    }

                    // Decrement the farm’s money appropriately
                    money -= newCrop.Cost;
                }
                // Print error for can't buy crop
                else
                {
                    SmartConsole.PrintError("Unable to plant right now. Not enough money.");
                }
            }
            // Print error for full plots.
            else
            {
                SmartConsole.PrintError("Unable to plant right now. Harvest something first.");
            }
        }

        /// <summary>
        /// Choose a plot with a ready plant and remove move it, gaining money.
        /// </summary>
        public void Harvest()
        {
            // Make sure plots aren't full first.
            bool plotsEmpty = true;
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if (currentCrops[i] != null)
                {
                    plotsEmpty = false;
                    break;
                }
            }

            if (!plotsEmpty)
            {
                // Prompt the player for which field to harvest
                int cropToHarvest = SmartConsole.GetValidNumericInput("Which field would you like to harvest?" +
                    "\n" + BuildFieldList() +
                    "\n> ",
                    1, currentCrops.Length) - 1;

                // Check for errors
                // If plot is empty
                if (currentCrops[cropToHarvest] == null)
                {
                    SmartConsole.PrintError(String.Format(
                        "You have to plant something in field #{0} first!", cropToHarvest + 1));
                    return;
                }
                // If plot isn't ready to harvest
                if (currentCrops[cropToHarvest].DaysLeft > 0)
                {
                    SmartConsole.PrintError(String.Format("{0} is not ready for harvest.",
                        currentCrops[cropToHarvest].Name));
                    return;
                }

                // If the chosen field can be harvested:
                // Increment the farm’s money by that selling price.
                Money += currentCrops[cropToHarvest].SellingPrice;
                // Print a message that the crop has been sold.
                Console.WriteLine("Sold {0} for {1:C}",
                    currentCrops[cropToHarvest].Name, currentCrops[cropToHarvest].SellingPrice);
                    // “Remove” the crop from the current crops array by setting that reference to null.
                    currentCrops[cropToHarvest] = null;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have to plant something first!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Prints current status of the farm to console.
        /// </summary>
        public void PrintStatus()
        {
            // Calculating the total potential earnings if all ready to harvest crops are sold
            double potentialEarnings = 0;
            for (int i = 0; i < currentCrops.Length; i++)
            {
                if(currentCrops[i] != null && currentCrops[i].DaysLeft == 0){
                    potentialEarnings = currentCrops[i].SellingPrice;
                }
            }

            // Building a status message containing:
            // Day number, Farm name, and Current money
            Console.WriteLine("Day {0} at {1} with {2:C} on hand.",
                daysPassed, name, money);
            // Potential earnings
            Console.WriteLine("We have {0} earnings from the fields ready to harvest.", potentialEarnings);
            // Status of all fields
            Console.Write(BuildFieldList());
        }

        /// <summary>
        /// Create and return a string that lists the status of every plot.
        /// </summary>
        /// <returns></returns>
        private string BuildFieldList()
        {
            string fieldList = "";
            for(int i = 0; i < currentCrops.Length; i++)
            {
                if(currentCrops[i] != null)
                {
                    fieldList += String.Format(CropStatusFormat,
                        i + 1, currentCrops[i]) + "\n";
                }
                else
                {
                    fieldList += String.Format(CropStatusFormat,
                        i + 1, "Empty") + "\n";
                }
            }
            return fieldList;
        }


    }
}
