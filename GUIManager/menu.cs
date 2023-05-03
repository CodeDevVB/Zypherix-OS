using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zypherix.OSManagement;
using Sys = Cosmos.System;

namespace Zypherix.GUIManager
{
    internal class menu
    {
        public menu() {
            Kernel.canvas.DrawFilledRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Sys.Graphics.Point(10, 100), 550, 450);
            Kernel.canvas.DrawString("ZyperiX1 (Zypherix X Window Manager 1)", PCScreenFont.Default, new Pen(Color.White), new Sys.Graphics.Point(15,110));

            //shutdown button
            Kernel.canvas.DrawFilledRectangle(new Pen(Color.FromArgb(45,45,45)), new Sys.Graphics.Point(15, 150), 70, 30);
            Kernel.canvas.DrawString("Shutdown", PCScreenFont.Default, new Pen(Color.White), new Sys.Graphics.Point(17, 155));
            if (Sys.MouseManager.X <= 15 && Sys.MouseManager.Y <= 120 && Sys.MouseManager.X >= 65 && Sys.MouseManager.Y >= 150)
            {
                if (Sys.MouseManager.MouseState == Sys.MouseState.Left && new gui().menuOpen == true)
                {
                    Sys.Power.Shutdown();
                }
            }

            Kernel.canvas.Display();
        }
    }
}
