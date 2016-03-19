using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public abstract class Layout : Widget
    {
        protected List<Widget> mChildren;

        public Layout()
        {
            mChildren = new List<Widget>();
        }

        public void Add(Widget widget)
        {
            mChildren.Add(widget);
        }

        public void Remove(Widget widget)
        {
            mChildren.Remove(widget);
        }
    }
}
