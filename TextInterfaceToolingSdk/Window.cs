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
        // Singleton Instance
        private static Window mInstance;
        public static Window Instance
        {
            get
            {
                if(mInstance == null)
                    mInstance = new Window();

                return mInstance;
            }
        }

        // Layout
        public int Width { get; set; }
        public int Height { get; set; }
        private Layout mRootLayout;

        // Threading
        private Thread mEventThread;

        // Window
        public Window(int width = 80, int height = 45)
        {
            Width = width;
            Height = height;

            mRootLayout = new LinearLayout(LayoutOrientation.HORIZONTAL);

            mEventThread = new Thread(new ThreadStart(ListenToKeyboard));
            mEventThread.Start();

            UpdateWindowSize();
        }

        public string Title
        {
            get { return Console.Title; }
            set { Console.Title = value; }
        }

        public void UpdateWindowSize()
        {
            Console.WindowWidth = Width;
            Console.WindowHeight = Height;

            Console.BufferWidth = Width;
            Console.BufferHeight = Height;

            mRootLayout.SetGeometry(0, 0, Width, Height);
        }

        // Root layout
        public Layout RootLayout
        {
            set
            {
                mRootLayout = value;
                UpdateWindowSize();
            }
        }

        public void Add(Widget widget)
        {
            mRootLayout.Add(widget);
            Update();
        }

        public void Remove(Widget widget)
        {
            mRootLayout.Remove(widget);
            Update();
        }

        public void Update()
        {
            mRootLayout.Update();
        }

        public void Draw()
        {
            mRootLayout.Draw();
        }

        // Threading
        public void ListenToKeyboard()
        {
            bool exit = false;
            while (!exit)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if ((keyInfo.Modifiers & ConsoleModifiers.Alt) != 0 && keyInfo.Key == ConsoleKey.F4)
                    exit = true;
                else
                    OnKeyPressed(keyInfo);
            }
        }

        public void OnKeyPressed(ConsoleKeyInfo keyInfo)
        {
            // Insert event processing code here
            // dispatch to children
        }
    }
}
