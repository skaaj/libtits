using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public abstract class Widget
    {
        public Frame Frame { get; set; }
        public abstract void Draw();
    }
}
