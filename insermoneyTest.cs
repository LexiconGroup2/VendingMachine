using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithxunit
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calc obj1=new Calc();

            Console.WriteLine("Enter the decimal value of a:");

            decimal a=decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the decimal value of b:");

            decimal b=decimal.Parse(Console.ReadLine());

            decimal total=obj1.Addition(a,b);

            
            decimal difference=obj1.Subtraction(a,b);
            decimal product=obj1.multiplication(a,b);
          
            
            
            Console.WriteLine($"The sum of {a} and {b} is :{total}");

            Console.WriteLine($"The difference of {a} and {b} is :{difference}");

            Console.WriteLine($"The product of {a} and {b} is :{product}");

            decimal quotient = 0;

            try
            {
                quotient = obj1.division(a, b);
                Console.WriteLine($"The division of {a} by {b} is:{quotient}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            

            decimal[] numbers =new decimal [] { +1.1m, -3.3m, +5, +7, +8.8m };
            Console.WriteLine("Array elements are:");

            foreach ( decimal number in numbers )
            {
                Console.Write(number +" , ");
            }
            Console.WriteLine();

            decimal sum2 = obj1.Addition(numbers);



            Console.WriteLine("Sum of Array Elements are:" + sum2);

            decimal[] numbers2 = new decimal[] { 1.5m, 2.3m, 5.3m, 5.6m };

            Console.WriteLine("Array elements to perform subtraction");

            foreach ( decimal item in numbers2 )
            {
                Console.Write(item + " , ");
            }
            Console.WriteLine();

            decimal diff2 = obj1.Subtraction(numbers2);

            Console.WriteLine("Array Elements difference:" + diff2);
        }
    }
}
