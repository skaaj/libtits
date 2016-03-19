using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class Text : Widget
    {
        public string Content { get; set; }

        public Text(string content)
        {
            Content = content;
        }

        public override void Draw()
        {
            Console.Write(Content);
        }
    }
}
