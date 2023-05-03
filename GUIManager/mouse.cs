using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sys = Cosmos.System;


namespace Zypherix.GUIManager
{
    internal class mouse
    {
        public mouse(int mouseState, Pen pen, bool menuOpen, uint mousePosX, uint mousePosY)
        {
            
            //hover management
            if (Sys.MouseManager.X >= 10 && Sys.MouseManager.Y >= 560 && Sys.MouseManager.X <= 60 && Sys.MouseManager.Y <= 590)
            {
                mouseState = 1;
            }
            else
            {
                mouseState = 0;
            }

            //click management
            if (Sys.MouseManager.X >= 10 && Sys.MouseManager.Y >= 560 && Sys.MouseManager.X <= 60 && Sys.MouseManager.Y <= 590 && Sys.MouseManager.MouseState == Sys.MouseState.Left)
            {
                mouseState = 2;
            }

            Pen alicePen = new Pen(Color.Blue);

            //mouseState for more 2 and above
            // 2 = menu
            // 3 = (next app)

            //mouse shape manager
            if (mouseState == 0)
            {
                Kernel.canvas.DrawFilledEllipse(pen, new Sys.Graphics.Point((int)Sys.MouseManager.X, (int)Sys.MouseManager.Y), 5, 5);
            }
            else if (mouseState == 1)
            {
                Kernel.canvas.DrawFilledEllipse(alicePen, new Sys.Graphics.Point((int)Sys.MouseManager.X, (int)Sys.MouseManager.Y), 5, 5);
            }
            else if (mouseState == 2)
            {
                menuOpen = !menuOpen;
            }

            if (mousePosX != Sys.MouseManager.X && mousePosY != Sys.MouseManager.Y)
            {
                mousePosX = Sys.MouseManager.X;
                mousePosY = Sys.MouseManager.Y;
                Kernel.canvas.DrawFilledEllipse(pen, new Sys.Graphics.Point((int)Sys.MouseManager.X, (int)Sys.MouseManager.Y), 5, 5);
            }
        }
    }
}
