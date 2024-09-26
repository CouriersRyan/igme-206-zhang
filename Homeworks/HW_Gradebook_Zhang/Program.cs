/*
 * Ryan Zhang
 * HW 3 - Gradebook
 * https://docs.google.com/document/d/1CRdgLx-tmPCrJD4Lz4gKxuINPltc_18wgmnESYKsGXA/edit?usp=sharing
 */
namespace HW_Gradebook_Zhang
{
    /// <summary>
    /// Gradebook program. Prompts the user for a number of grades to enter and prints out statistics for the grade.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration
            //    Activity 1
            int totalAssignments;
            string[] assignmentNames;
            double[] assignmentGrades;
            //    Activity 2 & 4
            double gradeAverage;
            double gradeSum;
            //    Activity 3
            int assignmentIndex; // First index is 1 (not 0)
            //    Activity 5
            bool isAllGradesUnique;
            double lowestGrade;
            double highestGrade;
            int gradesAboveAvg;


            // Activity 1: Getting the Data

            // Prompt for the number of grades being inputted.
            Console.Write("How many assignments are you saving? ");
            totalAssignments = int.Parse(Console.ReadLine());
            // Reprompt if the value is not nonzero and positive.
            while (totalAssignments < 1)
            {
                Console.Write("That is not a valid number. Enter the number of assignments: ");
                totalAssignments = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("You are saving {0} assigments.\n", totalAssignments);

            // Initialize arrays
            assignmentGrades = new double[totalAssignments];
            assignmentNames = new string[totalAssignments];

            for (int i = 0; i < totalAssignments; i++)
            {
                // Prompt for assignment name.
                Console.Write("Enter the name for assignment #{0}: ", i + 1);
                assignmentNames[i] = Console.ReadLine().Trim();
                // Reprompt if name was empty.
                while (assignmentNames[i].Equals(String.Empty))
                {
                    Console.Write("Assignment name can't be empty. Enter assignment name: ");
                    assignmentNames[i] = Console.ReadLine().Trim();
                }

                // Prompt for grade
                Console.Write("Enter the grade for {0}: ", assignmentNames[i]);
                assignmentGrades[i] = double.Parse(Console.ReadLine());
                // Reprompt if grade is not between 0 and 100
                while (assignmentGrades[i] < 0 || assignmentGrades[i] > 100)
                {
                    Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    assignmentGrades[i] = double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine("All grades entered!");
            Console.WriteLine();

            // Activity 2: Grade Average
            // Calculate the average of all grades
            gradeSum = 0;
            for (int i = 0; i < assignmentGrades.Length; i++)
            {
                gradeSum += assignmentGrades[i];
            }
            gradeAverage = gradeSum / assignmentGrades.Length;

            // Print Listing of assigment names and scores
            Console.WriteLine("Grade Report:");
            for(int i = 0; i < totalAssignments; i++)
            {
                Console.WriteLine("    {0}. {1}: {2}", i + 1, assignmentNames[i], assignmentGrades[i]);
            }
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Average {0:F2}", gradeAverage);
            Console.WriteLine();

            // Activity 3: Grade Replacement
            Console.Write("Which number grade do you want to replace? ");
            assignmentIndex = int.Parse(Console.ReadLine());

            while(assignmentIndex < 1 || assignmentIndex > totalAssignments)
            {
                Console.WriteLine("Index must be a number between 1 and {0}. Try again.", totalAssignments);
                Console.Write("Which number grade do you want to replace? ");
                assignmentIndex = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            Console.Write("What is the new grade for {0}? ", assignmentNames[assignmentIndex - 1]);
            assignmentGrades[assignmentIndex - 1] = double.Parse(Console.ReadLine());
            // Reprompt if grade is not between 0 and 100
            while (assignmentGrades[assignmentIndex - 1] < 0 || assignmentGrades[assignmentIndex - 1] > 100)
            {
                Console.Write("Grade must be between 0 and 100. Enter grade: ");
                assignmentGrades[assignmentIndex - 1] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine("Replacing the grade at index {0} with {0:F2}", assignmentIndex, assignmentGrades[assignmentIndex - 1]);
            Console.WriteLine();

            // Activity 4: Print Final Summary
            // Calculate the average of all grades
            gradeSum = 0;
            for (int i = 0; i < assignmentGrades.Length; i++)
            {
                gradeSum += assignmentGrades[i];
            }
            gradeAverage = gradeSum / assignmentGrades.Length;

            // Print Listing of assigment names and scores
            Console.WriteLine("Grade Report:");
            for (int i = 0; i < totalAssignments; i++)
            {
                Console.WriteLine("    {0}. {1}: {2}", i + 1, assignmentNames[i], assignmentGrades[i]);
            }
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Average {0:F2}", gradeAverage);
            Console.WriteLine();

            // Activity 5: Analyze and Report!
            // Calculations
            gradesAboveAvg = 0;
            lowestGrade = assignmentGrades[0];
            highestGrade = assignmentGrades[0];
            isAllGradesUnique = true;

            // Loop to check for grades above average and lowest and highest grades
            for (int i = 0; i < assignmentGrades.Length; i++)
            {
                // Count the number of grades above the average
                if (assignmentGrades[i] > gradeAverage)
                {
                    gradesAboveAvg++;
                }

                // Replace highest grade if program finds a higher one
                if(assignmentGrades[i] > highestGrade)
                {
                    highestGrade = assignmentGrades[i];
                }

                // Replace lowest grade if program finds a lower one
                if (assignmentGrades[i] < lowestGrade)
                {
                    lowestGrade = assignmentGrades[i];
                }
            }

            // Loop to check for uniqueness
            if (totalAssignments > 1)
            {
                // Compare each value against each other value once.
                for (int i = 0; i < assignmentGrades.Length - 1; i++)
                {
                    for (int j = i + 1; j < assignmentGrades.Length; j++)
                    {
                        if (assignmentGrades[i] == assignmentGrades[j])
                        {
                            isAllGradesUnique = false;
                            // Exit loop if non-unique value found
                            break;
                        }
                    }

                    // Exit loop if non-unique value found
                    if (!isAllGradesUnique)
                    {
                        break;
                    }
                }
            }

            // TODO: Print
            Console.WriteLine("{0} grades are above average.", gradesAboveAvg);
            Console.WriteLine("\nThe highest grade is {0}." +
                "\nThe lowest grade is {1}.", highestGrade, lowestGrade);
            if(isAllGradesUnique)
            {
                Console.WriteLine("\nAll grades are unique.");
            }
            else
            {
                Console.WriteLine("\nA grade appears more than once in this set of grades.");
            }
            
        }
    }
}
