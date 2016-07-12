using System;
namespace TextInterfaceToolingSdk
{
	public static class Tits
	{
		// @todo: add mutable state
		// @todo: enable/disable side effect mode

		public static void Move(int x, int y)
		{
			Console.SetCursorPosition(x, y);
		}

		public static void WriteAt(string content, int x, int y)
		{
			Move(x, y);
			Console.Write(content);
		}

		public static void ClearRect(int x1, int y1, int x2, int y2)
		{
			// @fixme : check react orientation

			for (int y = y1; y <= y2 && y < Console.BufferHeight; y++)
			{
				Console.SetCursorPosition(x1, y);
				for (int x = x1; x <= x2 && x < Console.BufferWidth; x++)
				{
					Console.Write(' ');
				}
				Console.Write('\n');
			}
		}

		// Cursor Visibility

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
	}
}

