using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class Viewport
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Layout root { get; set; }

        public Viewport(int width, int height)
        {
            Width = width;
            Height = height;

            root = new LinearLayout();

            Refresh();
        }

        public void Refresh()
        {
            Console.WindowWidth = Width;
            Console.WindowHeight = Height;

            Console.BufferWidth = Width;
            Console.BufferHeight = Height;

            root.Draw();
        }
    }
}
