using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public enum LayoutOrientation { VERTICAL, HORIZONTAL };

    public class LinearLayout : Layout
    {
        public LayoutOrientation Orientation { get; set; }

        public LinearLayout(LayoutOrientation orientation = LayoutOrientation.VERTICAL)
        {
            Orientation = orientation;
        }

        public override void Update()
        {
            int childCount = mChildren.Count;
            if (childCount == 0) return;

            for (int i = 0; i < mChildren.Count; i++)
            {
                if(Orientation == LayoutOrientation.VERTICAL)
                {
                    int widgetHeight = Box.Height / childCount;
                    mChildren[i].SetGeometry(Box.Left, Box.Top + i * widgetHeight, Box.Width, widgetHeight);
                }
                else if (Orientation == LayoutOrientation.HORIZONTAL)
                {
                    int widgetWidth = Box.Width / childCount;
                    mChildren[i].SetGeometry(Box.Left + i * widgetWidth, Box.Top, widgetWidth, Box.Height);
                }

                Layout layout = mChildren[i] as Layout;
                if (layout != null)
                    layout.Update();
            }

            Draw();
        }
    }
}
