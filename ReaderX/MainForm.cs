using Timer = System.Windows.Forms.Timer;

namespace ReaderX
{
    /// <summary>
    /// The manually created part of MainForm file.
    /// </summary>
    /// <remarks>
    /// Currently contains main logic.
    /// The main logic should be incapsulated into an abstraction layer 
    /// in case the application will be cross-platform
    /// </remarks>
    public partial class MainForm : Form
    {
        private const int MSECONDS_IN_SECOND = 1000;

        private Timer _timer;
        private Random _random;

        private Control[] _hidableItemsList;

        private string _helpTips;

        internal MainForm()
        {
            InitializeComponent();
            this.Size = SystemInformation.PrimaryMonitorSize;
            textBox.MinimumSize = this.Size;
            textBox.MaximumSize = new Size(this.Width, 0);

            _hidableItemsList = new Control[]
            {
                buttonLoadText,
                buttonFont,
                buttonColor,
                buttonLoadImages,
                listBoxImages,
                verticalScrollBar,
                panelCheckboxes,
                checkBoxSlideshow,
                secondsLabel,
                checkBoxRandomStep,
                numericUpDownSlideshow,
                checkBoxHideText,
                buttonHelp,
                buttonExit
            };

            _timer = new Timer();
            _random = new Random();

            InitializeLocale();
            InitializeEventSubscriptions();
        }


        /// <summary>
        /// Sets MainForm elements text according to the most appropriate locale
        /// </summary>
        public void InitializeLocale()
        {
            Locale locale = LocaleManager.GetLocale();

            buttonLoadText.Text = locale.buttonLoadText ?? buttonLoadText.Text;
            buttonFont.Text = locale.buttonFont ?? buttonFont.Text;
            buttonColor.Text = locale.buttonColor ?? buttonColor.Text;

            buttonLoadImages.Text = locale.buttonLoadImages ?? buttonLoadImages.Text;
            checkBoxSlideshow.Text = locale.checkBoxSlideshow ?? checkBoxSlideshow.Text;
            secondsLabel.Text = locale.secondsLabel ?? secondsLabel.Text;
            checkBoxRandomStep.Text = locale.checkBoxRandomStep;

            checkBoxHideText.Text = locale.checkBoxHideText ?? checkBoxHideText.Text;
            checkBoxHideGUI.Text = locale.checkBoxHideGUI ?? checkBoxHideGUI.Text;

            buttonHelp.Text = locale.buttonHelp ?? buttonHelp.Text;

            buttonExit.Text = locale.buttonExit ?? buttonExit.Text;

            _helpTips =
                locale.tips +
                "\n\n" + locale.hotkeys +
                "\n\n" + locale.hotkeyLabelTextControl +
                "\n>T< - " + locale.buttonLoadText +
                "\n>F< - " + locale.buttonFont +
                "\n>C< - " + locale.buttonColor +
                "\n>W< - " + locale.hotkeyScrollUp +
                "\n>S< - " + locale.hotkeyScrollDown +
                "\n\n" + locale.hotkeyLabelImageControl +
                "\n>I< - " + locale.hotkeyLoadImages +
                "\n>D< - " + locale.hotkeySelectNextImage +
                "\n>A< - " + locale.hotkeySelectPreviousImage +
                "\n\n" + locale.hotkeyLabelSlideshowControl +
                "\n>E< - " + locale.hotkeySlideshow +
                "\n>R< - " + locale.checkBoxRandomStep +
                "\n\n" + locale.hotkeyLabelHideElements +
                "\n>X< - " + locale.hotkeyHideGUI +
                "\n>B< - " + locale.hotkeyHideText +
                "\n" +
                "\n>H< - " + locale.hotkeyHelp +
                "\n" +
                "\n>Escape< - " + locale.hotkeyExit;
        }


