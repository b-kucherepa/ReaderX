using System.Globalization;
using System.Xml.Serialization;

namespace ReaderX
{
    internal static class LocaleManager
    {
        private readonly static string LOCALES_FOLDER_PATH = Environment.CurrentDirectory + "\\Resources\\Locales\\";

        private static readonly XmlSerializer _serializer = new(typeof(Locale));

        public static Locale GetLocale()
        {
            List<Locale> localeList = LoadFiles();
            Locale locale = FindSystemLocale(localeList);
            return locale;
        }

        private static List<Locale> LoadFiles()
        {
            string[] filePaths = Directory.GetFiles(LOCALES_FOLDER_PATH, "??-??.xml");
         
            List<Locale>? localeList = new();

            for (int i = 0; i < filePaths.Length; i++)
            {
                Locale? locale;
                using (FileStream fileStream = new(filePaths[i], FileMode.OpenOrCreate))
                {
                    if (fileStream.Position > 0)
                        fileStream.Position = 0;

                    try
                    {
                        locale = _serializer.Deserialize(fileStream) as Locale?;
                    }
                    catch
                    {
                        locale = null;
                    }

                    if (locale is not null)
                        localeList.Add((Locale)locale);
                }
            }

            if (localeList.Count == 0)
                localeList.Add(new Locale());

            return localeList;
        }

        private static Locale FindSystemLocale(List <Locale> languagesList)
        {
            string systemLocaleName = CultureInfo.InstalledUICulture.Name.Remove(2, 3);
            Locale? locale = languagesList.Find(item => item.localeCode.Contains(systemLocaleName));

            locale ??= languagesList.Find(item => item.localeCode.Contains("en-EN"));
            locale ??= languagesList[0];

            return (Locale)locale;
        }

        public static void SaveLocale(Locale locale, string filePath)
        {
            using (FileStream fileStream = new (filePath, FileMode.Create))
            {
                _serializer.Serialize(fileStream, locale);
            }
        }
    }
}
