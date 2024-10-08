/*
 * Ryan Zhang 
 * HW 5 - Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */

namespace HW_Farmstead_Zhang
{
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
        public Farm(string name, Crop[] availableCrops, int numPlots, double startingMoney, double maintenanceCost)
        {
            this.name = name;
            this.availableCrops = availableCrops;
            this.maintenanceCost = maintenanceCost;
            this.money = startingMoney;

            currentCrops = new Crop[numPlots];
            rng = new Random();
            daysPassed = 0;
        }

        //methods
        public void DaysPassed()
        {

        }

        public void Plant()
        {

        }

        public void Harvest()
        {

        }

        public void PrintStatus()
        {

        }

        private string BuildFieldList()
        {
            return null;
        }


    }
}
