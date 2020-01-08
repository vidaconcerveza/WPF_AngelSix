
namespace WpfTreeView
{
    /// <summary>
    /// Information about a directory item such as a drive, a file or a folder
    /// </summary>
    class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }
        /// <summary>
        /// The name of this directory item.
        /// </summary>
        public string Name { get { return this.Type==DirectoryItemType.Drive?this.FullPath: DirectoryStructure.GetFileFolderName(this.FullPath); } }
    }
}
