using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class LinearLayout : Layout
    {
        public enum LayoutOrientation { VERTICAL, HORIZONTAL };
        public LayoutOrientation Orientation { get; set; }

        public void Refresh()
        {
            Draw();
        }

        public override void Draw()
        {
            if (mChildren.Count == 0) return;


            // move that to update
            int windowWidth = Console.WindowWidth;
            int windowsHeight = Console.WindowHeight;
            int childCount = mChildren.Count;

            int widgetWidth = windowWidth;
            int widgetHeight = windowsHeight;
            if (Orientation == LayoutOrientation.VERTICAL)
            {
                widgetHeight = windowsHeight / childCount;
                for (int i = 0; i < mChildren.Count; i++)
                {
                    Console.SetCursorPosition(0, i * widgetHeight);
                    mChildren[i].Draw();
                }
            }

            if (Orientation == LayoutOrientation.HORIZONTAL)
            {
                widgetWidth = windowWidth / childCount;
                for (int i = 0; i < mChildren.Count; i++)
                {
                    Console.SetCursorPosition(i * widgetWidth, 0);
                    mChildren[i].Draw();
                }
            }
            // only chain to children
        }

        public override void Update()
        {
            // resize children boxes
        }
    }
}
