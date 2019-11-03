using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while(true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string postfix = calculator.ConvertToPostfix(input);
                    double result = calculator.Calculate(postfix);

                    Console.WriteLine(postfix);
                    Console.WriteLine(result);
                }
                catch(InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
        }
    }
}
