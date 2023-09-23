namespace ReaderX
{
    internal class ImageFileList
    {

        internal List<string> Files 
        { get => _imageNames; private set => _imageNames = value; }

        internal string Folder 
        { get => _folderPath; private set => _folderPath = value; }

        internal int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                int lastIndex = _imageNames.Count - 1;

                if (lastIndex <= 0)
                {
                    value = 0;
                }
                else
                {
                    //removes excessive overflow
                    value %= lastIndex;

                    if (value < 0)
                        value += lastIndex;
                }

                _selectedIndex = value;
                SelectedImage = ImageLoader.LoadImage(Folder + SelectedFile);
            }
        }

        internal string SelectedFile { get => _imageNames[_selectedIndex]; }

        internal Image SelectedImage 
        { get => _selectedImage; private set => _selectedImage = value; }

        private string _folderPath;
        private List<string> _imageNames;
        private int _selectedIndex;
        private Image _selectedImage;

        public ImageFileList(List<string> fileNameList, string folderPath = "")
        {
            _imageNames = fileNameList;
            _folderPath = folderPath;
            _selectedIndex = 0;
            _selectedImage = ImageLoader.LoadImage(Folder+SelectedFile);
        }
    }
}
