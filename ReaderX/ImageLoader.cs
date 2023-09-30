namespace ReaderX
{

    /// <summary>
    /// Contains a group of methods for loading an image file list from a folder
    /// and for loading an image from the file folder.
    /// </summary>
    internal static class ImageLoader
    {
        private const string DEFAULT_IMAGE_NAME = "default.png";
        private static readonly string DEFAULT_IMAGE_DIRECTORY = Environment.CurrentDirectory.ToString() + "\\Resources\\Backgrounds\\";
        private static readonly string[] SUPPORTED_IMAGE_FORMATS = new string[] {
            ".bmp",
            ".gif",
            ".png",
            ".jpg",
            ".jpeg",
            ".tiff",
            ".exif"
        };

        private static string _last_directory = DEFAULT_IMAGE_DIRECTORY;


        /// <summary>
        /// Begins the folder selecting system dialogue to list all the files in a folder
        /// </summary>
        /// <returns>List of image paths</returns>
        internal static List<string> ListImagesInFolder()
        {
            //initializes the folder selecting system dialogue
            using (FolderBrowserDialog folderDialog = new())
            {
                folderDialog.InitialDirectory = _last_directory;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _last_directory = folderDialog.SelectedPath + "\\";
                }
            }

            string[] fileArray = Directory.GetFiles(_last_directory);
            List<string> _imageList = FilterSupportedFiles(fileArray);

            //if no images found, returns the List containing only default background
            if (_imageList.Count < 0)
            {
                _imageList.Add(DEFAULT_IMAGE_DIRECTORY + DEFAULT_IMAGE_NAME);
            }

            return _imageList;
        }


        /// <summary>
        /// Filters the file list returning only supportable image files
        /// </summary>
        /// <param name="fileArray">a String[] array to be purged</param>
        /// <returns>List of supportable image paths</returns>
        private static List<string> FilterSupportedFiles(string[] fileArray)
        {
            List<string> filteredList = new();

            //interates through the files
            foreach (string filePath in fileArray)
            {
                //checks every format from the supported formats list...
                foreach (string format in SUPPORTED_IMAGE_FORMATS)
                {
                    bool isSupported = filePath.EndsWith(format, true, null);
                    //...and if it's of one of supported formats, finishes the subloop
                    if (isSupported)
                    {
                        filteredList.Add(filePath);
                        break;
                    }
                }         
            }

            return filteredList;
        }


        /// <summary>
        /// Loads an Image file
        /// </summary>
        /// <param name="fileName">the name of an image file to be loaded</param>
        /// <returns>The loaded Image file or default image</returns>
        internal static Image LoadImage(string fileName)
        {
            Image image;
            try
            {
                image = Image.FromFile(_last_directory + fileName, false);
            }
            catch
            {
                image = Image.FromFile(DEFAULT_IMAGE_DIRECTORY + DEFAULT_IMAGE_NAME);
            }
            return image;
        }
    }
}
