using System;
using System.Collections.Generic;
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
            Window window = Window.Instance;
            window.Title = "libtits 0.0.0";

            window.Root.Add(new Text("Hello"));
            window.Root.Add(new Text("World!"));

            window.Refresh();

            Console.ReadKey();
        }
    }
}
