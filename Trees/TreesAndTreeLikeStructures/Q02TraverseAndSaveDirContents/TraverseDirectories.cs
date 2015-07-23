using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Q02TraverseAndSaveDirContents
{
    class TraverseDirectories
    {
        public static float CalculateFolderSize(string folder)
        {
            float folderSize = 0.0f;
            try
            {
                //Checks if the path is valid or not
                if (!Directory.Exists(folder))
                    return folderSize;
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            FileInfo finfo = new FileInfo(file);
                            folderSize += finfo.Length;
                        }

                        foreach (string dir in Directory.GetDirectories(folder))
                            folderSize += CalculateFolderSize(dir);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return folderSize;
        }

        public static void TraverseDir(Folder folder, string startpath, string spaces = "")
        {
            string path = startpath + "\\" + folder.Name;
            DirectoryInfo dir = new DirectoryInfo(path);
            folder.Files = dir.GetFiles().Select(f => new File() { Name = f.Name, Size = f.Length }).ToArray();
            folder.ChildFolders = dir.GetDirectories().Select(d => new Folder() { Name = d.Name }).ToArray();
            Console.WriteLine(spaces + "==============================");
            Console.WriteLine(spaces + "-> Folder name: " + folder.Name);
            Console.WriteLine(spaces + "-> Path: " + path);
            Console.WriteLine(spaces + "-> Size: " + CalculateFolderSize(path) + " bytes");
            Console.WriteLine(spaces + "==============================");
            foreach (var file in folder.Files)
            {
                Console.WriteLine(spaces + "||=>" + file.Name + " " + file.Size + " bytes");
            }
            foreach (var childFolder in folder.ChildFolders)
            {
                TraverseDir(childFolder, path, spaces + " ");
            }
        }

        static void Main()
        {
            //Note this will work only if visual studio has the necessary permissions to open the directories
            //Alternatively test it in another folder
            //Do not foreget to include escapes in the startpath (i.e. C:\\Program Files)
            Folder startFolder = new Folder() { Name = "Windows" };
            TraverseDir(folder: startFolder, startpath: "C:");
        }
    }
}
