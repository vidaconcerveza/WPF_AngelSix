using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default Constructor
        /// </summary>

        #region        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get Every logical drive on the machine
            foreach(var drive in Directory.GetLogicalDrives())
            {
                //Create a new item for it
                var item = new TreeViewItem()
                {
                    //SEt the header and path
                    Header = drive,
                    //full path
                    Tag = drive
                };

                // add dummy item
                item.Items.Add(null);
                item.Expanded += Folder_Expanded;
                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            // If the item only contains the dummy data..
            if(item.Items.Count !=1 || item.Items[0]!=null)
            {
                return;
            }

            //Crear Dummy Data
            item.Items.Clear();

            //get folder name
            var fullPath = (string)item.Tag;

            // Create a blank list for directories
            var directories = new List<string>();

            //Try and get directories from the folder
            // ignoring and issues doing so.
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch
            {

            }

            directories.ForEach(directoryPath =>
            {
                //Create Directory Item
                var subItem = new TreeViewItem()
                {
                    // Set Header as folder name
                    Header = GetFileFolderName(directoryPath),
                    // And tag as full path
                    Tag = directoryPath

                };

                //WpfTreeView.HeaderToImageConverter.Instace;

                subItem.Items.Add(null);

                // Handle Expanding.
                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });


            //Items - files
            // Create a blank list for files
            var files = new List<string>();

            //Try and get files from the folder
            // ignoring and issues doing so.
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch
            {

            }

            files.ForEach(filePath =>
            {
                //Create Directory Item
                var subItem = new TreeViewItem()
                {
                    // Set Header as folder name
                    Header = GetFileFolderName(filePath),
                    // And tag as full path
                    Tag = filePath

                };
                item.Items.Add(subItem);
            });
        }
        #endregion

        public static string GetFileFolderName(string path)
        {
            // C:\Something\a folder
            // C:\Something\a file.png
            if(string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            //Make all slashed back slackes
            var normalizedPath = path.Replace('/','\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //If we don;t find a backslash, return the path itself
            if(lastIndex<=0)
            {
                return path;
            }

            //return the name after the last bask slash
            return path.Substring(lastIndex + 1);


        }
    }
}
