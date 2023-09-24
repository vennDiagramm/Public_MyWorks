//Take user input
//Do simple calculations
//Redo calculations

using System;
using System.IO;

namespace TrialForProg3_1._0_
{
    class Program
    {
        static void Main(string[] args)
        {
            //For continuous calculations
            bool continueCalculation = true;

            //FOR USER INPUT
            while (continueCalculation)
            {
                // Declaration of variables
                double num1 = 0, num2 = 0, res = 0;
                string op = "";
                bool valid = false;

                //Input validation for num1 and num2
                while (!valid)
                {
                    try
                    {
                        //1ST NUMBER
                        Console.Write("Enter first number: ");
                        num1 = double.Parse(Console.ReadLine());

                        //2ND NUMBER
                        Console.Write("Enter second number: ");
                        num2 = double.Parse(Console.ReadLine());

                        //RETURN TRUE
                        valid = true;

                        //OPERATION TO BE USED
                        Console.Write("Enter operation (+, -, *, /): ");
                        op = Console.ReadLine();
                        
                        // Check the validity of the operation
                        if (op != "+" && op != "-" && op != "*" && op != "/")
                        {
                            Console.WriteLine("Invalid operation. Please enter a valid operation (+, -, *, /).");
                            valid = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        valid = false;
                    }
                }


            //BREAK HERE -- OPERATION (call for function-below the code)

                //Operation - call up the function
                res = Calculate(num1, num2, op);

                // Print the result
                Console.WriteLine($"{num1} {op} {num2} = {res}");

            
            //BREAK HERE -- FILE HANDLING

                //Save to file
                string filePath = @"C:\Users\marga\OneDrive\Documents\Marga_Pilapil\C#\TrialFor3rdProg\Stored_Numbers.txt";
                string[] lines = { $"{num1} {op} {num2} = {res}" };
                using (FileStream storage = new FileStream(filePath, FileMode.OpenOrCreate))
                using (StreamWriter writer = new StreamWriter(storage))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }

                //Retrieve from file
                Console.WriteLine("\nPrevious Results:");
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }


            //BREAK HERE -- THE CONTINOUS CALCULATIONS
                Console.Write("Do you want to perform another calculation? (Y/N): ");
                string input = Console.ReadLine();
                if (input.ToUpper() != "Y")
                {
                    continueCalculation = false;
                }
            }
        }


        //FUNCTIONS (This is where the solving happens)
        static double Calculate(double num1, double num2, string op)
        {
            double result = 0;

            switch (op)
            {
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero. Please enter a different second number.");
                    }
                    break;

                case "+":
                    result = num1 + num2;
                    break;

                case "-":
                    result = num1 - num2;
                    break;

                case "*":
                    result = num1 * num2;
                    break;

                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }

            return result;
        }
    }
}
