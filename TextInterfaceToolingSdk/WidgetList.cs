using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class WidgetMap : List<Widget>
    {
        public Widget this[string id]
        {
            get
            {
                int i = GetIndex(id);
                return (i == -1) ? null : this[i];
            }
        }

        private int GetIndex(string id)
        {
            for (int i = 0; i < this.Count; i++)
                if (this[i].Identifier == id)
                    return i;

            return -1;
        }

        public int GetNextFocusable(int from = 0)
        {
            for(int i = from + 1; i < Count; i++)
                if (this[i].Focusable)
                    return i;
            for (int i = 0; i < from; i++)
                if (this[i].Focusable)
                    return i;

            return -1;
        }

        public void Append(WidgetMap widgets)
        {
            if (widgets == null || widgets.Count == 0) return;

            foreach (var widget in widgets)
                if (!Contains(widget))
                    Add(widget);
        }
    }
}
