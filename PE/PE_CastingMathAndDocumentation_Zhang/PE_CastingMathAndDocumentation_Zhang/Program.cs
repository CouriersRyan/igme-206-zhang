/*
 * Ryan Zhang
 * PE - Casting, Math & Documentation
 * https://docs.google.com/document/d/1ibDROBK1nO4bHIbmaB10vAJ66pUrSGBGLV_ziIb1EAM/edit
 */
namespace PE_CastingMathAndDocumentation_Zhang
{

    internal class Program
    {
        // Does calculations with several given 
        static void Main(string[] args)
        {
            String playerName = "Bobby McBobberson";

            // 5 whole number variables
            int totalHours = 274;
            int point1X = -13;
            int point1Y = 51;
            int point2X = 17;
            int point2Y = 28;

            // 4 floating-point number variables
            double pointA = 7.9;
            double pointB = 2.25;
            double angleDegrees = 60;
            double angleRadians = angleDegrees * Math.PI / 180;

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


            // Calculations
            //  Addition & explicit casting
            sumOfDoubles = pointA + pointB;
            sumOfWholes = (int)pointA + (int)pointB;

            //  Division & Modulus
            timePlayedDays = totalHours / 24;
            timePlayedHours = totalHours % 24;

            //  Sine and Cosine
            sine = Math.Sin(angleRadians);
            cosine = Math.Cos(angleRadians);

            //  Distance
            distanceBetweenPoints = Math.Sqrt(Math.Pow(point2X - point1X, 2) + Math.Pow(point2Y - point1Y, 2));

            //  Rounding
            nearestWhole = (int)Math.Round(distanceBetweenPoints); // TODO: Do I need to cast this?
            nearestThousandths = Math.Round(distanceBetweenPoints, 3);


            // Formatting and Printing
            //  Addition & explicit casting
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + pointA);
            Console.WriteLine("Number B: " + pointB);
            Console.WriteLine(pointA + " + " + pointB + " = " + sumOfDoubles);
            Console.WriteLine("Now I'll add just the whole number parts.");
            Console.WriteLine((int)pointA + " + " + (int)pointB + " = " + sumOfWholes);
            Console.WriteLine();

            //  Division & Modulus
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + totalHours + "hours.");
            Console.WriteLine("They have played for " + timePlayedDays + " days and " + timePlayedHours + " hours.");
            Console.WriteLine();

            //  Sine and Cosine
            Console.WriteLine("--- SINE and COSINE ---");
            Console.WriteLine(angleDegrees + " degrees is " + angleRadians + " radians.");
            Console.WriteLine("The sine is " + sine);
            Console.WriteLine("The cosine is " + cosine);
            Console.WriteLine();

            //  Distance
            Console.WriteLine("--- DISTANCE ---");
            Console.WriteLine("Point One: (" + point1X + "," + point1Y + ")");
            Console.WriteLine("Point One: (" + point2X + "," + point2Y + ")");
            Console.WriteLine("The distance between these points is " + distanceBetweenPoints);
            Console.WriteLine();

            //  Rounding
            Console.WriteLine("--- ROUNDING ---");
            Console.WriteLine("The distance is " + distanceBetweenPoints + ", which is approximately " + nearestWhole +
                " units, or " + nearestThousandths + " to be more precise.");
            Console.WriteLine();
        }
    }
}
