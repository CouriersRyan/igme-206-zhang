/*
 * Ryan Zhang 
 * HW 5 - Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */

namespace HW_Farmstead_Zhang
{
    internal class Crop
    {
        //fields
        private string name;
        private double cost;
        private int growthTime;
        private int daysLeft;

        //properties
        public bool CanHarvest
        {
            get => daysLeft <= 0;
        }

        public double SellingPrice
        {
            get => cost * growthTime;
        }

        public double Cost
        {
            get => cost;
            set => cost = value;
        }

        public int DaysLeft
        {
            get => daysLeft;
            set => daysLeft = value;
        }

        public int GrowthTime
        {
            get => daysLeft;
            set => daysLeft = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        //constructors
        public Crop(string name, double cost, int growthTime)
        {

        }

        /// <summary>
        /// Copy constructor for Crop class
        /// </summary>
        /// <param name="other"></param>
        public Crop(Crop other) : this(other.Name, other.Cost, other.GrowthTime)
        { }

        //methods
        public void DaysPassed()
        {

        }

        public string ToString()
        {
            return null;
        }
    }
}
