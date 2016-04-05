using System;
using System.Collections.Generic;
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
        }

        public string Content { get; set; }

        public override void Draw()
        {
            Console.SetCursorPosition(Box.Left, Box.Top);
            Console.Write(Content);
        }
    }
}
