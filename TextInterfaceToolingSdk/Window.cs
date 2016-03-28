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
        // Window
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
        public string Title
        {
            get { return Console.Title; }
            set { Console.Title = value; }
        }

        // Root Layout
        private Layout mRootLayout;
        public int Width { get; set; }
        public int Height { get; set; }

        public Layout RootLayout
        {
            private get
            {
                return mRootLayout;
            }

            set
            {
                mRootLayout = value;

                Console.SetWindowSize(Width, Height);
                Console.SetBufferSize(Width, Height);

                mRootLayout.SetGeometry(0, 0, Width, Height);
            }
        }

        // Focus
        private List<Widget> mFocusables;
        private int mFocusedIndex;

        // Threading
        private Thread mEventThread;

        // Window
        public Window(int width = 80, int height = 45)
        {
            Width = width;
            Height = height;

            RootLayout = new LinearLayout(LayoutOrientation.HORIZONTAL);

            mFocusables = new List<Widget>();

            mEventThread = new Thread(new ThreadStart(ListenToKeyboard));
            mEventThread.Start();
        }

        public void Add(Widget widget)
        {
            RootLayout.Add(widget);
            RootLayout.Update();

            Subscribe(widget);
        }

        public void Remove(Widget widget)
        {
            RootLayout.Remove(widget);
            RootLayout.Update();

            // Unsubscribe
        }

        private void Draw()
        {
            if (mFocusables.Count > 0)
            {
                Console.SetCursorPosition(mFocusables[mFocusedIndex].Box.Left, mFocusables[mFocusedIndex].Box.Top);
            }
        }

        private void OnHierarchyChanged(object sender, LayoutEventArgs args)
        {
            if(args.Type == LayoutEventType.ADD)
            {
                Subscribe(args.Widget);

                if(args.Widget is Focusable)
                    mFocusables.Add(args.Widget);
            }

            Draw();
        }

        private bool Subscribe(Widget widget)
        {
            Layout layout = widget as Layout;
            if (layout != null)
            {
                layout.Changed += OnHierarchyChanged;
                return true;
            }

            return false;
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
            // handle focus
            if(keyInfo.Key == ConsoleKey.Tab)
            {
                mFocusedIndex = (mFocusedIndex + 1) % mFocusables.Count;
                Draw();
            }
            // dispatch to children
        }
    }
}
