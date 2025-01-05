using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileTraversel
{
    internal class Program
    {
        static void Main()
        {
            string rootDirectory = @"C:\Users\T-Box";

            string[] fileExtensions = { ".png", ".old",".mp4" };

            string[] excludedDirectories = { "AppData", "Application Data" };

            var files = new List<string>();

            GetFiles(rootDirectory, fileExtensions, excludedDirectories, files);

            ProcessFiles(files.ToArray());

            Console.WriteLine("Press something to close the application. .");
            Console.ReadLine();
        }

        static void GetFiles(string directory, string[] fileExtensions, string[] excludedDirectories, List<string> files)
        {
            try
            {
                // Check if the current directory is in the excluded list
                if (!excludedDirectories.Any(excludedDirectory => directory.EndsWith(excludedDirectory, StringComparison.OrdinalIgnoreCase)))
                {
                    try
                    {
                        // Get all files in the current directory
                        foreach (string file in Directory.EnumerateFiles(directory, "*.*"))
                        {
                            // Check file extension
                            if (fileExtensions.Any(extension =>
                                file.EndsWith(extension, StringComparison.OrdinalIgnoreCase)))
                            {
                                files.Add(file);
                            }
                        }
                    }
                    
                    catch (Exception ex)
                    {
                    }

                    // Traverse subdirectories
                    try
                    {
                        foreach (string subdirectory in Directory.EnumerateDirectories(directory))
                        {
                            GetFiles(subdirectory, fileExtensions, excludedDirectories, files);
                        }
                    }
                    
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        static void ProcessFiles(string[] files)
        {
            foreach (string file in files)
            {
                Console.WriteLine($"Processing file: {file}");
            }
        }
    }
}
