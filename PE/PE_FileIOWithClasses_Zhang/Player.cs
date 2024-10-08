/*
 * Ryan Zhang
 * PE - File IO with Classes
 * https://docs.google.com/document/d/1bdEwXtXEnyY2xfeDdS7XJ7FMqHUE0IzZn2OLopcwEwU/edit?usp=sharing
 */

namespace PE_FileIOWithClasses_Zhang
{
    /// <summary>
    /// Classing representing a player in a game with saving and loading.
    /// </summary>
    internal class Player
    {
        // fields
        private string name;
        private int health;
        private int strength;

        // properties
        public int Health
        {
            get => health;
        }

        public string Name
        {
            get => name;
        }

        public int Strength
        {
            get => strength;
        }

        //constructor
        public Player (string name, int strength, int health)
        {
            this.health = health;
            this.name = name;
            this.strength = strength;
        }

        //methods
        /// <summary>
        /// Returns a string listing the player name, strength, and health
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return String.Format("Player: {0}. Strength {1}, Heath {2}.", name, strength, health);
        }
    }
}
