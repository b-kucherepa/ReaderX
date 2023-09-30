/*********************************************************************************************
 * A record structure which contains loaded locale strings.
 * Its constructor used in case if locale loading failed.
 * For more information check "LocaleManager" class.
*********************************************************************************************/

namespace ReaderX
{
    public record struct Locale
    {
        public string languageName;             //the human readable language name

        public string localeCode;               //the xx-XX format code

        public string buttonLoadText;           //GUI elements...
        public string buttonFont;
        public string buttonColor;

        public string buttonLoadImages;

        public string checkBoxSlideshow;
        public string secondsLabel;
        public string checkBoxRandomStep;

        public string checkBoxHideText;
        public string checkBoxHideGUI;

        public string buttonHelp;
        public string buttonExit;

        public string tips;                     //help window tips and hotkeys descriptions...
        public string hotkeys;
        public string hotkeyLabelTextControl;
        public string hotkeyLoadText;
        public string hotkeyFont;
        public string hotkeyColor;
        public string hotkeyScrollUp;
        public string hotkeyScrollDown;
        public string hotkeyLabelImageControl;
        public string hotkeyLoadImages;
        public string hotkeySelectNextImage;
        public string hotkeySelectPreviousImage;
        public string hotkeyLabelSlideshowControl;
        public string hotkeySlideshow;
        public string hotkeySlideshowRandom;
        public string hotkeyLabelHideElements;
        public string hotkeyHideGUI;
        public string hotkeyHideText;
        public string hotkeyHelp;
        public string hotkeyExit;


        public Locale()
        {
            languageName = "Default";

            localeCode = "";

            buttonLoadText = "OPEN_TEXT";
            buttonFont = "SELECT_FONT";
            buttonColor = "SELECT_COLOR";

            buttonLoadImages = "LOAD_IMAGE_LIST";

            checkBoxSlideshow = "ENABLE_SLIDESHOW";
            secondsLabel = "seconds";
            checkBoxRandomStep = "RANDOM_SLIDESHOW";

            checkBoxHideText = "HIDE_TEXT";
            checkBoxHideGUI = "HIDE_GUI";

            buttonHelp = "HELP";
            buttonExit = "EXIT";

            tips = "ERROR: LOCALIZATION LOADING HAVE BEEN FAILED";
            hotkeys = "OR NO LOCALIZATIONS FOUND";
            hotkeyLabelTextControl = "";
            hotkeyLoadText = "";
            hotkeyFont = "";
            hotkeyColor = "";
            hotkeyScrollUp = "";
            hotkeyScrollDown = "";
            hotkeyLabelImageControl = "";
            hotkeyLoadImages = "";
            hotkeySelectNextImage = "";
            hotkeySelectPreviousImage = "";
            hotkeyLabelSlideshowControl = "";
            hotkeySlideshow = "";
            hotkeySlideshowRandom = "";
            hotkeyLabelHideElements = "";
            hotkeyHideGUI = "";
            hotkeyHideText = "";
            hotkeyHelp = "";
            hotkeyExit = "";
        }
    }
}
