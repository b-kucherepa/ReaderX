namespace ReaderX
{
    internal static class TextLoader
    {
        private static readonly string DEFAULT_FILE_PATH = Environment.CurrentDirectory.ToString() + "\\Resources\\Texts\\default.txt";
        private const string FILE_TYPES_FILTER = "Text file (*.txt) | *.TXT; | All files (*.*) | *.*";

        private static string _last_file_path = DEFAULT_FILE_PATH;
        private static Font _last_font = new("Verdana", 16);
        private static Color _last_color = Color.IndianRed;
        
        internal static string LoadText()
        {
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.InitialDirectory = _last_file_path;
                openFileDialog.Filter = FILE_TYPES_FILTER;

                string text;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _last_file_path = openFileDialog.FileName;
                    try
                    {
                        text = File.ReadAllText(openFileDialog.FileName);
                    }
                    catch
                    {
                        text = "CAN'T LOAD FILE";
                    }
                }
                else
                {
                    text = File.ReadAllText(_last_file_path);
                }

                return text;
            }
        }
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
