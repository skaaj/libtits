using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public enum LayoutOrientation {
        Vertical,
        Horizontal
    };

    public class LinearLayout : Layout
    {
        private LayoutOrientation mOrientation;

        public LinearLayout(LayoutOrientation orientation)
        {
            Orientation = orientation;
        }

        public LinearLayout()
        {
            Orientation = LayoutOrientation.Vertical;
        }

        public LayoutOrientation Orientation
        {
            get
            {
                return mOrientation;
            }
            set
            {
                mOrientation = value;
                Update();
            }
        }

        public override void Update()
        {
            var childCount = mChildren.Count;
            if (childCount > 0)
            {

                for (int i = 0; i < mChildren.Count; i++)
                {
                    if (Orientation == LayoutOrientation.Vertical)
                    {
                        var widgetHeight = Box.Height / childCount;
                        mChildren[i].SetGeometry(Box.Left, Box.Top + i * widgetHeight, Box.Width, widgetHeight);
                    }
                    else if (Orientation == LayoutOrientation.Horizontal)
                    {
                        var widgetWidth = Box.Width / childCount;
                        Type t = widgetWidth.GetType();
                        mChildren[i].SetGeometry(Box.Left + i * widgetWidth, Box.Top, widgetWidth, Box.Height);
                    }

                    var layout = mChildren[i] as Layout;
                    if (layout != null)
                        layout.Update();
                }

                Draw();
            }
        }
    }
}
