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

            window.RootLayout = new LinearLayout(LayoutOrientation.HORIZONTAL);

            LinearLayout left = new LinearLayout();
            LinearLayout right = new LinearLayout();

            window.Add(left);
            window.Add(right);

            left.Add(new Text("Ceci est un texte"));
            left.Add(new Button("Ceci est un bouton"));

            right.Add(new Button("Ceci est un autre bouton"));
        }
    }
}
