using System.Windows.Forms;

namespace ReaderX
{
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

        internal static List<string> ListImagesInFolder()
        {
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

            if (_imageList.Count < 0)
                _imageList.Add(DEFAULT_IMAGE_DIRECTORY + DEFAULT_IMAGE_NAME);

            return _imageList;
        }

        private static List<string> FilterSupportedFiles(string[] fileArray)
        {
            List<string> filteredList = new();

            foreach (string filePath in fileArray)
            {
                bool isSupported = false;

                foreach (string format in SUPPORTED_IMAGE_FORMATS)
                {
                    isSupported |= filePath.EndsWith(format, true, null);
                }

                if (isSupported)
                    filteredList.Add(filePath);
            }

            return filteredList;
        }

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
