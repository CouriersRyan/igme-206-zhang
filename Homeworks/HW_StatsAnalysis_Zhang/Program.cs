/*
 * Ryan Zhang
 * HW 2 - Stats Analysis
 * https://docs.google.com/document/d/13uxd-298WyJnL3v0W3L5OD_eGMS3xIth-ASy47Wy42s/edit
 */
namespace HW_StatsAnalysis_Zhang
{
    internal class Program
    {
        // Takes in a series of data inputs for two players and evaluates and prints a comparison of the two players.
        static void Main(string[] args)
        {
            // Activity 1
            // Player 1 Variables
            string namePlayer1;
            int gamesWonPlayer1;
            int gamesLostPlayer1;
            int gamesTotalPlayer1;
            double hoursPlayedPlayer1;
            double avgHoursPerGamePlayer1;
            double winRatePlayer1;

            // Player 2 Variables
            string namePlayer2;
            int gamesWonPlayer2;
            int gamesLostPlayer2;
            int gamesTotalPlayer2;
            double hoursPlayedPlayer2;
            double avgHoursPerGamePlayer2;
            double winRatePlayer2;

            // Formatted strings for Activity 2
            string namePrompt = "Enter the name for Player {0}: ";
            string gamesPlayedPrompt = "Enter the number of games {0} {1}: ";
            string hoursPlayedPrompt = "Enter the total time played by {0} in hours: ";

            // Formatted strings for Activity 3
            string summaryTable = "Summary Table:" +
                "\n\t\t\t{0}\t\t{1}" +
                "\n\tGames Played\t{2}\t\t{3}" +
                "\n\tGames Won\t{4}\t\t{5}" +
                "\n\tGames Lost\t{6}\t\t{7}" +
                "\n\tTotal Time (h)\t{8:F1}\t\t{9:F1}" +
                "\n\tWin Rate\t{10:P3}\t\t{11:P3}" +
                "\n\tAvg Time (m)\t{12}\t\t{13}";
            string betterPlayerStatement = "{0} has a better win rate!";

            // Error Flags
            bool statValidPlayer1 = true;
            bool statValidPlayer2 = true;

            // Activity 2
            Console.WriteLine("========= STATS ANALYZER =========\n");

            // Get Player 1 inputs
            Console.Write(namePrompt, 1);
            namePlayer1 = Console.ReadLine().Trim();
            Console.Write(gamesPlayedPrompt, namePlayer1, "played");
            gamesTotalPlayer1 = int.Parse(Console.ReadLine());
            Console.Write(gamesPlayedPrompt, namePlayer1, "won");
            gamesWonPlayer1 = int.Parse(Console.ReadLine());
            Console.Write(gamesPlayedPrompt, namePlayer1, "lost");
            gamesLostPlayer1 = int.Parse(Console.ReadLine());
            Console.Write(hoursPlayedPrompt, namePlayer1);
            hoursPlayedPlayer1 = double.Parse(Console.ReadLine());

            // Player 1 Error Check
            // empty player name
            if (namePlayer1.Equals(String.Empty))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Invalid name for player 1");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer1 = false;
            }

            // any numerical value less than zero
            if (gamesTotalPlayer1 < 0 || gamesWonPlayer1 < 0 || gamesLostPlayer1 < 0 || hoursPlayedPlayer1 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Games & total play time must be non-negative numbers!");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer1 = false;
            }

            // games won and lost don't sum up to total number of games
            if (gamesLostPlayer1 + gamesWonPlayer1 != gamesTotalPlayer1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: The number of games won and lost does not match the total number of games played!");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer1 = false;
            }

            // total games is zero OR total play time is zero
            if (gamesTotalPlayer1 == 0 || hoursPlayedPlayer1 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: No stats to calculate for a player with zero games or no play time!");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer1 = false;
            }
            Console.WriteLine();

            // Stop the program if there are any errors
            if(!statValidPlayer1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot continue with analysis. Goodbye.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            

            // Get Player 2 input
            Console.Write(namePrompt, 2);
            namePlayer2 = Console.ReadLine().Trim();
            Console.Write(gamesPlayedPrompt, namePlayer2, "played");
            gamesTotalPlayer2 = int.Parse(Console.ReadLine());
            Console.Write(gamesPlayedPrompt, namePlayer2, "won");
            gamesWonPlayer2 = int.Parse(Console.ReadLine());
            Console.Write(gamesPlayedPrompt, namePlayer2, "lost");
            gamesLostPlayer2 = int.Parse(Console.ReadLine());
            Console.Write(hoursPlayedPrompt, namePlayer2);
            hoursPlayedPlayer2 = double.Parse(Console.ReadLine());

            // Player 2 Error Check
            // empty player name
            if (namePlayer2.Equals(String.Empty))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Invalid name for player 2");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer2 = false;
            }

            // any numerical value less than zero
            if (gamesTotalPlayer2 < 0 || gamesWonPlayer2 < 0 || gamesLostPlayer2 < 0 || hoursPlayedPlayer2 < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Games & total play time must be non-negative numbers!");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer2 = false;
            }

            // games won and lost don't sum up to total number of games
            if (gamesLostPlayer2 + gamesWonPlayer2 != gamesTotalPlayer2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: The number of games won and lost does not match the total number of games played!");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer2 = false;
            }

            // total games is zero OR total play time is zero
            if (gamesTotalPlayer2 == 0 || hoursPlayedPlayer2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: No stats to calculate for a player with zero games or no play time!");
                Console.ForegroundColor = ConsoleColor.White;
                statValidPlayer2 = false;
            }
            Console.WriteLine();

            // Stop the program if there are any errors
            if (!statValidPlayer2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot continue with analysis. Goodbye.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            // Activity 3
            // Calculations
            avgHoursPerGamePlayer1 = 60 * hoursPlayedPlayer1 / gamesTotalPlayer1; // Player 2 avg play time (m)
            winRatePlayer1 = (double)gamesWonPlayer1 / gamesTotalPlayer1; // Player 1 winrate
            avgHoursPerGamePlayer2 = 60 * hoursPlayedPlayer2 / gamesTotalPlayer2; // Player 2 avg play time (m)
            winRatePlayer2 = (double)gamesWonPlayer2 / gamesTotalPlayer2; // Player 2 winrate

            // Print Summary
            Console.WriteLine(summaryTable, namePlayer1, namePlayer2, gamesTotalPlayer1, gamesTotalPlayer2,
                gamesWonPlayer1, gamesWonPlayer2, gamesLostPlayer1, gamesLostPlayer2, hoursPlayedPlayer1,
                hoursPlayedPlayer2, winRatePlayer1, winRatePlayer2, avgHoursPerGamePlayer1, avgHoursPerGamePlayer2);
            Console.WriteLine();

            // Compare & Print who has a better winrate.
            // player 1 wins
            if (winRatePlayer1 > winRatePlayer2)
            {
                Console.WriteLine(betterPlayerStatement, namePlayer1);
            }
            // player 2 wins
            else if (winRatePlayer2 > winRatePlayer1)
            {
                Console.WriteLine(betterPlayerStatement, namePlayer2);
            }
            // draw
            else
            {
                Console.WriteLine("It's a draw!");
            }
            // TODO: evaluate everything against rubric cases
        }
    }
}
