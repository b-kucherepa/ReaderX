using System.Globalization;
using System.Xml.Serialization;


namespace ReaderX
{
    /// <summary>
    ///  Contains a group of methods using XML serialization to recover localized text
    ///  from files. The correspinding XML files pre-exist already in the project.
    /// </summary>
    /// <remarks>
    ///  NB! FindSystemLocale method cuts the second region-specific part of a locale code.
    ///  It was made for better locales compability. Be careful if you want to use specialized
    ///  region-specific locale files, don't forget to remove that "plug".
    ///</remarks>
    internal static class LocaleManager
    {
        private const string DEFAULT_LANGUAGE = "en";
        private static readonly string LOCALES_FOLDER_PATH 
            = Environment.CurrentDirectory + "\\Resources\\Locales\\";
        private static readonly XmlSerializer _serializer = new(typeof(Locale));


        /// <summary>
        /// Retrieves authomatically the best Locale in the current application enviroment
        /// </summary>
        /// <returns>The appropriate Locale</returns>
        internal static Locale GetLocale()
        {
            List<Locale> localeList = LoadFiles();
            Locale locale = FindSystemLocale(localeList);
            return locale;
        }


        /// <summary>
        /// Opens the application directory containing locales and returns the list of locales found
        /// </summary>
        /// <returns>List of found Locales</returns>
        private static List<Locale> LoadFiles()
        {
            string[] filePaths = Directory.GetFiles(LOCALES_FOLDER_PATH);

            List<Locale>? localeList = new();

            //this loop iterates through the found file list and adds them into Locales list 
            for (int i = 0; i < filePaths.Length; i++)
            {
                Locale loadedLocale = LoadLocaleFile(filePaths[i]);
                localeList.Add(loadedLocale);
            }

            //if no locales found, creates an empty default locale
            if (localeList.Count == 0)
            {
                localeList.Add(new Locale());
            }

            return localeList;
        }


        /// <summary>
        /// Loads one locale file from the path and returns it as a Locale struct:
        /// </summary>
        /// <param name="path">a full Locale file path</param>
        /// <returns>A Locale loaded from the file</returns>
        private static Locale LoadLocaleFile(string path)
        {
            Locale? locale = new Locale();
            using (FileStream fileStream = new(path, FileMode.OpenOrCreate))
            {
                if (fileStream.Position > 0)
                {
                    fileStream.Position = 0;
                }

                try
                {
                    locale = _serializer.Deserialize(fileStream) as Locale?;
                }
                catch
                {
                    //leaves the default constructor-built locale
                }
            }

            return (Locale)locale;
        }


        /// <summary>
        /// Tries to find the locale appropriate for the current system locale settings: 
        /// </summary>
        /// <param name="languagesList">a list of Locales to find from</param>
        /// <returns>A system-correspinding Locale, an English locale or just the first one in list</returns>
        private static Locale FindSystemLocale(List<Locale> languagesList)
        {
            //gets the system locale ignoring region specifics
            //(*see NB! in the class description)
            string systemLocaleName = CultureInfo.InstalledUICulture.Name.Remove(2, 3);

            //tries to find relevant locale in the list
            Locale? locale = languagesList.Find(item 
                => item.localeCode.Contains(systemLocaleName));

            //if failed, searches for the default language locale
            locale ??= languagesList.Find(item => item.localeCode.Contains(DEFAULT_LANGUAGE));

            //else takes first locale in the list
            locale ??= languagesList[0];

            return (Locale)locale;
        }
    }
}
