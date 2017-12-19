using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsMethodsExceptionsArraysClasses
{
	class Program
	{
		// Add a static method named MultiplytTwoNumbers that takes two int
		// parameters named x and y, and returns the int result that is the
		// product of the two parameters.

		public static int MultiplyTwoNumbers(int x, int y)
		{
			return x*y;
		}

		// Add an instance method named AddTwoNumbers that takes two int
		// parameters named x and y, and returns the int result that is
		// the sum of the two parameters.

		public int AddTwoNumbers(int x, int y)
		{
			return x + y;
		}


		// Add a static method named DoubleIt that returns void
		//It should take two parameters of type int, x and y, where y is an out parameter
		//Modify the outgoing value by assigning it the value of x multiplied by 2

		public static void DoubleIt(int x, out int y)
		{
			y = x * 2;
		}

		// Add an instance method named LoopOverParams that returns void, and
		// takes a single parameter that is an array of int type elements
		// declared using the params keyword. The LoopOverParams method uses a
		// foreach loop to iterate over the collection of values it receives
		// and it displays the list of elements in the parameter.

		public void LoopOverParams(params int[] args)
		{
			foreach(int i in args)
			{
				Console.WriteLine(i);
			}
		}

		// Add a static method named DivideIntegers that takes two int
		// parameters named dividend and divisor. It returns the result
		// of dividing the dividend parameter by the divisor parameter.

		public static int DivideIntegers(int dividend, int divisor)
		{
			return dividend / divisor;
		}


		static void Main(string[] args)
		{
			// Call the static method named MultiplytTwoNumbers
			// passing in the two int values of 3 and 4. Then
			// assign the result to a local variable named product and
			// display the resulting value of product in console output.

			int product = MultiplyTwoNumbers(3, 4);
			Console.WriteLine(product.ToString());

			// Create an instance of the Program class named program.
			// Then call the instance method named AddTwoNumbers
			// passing in the values of 3 and 4. Then assign
			// the result to a local variable named sum and
			// display the value of sum in console output

			Program program = new Program();
			int sum = program.AddTwoNumbers(3, 4);
			Console.WriteLine(sum.ToString());

			// Declare an int variable named x and initialize it
			// with the literal value of 42. Call the static method
			// named DoubleIt passing in the x variable as the
			// parameter. Then display the resulting value of x in
			// console output.

			int x = 42;
			DoubleIt(x, out x);
			Console.WriteLine(x.ToString());

			// Call the LoopOverParams instance method, passing in
			// three parameters with the values of 1, 2, and 3.

			program.LoopOverParams(1, 2, 3);

			// Call the method named DivideIntegers with the first
			// parameter set to 1, and second parameter set to 0.
			// Assign the result to an int variable named quotient.
			// Apply the try and catch keywords to properly handle
			// the resulting divide by zero exception. In the
			// exception handler, display the exception message
			// in the console output.

			try
			{
				int quotient = DivideIntegers(1, 0);
			}
			catch(DivideByZeroException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			// Declare a two-dimensional array named multiplicationTable
			// that contains 4 elements by 4 elements. Initialize it in
			// a nested loop to contain elements that equal to the value
			// that is the product of the two index values for
			// each element. In a second nested loop, display the values
			// in the console output, with column elements seperated with
			// commas, and row elements seperated with carriage returns.

			int[,] multiplicationTable = new int[4, 4];

			int y = multiplicationTable.GetUpperBound(0);
			int z = multiplicationTable.GetUpperBound(1);

			for(int a = 0; a <= y; a++)
			{
				for (int b = 0; b <= z; b++)
				{
					multiplicationTable[a, b] = a * b;
				}
			}

			for(int a = 0; a <= y; a++)
			{
				for(int b = 0; b <= z; b++)
				{
					Console.Write(multiplicationTable[a, b]);
					if(b < z) Console.Write(",");
				}
				Console.Write("\n");
			}

			Console.ReadLine();
		}
	}
}
