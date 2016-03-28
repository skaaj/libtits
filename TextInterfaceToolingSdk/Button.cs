using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class Button : Widget, Focusable
    {
        public string Content { get; set; }

        public Button(string content)
        {
            Content = content;
        }

        public bool CatchFocus()
        {
            return true;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Box.Left, Box.Top);
            Console.Write(Content);
        }
    }
}
