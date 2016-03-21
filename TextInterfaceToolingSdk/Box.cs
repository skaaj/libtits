using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class Box
    {
        private Rect mOuterBounds;

        public int Width
        {
            get { return mOuterBounds.Width; }
            set { mOuterBounds.Width = value; }
        }

        public int Height
        {
            get { return mOuterBounds.Height; }
            set { mOuterBounds.Height = value; }
        }

        public int Left
        {
            get { return mOuterBounds.Left; }
            set { mOuterBounds.Left = value; }
        }

        public int Right
        {
            get { return mOuterBounds.Left + mOuterBounds.Width; }
        }

        public int Top
        {
            get { return mOuterBounds.Top; }
            set { mOuterBounds.Top = value;  }
        }

        public int Bottom
        {
            get { return mOuterBounds.Top + mOuterBounds.Height; }
        }

        public int PaddingLeft { get; set; }
        public int PaddingTop { get; set; }
        public int PaddingRight { get; set; }
        public int PaddingBottom { get; set; }

        public Rect InnerBounds
        {
            get
            {
                return new Rect(
                    mOuterBounds.Left + PaddingLeft,
                    mOuterBounds.Top + PaddingTop,
                    mOuterBounds.Width - PaddingLeft - PaddingRight,
                    mOuterBounds.Height - PaddingTop - PaddingBottom
                    );
            }
        }
    }
}
