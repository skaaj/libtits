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
            Viewport window = new Viewport(120, 40);
            window.root.Add(new Text("Hello"));
            window.root.Add(new Text("World!"));

            LinearLayout ll = window.root as LinearLayout;
            ll.Orientation = LinearLayout.LayoutOrientation.HORIZONTAL;

            window.Refresh();

            Console.ReadKey();
        }
    }
}
