namespace ZintNetLibTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.generateButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.symbologyComboBox = new System.Windows.Forms.ComboBox();
            this.barcodeDataTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.commomPropertiesTabPage = new System.Windows.Forms.TabPage();
            this.rotateTextBox = new System.Windows.Forms.TextBox();
            this.showTextCheckBox = new System.Windows.Forms.CheckBox();
            this.barHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textMarginNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.rotateButton = new System.Windows.Forms.Button();
            this.textColorButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.barcodeColorButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.XvaluenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.symbolPropertiesTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.commomPropertiesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMarginNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XvaluenumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(73, 443);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(170, 21);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate Barcode";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pNGToolStripMenuItem,
            this.bMPToolStripMenuItem,
            this.gIFToolStripMenuItem,
            this.tIFToolStripMenuItem});
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveAsToolStripMenuItem.Text = "Save As . . .";
            // 
            // pNGToolStripMenuItem
            // 
            this.pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
            this.pNGToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.pNGToolStripMenuItem.Text = "PNG";
            this.pNGToolStripMenuItem.Click += new System.EventHandler(this.pNGToolStripMenuItem_Click);
            // 
            // bMPToolStripMenuItem
            // 
            this.bMPToolStripMenuItem.Name = "bMPToolStripMenuItem";
            this.bMPToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.bMPToolStripMenuItem.Text = "BMP";
            this.bMPToolStripMenuItem.Click += new System.EventHandler(this.bMPToolStripMenuItem_Click);
            // 
            // gIFToolStripMenuItem
            // 
            this.gIFToolStripMenuItem.Name = "gIFToolStripMenuItem";
            this.gIFToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem.Text = "GIF";
            this.gIFToolStripMenuItem.Click += new System.EventHandler(this.gIFToolStripMenuItem_Click);
            // 
            // tIFToolStripMenuItem
            // 
            this.tIFToolStripMenuItem.Name = "tIFToolStripMenuItem";
            this.tIFToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.tIFToolStripMenuItem.Text = "TIFF";
            this.tIFToolStripMenuItem.Click += new System.EventHandler(this.tIFToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.Location = new System.Drawing.Point(320, 38);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(694, 290);
            this.imagePanel.TabIndex = 11;
            this.imagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ImagePanel_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.symbologyComboBox);
            this.groupBox1.Controls.Add(this.barcodeDataTextBox);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 134);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Input";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Symbology:";
            // 
            // symbologyComboBox
            // 
            this.symbologyComboBox.DropDownHeight = 198;
            this.symbologyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.symbologyComboBox.FormattingEnabled = true;
            this.symbologyComboBox.IntegralHeight = false;
            this.symbologyComboBox.Location = new System.Drawing.Point(16, 34);
            this.symbologyComboBox.Name = "symbologyComboBox";
            this.symbologyComboBox.Size = new System.Drawing.Size(258, 21);
            this.symbologyComboBox.TabIndex = 0;
            this.symbologyComboBox.SelectedIndexChanged += new System.EventHandler(this.symbologyComboBox_SelectedIndexChanged);
            // 
            // barcodeDataTextBox
            // 
            this.barcodeDataTextBox.Location = new System.Drawing.Point(16, 76);
            this.barcodeDataTextBox.Multiline = true;
            this.barcodeDataTextBox.Name = "barcodeDataTextBox";
            this.barcodeDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.barcodeDataTextBox.Size = new System.Drawing.Size(258, 36);
            this.barcodeDataTextBox.TabIndex = 1;
            this.barcodeDataTextBox.TextChanged += new System.EventHandler(this.barcodeDataTextBox_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 60);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Barcode Data:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(320, 347);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(694, 117);
            this.outputTextBox.TabIndex = 4;
            this.outputTextBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Binary Output\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.commomPropertiesTabPage);
            this.tabControl1.Controls.Add(this.symbolPropertiesTabPage);
            this.tabControl1.Location = new System.Drawing.Point(8, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(270, 204);
            this.tabControl1.TabIndex = 2;
            // 
            // commomPropertiesTabPage
            // 
            this.commomPropertiesTabPage.Controls.Add(this.rotateTextBox);
            this.commomPropertiesTabPage.Controls.Add(this.showTextCheckBox);
            this.commomPropertiesTabPage.Controls.Add(this.barHeightNumericUpDown);
            this.commomPropertiesTabPage.Controls.Add(this.label6);
            this.commomPropertiesTabPage.Controls.Add(this.textMarginNumericUpDown);
            this.commomPropertiesTabPage.Controls.Add(this.label8);
            this.commomPropertiesTabPage.Controls.Add(this.rotateButton);
            this.commomPropertiesTabPage.Controls.Add(this.textColorButton);
            this.commomPropertiesTabPage.Controls.Add(this.label13);
            this.commomPropertiesTabPage.Controls.Add(this.button4);
            this.commomPropertiesTabPage.Controls.Add(this.label14);
            this.commomPropertiesTabPage.Controls.Add(this.barcodeColorButton);
            this.commomPropertiesTabPage.Controls.Add(this.label15);
            this.commomPropertiesTabPage.Controls.Add(this.XvaluenumericUpDown);
            this.commomPropertiesTabPage.Controls.Add(this.label16);
            this.commomPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.commomPropertiesTabPage.Name = "commomPropertiesTabPage";
            this.commomPropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.commomPropertiesTabPage.Size = new System.Drawing.Size(262, 178);
            this.commomPropertiesTabPage.TabIndex = 0;
            this.commomPropertiesTabPage.Text = "Common Properties";
            this.commomPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // rotateTextBox
            // 
            this.rotateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotateTextBox.CausesValidation = false;
            this.rotateTextBox.Enabled = false;
            this.rotateTextBox.Location = new System.Drawing.Point(93, 112);
            this.rotateTextBox.Name = "rotateTextBox";
            this.rotateTextBox.ReadOnly = true;
            this.rotateTextBox.Size = new System.Drawing.Size(31, 20);
            this.rotateTextBox.TabIndex = 28;
            this.rotateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // showTextCheckBox
            // 
            this.showTextCheckBox.AutoSize = true;
            this.showTextCheckBox.Checked = true;
            this.showTextCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTextCheckBox.Location = new System.Drawing.Point(142, 115);
            this.showTextCheckBox.Name = "showTextCheckBox";
            this.showTextCheckBox.Size = new System.Drawing.Size(77, 17);
            this.showTextCheckBox.TabIndex = 8;
            this.showTextCheckBox.Text = "Show Text";
            this.showTextCheckBox.UseVisualStyleBackColor = true;
            this.showTextCheckBox.Click += new System.EventHandler(this.showTextCheckBox_CheckedChanged);
            // 
            // barHeightNumericUpDown
            // 
            this.barHeightNumericUpDown.DecimalPlaces = 2;
            this.barHeightNumericUpDown.Location = new System.Drawing.Point(70, 49);
            this.barHeightNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.barHeightNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.barHeightNumericUpDown.Name = "barHeightNumericUpDown";
            this.barHeightNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.barHeightNumericUpDown.TabIndex = 3;
            this.barHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.barHeightNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.barHeightNumericUpDown.ValueChanged += new System.EventHandler(this.barHeightNumericUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Height:";
            // 
            // textMarginNumericUpDown
            // 
            this.textMarginNumericUpDown.DecimalPlaces = 1;
            this.textMarginNumericUpDown.Location = new System.Drawing.Point(206, 19);
            this.textMarginNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.textMarginNumericUpDown.Name = "textMarginNumericUpDown";
            this.textMarginNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.textMarginNumericUpDown.TabIndex = 2;
            this.textMarginNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMarginNumericUpDown.ValueChanged += new System.EventHandler(this.textMarginNumericUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(139, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Text Margin:";
            // 
            // rotateButton
            // 
            this.rotateButton.Location = new System.Drawing.Point(11, 112);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(59, 20);
            this.rotateButton.TabIndex = 7;
            this.rotateButton.Text = "Rotate";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // textColorButton
            // 
            this.textColorButton.BackColor = System.Drawing.Color.Black;
            this.textColorButton.FlatAppearance.BorderSize = 0;
            this.textColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textColorButton.ForeColor = System.Drawing.Color.Black;
            this.textColorButton.Location = new System.Drawing.Point(222, 80);
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.Size = new System.Drawing.Size(30, 20);
            this.textColorButton.TabIndex = 6;
            this.textColorButton.UseVisualStyleBackColor = false;
            this.textColorButton.Click += new System.EventHandler(this.textColorButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(139, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Text Color:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(193, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 20);
            this.button4.TabIndex = 4;
            this.button4.Text = "Select";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(139, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Text Font:";
            // 
            // barcodeColorButton
            // 
            this.barcodeColorButton.BackColor = System.Drawing.Color.Black;
            this.barcodeColorButton.FlatAppearance.BorderSize = 0;
            this.barcodeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.barcodeColorButton.ForeColor = System.Drawing.Color.Black;
            this.barcodeColorButton.Location = new System.Drawing.Point(94, 80);
            this.barcodeColorButton.Name = "barcodeColorButton";
            this.barcodeColorButton.Size = new System.Drawing.Size(30, 20);
            this.barcodeColorButton.TabIndex = 5;
            this.barcodeColorButton.UseVisualStyleBackColor = false;
            this.barcodeColorButton.Click += new System.EventHandler(this.barcodeColorButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Barcode Color:";
            // 
            // XvaluenumericUpDown
            // 
            this.XvaluenumericUpDown.DecimalPlaces = 2;
            this.XvaluenumericUpDown.Location = new System.Drawing.Point(70, 19);
            this.XvaluenumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.XvaluenumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XvaluenumericUpDown.Name = "XvaluenumericUpDown";
            this.XvaluenumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.XvaluenumericUpDown.TabIndex = 1;
            this.XvaluenumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.XvaluenumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XvaluenumericUpDown.ValueChanged += new System.EventHandler(this.XvaluenumericUpDown_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Multiplier:";
            // 
            // symbolPropertiesTabPage
            // 
            this.symbolPropertiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.symbolPropertiesTabPage.Name = "symbolPropertiesTabPage";
            this.symbolPropertiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.symbolPropertiesTabPage.Size = new System.Drawing.Size(262, 178);
            this.symbolPropertiesTabPage.TabIndex = 1;
            this.symbolPropertiesTabPage.Text = "Symbol Name";
            this.symbolPropertiesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 237);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Symbol Properties";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1026, 471);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZintNET Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.commomPropertiesTabPage.ResumeLayout(false);
            this.commomPropertiesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMarginNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XvaluenumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox symbologyComboBox;
        private System.Windows.Forms.TextBox barcodeDataTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage commomPropertiesTabPage;
        private System.Windows.Forms.TextBox rotateTextBox;
        private System.Windows.Forms.CheckBox showTextCheckBox;
        private System.Windows.Forms.NumericUpDown barHeightNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown textMarginNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button barcodeColorButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown XvaluenumericUpDown;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage symbolPropertiesTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem pNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIFToolStripMenuItem;
    }
}

