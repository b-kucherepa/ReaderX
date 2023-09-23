using Timer = System.Windows.Forms.Timer;


namespace ReaderX
{
    public partial class MainForm : Form
    {
        private const int MSECONDS_IN_SECOND = 1000;

        private Timer _timer;
        private Random _random;

        private Control[] _hidableItemsList;

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
                buttonExit
            };

            _timer = new Timer();
            _random = new Random();

            InitializeLocale();
            InitializeEventSubscriptions();
        }

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

            buttonExit.Text = locale.buttonExit ?? buttonExit.Text;

            string[] listBoxImagesTips = new string[]
                {
                locale.useTheButtonToList,
                "",
                locale.hotkeys,
                "",
                locale.hotkeyLabelTextControl,
                ">T<",
                locale.buttonLoadText,
                ">F<",
                locale.buttonFont,
                ">C<",
                locale.buttonColor,
                ">W<",
                locale.hotkeyScrollUp,
                ">S<",
                locale.hotkeyScrollDown,
                "",
                locale.hotkeyLabelImageControl,
                ">I<",
                locale.hotkeyLoadImages,
                ">D<",
                locale.hotkeySelectNextImage,
                ">A<",
                locale.hotkeySelectPreviousImage,
                "",
                locale.hotkeyLabelSlideshowControl,
                ">E<",
                locale.hotkeySlideshow,
                ">R<",
                locale.checkBoxRandomStep,
                "",
                locale.hotkeyLabelHideElements,
                ">H<",
                locale.hotkeyHideGUI,
                ">B<",
                locale.hotkeyHideText,
                "",
                ">Escape<",
                locale.hotkeyExit
                };

            bool listBoxImagesTipsIsComplete = true;
            foreach (string s in listBoxImagesTips)
                if (s is null)
                    listBoxImagesTipsIsComplete = false;

            if (listBoxImagesTipsIsComplete)
            {
                listBoxImages.Items.Clear();
                listBoxImages.Items.AddRange(listBoxImagesTips);
            } //else leaving default hard-coded text
        }

        private void InitializeEventSubscriptions()
        {
            this.KeyDown += OnHotkeyPressed;
            this.MouseWheel += OnMouseWheel;

            //text GUI events
            buttonLoadText.Click += OnLoadTextClicked;
            buttonFont.Click += OnFontButtonClicked;
            buttonColor.Click += OnColorButtonClicked;
            verticalScrollBar.ValueChanged += OnVerticalScrolling;

            //images GUI events
            buttonLoadImages.Click += OnLoadImagesClicked;
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
            buttonExit.Click += OnExitButtonClick;
        }

        private void OnHotkeyPressed(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //text related buttons:
                case (Keys.T):
                    OnLoadTextClicked(sender, e);
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
                    OnLoadImagesClicked(sender, e);
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
                case (Keys.H):
                    checkBoxHideGUI.Checked = !checkBoxHideGUI.Checked;
                    break;
                case (Keys.B):
                    checkBoxHideText.Checked = !checkBoxHideText.Checked;
                    break;

                //app closing:
                case (Keys.Escape):
                    Program.Exit();
                    break;
            }
        }

        private void OnMouseWheel(object? sender, MouseEventArgs e)
        {
            ChangeScrollBarValueTo(-e.Delta);
        }

        private void OnLoadTextClicked(object? sender, EventArgs e)
        {
            textBox.Text = TextLoader.LoadText();

            UpdateScrollBar();
            
        }

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
            textBox.Font = TextLoader.SelectFont();
            UpdateScrollBar();
        }

        private void OnColorButtonClicked(object? sender, EventArgs e)
        {
            textBox.ForeColor = TextLoader.SelectColor();
        }

        private void OnVerticalScrolling(object? sender, EventArgs e)
        {
            int newTextBoxPosition = (this.Height - textBox.Height) * verticalScrollBar.Value / verticalScrollBar.Maximum;
            textBox.Location = new Point(textBox.Location.X, newTextBoxPosition);
        }

        private void ChangeScrollBarValueTo(int step)
        {
            int newScrollBarValue = verticalScrollBar.Value + step;

            if (newScrollBarValue < verticalScrollBar.Minimum)
                newScrollBarValue = verticalScrollBar.Minimum;
            else if (newScrollBarValue > verticalScrollBar.Maximum)
                newScrollBarValue = verticalScrollBar.Maximum;

            verticalScrollBar.Value = newScrollBarValue;
        }

        private void OnLoadImagesClicked(object? sender, EventArgs e)
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
            Image image = ImageLoader.LoadImage (listBoxImages.SelectedItem.ToString());
            BackgroundImage?.Dispose();
            BackgroundImage = image;
        }

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

        private void OnExitButtonClick(object? sender, EventArgs e)
        {
            Program.Exit();
        }

        //private void OnMouseMoved(object? sender, MouseEventArgs e)
        //{
        //    if (verticalScrollBar.Bounds.Contains(e.Location))
        //        verticalScrollBar.Show();
        //    else
        //        verticalScrollBar.Hide();

        //    if (checkBoxHideGUI.Checked)
        //    {
        //        if (checkBoxHideGUI.Bounds.Contains(e.Location)) { }

        //        checkBoxHideGUI.Text = "Show control elements";
        //        else
        //            checkBoxHideGUI.Text = "X";
        //    }
        //    else
        //    {
        //        checkBoxHideGUI.Text = "Hide control elements";
        //    }
        //}
    }
}