using System;

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
                Console.WriteLine("Program completed successfully.");
            }
        }

        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Enter a number greater than zero.");
                int userInput = Convert.ToInt32(Console.ReadLine());
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

        static int[] Populate(int[] intArray)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine("Please enter number {0} or {1}", i + 1, intArray.Length);
                intArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            return intArray;
        }

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
                throw new System.InvalidOperationException($"Value of {sum} is too low. Needs to be >= {minSum}.");
            }
            return sum;
        }

        static int GetProduct(int[] intArray, int sum)
        {
            Console.WriteLine("Please choose a number between 1 and {0}", intArray.Length);
            int userEntry = Convert.ToInt32(Console.ReadLine());
            if (userEntry < 1 || userEntry > intArray.Length)
            {
                throw new System.IndexOutOfRangeException($"Number needed to be between 1 and {intArray.Length}.");
            }
            int product = sum * intArray[userEntry - 1];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine("Please enter a number to divide your product {0} by:", product);
                int divisor = Convert.ToInt32(Console.ReadLine());
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
