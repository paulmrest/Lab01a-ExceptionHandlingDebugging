﻿using System;

namespace Lab01a___Exception_Handling_and_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Program completed.");
            }
        }

        //Our controller method. Will be calling all other methods from here.
        //Input: none
        //Output: print to console
        //Exceptions: none
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Enter a number greater than zero.");
                string rawInput = Console.ReadLine();
                int userInput = Convert.ToInt32(rawInput);
                int[] intArray = new int[userInput];
                Populate(intArray);
                int sum = GetSum(intArray);
                int product = GetProduct(intArray, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine("Your array size is: {0}", intArray.Length);
                Console.Write("The numbers in the array are: ");
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (i == intArray.Length - 1)
                    {
                        Console.Write("{0}\n", intArray[i]);
                    }
                    else
                    {
                        Console.Write("{0}, ", intArray[i]);
                    }
                }
                Console.WriteLine("The sum of the array is: {0}", sum);
                Console.WriteLine("{0} * {1} = {2}", sum, product / sum, product);
                Console.WriteLine("{0} / {1} = {2}", product, product / quotient, quotient);
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException error.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("OverflowException error.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Populate the integer array with user input
        //Input: an integer array of Length > 0
        //Output: an integer array populated with user input
        //Exceptions: FormatException, OverflowExecption
        static int[] Populate(int[] intArray)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine("Please enter number {0} of {1}", i + 1, intArray.Length);
                string rawInput = Console.ReadLine();
                intArray[i] = Convert.ToInt32(rawInput);
            }
            return intArray;
        }

        //Calculates and returns a sum of all integers in an array
        //Input: an integer array of Length > 0
        //Output: an integer value representing the sum
        //Exceptions: InvalidOperationException if sum < 20
        static int GetSum(int[] intArray)
        {
            int minSum = 20;
            int sum = 0;
            foreach (int oneInt in intArray)
            {
                sum += oneInt;
            }
            if (sum < minSum)
            {
                //within the bounds of "good pratice" C#/.NET Exception throwing, InvalidOPerationException seemed the most logical choice
                throw new System.InvalidOperationException($"Value of {sum} is too low. Needs to be >= {minSum}.");
            }
            return sum;
        }

        //Asks the user for a value that is a valid index (+1) for the parameter array passed in, then multiples the value at that index
        //by the sum parameter. Returns that product.
        //Input: an integer array of Length > 0
        //Output: an integer value represending the product of sum * value at user inputted index
        //Exceptions: IndexOutOfRangeException if user chooses a value that doesn't correspodn to a valid index
        static int GetProduct(int[] intArray, int sum)
        {
            Console.WriteLine("Please choose a number between 1 and {0}", intArray.Length);
            string rawInput = Console.ReadLine();
            int userEntry = Convert.ToInt32(rawInput);
            if (userEntry < 1 || userEntry > intArray.Length)
            {
                throw new System.IndexOutOfRangeException($"Number needed to be between 1 and {intArray.Length}.");
            }
            int product = sum * intArray[userEntry - 1];
            return product;
        }

        //Asks the user for number to divide the product parameter by, performs that division, and returns the result.
        //Input: a integer value
        //Output: a decmial value representing the product / user Input
        //Exceptions: DivideByZeroException if the user entered value is 0
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine("Please enter a number to divide your product {0} by:", product);
                string rawInput = Console.ReadLine();
                int divisor = Convert.ToInt32(rawInput);
                decimal quot = decimal.Divide(product, divisor);
                return quot;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("DivideByZeroException.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return 0;
            }
        }
    }
}
