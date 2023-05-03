using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using Zypherix;
using Sys = Cosmos.System;
using Cosmos.HAL;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;
using IL2CPU.API.Attribs;
using System.Reflection.Metadata;
using System.IO;
using System.Threading;
using Zypherix.OSManagement;

namespace Zypherix
{
    public class Kernel : Sys.Kernel
    {
        
        public static CosmosVFS vfs;
        public static Canvas canvas;
        public static string[] users;

        public static bool consoleMode = true;
        public static string currentUser = "none";

        protected override void BeforeRun()
        {
            vfs = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(vfs);

            try
            {
                users = File.ReadAllLines("users.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Users file not found!\n");
            }

            Console.Write("Welcome to ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Zypherix");
            Console.ResetColor();
            Console.Write("!\n");
            Console.WriteLine("\nSelect Mode:\n   [G] Graphical\n   [C] Console\n");
            
            ConsoleKeyInfo selection = new ConsoleKeyInfo();
            while (selection.Key == ConsoleKey.G || selection.Key == ConsoleKey.C)
            {
                Console.Write("Enter G or C: ");
                selection = Console.ReadKey();
            }
            if (selection.Key == ConsoleKey.C)
            {
                Console.Write("Username: ");
                var user = Console.ReadLine();
                foreach (string usr in users)
                {
                    if (usr == user)
                    {
                        if (usr == "root")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Enter password for root: ");
                            var pass = "";
                            while (pass == "")
                            {
                                pass = Console.ReadLine();
                            }
                            consoleMode = true;
                        }
                    }
                }
            } else if (selection.Key == ConsoleKey.G)
            {
                try
                {
                    File.ReadAllText("defaultgui.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Using default root user for GUI");
                    Thread.Sleep(2000);
                    consoleMode = false;
                }
            }
        }

        public static string currentDirectory = "0:\\";

        protected override void Run()
        {
            if (consoleMode == true)
            {
                if (currentUser == "root")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("root@Zypherix~");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(currentDirectory);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" # ");
                    Console.ResetColor();
                    var command = Console.ReadLine();
                    commandManager cmdMgr = new commandManager(command);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(currentUser + "@Zypherix~");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(currentDirectory);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" $ ");
                    Console.ResetColor();
                    var command = Console.ReadLine();
                    commandManager cmdMgr = new commandManager(command);
                }
            } else if (consoleMode == false)
            {
                gui GUI = new gui();
            }
        }
    }
}
