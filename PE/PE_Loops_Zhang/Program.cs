/*
 * Ryan Zhang
 * PE - Loops
 * https://docs.google.com/document/d/1BFxvyQRAT6S3IS4F8xWYHjsIJ-0Gz_nqseCfAGFf-SU/edit
 */
namespace PE_Loops_Zhang
{
    internal class Program
    {
        // Several bits of code that use loops. Looping over numbers for the first part, and printing a ASCII rectangle for the second part with user input.
        static void Main(string[] args)
        {
            // Variable Declaration
            int count1 = 0;
            int count2 = 100;

            int rectWidth;
            int rectHeight;

            // Part 1
            // 0 to 5 - while
            while(count1 <= 5)
            {
                Console.WriteLine(count1);
                count1++;
            }

            // 100 to 95 - do/while
            do
            {
                Console.WriteLine(count2);
                count2--;
            } while (count2 >= 95);

            // 0 to 25, multiples of 5, inclusive - for loop
            for(int i = 0; i <= 25; i += 5)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // Part 2
            // Prompt for dimensions
            Console.Write("Enter a width: ");
            rectWidth = int.Parse(Console.ReadLine());
            Console.Write("Enter a height: ");
            rectHeight = int.Parse(Console.ReadLine());

            // Draw a solid rectangle
            // Iterate over height to make new lines/rows
            for(int i = 0; i < rectHeight; i++)
            {
                // Iterate over width to draw individual cells of the rectangle
                for(int j = 0; j <= rectWidth; j++)
                {
                    Console.Write("O");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Draw just the border
            // Iterate over height to make new lines/rows
            for (int i = 0; i < rectHeight; i++)
            {
                // Iterate over width to draw individual cells of the rectangle
                for (int j = 0; j < rectWidth; j++)
                {
                    // Check so that "O" is only printed on the edges and the centers are " "
                    if ((j == 0 || j == rectWidth - 1) || (i == 0 || i == rectHeight - 1))
                    {

                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
