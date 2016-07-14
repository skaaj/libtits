using System;
using System.Collections.Generic;
using System.Text;

namespace TextInterfaceToolingSdk
{
	public static class Tits
	{
		// @todo: add mutable state
		// @todo: enable/disable side effect mode

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
		public enum Overflow { HIDE, NEW_LINE, ELLIPSIS }
		private static Overflow _defaultOverflow = Overflow.HIDE;

		// ---- Text
		public static void WriteAt(string content, int x, int y)
		{
			Move(x, y);
			Console.Write(content);
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

