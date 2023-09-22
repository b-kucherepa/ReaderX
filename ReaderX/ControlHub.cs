namespace ReaderX
{
    internal static class ControlHub
    {
        //
        internal static List<string> LoadImageList() => ImageLoader.ListImagesInFolder();

        internal static Image LoadSelectedImage(string fileName) => ImageLoader.LoadImage(fileName);

        internal static string LoadText() => TextLoader.LoadText();

        internal static Font SelectFont() => TextLoader.SelectFont();

        internal static Color SelectColor() => TextLoader.SelectColor();

        internal static Locale GetLocale() => LocaleManager.GetLocale();

        internal static void Exit() => Program.Exit();
    }
}
