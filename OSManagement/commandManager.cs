using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using Cosmos.System.Graphics;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Text;
using Zypherix;
using Zypherix.OSManagement;
using Sys = Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.Core.IOGroup;
using System.Runtime.CompilerServices;
using Cosmos.Core;
using Microsoft.VisualBasic;
using System.Threading;

namespace Zypherix
{
    public class commandManager
    {
        public commandManager(string command)
        {
            if (command.Contains("cat "))
            {
                try
                {
                    Console.WriteLine(File.ReadAllText(command.Replace("cat ", Kernel.currentDirectory)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! " + ex.ToString());
                }
            }
            else if (command.Contains("ls"))
            {
                var lsArgs = command.Replace("ls ", "");
                if (lsArgs.Contains("--help") || lsArgs.Contains("-h"))
                {
                    Console.WriteLine("This lists the directory!");
                }
                else
                {
                    if (Directory.Exists(lsArgs))
                    {
                        Console.Write("Pattern :");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Folders");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(", ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Files");

                        Console.WriteLine(Directory.GetFiles(lsArgs));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Directory.GetDirectories(lsArgs));
                    }
                    else
                    {
                        Console.Write("Pattern :");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Folders");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(", ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Files");

                        foreach (var file in Directory.GetFiles(Kernel.currentDirectory))
                        {
                            Console.WriteLine(Path.GetFileName(file) + " ");
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (var dir in Directory.GetDirectories(Kernel.currentDirectory))
                        {
                            Console.WriteLine(Path.GetFileName(dir) + " ");
                        }
                    }
                }
            }
            else if (command.Contains("touch ") || command.Contains("spill ") || command.Contains("mkdir ") || command.Contains("rmdir ") || command.Contains("cp ") || command.Contains("mv "))
            {
                fileManagement.manager(command);
            }
            else if (command.StartsWith("pedit "))
            {
                pedit.StartPedit(command.Replace("pedit ", Kernel.currentDirectory));
            }
            else if (command == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            else if (command == "shutdown -r")
            {
                Sys.Power.Reboot();
            }
            else if (command.ToLower() == "zypherix-desktop-environment" || command.ToLower() == "zypherix-desktop" || command.ToLower() == "zypherix-env")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("About to load ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Zypherix Desktop");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" environment!");
                Console.ResetColor();
                Console.Write("Are you sure? (");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("y");
                Console.ResetColor();
                Console.Write("/");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("n");
                Console.ResetColor();
                Console.Write("): ");

                var response = Console.ReadKey();
                if (response.Key == ConsoleKey.N)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\bn");
                }
                else if (response.Key == ConsoleKey.Y)
                {
                    gui summonGUI = new gui();
                    if (summonGUI.closeGUI == true)
                    {
                        Sys.Power.Reboot();
                    }
                }
            }
            else if (command.ToLower() == "clear")
            {
                Console.Clear();
            }   
        }
    }
}