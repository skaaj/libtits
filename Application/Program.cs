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
            window.Title = "libtits 0.1.0";

            window.Add(new Text("Hello"));
            window.Add(new Text("World!"));
            window.Add(new Text("yo dawg u there?"));

            window.Draw();

            Console.ReadKey();
        }
    }
}
