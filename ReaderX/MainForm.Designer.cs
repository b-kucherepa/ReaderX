namespace ReaderX
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonLoadText = new Button();
            buttonLoadImages = new Button();
            checkBoxHideText = new CheckBox();
            checkBoxSlideshow = new CheckBox();
            checkBoxHideGUI = new CheckBox();
            listBoxImages = new ListBox();
            numericUpDownSlideshow = new NumericUpDown();
            textBox = new Label();
            secondsLabel = new Label();
            verticalScrollBar = new VScrollBar();
            buttonFont = new Button();
            buttonColor = new Button();
            buttonExit = new Button();
            checkBoxRandomStep = new CheckBox();
            panelCheckboxes = new Panel();
            buttonHelp = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSlideshow).BeginInit();
            panelCheckboxes.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLoadText
            // 
            buttonLoadText.BackColor = SystemColors.ButtonHighlight;
            buttonLoadText.FlatStyle = FlatStyle.System;
            buttonLoadText.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLoadText.Location = new Point(37, 30);
            buttonLoadText.Margin = new Padding(5);
            buttonLoadText.Name = "buttonLoadText";
            buttonLoadText.Size = new Size(450, 80);
            buttonLoadText.TabIndex = 0;
            buttonLoadText.Text = "Open a text file";
            buttonLoadText.UseVisualStyleBackColor = false;
            // 
            // buttonLoadImages
            // 
            buttonLoadImages.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLoadImages.BackColor = SystemColors.ButtonHighlight;
            buttonLoadImages.FlatStyle = FlatStyle.System;
            buttonLoadImages.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLoadImages.Location = new Point(1452, 30);
            buttonLoadImages.Margin = new Padding(4);
            buttonLoadImages.Name = "buttonLoadImages";
            buttonLoadImages.Size = new Size(450, 80);
            buttonLoadImages.TabIndex = 1;
            buttonLoadImages.Text = "Select an image folder";
            buttonLoadImages.UseVisualStyleBackColor = false;
            // 
            // checkBoxHideText
            // 
            checkBoxHideText.AutoSize = true;
            checkBoxHideText.BackColor = Color.Transparent;
            checkBoxHideText.FlatStyle = FlatStyle.System;
            checkBoxHideText.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxHideText.ForeColor = Color.Black;
            checkBoxHideText.Location = new Point(4, 4);
            checkBoxHideText.Margin = new Padding(4);
            checkBoxHideText.Name = "checkBoxHideText";
            checkBoxHideText.Size = new Size(211, 38);
            checkBoxHideText.TabIndex = 2;
            checkBoxHideText.Text = "hide the text";
            checkBoxHideText.UseVisualStyleBackColor = false;
            // 
            // checkBoxSlideshow
            // 
            checkBoxSlideshow.AutoSize = true;
            checkBoxSlideshow.BackColor = Color.Transparent;
            checkBoxSlideshow.CheckAlign = ContentAlignment.TopLeft;
            checkBoxSlideshow.FlatStyle = FlatStyle.System;
            checkBoxSlideshow.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSlideshow.ForeColor = Color.Black;
            checkBoxSlideshow.Location = new Point(4, 59);
            checkBoxSlideshow.Margin = new Padding(4);
            checkBoxSlideshow.Name = "checkBoxSlideshow";
            checkBoxSlideshow.Size = new Size(341, 38);
            checkBoxSlideshow.TabIndex = 3;
            checkBoxSlideshow.Text = "change the image each";
            checkBoxSlideshow.UseVisualStyleBackColor = false;
            // 
            // checkBoxHideGUI
            // 
            checkBoxHideGUI.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBoxHideGUI.Appearance = Appearance.Button;
            checkBoxHideGUI.AutoSize = true;
            checkBoxHideGUI.BackColor = Color.Transparent;
            checkBoxHideGUI.CheckAlign = ContentAlignment.TopLeft;
            checkBoxHideGUI.FlatStyle = FlatStyle.System;
            checkBoxHideGUI.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxHideGUI.ForeColor = Color.Black;
            checkBoxHideGUI.Location = new Point(37, 1038);
            checkBoxHideGUI.Margin = new Padding(4);
            checkBoxHideGUI.Name = "checkBoxHideGUI";
            checkBoxHideGUI.Size = new Size(309, 43);
            checkBoxHideGUI.TabIndex = 5;
            checkBoxHideGUI.Text = "Hide control elements";
            checkBoxHideGUI.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxHideGUI.UseVisualStyleBackColor = false;
            // 
            // listBoxImages
            // 
            listBoxImages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBoxImages.BackColor = SystemColors.Window;
            listBoxImages.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxImages.FormattingEnabled = true;
            listBoxImages.HorizontalScrollbar = true;
            listBoxImages.ItemHeight = 20;
            listBoxImages.Items.AddRange(new object[] { "default.png" });
            listBoxImages.Location = new Point(1452, 118);
            listBoxImages.Margin = new Padding(4);
            listBoxImages.Name = "listBoxImages";
            listBoxImages.Size = new Size(449, 784);
            listBoxImages.TabIndex = 6;
            // 
            // numericUpDownSlideshow
            // 
            numericUpDownSlideshow.BackColor = SystemColors.Menu;
            numericUpDownSlideshow.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownSlideshow.Location = new Point(4, 114);
            numericUpDownSlideshow.Margin = new Padding(4);
            numericUpDownSlideshow.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownSlideshow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSlideshow.Name = "numericUpDownSlideshow";
            numericUpDownSlideshow.Size = new Size(209, 40);
            numericUpDownSlideshow.TabIndex = 7;
            numericUpDownSlideshow.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // textBox
            // 
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.AutoSize = true;
            textBox.BackColor = Color.Transparent;
            textBox.FlatStyle = FlatStyle.Flat;
            textBox.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox.ForeColor = Color.IndianRed;
            textBox.Location = new Point(0, 0);
            textBox.Margin = new Padding(4, 0, 4, 0);
            textBox.MaximumSize = new Size(2375, 0);
            textBox.MinimumSize = new Size(2375, 1325);
            textBox.Name = "textBox";
            textBox.Size = new Size(2375, 1325);
            textBox.TabIndex = 8;
            textBox.Text = resources.GetString("textBox.Text");
            // 
            // secondsLabel
            // 
            secondsLabel.AutoSize = true;
            secondsLabel.BackColor = Color.Transparent;
            secondsLabel.FlatStyle = FlatStyle.System;
            secondsLabel.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            secondsLabel.ForeColor = Color.Black;
            secondsLabel.Location = new Point(220, 116);
            secondsLabel.Margin = new Padding(4, 0, 4, 0);
            secondsLabel.Name = "secondsLabel";
            secondsLabel.Size = new Size(132, 33);
            secondsLabel.TabIndex = 9;
            secondsLabel.Text = "second(s)";
            // 
            // verticalScrollBar
            // 
            verticalScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            verticalScrollBar.LargeChange = 100;
            verticalScrollBar.Location = new Point(1908, 0);
            verticalScrollBar.Name = "verticalScrollBar";
            verticalScrollBar.ScaleScrollBarForDpiChange = false;
            verticalScrollBar.Size = new Size(32, 1350);
            verticalScrollBar.SmallChange = 50;
            verticalScrollBar.TabIndex = 10;
            verticalScrollBar.Visible = false;
            // 
            // buttonFont
            // 
            buttonFont.BackColor = SystemColors.ButtonHighlight;
            buttonFont.FlatStyle = FlatStyle.System;
            buttonFont.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFont.Location = new Point(37, 348);
            buttonFont.Margin = new Padding(5);
            buttonFont.Name = "buttonFont";
            buttonFont.Size = new Size(450, 80);
            buttonFont.TabIndex = 12;
            buttonFont.Text = "Set the font";
            buttonFont.UseVisualStyleBackColor = false;
            // 
            // buttonColor
            // 
            buttonColor.BackColor = SystemColors.ButtonHighlight;
            buttonColor.FlatStyle = FlatStyle.System;
            buttonColor.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonColor.Location = new Point(37, 438);
            buttonColor.Margin = new Padding(5);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(450, 80);
            buttonColor.TabIndex = 13;
            buttonColor.Text = "Set the text color";
            buttonColor.UseVisualStyleBackColor = false;
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExit.BackColor = SystemColors.ButtonHighlight;
            buttonExit.FlatStyle = FlatStyle.System;
            buttonExit.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExit.Location = new Point(1451, 1001);
            buttonExit.Margin = new Padding(4);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(450, 80);
            buttonExit.TabIndex = 14;
            buttonExit.Text = "Quit";
            buttonExit.UseVisualStyleBackColor = false;
            // 
            // checkBoxRandomStep
            // 
            checkBoxRandomStep.AutoSize = true;
            checkBoxRandomStep.BackColor = Color.Transparent;
            checkBoxRandomStep.FlatStyle = FlatStyle.System;
            checkBoxRandomStep.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxRandomStep.ForeColor = Color.Black;
            checkBoxRandomStep.Location = new Point(4, 168);
            checkBoxRandomStep.Margin = new Padding(4);
            checkBoxRandomStep.Name = "checkBoxRandomStep";
            checkBoxRandomStep.Size = new Size(367, 38);
            checkBoxRandomStep.TabIndex = 15;
            checkBoxRandomStep.Text = "randomize the slideshow";
            checkBoxRandomStep.UseVisualStyleBackColor = false;
            // 
            // panelCheckboxes
            // 
            panelCheckboxes.BackColor = SystemColors.Window;
            panelCheckboxes.BorderStyle = BorderStyle.FixedSingle;
            panelCheckboxes.Controls.Add(checkBoxHideText);
            panelCheckboxes.Controls.Add(checkBoxRandomStep);
            panelCheckboxes.Controls.Add(checkBoxSlideshow);
            panelCheckboxes.Controls.Add(numericUpDownSlideshow);
            panelCheckboxes.Controls.Add(secondsLabel);
            panelCheckboxes.Location = new Point(40, 120);
            panelCheckboxes.Margin = new Padding(5);
            panelCheckboxes.Name = "panelCheckboxes";
            panelCheckboxes.Size = new Size(447, 218);
            panelCheckboxes.TabIndex = 16;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonHelp.BackColor = SystemColors.ButtonHighlight;
            buttonHelp.FlatStyle = FlatStyle.System;
            buttonHelp.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonHelp.Location = new Point(1451, 913);
            buttonHelp.Margin = new Padding(4);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(450, 80);
            buttonHelp.TabIndex = 17;
            buttonHelp.Text = "Help";
            buttonHelp.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources._default;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1942, 1102);
            ControlBox = false;
            Controls.Add(buttonHelp);
            Controls.Add(checkBoxHideGUI);
            Controls.Add(verticalScrollBar);
            Controls.Add(panelCheckboxes);
            Controls.Add(buttonExit);
            Controls.Add(buttonColor);
            Controls.Add(buttonFont);
            Controls.Add(listBoxImages);
            Controls.Add(buttonLoadImages);
            Controls.Add(buttonLoadText);
            Controls.Add(textBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReaderX";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)numericUpDownSlideshow).EndInit();
            panelCheckboxes.ResumeLayout(false);
            panelCheckboxes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLoadText;
        private Button buttonLoadImages;
        private CheckBox checkBoxHideText;
        private CheckBox checkBoxSlideshow;
        private CheckBox checkBoxHideGUI;
        private ListBox listBoxImages;
        private NumericUpDown numericUpDownSlideshow;
        private Label textBox;
        private Label secondsLabel;
        private VScrollBar verticalScrollBar;
        private Button buttonFont;
        private Button buttonColor;
        private Button buttonExit;
        private CheckBox checkBoxRandomStep;
        private Panel panelCheckboxes;
        private Button buttonHelp;
    }
}