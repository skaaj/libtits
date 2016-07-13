using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextInterfaceToolingSdk;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Back to the basics");
			Tits.Save("title", 1, 2);
			string a = Tits.Retrieve("tile");
			Console.ReadKey();
		}
    }
}
