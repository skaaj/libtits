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
            Console.Title = "libtits dev version";

            // set tits mutable only for initialization
            Tits.SetMutable(true);
            Tits.OverflowMode = Tits.Overflow.ELLIPSIS;
            Tits.SetMutable(false);

            // tests
            Tits.WriteAt("123456789", Console.BufferWidth - 3, 1);
            Tits.HideCursor();

            Console.ReadKey();
		}
    }
}
