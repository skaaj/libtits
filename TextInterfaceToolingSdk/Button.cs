using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class Button : Widget
    {
        public Button(string content)
        {
            Content = content;
            Focusable = true;
        }

        public string Content { get; set; }

        public override void Draw()
        {
            Clear();

            Console.SetCursorPosition(Box.Left, Box.Top);
            Console.Write(Content);
        }
    }
}
