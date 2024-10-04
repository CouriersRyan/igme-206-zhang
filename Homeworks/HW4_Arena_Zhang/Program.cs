/***
 * Ryan Zhang
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/1eOYYtup_hlHzLSw62bFBEFJY8Qm_7SFdtTi3FH8IIuw/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. 
 *  2.
 *  
 * Optional extra upgrades:
 *  3.
 *  4.
 *  
 * Known Bugs:
 * 
 * Other notes:
 * I'm wondering how to handle movement and build the arena.
 */
namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';

        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 10;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 50;

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[4];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = {1, 1};

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch(arena[nextLoc[0], nextLoc[1]])
                {
                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch(Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult)/2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if(numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        private static int Fight(int[] stats)
        {
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            int enemyHealth = EnemyMaxHealth;
            string combatStatusFormat = "Your current health is {0}, the goat's health is {1}.";
            string combatPrompt = "What would you like to do? Attack/Run >";
            bool isInFight = true;
            string input;
            int playerDamage;
            int enemyDamage;


            Console.WriteLine("An angry goat attacks you!");
            Console.WriteLine();

            do
            {
                // Print current status of the fight and ask for an input
                Console.WriteLine(combatStatusFormat, stats[Health], enemyHealth);
                input = SmartConsole.GetPromptedInput(combatPrompt);

                // Attack
                if (input.Equals("attack"))
                {
                    // Calculate damage.
                    playerDamage = stats[Strength] * DamageMult;

                    // Print damage dealt.
                    Console.WriteLine("You swing at the goat doing {0} damage.", playerDamage);

                    // Apply damage.
                    enemyHealth -= playerDamage;
                }
                // Run
                else if (input.Equals("run"))
                {
                    Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                    return Run;
                }
                // Anything else
                else
                {
                    Console.WriteLine("Command not recognized! Oh no! LOOK OUT!!");
                }

                // Enemy attacks.
                enemyDamage = EnemyAttack - stats[Dexterity];
                Console.WriteLine("The goat charges at you for {0} damage!", enemyDamage);
                stats[Health] -= enemyDamage;

                Console.WriteLine();

                // If any character's health drop to or below 0, exit the fight.
                if (stats[Health] <= 0 || enemyHealth <= 0)
                {
                    isInFight = false;
                }
            } while (isInFight);

            // Check if the fight is a win, loss, or draw.
            // Win if player has health but enemy doesn't.
            if (stats[Health] > 0 && enemyHealth <= 0)
            {
                Console.WriteLine("You have defeated the beast! Congratulations!");
                return Win;
            }

            // Lose if enemy has health but player doesn't.
            if (stats[Health] <= 0 && enemyHealth > 0)
            {
                Console.WriteLine("Your wounds are too much, the goat wins this time.");
                return Lose;
            }

            // All other cases, draw.
            Console.WriteLine("You defeat the goat with you last breath.");
            return Draw;

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        private static string GetPlayerInfo(int[] statsArray)
        {
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            int remainingPoints = MaxPoints;

            // Number of stats that need points after the next one (Strength)
            // Used to ensure that the player will always be able to allocate at least one point in all stats.
            int remainingStats = 2; // Dexterity and Constitution

            // Prompt repeated to give the player how many points they have left to distribute.
            string pointsRemainingFormat = "You have {0} points remaining.";

            // Get player name
            string playerName = SmartConsole.GetPromptedInput("Welcome, please enter your name: >");

            // Get stats
            Console.WriteLine("Hello {0}, I'll need a bit more information from you before we can start.", playerName);
            Console.WriteLine("You have {0} points to build your character and three attributes to allocate them to.",
                remainingPoints);
            Console.WriteLine();

            // Ask for strength
            statsArray[Strength] = SmartConsole.GetValidIntegerInput("How many points would you like to " +
                "allocate to Strength? >", 1, remainingPoints - remainingStats);
            remainingPoints -= statsArray[Strength];
            remainingStats--; // Constitution
            Console.WriteLine(pointsRemainingFormat, remainingPoints);
            Console.WriteLine();

            // Ask for dexterity
            statsArray[Dexterity] = SmartConsole.GetValidIntegerInput("How many points would you like to " +
                "allocate to Dexterity? >", 1, remainingPoints - remainingStats);
            remainingPoints -= statsArray[Dexterity];
            remainingStats--; // None
            Console.WriteLine(pointsRemainingFormat, remainingPoints);
            Console.WriteLine();

            // Ask for constitution
            statsArray[Constitution] = SmartConsole.GetValidIntegerInput("How many points would you like to " +
                "allocate to Constitution? >", 1, remainingPoints);
            remainingPoints -= statsArray[Constitution];
            Console.WriteLine("You have {0} points unused.", remainingPoints);
            Console.WriteLine();

            // Calculate health
            statsArray[Health] = statsArray[Constitution] * HealthMult;

            return playerName;
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Get arena dimensions.
            int arenaWidth = SmartConsole.GetValidIntegerInput("How wide should the arena be?" +
                "(Enter a value from 10 to 50) >", 10, 50);
            int arenaHeight = SmartConsole.GetValidIntegerInput("How tall should the arena be?" +
                "(Enter a value from 10 to 50) >", 10, 50);

            char[,] arena = new char[arenaHeight, arenaWidth];

            // Loop through the arena and populate it with elements
            for(int i = 0; i < arenaHeight; i++)
            {

                for(int j = 0; j < arenaWidth; j++)
                {
                    // Populate with walls along edge.
                    if (i == 0 || i == arenaHeight - 1 ||
                        j == 0 || j == arenaWidth-1)
                    {
                        arena[i, j] = Wall;
                    }
                    // Place player start location in top left corner.
                    else if (i == 1 && j == 1)
                    {
                        arena[1, 1] = PlayerStart;
                    }
                    // Place exit in bottom right corner.
                    else if (i == arenaHeight - 2 && j == arenaWidth - 2)
                    {
                        arena[arenaHeight - 2, arenaWidth - 2] = Exit;
                    }
                    // Populate with enemies with even spacing, prevent overlap with walls.
                    else if(i % EnemySpacing == 0 && j % EnemySpacing == 0)
                    {
                        arena[i, j] = Enemy;
                        numEnemies++;
                    }
                    // Insert with empty space anywhere else.
                    else
                    {
                        arena[i, j] = Empty;
                    }
                    
                }
            }
            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Loop through arena
            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for(int j = 0; j < arena.GetLength(1); j++)
                {
                    // If the player is at the tile, prints the player instead
                    if(i == playerLoc[0] && j == playerLoc[1])
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Player);
                    }
                    // Otherwise print the tile
                    else
                    {
                        // Check for specific tile and print it with specific color.
                        switch (arena[i,j])
                        {
                            case Enemy: 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(Enemy); 
                                break;

                            case Wall:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(Wall);
                                break;

                            case PlayerStart: 
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(PlayerStart);
                                break;

                            case Exit:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(Exit);
                                break;

                            // Empty and anything that isn't valid
                            case Empty:
                            default:
                                Console.Write(Empty);
                                break;
                        }
                    }
                }

                // Move to next row.
                Console.WriteLine();
            }

            // Reset the color.
            Console.ForegroundColor = ConsoleColor.White;

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}