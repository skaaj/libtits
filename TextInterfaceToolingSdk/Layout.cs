using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public enum LayoutEventType { Add, Remove };

    public class LayoutEventArgs
    {
        public LayoutEventArgs(LayoutEventType type, Widget widget)
        {
            Type = type;
            Widget = widget;
        }

        public LayoutEventType Type { get; private set; }
        public Widget Widget { get; private set; }
    }

    public delegate void LayoutEventHandler(object sender, LayoutEventArgs e);

    public abstract class Layout : Widget
    {
        protected List<Widget> mChildren;

        public Layout()
        {
            mChildren = new List<Widget>();
            Focusable = false;
        }

        public event LayoutEventHandler TreeChanged;

        public void Add(Widget widget)
        {
            mChildren.Add(widget);
            Update();

            if (TreeChanged != null)
                TreeChanged(this, new LayoutEventArgs(LayoutEventType.Add, widget));
        }

        public void Remove(Widget widget)
        {
            mChildren.Remove(widget);
            Update();

            if (TreeChanged != null)
                TreeChanged(this, new LayoutEventArgs(LayoutEventType.Remove, widget));
        }

        public WidgetMap GetChildren()
        {
            if (mChildren.Count == 0) return null;

            var wl = new WidgetMap();
            foreach (var child in mChildren)
            {
                wl.Add(child);

                var layout = child as Layout;
                if (layout != null)
                    wl.Append(layout.GetChildren());
            }

            return wl;
        }

        public abstract void Update();

        public override void Draw()
        {
            foreach (var child in mChildren)
                child.Draw();
        }
    }
}
