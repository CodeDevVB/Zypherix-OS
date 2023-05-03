using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using Zypherix.GUIManager;
using Cosmos.System;

namespace Zypherix.OSManagement
{
    
    internal class gui
    {
        public bool menuOpen = false;

        public bool closeGUI = false;

        public int mouseState = 0;
        public Color penColorForMenu = Color.White;

        public uint mousePosX = Sys.MouseManager.X;
        public uint mousePosY = Sys.MouseManager.Y;

        public Pen pen = new Pen(Color.White);
        public Pen taskpen = new Pen(Color.FromArgb(40, 40, 40));
        public Pen starttaskpen = new Pen(Color.FromArgb(32, 32, 32));

        public gui()
        {
            Sys.MouseManager.ScreenWidth = 800;
            Sys.MouseManager.ScreenHeight = 600;
            Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
            //Set the cursor to the middle of the screen
            Sys.MouseManager.X = 800 / 2;
            Sys.MouseManager.Y = 600 / 2;
            
            while (true)
            {

                Kernel.canvas.Clear(Color.FromArgb(23, 23, 23));
                
                var initialPosX = 0;
                var initialPosY = 0;
                Kernel.canvas.DrawString("Welcome to Zypherix Desktop!", PCScreenFont.Default, pen, new Sys.Graphics.Point(initialPosX + 10, initialPosY + 30)); initialPosX = initialPosX + 10; initialPosY = initialPosY + 30;
                Kernel.canvas.DrawFilledRectangle(taskpen, new Sys.Graphics.Point(0, 0), 800, 50);

                Kernel.canvas.DrawString($"{DateTime.UtcNow.Hour + ":" + DateTime.UtcNow.Minute}", PCScreenFont.Default, pen, new Sys.Graphics.Point(650, 20));
                Kernel.canvas.DrawString($"{DateTime.UtcNow.Day + "/" + DateTime.UtcNow.Month + "/" + DateTime.UtcNow.Year}", PCScreenFont.Default, pen, new Sys.Graphics.Point(645, 40));

                Kernel.canvas.DrawString("Press Super Key", PCScreenFont.Default, new Pen(penColorForMenu), new Sys.Graphics.Point(10, 10));


                KeyEvent super;
                bool winPress = KeyboardManager.TryReadKey(out super);
                if (winPress)
                {
                    if (super.Key == ConsoleKeyEx.LWin)
                    {
                        menuOpen = !menuOpen;
                    }
                    else if (super.Key == ConsoleKeyEx.Escape)
                    {
                        Kernel.canvas.Disable();
                        closeGUI = true;
                    }
                }

                if (menuOpen)
                {
                    var menu = new menu();
                }

                var mouse = new mouse(mouseState, pen, menuOpen, mousePosX, mousePosY);


                Kernel.canvas.Display();

                if (closeGUI)
                {
                    return;
                }
            }
        }
    }
}
