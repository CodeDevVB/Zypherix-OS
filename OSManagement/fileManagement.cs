using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Zypherix.OSManagement
{
    public class fileManagement
    {
        public static void manager(string command)
        {
            if (command.Contains("touch "))
            {
                try
                {
                    VFSManager.CreateFile(command.Replace("touch ", Kernel.currentDirectory));
                    Console.WriteLine("File named " + command.Replace("touch ", "") + " was created!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Entered command: " + command.Replace("touch ", Kernel.currentDirectory));
                    Console.WriteLine("ERROR! " + ex.ToString());
                }
            }
            else if (command.Contains("rm "))
            {
                try
                {
                    VFSManager.DeleteFile(command.Replace("spill ", Kernel.currentDirectory));
                    Console.WriteLine("File named " + command.Replace("spill ", "") + " was deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR!" + ex.ToString());
                }
            }
            else if (command.Contains("mkdir "))
            {
                try
                {
                    Sys.FileSystem.VFS.VFSManager.CreateDirectory(command.Replace("mkdir ", Kernel.currentDirectory));
                    Console.WriteLine("Created Directory!");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! " + ex.ToString());
                }
            }
            else if (command.Contains("rmdir "))
            {
                try
                {
                    Sys.FileSystem.VFS.VFSManager.DeleteDirectory(command.Replace("rmdir ", Kernel.currentDirectory), true);
                    Console.WriteLine("Removed directory!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! " + ex.ToString());
                }
            } else if (command.StartsWith("cp "))
            {
                var argarr = command.Split(' ');
                try
                {
                    File.Copy(Kernel.currentDirectory + argarr[1], Kernel.currentDirectory + argarr[2], Convert.ToBoolean(argarr[3]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! " + ex.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The parameters are-");
                    Console.WriteLine("'cp [copyFrom] [destination] [overwrite(true/false)]'");
                    Console.WriteLine("Make sure the overwrite is exactly \"true\" or \"false\"");
                }
            } else if (command.StartsWith("mv "))
            {
                var argarr = command.Split(' ');
                try
                {
                    File.Copy(Kernel.currentDirectory + argarr[1], Kernel.currentDirectory + argarr[2], true);
                    File.Delete(argarr[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! " + ex.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The parameters are-");
                    Console.WriteLine("'mv [copyFrom] [destination]'");
                }
            } else if (command.StartsWith("rename "))
            {
                var argarr = command.Split(' ');
                try
                {
                    File.Copy(Kernel.currentDirectory + argarr[1], Kernel.currentDirectory + argarr[1], true);
                    File.Delete(argarr[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR! " + ex.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The parameters are-");
                    Console.WriteLine("'rename [fileName]'");
                }
            }
        }
    }
}
