
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
/// <summary>
/// A Helper Class to query information about directories.
/// </summary>
namespace WpfTreeView
{
    class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrive()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            //Try and get directories from the folder
            // ignoring and issues doing so.
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir=>new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch
            {

            }


            //Try and get files from the folder
            // ignoring and issues doing so.
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(file=>new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch
            {

            }

            return items;   
    }


        public static string GetFileFolderName(string path)
        {


            // C:\Something\a folder
            // C:\Something\a file.png
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            //Make all slashed back slackes
            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //If we don;t find a backslash, return the path itself
            if (lastIndex <= 0)
            {
                return path;
            }

            //return the name after the last bask slash
            return path.Substring(lastIndex + 1);


        }
    }
}
