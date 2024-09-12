/*
 * Ryan Zhang
 * 
 * PE - Casting, Math & Documentation
 * https://docs.google.com/document/d/1ibDROBK1nO4bHIbmaB10vAJ66pUrSGBGLV_ziIb1EAM/edit
 * 
 * PE - Input & Parsing
 * https://docs.google.com/document/d/1-cwu4r6ES1Cg5RujrKAKU8aGUKaWGBjv5wgFe6IvKmk/edit
 */
namespace PE_CastingMathAndDocumentation_Zhang
{

    internal class Program
    {
        // Does calculations with several given 
        static void Main(string[] args)
        {
            string playerName;

            // 5 whole number variables
            int totalHours;
            int point1X;
            int point1Y;
            int point2X;
            int point2Y;

            // 4 floating-point number variables
            double numberA;
            double numberB;
            double angleDegrees;
            double angleRadians;

            // Result storage variables
            double sumOfDoubles;
            int sumOfWholes;
            int timePlayedDays;
            int timePlayedHours;
            double sine;
            double cosine;
            double distanceBetweenPoints;
            int nearestWhole;
            double nearestThousandths;

            // Stores user inputs from console
            string input;


            // Inputs, Calculations and outputs
            //  Addition & explicit casting
            //      Input
            Console.WriteLine("--- ADDITION ---");
            Console.Write("What is the first number? ");
            input = Console.ReadLine();
            numberA = double.Parse(input);
            Console.Write("What is the second number? ");
            input = Console.ReadLine();
            numberB = double.Parse(input);

            //      Output
            sumOfDoubles = numberA + numberB;
            sumOfWholes = (int)numberA + (int)numberB;
            Console.WriteLine(numberA + " + " + numberB + " = " + sumOfDoubles);
            Console.WriteLine("Now I'll add just the whole number parts.");
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + sumOfWholes);
            Console.WriteLine();


            //  Division & Modulus
            //      Input
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.Write("What is the player's name? ");
            input = Console.ReadLine();
            playerName = input;
            Console.Write("How many hours have they logged? ");
            input = Console.ReadLine();
            totalHours = int.Parse(input);

            //      Output
            Console.WriteLine(playerName + " has played a game for " + totalHours + " hours.");
            timePlayedDays = totalHours / 24;
            timePlayedHours = totalHours % 24;
            Console.WriteLine("They have played for " + timePlayedDays + " days and " + timePlayedHours + " hours.");
            Console.WriteLine();


            //  Sine and Cosine
            //      Input
            Console.WriteLine("--- SINE and COSINE ---");
            Console.Write("Enter an angle in degrees: ");
            input = Console.ReadLine();
            angleDegrees = double.Parse(input);


            //      Output
            angleRadians = angleDegrees * Math.PI / 180.0;
            Console.WriteLine(angleDegrees + " degrees is " + angleRadians + " radians.");
            sine = Math.Sin(angleRadians);
            cosine = Math.Cos(angleRadians);
            Console.WriteLine("The sine is " + sine);
            Console.WriteLine("The cosine is " + cosine);
            Console.WriteLine();


            //  Distance and Rounding
            //      Input
            Console.WriteLine("--- DISTANCE and ROUNDING---");
            Console.Write("Enter Point 1 X: ");
            input = Console.ReadLine();
            point1X = int.Parse(input);
            Console.Write("Enter Point 1 Y: ");
            input = Console.ReadLine();
            point1Y = int.Parse(input);
            Console.Write("Enter Point 2 X: ");
            input = Console.ReadLine();
            point2X = int.Parse(input);
            Console.Write("Enter Point 2 Y: ");
            input = Console.ReadLine();
            point2Y = int.Parse(input);

            //      Output
            Console.WriteLine("Point One: (" + point1X + "," + point1Y + ")");
            Console.WriteLine("Point One: (" + point2X + "," + point2Y + ")");
            distanceBetweenPoints = Math.Sqrt(Math.Pow(point2X - point1X, 2) + Math.Pow(point2Y - point1Y, 2));
            Console.WriteLine("The distance between these points is " + distanceBetweenPoints);
            nearestWhole = (int)Math.Round(distanceBetweenPoints); // TODO: Do I need to cast this?
            nearestThousandths = Math.Round(distanceBetweenPoints, 3);
            Console.WriteLine("The distance is " + distanceBetweenPoints + ", which is approximately " + nearestWhole +
                " units, or " + nearestThousandths + " to be more precise.");
            Console.WriteLine();
        }
    }
}
