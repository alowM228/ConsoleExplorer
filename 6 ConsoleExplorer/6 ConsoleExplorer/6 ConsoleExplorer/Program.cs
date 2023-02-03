using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Diagnostics;
using System.IO;

namespace ConsoleExplorer
{
    class Program
    {
        private static string selectedFile;
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите диск:");
            var drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {drives[i].Name}");
            }

            int selectedDriveIndex = int.Parse(Console.ReadLine()) - 1;
            DriveInfo selectedDrive = drives[selectedDriveIndex];

            List<string> breadcrumb = new List<string> { selectedDrive.Name };
            string currentDirectory = selectedDrive.Name;


            while (true)
            {
                Console.WriteLine($"\n{String.Join(" > ", breadcrumb)}");
                Console.WriteLine($"Свободное место {selectedDrive.TotalFreeSpace / 1024 / 1024 / 1024} GB");
                Console.WriteLine("Папки и файлы:");
                var directories = Directory.GetDirectories(currentDirectory);
                var files = Directory.GetFiles(currentDirectory);
                int index = 1;
                foreach (var directory in directories)
                {
                    Console.WriteLine($"{index}. {Path.GetFileName(directory)} [Папка]");
                    index++;
                }

                foreach (var file in files)
                {
                    Console.WriteLine($"{index}. {Path.GetFileName(file)}");
                    index++;
                }

                Console.WriteLine("Введите номер элемента, который вы хотите открыть (или \"q\", чтобы выйти, \"b\", чтобы вернуться:");
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    break;
                }
                else if (input.ToLower() == "b")
                {
                    if (breadcrumb.Count > 1)
                    {
                        breadcrumb.RemoveAt(breadcrumb.Count - 1);
                        currentDirectory = String.Join(Path.DirectorySeparatorChar.ToString(), breadcrumb);
                    }
                }
                else
                {
                    int selectedIndex = int.Parse(input) - 1;
                    if (selectedIndex < directories.Length)
                    {
                        string selectedDirectory = directories[selectedIndex];
                        currentDirectory = selectedDirectory;
                        breadcrumb.Add(Path.GetFileName(selectedDirectory));
                    }
                    else if (selectedIndex < directories.Length + files.Length)
                    {
                        int fileIndex = selectedIndex - directories.Length;
                        selectedFile = files[fileIndex];
                        Console.WriteLine("Selected file: " + selectedFile);
                        try
                        {
                            Process.Start(selectedFile);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}