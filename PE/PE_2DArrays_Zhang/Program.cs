/*
 * Ryan Zhang
 * PE - 2D Arrays
 * https://docs.google.com/document/d/1sHTLdpL9oFUDTzCVaOG38gYA_nSnDhd7MVY6IYx2P4A/edit?usp=sharing
 */
namespace PE_2DArrays_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Fills a 2D array with sequential numbers and prints it.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Init a 2D array of 2 x 4 elements with sequential values
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 5);

            // Print values in the array
            Print2DArray(integerArray);
        }

        /// <summary>
        /// Fills a 2D arrays with sequential values starting from startNum.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startNum"></param>
        public static void Fill2DArray(int[,] array, int startNum)
        {
            int count = startNum;

            // Iterate over a 2D array.
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    // Sets element at index to number in sequence then increments it.
                    array[i, j] = count++;
                }
            }
        }

        /// <summary>
        /// Prints a 2D array to console, formatted to indicate rows and columns.
        /// </summary>
        /// <param name="array"></param>
        public static void Print2DArray(int[,] array)
        {
            // Print Column labels
            for(int i = 0;i < array.GetLength(1); i++)
            {
                Console.Write("\tCol {0}", i + 1);
            }
            Console.WriteLine();

            // Iterate over 2D array.
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // Print Row labels
                Console.Write("Row {0}:", i + 1);
                for (int j = 0;j < array.GetLength(1); j++)
                {
                    // Prints each element
                    Console.Write("\t" + array[i, j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
