using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public enum Alignment {
        Left,
        TopLeft,
        TopCenter,
        TopRight,
        Right,
        BottomRight,
        BottomCenter,
        BottomLeft,
        Center
    };

    public abstract class Widget
    {
        public Widget()
        {
            Box = new Box();
        }

        public string Identifier { get; set; }
        public Box Box { get; set; }
        public LayoutParams LayoutParams { get; set; }

        public void SetGeometry(int x, int y, int w, int h) => Box.SetGeometry(x, y, w, h);

        public abstract void Draw();
    }
}
