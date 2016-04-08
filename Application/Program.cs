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
            Window window = Window.GetInstance("libtits 0.1.0", 80, 40);
            BuildLayout(window);
        }

        static void BuildLayout(Window window)
        {
            LinearLayout left = new LinearLayout();
              left.Add(new Text("Ceci est un texte"));
              left.Add(new Button("Ceci est un bouton"));
            LinearLayout right = new LinearLayout();
              right.Add(new Button("Ceci est un autre"));

            window.Add(left);
            window.Add(right);
        }
    }
}