        private void InitializeEventSubscriptions()
        {
            this.KeyDown += OnHotkeyPressed;
            this.MouseWheel += OnMouseWheel;

            //text GUI events
            buttonLoadText.Click += OnLoadTextButtonClicked;
            buttonFont.Click += OnFontButtonClicked;
            buttonColor.Click += OnColorButtonClicked;
            verticalScrollBar.ValueChanged += OnVerticalScrolling;

            //images GUI events
            buttonLoadImages.Click += OnLoadImagesButtonClicked;
            listBoxImages.SelectedIndexChanged += OnImageInListSelected;

            //slideshow GUI events
            checkBoxSlideshow.CheckedChanged += OnSlideshowCheckedChanged;
            checkBoxSlideshow.CheckedChanged += OnSlideshowIntervalFieldChanged;
            numericUpDownSlideshow.ValueChanged += OnSlideshowIntervalFieldChanged;
            _timer.Tick += OnSlideshowTimerTick;

            //GUI hiding events
            checkBoxHideText.CheckedChanged += OnHideTextCheckedChanged;
            checkBoxHideGUI.CheckedChanged += OnHideGUICheckedChanged;

            //exit button events
            buttonHelp.Click += OnHelpButtonClicked;
            buttonExit.Click += OnExitButtonClick;
        }

        private void OnHotkeyPressed(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //text related buttons:
                case (Keys.T):
                    OnLoadTextButtonClicked(sender, e);
                    break;
                case (Keys.F):
                    OnFontButtonClicked(sender, e);
                    break;
                case (Keys.C):
                    OnColorButtonClicked(sender, e);
                    break;

                //vertical scrolling
                case (Keys.W):
                    ChangeScrollBarValueTo(-verticalScrollBar.LargeChange);
                    break;
                case (Keys.S):
                    ChangeScrollBarValueTo(verticalScrollBar.LargeChange);
                    break;

                //image loading button:
                case (Keys.I):
                    OnLoadImagesButtonClicked(sender, e);
                    break;

                //changing the selected image:
                case (Keys.D):
                    SwitchImageIndexAt(1);
                    break;
                case (Keys.A):
                    SwitchImageIndexAt(-1);
                    break;

                //slideshow checkers:
                case (Keys.E):
                    checkBoxSlideshow.Checked = !checkBoxSlideshow.Checked;
                    break;
                case (Keys.R):
                    checkBoxRandomStep.Checked = !checkBoxRandomStep.Checked;
                    break;

                //hiding checkers:
                case (Keys.X):
                    checkBoxHideGUI.Checked = !checkBoxHideGUI.Checked;
                    break;
                case (Keys.B):
                    checkBoxHideText.Checked = !checkBoxHideText.Checked;
                    break;

                //app closing:
                case (Keys.H):
                    OnHelpButtonClicked(sender, e);
                    break;
                case (Keys.Escape):
                    Program.Exit();
                    break;
            }
        }

        private void OnMouseWheel(object? sender, MouseEventArgs e)
        {
            ChangeScrollBarValueTo(-e.Delta);
        }


        private void OnLoadTextButtonClicked(object? sender, EventArgs e)
        {
            textBox.Text = TextManager.LoadText();

            UpdateScrollBar();

        }


        /// <summary>
        /// Updates scroll bar position and aligns text correspondingly if needed
        /// </summary>
        private void UpdateScrollBar()
        {
            int textBoxScrollLimit = this.Height - textBox.Height;

            if (textBox.Location.Y < textBoxScrollLimit)
                textBox.Location = new Point(textBox.Location.X, textBoxScrollLimit);

            verticalScrollBar.Maximum = -textBoxScrollLimit;

            verticalScrollBar.Value = Math.Min(verticalScrollBar.Value, verticalScrollBar.Maximum);

            if (verticalScrollBar.Maximum < verticalScrollBar.SmallChange)
                verticalScrollBar.Hide();
            else if (!checkBoxHideGUI.Checked)
                verticalScrollBar.Show();
        }

        private void OnFontButtonClicked(object? sender, EventArgs e)
        {
            textBox.Font = TextManager.SelectFont();
            UpdateScrollBar();
        }

