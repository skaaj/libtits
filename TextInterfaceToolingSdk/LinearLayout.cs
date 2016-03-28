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
            if (childCount > 0)
            {
                if (Orientation == LayoutOrientation.VERTICAL)
                {
                    int widgetHeight = Box.Height / childCount;
                    for (int i = 0; i < mChildren.Count; i++)
                    {
                        mChildren[i].SetGeometry(Box.Left, Box.Top + i * widgetHeight, Box.Width, widgetHeight);
                    }
                }

                if (Orientation == LayoutOrientation.HORIZONTAL)
                {
                    int widgetWidth = Box.Width / childCount;
                    for (int i = 0; i < mChildren.Count; i++)
                    {
                        mChildren[i].SetGeometry(Box.Left + i * widgetWidth, Box.Top, widgetWidth, Box.Height);
                    }
                }

                Draw();
            }
        }
    }
}
