namespace ReaderX
{
    /// <summary>
    /// Contains a group of methods for loading text and picking its font and color.
    /// </summary>
    internal static class TextManager
    {
        private static readonly string DEFAULT_FILE_PATH
            = Environment.CurrentDirectory.ToString() + "\\Resources\\Texts\\default.txt";
        private const string FILE_TYPES_FILTER
            = "Text file (*.txt) | *.TXT; | All files (*.*) | *.*";

        private static string _last_file_path = DEFAULT_FILE_PATH;
        private static Font _last_font = new("Verdana", 16);
        private static Color _last_color = Color.IndianRed;


        /// <summary>
        /// Begins a system "open file" dialogue and loads the file
        /// </summary>
        /// <returns>String containing the text</returns>
        internal static string LoadText()
        {
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_last_file_path);
                openFileDialog.Filter = FILE_TYPES_FILTER;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _last_file_path = openFileDialog.FileName??DEFAULT_FILE_PATH;
                    try
                    {
                        return File.ReadAllText(_last_file_path);
                    }
                    catch
                    {
                        return "CAN'T LOAD THE FILE";
                    }
                }
                else
                {
                    return File.ReadAllText(_last_file_path);
                }
            }
        }


        /// <summary>
        /// Begins a system "select font" dialogue returning the selected font
        /// </summary>
        /// <returns>The selected Font</returns>
        internal static Font SelectFont()
        {
            using (FontDialog fontDialog = new())
            {
                fontDialog.Font = _last_font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    _last_font = fontDialog.Font;
                }
            }
            return _last_font;
        }


        /// <summary>
        /// Begins a system "select color" dialogue returning the selected color
        /// </summary>
        /// <returns>The selected Color</returns>
        internal static Color SelectColor()
        {
            using (ColorDialog colorDialog = new())
            {
                colorDialog.Color = _last_color;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _last_color = colorDialog.Color;
                }
            }
            return _last_color;
        }
    }
}
