/*
 * Ryan Zhang
 * PE - Casting, Math & Documentation
 * https://docs.google.com/document/d/1ibDROBK1nO4bHIbmaB10vAJ66pUrSGBGLV_ziIb1EAM/edit
 */
namespace PE_CastingMathAndDocumentation_Zhang
{

    internal class Program
    {
        static void Main(string[] args)
        {
            String playerName = "Bobby McBobberson";

            // 5 whole number variables
            int totalHours = 274;
            int x1 = -13;
            int y1 = 51;
            int x2 = 17;
            int y2 = 28;

            // 4 floating-point number variables
            double a = 7.9f;
            double b = 2.25f;
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
            sumOfDoubles = a + b;
            sumOfWholes = (int)a + (int)b;

            //  Division & Modulus
            timePlayedDays = totalHours / 24;
            timePlayedHours = totalHours % 24;

            //  Sine and Cosine
            sine = Math.Sin(angleRadians);
            cosine = Math.Cos(angleRadians);

            //  Distance
            distanceBetweenPoints = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            //  Rounding
            nearestWhole = (int)Math.Round(distanceBetweenPoints); // TODO: Do I need to cast this?
            nearestThousandths = Math.Round(distanceBetweenPoints, 3);


            // Formatting and Printing
            //  Addition & explicit casting
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + a);
            Console.WriteLine("Number B: " + b);
            Console.WriteLine(a + " + " + b + " = " + sumOfDoubles);
            Console.WriteLine("Now I'll add just the whole number parts.");
            Console.WriteLine((int)a + " + " + (int)b + " = " + sumOfWholes);
            Console.WriteLine();

            //  Division & Modulus
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + totalHours);
            Console.WriteLine("They have played for " + timePlayedDays + " days and " + timePlayedHours + " hours.");
            Console.WriteLine();

            //  Sine and Cosine
            Console.WriteLine("--- SINE and COSINE ---");
            Console.WriteLine();

            //  Distance
            Console.WriteLine("--- DISTANCE ---");
            Console.WriteLine();

            //  Rounding
            Console.WriteLine("--- ROUNDING ---");
            Console.WriteLine();
        }
    }
}
