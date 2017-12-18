using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsNullablesConversionsDecisions
{
	class Program
	{
		static void Main(string[] args)
		{
			// Use a StringBuilder to efficiently change an original string containing
			// the text "Cat" to a result that has one character changed to produce the
			// result "Rat". Then display that result in the console window.
			string inPet = "Cat";
			StringBuilder pet = new StringBuilder(inPet);
			pet.Replace('C', 'R');
			Console.WriteLine(pet.ToString());

			// Declare a nullable int named x, initialize it to null, and then
			// display it in console output. Then display the boolean value that
			// indicates whether x has a value or not. After that, assign 42 to it
			// and display it again and then display the boolean value again that
			// indicates whether x has a value or not.

			int? x = null;
			Console.WriteLine(x.ToString());
			Console.WriteLine(x.HasValue);
			x = 42;
			Console.WriteLine(x.ToString());
			Console.WriteLine(x.HasValue);

			// Declare a DateTime variable named aDateTime, and assign it to the result of
			// converting the string "4 July 1776" to a DateTime object. Then display the result.
			DateTime aDateTime = Convert.ToDateTime("4 July 1776");
			Console.WriteLine(aDateTime);


			// Declare a variable of type char named ch and initialize it with the value '7'.
			// Then test it in an if statement to see if it is a letter or a
			// non-letter character. Display output on the console that indicates
			// whether it is a letter or a non-letter.
			char ch = '7';
			if(Char.IsLetter(ch))
			{
				Console.WriteLine(ch + " is a letter.");
			}
			else Console.WriteLine(ch + " is not a letter.");

			Console.ReadLine();
		}
	}
}
