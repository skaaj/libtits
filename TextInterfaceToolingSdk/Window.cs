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
        public static Window GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new Window();
            }

            return mInstance;
        }

        public static Window GetInstance(string title, int width, int height)
        {
            if (mInstance == null)
            {
                mInstance = new Window(title, width, height);
            }
            else
            {
                mInstance.Title = title;
                mInstance.Width = width;
                mInstance.Height = height;
            }

            return mInstance;
        }

        public string Title
        {
            get { return Console.Title; }
            set { Console.Title = value; }
        }

        // Logic
        private WidgetList mWidgetsMap;

        // Root Layout
        private Layout mRootLayout;
        private int Width { get; set; }
        private int Height { get; set; }

        public Layout RootLayout
        {
            private get
            {
                return mRootLayout;
            }

            set
            {
                mRootLayout = value;
                mRootLayout.SetGeometry(0, 0, Width, Height);
                mRootLayout.TreeChanged += OnTreeChanged;

                Console.SetWindowSize(Width, Height);
                Console.SetBufferSize(Width, Height);
            }
        }

        // Threading
        private Thread mEventThread;

        // Window constructor
        public Window(string title = "Window", int width = 80, int height = 45)
        {
            Title = title;
            Width = width;
            Height = height;

            mWidgetsMap = new WidgetList();

            RootLayout = new LinearLayout(LayoutOrientation.HORIZONTAL);

            mEventThread = new Thread(new ThreadStart(ListenToKeyboard));
            mEventThread.Start();
        }

        public void Add(Widget widget)
        {
            RootLayout.Add(widget);
            UpdateMap(widget);
        }

        private void UpdateMap(Widget widget)
        {
            if(!mWidgetsMap.Contains(widget))
                mWidgetsMap.Add(widget);

            Layout layout = widget as Layout;
            if (layout != null)
            {
                // subscribe to any subtree modification
                layout.TreeChanged += OnTreeChanged;

                // concat its flattened widget tree to the lookup table
                mWidgetsMap.Append(layout.GetChildren());
            }
        }

        public void Remove(Widget widget)
        {
            // @todo : unsub and remove from widgets list
        }

        private void OnTreeChanged(object sender, LayoutEventArgs args)
        {
            if(args.Type == LayoutEventType.ADD)
            {
                UpdateMap(args.Widget);
            }
            else if(args.Type == LayoutEventType.REMOVE)
            {
                // @todo: unsub and remove from widgets list
            }
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
                // @todo : handle focus
            }

            // dispatch to children
        }
    }
}
