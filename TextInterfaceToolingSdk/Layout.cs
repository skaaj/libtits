using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public enum LayoutEventType { ADD, REMOVE };
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

    public abstract class Layout : Widget
    {
        public delegate void LayoutEventHandler(object sender, LayoutEventArgs e);
        public event LayoutEventHandler Changed;

        protected List<Widget> mChildren;

        public Layout()
        {
            mChildren = new List<Widget>();
        }

        public void Add(Widget widget)
        {
            mChildren.Add(widget);
            Update();

            if (Changed != null)
                Changed(this, new LayoutEventArgs(LayoutEventType.ADD, widget));
        }

        public void Remove(Widget widget)
        {
            mChildren.Remove(widget);
            Update();

            if (Changed != null)
                Changed(this, new LayoutEventArgs(LayoutEventType.REMOVE, widget));
        }

        public abstract void Update();

        public override void Draw()
        {
            foreach (var child in mChildren)
            {
                child.Draw();
            }
        }
    }
}
