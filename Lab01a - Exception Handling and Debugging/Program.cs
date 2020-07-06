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
                        Console.Write("{0}", intArray[i]);
                    }
                    else
                    {
                        Console.Write("{0}, ", intArray[i]);
                    }
                }
                Console.WriteLine("The sum of the array is: {0}", sum);
                Console.WriteLine("{0} * {1} = {2}", sum, product, sum * product);
                Console.WriteLine("{0} / {1} = {2}", sum * product, quotient, (sum * product) / quotient);
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
                Console.WriteLine("Exception encountered.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
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
            return -1;
        }

        static int GetProduct(int[] intArray, int sum)
        {
            return -1;
        }

        static decimal GetQuotient(int product)
        {
            return (decimal)-1.0;
        }
    }
}
