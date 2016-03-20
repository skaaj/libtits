using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextInterfaceToolingSdk
{
    public class Window
    {
        private static Window mInstance;
        public static Window Instance
        {
            get
            {
                if(mInstance == null)
                    mInstance = new Window(100, 50);

                return mInstance;
            }
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public Layout Root { get; set; }

        private Thread mEventThread;

        public Window(int width = 80, int height = 45)
        {
            Width = width;
            Height = height;

            Root = new LinearLayout();

            mEventThread = new Thread(new ThreadStart(ListenToKeyboard));
            mEventThread.Start();

            Refresh();
        }

        public string Title
        {
            get { return Console.Title; }
            set { Console.Title = value; }
        }

        public void Refresh()
        {
            Console.WindowWidth = Width;
            Console.WindowHeight = Height;

            Console.BufferWidth = Width;
            Console.BufferHeight = Height;

            Root.Draw();
        }

        public void ListenToKeyboard()
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if ((keyInfo.Modifiers & ConsoleModifiers.Alt) != 0 && keyInfo.Key == ConsoleKey.F1)
                    exit = true;
                else
                    OnKeyPressed(keyInfo);
            }
        }

        public void OnKeyPressed(ConsoleKeyInfo keyInfo)
        {
            // Insert event processing code here
        }
    }
}
