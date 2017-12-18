using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn
{
	class Program
	{
		static void Main(string[] args)
		{
			// Main method demonstrates the use of variables, operators, expressions, and statements
			int x = 3;
			int y = 4;
			int sum = x + y;

			Console.WriteLine("Sum of 3 and 4 is: " + sum.ToString());
			Console.WriteLine("Are the values of sum and 7 equal? " + (sum == 7));

			string text1 = "Hello";
			string text2 = "World";
			string message = text1 + " " + text2;
			Console.WriteLine("Message: " + message);

			Console.ReadLine();
		}
	}
}
