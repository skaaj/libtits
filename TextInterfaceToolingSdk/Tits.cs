using System;
using System.Collections.Generic;
using System.Text;

namespace TextInterfaceToolingSdk
{
	public static class Tits
	{
		// @todo: add mutable state
		// @todo: enable/disable side effect mode

        // Immutable Lock
        public static bool IsMutable { get; private set; }
        public static void SetMutable(bool isMutable)
        {
            IsMutable = isMutable;
        }

		// -----------------
		// Cursor
		// -----------------

		// ---- Position
		public static void Move(int x, int y)
		{
			Console.SetCursorPosition(x, y);
		}

		// ---- Visibility
		public static void Cursor(bool visibility)
		{
			Console.CursorVisible = visibility;
		}

		public static void HideCursor()
		{
			Cursor(false);
		}

		public static void ShowCursor()
		{
			Cursor(true);
		}

		// -----------------
		// Writing
		// -----------------

		// ---- State
		public enum Overflow { HIDE, ELLIPSIS }

        private static Overflow _overflowMode;
        public static Overflow OverflowMode {
            get
            {
                return _overflowMode;
            }
            set
            {
                if (IsMutable) _overflowMode = value;
            }
        }

		// ---- Text
		public static void WriteAt(string content, int x, int y)
		{
			Move(x, y);

            int overflow = (x + content.Length) - Console.BufferWidth;
            if (overflow > 0)
            {
                switch (OverflowMode)
                {
                    case Overflow.HIDE:
                        content = content.Substring(0, content.Length - overflow);
                        break;
                    case Overflow.ELLIPSIS:
                        content = content.Substring(0, content.Length - overflow);
                        if(content.Length > 3)
                        {
                            int startIndex = content.Length - 3;
                            content = content.Remove(startIndex, 3).Insert(startIndex, "...");
                        }
                        break;
                    default:
                        break;
                }
                
            }

			Console.Write(content);
		}

        public static void WriteAt(string content, Point pos)
        {
            WriteAt(content, pos.X, pos.Y);
        }

        public static void WriteIn(string content, Rect bounds)
        {
            List<string> lines = fitInRect(content, bounds);
            for (int i = 0; i < lines.Count; i++)
            {
                Move(bounds.Left, bounds.Top + i);
                Console.Write(lines[i]);
            }
        }

        private static List<string> fitInRect(string content, Rect bounds)
        {
            int width = bounds.Width;
            int remainingChars = content.Length;

            List<string> lines = new List<string>();

            int i = 0;
            while (remainingChars > width && i < bounds.Height)
            {
                lines.Add(content.Substring(i * width, width));

                remainingChars -= width;
                i++;
            }

            if (i < bounds.Height)
            {
                lines.Add(content.Substring(i * width));
            }
            else
            {
                if (OverflowMode == Overflow.ELLIPSIS)
                {
                    string lastLine = lines[lines.Count - 1];
                    if (lastLine.Length > 3)
                    {
                        int startIndex = lastLine.Length - 3;
                        lines[lines.Count - 1] = lastLine.Remove(startIndex, 3).Insert(startIndex, "...");
                    }
                }
            }

            return lines;
        }

        // ---- Shapes


        // ---- Clearing
        public static void ClearRect(int x1, int y1, int x2, int y2)
		{
			int xMin = Math.Min(x1, x2);
			int xMax = Math.Max(x1, x2);
			int yMin = Math.Min(y1, y2);
			int yMax = Math.Max(y1, y2);

			for (int y = yMin; y <= yMax && y < Console.BufferHeight; y++)
			{
				Console.SetCursorPosition(xMin, y);
				for (int x = xMin; x <= xMax && x < Console.BufferWidth; x++)
				{
					Console.Write(' ');
				}
				Console.Write('\n');
			}
		}

	}
}

