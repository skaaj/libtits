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

        public Box()
        {
            mOuterBounds = new Rect();
        }

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

        public void SetPosition(int x, int y)
        {
            mOuterBounds.Left = x;
            mOuterBounds.Top = y;
        }

        public void SetSize(int w, int h)
        {
            mOuterBounds.Width = w;
            mOuterBounds.Height = h;
        }

        public void SetGeometry(int x, int y, int w, int h)
        {
            SetPosition(x, y);
            SetSize(w, h);
        }

        public override string ToString()
        {
            return string.Format("Box ({1}, {2}, {3}, {4})", Left, Top, Width, Height);
        }
    }
}
