/***
 * Ryan Zhang
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/1eOYYtup_hlHzLSw62bFBEFJY8Qm_7SFdtTi3FH8IIuw/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. Random enemy placement
 *  2. Enemy Customization
 *  
 * Optional extra upgrades:
 *  3. Additional Combat Options
 *      a. I added a 'reckless' option that does double damage
 *      b. but the player can't attack the turn afterwards
 *  4. Experience Points
 *      a. I implemented experience and level stats to the array
 *      b. the player can get exp from winning a fight
 *      c. if they hit the exp threshold for the next level, they level up.
 *  
 * Known Bugs:
 * None
 * 
 * Other notes:
 * I'm wondering how to handle movement and building the arena.
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

        // Constants for stats choices
        private const char StrChoice = 's';
        private const char DexChoice = 'd';
        private const char ConChoice = 'c';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;
        private const int Experience = 4;
        private const int Level = 5;

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
        const int EnemyExperienceDrop = 1;
        const int MaxRandomEnemies = 10; // inclusive

        // Enemy Customization
        readonly static int[] EnemyMaxHealth = new int[] { 10, 20, 40, 50, 100, 150 };
        readonly static string[] EnemyNames = new string[] {"goat", "slimy goat", "batty goat", "demon goat",
            "evil goat", "oozy goat",
            "slime", "bat", "ooze", "demon"};

        // Points of where experience will allow a level up.
        readonly static int[] levelUpThresholds = new int[] {1, 2, 4, 8, 16, 32, 64, 128, 256, int.MaxValue};

        // Random
        private static Random rng = new Random();

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
            int[] stats = new int[6];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = {1, 1};

            // Is the game still running?
            bool stillPlaying = true;
            
            // How many enemies are left?
            int numEnemies;

            int expToNextLevel;

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
                expToNextLevel = (stats[Level] <= levelUpThresholds.Length ?
                                        levelUpThresholds[stats[Level] - 1] :
                                        0);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}, " +
                    $"Experience {stats[Experience]}/{expToNextLevel}, " +
                    $"Level {stats[Level]}");

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
            int enemyHealth = EnemyMaxHealth[rng.Next(EnemyMaxHealth.Length)];
            string enemyName = EnemyNames[rng.Next(EnemyNames.Length)];
            string combatStatusFormat = "Your current health is {0}, the {2}'s health is {1}.";
            string combatPrompt = "What would you like to do? Attack/Reckless/Run >";
            bool isInFight = true;
            string input;
            int playerDamage;
            int enemyDamage;
            bool exhausted = false;


            Console.WriteLine("An angry {0} attacks you!", enemyName);
            Console.WriteLine();

            do
            {
                // Print current status of the fight and ask for an input
                Console.WriteLine(combatStatusFormat, stats[Health], enemyHealth, enemyName);
                input = SmartConsole.GetPromptedInput(combatPrompt).ToLower();

                // Prevent command from resolving for a turn if you are exhausted.
                if (!exhausted)
                {
                    // Attack
                    if (input.Equals("attack"))
                    {
                        // Calculate damage.
                        playerDamage = stats[Strength] * DamageMult;
                        if (playerDamage < 0)
                        {
                            playerDamage = 0;
                        }

                        // Print damage dealt.
                        Console.WriteLine("You swing at the {1} doing {0} damage.", playerDamage, enemyName);

                        // Apply damage.
                        enemyHealth -= playerDamage;
                    }
                    // Reckless - attack for double damage but skip the next turn.
                    else if (input.Equals("reckless"))
                    {
                        // Calculate damage.
                        playerDamage = stats[Strength] * DamageMult * 2;
                        if (playerDamage < 0)
                        {
                            playerDamage = 0;
                        }

                        // Print damage dealt.
                        Console.WriteLine("You swing recklessly for double damage at the {1} doing {0} damage!",
                            playerDamage, enemyName);

                        // Apply damage.
                        enemyHealth -= playerDamage;

                        // Become exhausted for a turn
                        exhausted = true;
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
                }
                else
                {
                    exhausted = false;
                    Console.WriteLine("You have overexerted yourself! You need a turn to recover.");
                }

                // Enemy attacks.
                enemyDamage = EnemyAttack - stats[Dexterity];
                if(enemyDamage < 0)
                {
                    enemyDamage = 0;
                }
                Console.WriteLine("The {1} charges at you for {0} damage!", enemyDamage, enemyName);
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

                // Gain Experience on a win
                stats[Experience]++;
                
                // Check for level up
                if(stats[Level - 1] < levelUpThresholds.Length && // Check player is not max level
                    stats[Experience] >= levelUpThresholds[stats[Level] - 1]) // Check player has required exp
                {
                    LevelUp(stats);
                }

                return Win;
            }

            // Lose if enemy has health but player doesn't.
            if (stats[Health] <= 0 && enemyHealth > 0)
            {
                Console.WriteLine("Your wounds are too much, the {0} wins this time.", enemyName);
                return Lose;
            }

            // All other cases, draw.
            Console.WriteLine("You defeat the {0} with you last breath.", enemyName);
            return Draw;

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Levels up the player. Recursively checks if player happens to level up multiples times at once.
        /// </summary>
        /// <param name="stats"></param>
        private static void LevelUp(int[] stats)
        {
            stats[Level]++;

            char levelUpChoice;

            Console.WriteLine("Leveled up! You have grown stronger!");
            levelUpChoice =  SmartConsole.GetPromptedChoice("Choose an attribute to improve. " +
                "'s' - Strength / 'd' - Dexterity / 'c' - Constitution >", new char[] { StrChoice, DexChoice, ConChoice });

            switch (levelUpChoice)
            {
                case StrChoice:
                    stats[Strength]++;
                    Console.WriteLine("\nStrength improved by 1! Strength is now {0}", stats[Strength]);
                    break;

                case DexChoice:
                    stats[Dexterity]++;
                    Console.WriteLine("\nDexterity improved by 1! Dexterity is now {0}", stats[Dexterity]);
                    break;

                case ConChoice:
                    stats[Constitution]++;
                    Console.WriteLine("\nConstitution improved by 1! Constitution is now {0}", stats[Constitution]);
                    break;
            }

            // Recursive, check for possible level up again
            if (stats[Level - 1] < levelUpThresholds.Length && // Check player is not max level
                    stats[Experience] >= levelUpThresholds[stats[Level] - 1]) // Check player has required exp
            {
                LevelUp(stats);
            }
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

            // Set default level and exp
            statsArray[Level] = 1;
            statsArray[Experience] = 0;

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
            bool randomEnemyPlacement = false;
            string input;

            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Ask if player wants random enemy placement
            input = SmartConsole.GetPromptedInput("Would you like to use random enemy placements? (Yes/No)").ToLower();
            if (input.Equals("yes"))
            {
                Console.WriteLine("Using random enemy placement!");
                randomEnemyPlacement = true;
            }
            else if (input.Equals("no"))
            {
                Console.WriteLine("Using evenly spaced enemy placement!");
            }
            else
            {
                Console.WriteLine("Invalid input. Defaulting to evenly space enemy placement!");
            }

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
                    // Only do it if using even enemy placement.
                    else if(i % EnemySpacing == 0 && j % EnemySpacing == 0 && !randomEnemyPlacement)
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

            // Populate with random enemies.
            if (randomEnemyPlacement)
            {
                numEnemies = rng.Next(1, MaxRandomEnemies + 1);
                int count = 0;
                int iterations = 0;
                while(count < numEnemies && iterations < 5000)
                {
                    // Choose random coordinates
                    // Exclude edge, where walls always are.
                    int x = rng.Next(1, arenaHeight - 2);
                    int y = rng.Next(1, arenaWidth - 2);

                    if (arena[x, y] == Empty)
                    {
                        count++;
                        arena[x, y] = Enemy;
                    }

                    // This is to prevent an infinite loop
                    iterations++;
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