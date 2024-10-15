/*
 * Ryan Zhang 
 * HW 5 - Farmstead
 * https://docs.google.com/document/d/1xnF9pZIhLC-PW3OAOktW15VzMtAktTZWnHEsuQSDBpQ/edit?usp=sharing
 */

namespace HW_Farmstead_Zhang
{
    /// <summary>
    /// Represents a Crop that can grow over a number of days, have a buy price and sell price.
    /// </summary>
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
        /// <summary>
        /// Creates an instance of a Crop from a name, cost, and growth time in days.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="growthTime"></param>
        public Crop(string name, double cost, int growthTime)
        {
            this.name = name;
            this.cost = cost;
            this.growthTime = growthTime;
            daysLeft = this.growthTime;
        }

        /// <summary>
        /// Copy constructor for Crop class
        /// </summary>
        /// <param name="other"></param>
        public Crop(Crop other) : this(other.Name, other.Cost, other.GrowthTime)
        { }

        //methods
        /// <summary>
        /// Decrements days left until the crop is ready to harvest (daysLeft is 0)
        /// </summary>
        public void DayPassed()
        {
            if(daysLeft > 0)
            {
                daysLeft--;
            }
        }

        /// <summary>
        /// Return a string based on state of the crop, telling days
        /// until harvest if not ready, and selling price if ready.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Print days left until harvest if not ready for harvest.
            if (daysLeft > 0)
            {
                return String.Format("{0} has {1} day(s) left to harvest", name, daysLeft);
            }
            // Print sell price if it is ready.
            else
            {
                return String.Format("{0} ready to harvest for {1:C}", name, SellingPrice);
            }
            
        }
    }
}
