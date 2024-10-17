/**
 * 1. READ the ENTIRE exam write-up PDF document before starting! 
 * 
 * 2. Your instructor will not be available for questions!
 *       - If something is unclear, document any assumptions you make clearly 
 *         in the comments in your program.
 *       
 * 3. SAVE OFTEN!  
 *       - Any computer can crash.  You are responsible for saving your code.
 *       - Make your you COMMIT and PUSH to your GitHub repo before making
 *         the final release!
 *       
 * 4. Look over the grading rubric for specifics on how this practical will be graded!
 *       - Be strategic about how you spend your time! 
 *       - TEST as you go!
 * 
 * 5. Your program must compile and run without errors to get full credit.  
 *       - Comment out (but do not delete!) anything that doesn’t compile, crashes, or 
 *         otherwise prevents demonstration of features that you have working.
 */
namespace GDP_Exam_1
{
    /*
     * Ryan Zhang
     * No known issues.
     */
    class Program
    {

        /// <summary>
        /// An outline of Main() has been written for you with some test code and
        /// prompts for questions to answer
        /// 
        /// DO NOT MODIFY **except** where clearly marked with: 
        ///    - TODO: UNCOMMENT the following
        /// </summary>
        static void Main(string[] args)
        {
            // Note: Yes, normally all variables used within the method should be declared
            // at the top of the method. This is not done in Main() to allow isolation of code
            // that won't compile until you complete each activity.

            /**************************************************/
            /* ACTIVITY 1: Setup a basic inventory of Weapons */
            /**************************************************/

            // TODO: UNCOMMENT the following to test Activity 1

            Console.WriteLine("\n\n** Activity 1 **");
            Console.WriteLine("Testing the Weapon class...");
            Weapon potatoL = new Weapon("Potato Launcher", 3, 1.07);
            Console.WriteLine(potatoL);
            Console.WriteLine("- - - - - - - - - - - - - - - - -");


            Console.WriteLine("Testing the Inventory class...");
            Inventory myItems = new Inventory();
            myItems.AddItem(new Weapon("Sharp Stick", 5, 0.05));
            myItems.AddItem(new Weapon("Mediocre Pew Pew", 12, 2.75));
            myItems.PrintSummary();



            /********************************************/
            /* ACTIVITY 2: Add support for foods        */
            /********************************************/
            // TODO: UNCOMMENT the following to test Activity 2

            Console.WriteLine("\n\n** Activity 2 **");
            Console.WriteLine("Testing the Food class...");
            Food soup = new Food("Slime Soup", 2, 0.1);
            Console.WriteLine(soup);
            soup.Eat();
            soup.Eat();
            soup.Eat();
            Console.WriteLine(soup);


            Console.WriteLine("- - - - - - - - - - - - - - - - -");
            myItems.AddItem(soup);
            myItems.AddItem(new Food("Pumpkin Pie", 8, 0.2));
            myItems.AddItem(new Food("Cookies", 25, 0.03));
            myItems.PrintSummary();


            /********************************************/
            /* ACTIVITY 3: Load more items from a file  */
            /********************************************/

            // TODO: UNCOMMENT the following to test Activity 3

            Console.WriteLine("\n\n** Activity 3 **");
            myItems.LoadItems("../../../BAD.txt");
            Console.WriteLine();
            myItems.LoadItems("../../../items.txt");
            myItems.PrintSummary();

        }

    }
}
