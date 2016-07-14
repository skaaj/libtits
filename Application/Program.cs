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
			Tits.WriteAt("some long text lets see what happen", Console.BufferWidth - 4, 0);
			Console.ReadKey();
		}
    }
}
