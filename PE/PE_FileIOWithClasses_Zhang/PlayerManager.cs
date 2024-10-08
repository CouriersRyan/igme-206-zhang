/*
 * Ryan Zhang
 * PE - File IO with Classes
 * https://docs.google.com/document/d/1bdEwXtXEnyY2xfeDdS7XJ7FMqHUE0IzZn2OLopcwEwU/edit?usp=sharing
 */

namespace PE_FileIOWithClasses_Zhang
{
    internal class PlayerManager
    {
        // fields
        private string fileName;
        private List<Player> players;

        // constructor
        public PlayerManager()
        {
            this.fileName = "players.txt";
            this.players = new List<Player>();
        }


        //methods
        /// <summary>
        /// Creates a new Player instance and adds it to the list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strength"></param>
        /// <param name="health"></param>
        public void CreatePlayer(string name, int strength, int health)
        {
            Player newPlayer = new Player(name, strength, health);

            players.Add(newPlayer);
        }

        /// <summary>
        /// Prints to console every player in the manager's list.
        /// </summary>
        public void Print()
        {
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("\t{0}", players[i].ToString());
                }
            }
            else
            {
                Console.WriteLine("\tThere are no players yet.");
            }
        }

        /// <summary>
        /// Load a list of players from file.
        /// </summary>
        public void Load()
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);

                players.Clear();

                // loop through and read lines until end of file.
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string playerLine = reader.ReadLine();

                        // Parse each line into a player instance
                        string[] playerElements = playerLine.Split(",");
                        string name = playerElements[0];
                        int strength = int.Parse(playerElements[1]);
                        int health = int.Parse(playerElements[2]);

                        CreatePlayer(name, strength, health);
                        Console.WriteLine("\tAdded {0} to the list.", name);
                    }
                    // catch if line's specific formatting is incorrect.
                    catch (Exception e) {
                        Console.WriteLine("\tError reading player data.");
                    }
                }
                reader.Close();

                // Print confirmation of success.
                Console.WriteLine("\tLoaded all data from file");
                Console.WriteLine("\t{0} player(s) created.", players.Count);
            }
            // Error from reading the file outright.
            catch (Exception e)
            {
                Console.WriteLine("\tError opening save file!");
            }
        }

        /// <summary>
        /// Saves the list of players to a text file.
        /// </summary>
        public void Save()
        {
            // Only save to file if there is player data to save.
            if (players.Count > 0)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(fileName);

                    // Write player to each line.
                    for (int i = 0; i < players.Count; i++)
                    {
                        writer.WriteLine("{0},{1},{2}", players[i].Name, players[i].Strength, players[i].Health);
                    }

                    writer.Close();

                    Console.WriteLine("\tSaved {0} player(s) to file {1}", players.Count, fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t{0}", e.ToString());
                }
            }
            else
            {
                Console.WriteLine("\tThere are no players yet.");
            }
        }
    }
}