        private void OnColorButtonClicked(object? sender, EventArgs e)
        {
            textBox.ForeColor = TextManager.SelectColor();
        }

        private void OnVerticalScrolling(object? sender, EventArgs e)
        {
            int newTextBoxPosition = (this.Height - textBox.Height) * verticalScrollBar.Value / verticalScrollBar.Maximum;
            textBox.Location = new Point(textBox.Location.X, newTextBoxPosition);
        }


        /// <summary>
        /// Adds a value to the current scroll bar position limiting the result safely
        /// </summary>
        /// <param name="step">a value to be added</param>
        private void ChangeScrollBarValueTo(int step)
        {
            int newScrollBarValue = verticalScrollBar.Value + step;

            if (newScrollBarValue < verticalScrollBar.Minimum)
                newScrollBarValue = verticalScrollBar.Minimum;
            else if (newScrollBarValue > verticalScrollBar.Maximum)
                newScrollBarValue = verticalScrollBar.Maximum;

            verticalScrollBar.Value = newScrollBarValue;
        }

        private void OnLoadImagesButtonClicked(object? sender, EventArgs e)
        {
            string[] imageArray = ImageLoader.ListImagesInFolder().ToArray();
            for (int i = 0; i < imageArray.Length; i++)
            {
                imageArray[i] = Path.GetFileName(imageArray[i]);
            }

            listBoxImages.Items.Clear();
            listBoxImages.Items.AddRange(imageArray);
            listBoxImages.SelectedIndex = 0;
        }

        private void OnImageInListSelected(object? sender, EventArgs e)
        {
            Image image = ImageLoader.LoadImage(listBoxImages.SelectedItem.ToString());
            BackgroundImage?.Dispose();
            BackgroundImage = image;
        }


        /// <summary>
        /// Adds a value to the current list box selected item index emulating 
        /// the looping scroll effect
        /// </summary>
        /// <param name="step">a value to be added</param>
        internal void SwitchImageIndexAt(int step)
        {
            int lastIndex = listBoxImages.Items.Count;
            int newIndex = listBoxImages.SelectedIndex + step;

            if (lastIndex <= 0)
                listBoxImages.SelectedIndex = 0;
            else if (newIndex < 0)
                newIndex += lastIndex;
            else if (newIndex >= lastIndex)
                newIndex -= lastIndex;

            listBoxImages.SelectedIndex = newIndex;
        }

        private void OnSlideshowCheckedChanged(object? sender, EventArgs e)
        {
            if (checkBoxSlideshow.Checked)
                _timer.Start();
            else
                _timer.Stop();
        }


        private void OnSlideshowIntervalFieldChanged(object? sender, EventArgs e)
        {
            _timer.Interval = (int)numericUpDownSlideshow.Value * MSECONDS_IN_SECOND;
        }


        internal void OnSlideshowTimerTick(object? sender, EventArgs e)
        {
            int slideshowStep = 1;

            if (checkBoxRandomStep.Checked)
            {
                int randomLimit = listBoxImages.Items.Count;
                slideshowStep = _random.Next(randomLimit);
            }

            SwitchImageIndexAt(slideshowStep);
        }


        private void OnHideTextCheckedChanged(object? sender, EventArgs e)
        {
            if (checkBoxHideText.Checked)
                textBox.Hide();
            else
                textBox.Show();
        }

        private void OnHideGUICheckedChanged(object? sender, EventArgs e)
        {
            if (checkBoxHideGUI.Checked)
            {
                foreach (Control item in _hidableItemsList)
                {
                    item.Hide();
                }
                checkBoxHideGUI.Text = "X";
            }
            else
            {
                foreach (Control item in _hidableItemsList)
                {
                    item.Show();
                }
                UpdateScrollBar();
                checkBoxHideGUI.Text = "Hide control elements";
            }
        }

        private void OnHelpButtonClicked(object? sender, EventArgs e)
        {
            MessageBox.Show(_helpTips, buttonHelp.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void OnExitButtonClick(object? sender, EventArgs e)
        {
            Program.Exit();
        }
    }
}