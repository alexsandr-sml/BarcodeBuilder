using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ZintNet;

namespace ZintNetLibTest
{
    public partial class Form1 : Form
    {
        private ZintNetLib barcode = null;
        private Symbology symbolID = Symbology.Code128;
        private string barcodeData;
        private Color barcodeColor = Color.Black;
        private Color backgroundColor = Color.White;
        private Color textColor = Color.Black;
        private Font barcodeTextFont = new Font("Arial", 10.0f, FontStyle.Regular);
        private int angle = 0;
        float textMargin = 0.0f;
        float barHeight = 20.0f;
        float Xvalue = 1.0f;

        private string outputFile = "out";

        private int qrVersion = 0;
        private QRCodeErrorLevel qrErrorLevel = QRCodeErrorLevel.Low;

        private int aztecVersion = 0;
        private int aztecErrorLevel = -1;

        private EncodingMode encodingMode = EncodingMode.Standard;
        private CompositeMode compositeMode = CompositeMode.CCA;

        private string compositeText = String.Empty;
        private string supplementText = String.Empty;

        private ITF14BearerStyle itfBearerStyle = ITF14BearerStyle.Rectangle;

        public Form1()
        {
            InitializeComponent();
            // Double buffer the barcode image panel.
            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.SetProperty,
                null,
                imagePanel,
                new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            barcode = new ZintNetLib();
            if (barcode != null)
            {
                printToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                generateButton.Enabled = false;
                GetSymbologies();
                textMarginNumericUpDown.Value = (decimal)(barcode.TextMargin);
                barHeightNumericUpDown.Value = (decimal)(barcode.BarcodeHeight);
                rotateTextBox.Text = angle.ToString();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            barcodeDataTextBox.Focus();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument barcodeDoc = new PrintDocument();
            PrintDialog pd = new PrintDialog();
            pd.UseEXDialog = true;
            pd.Document = barcodeDoc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                barcodeDoc.PrintPage += new PrintPageEventHandler(this.printBarcode);
                barcodeDoc.Print();
            }
        }

        void printBarcode(object sender, PrintPageEventArgs e)
        {
            //barcode.DrawBarcode(e.Graphics, new Point(e.MarginBounds.Left + 500, e.MarginBounds.Top + 500));
            barcode.DrawBarcode(e.Graphics, new Point(10, 10));
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (barcode == null)
                return;

            angle += 90;
            if (angle > 270)
                angle = 0;

            rotateTextBox.Text = angle.ToString();
            imagePanel.Invalidate();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ImagePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (barcode != null && !String.IsNullOrEmpty(barcodeData))
            {
                try
                {
                    SetBarcodeProperties();
                    barcode.CreateBarcode(symbolID, barcodeData);
                    SizeF bcSize = barcode.SymbolSize(graphics);
                    // Location in millimeters.
                    PointF location = new PointF((((imagePanel.Width / graphics.DpiX) * 25.4f) / 2) - (bcSize.Width / 2),
                                               (((imagePanel.Height / graphics.DpiY) * 25.4f) / 2) - (bcSize.Height / 2));

                    barcode.DrawBarcode(graphics, location);
                    outputTextBox.Text = barcode.ToString();
                }

                catch (ZintNetDLLException ex)
                {
                    graphics.Clear(imagePanel.BackColor);
                    outputTextBox.Text = String.Empty;
                    string errorMessage = ex.Message;
                    if (ex.InnerException != null)
                        errorMessage += ex.InnerException.Message;

                    System.Windows.Forms.MessageBox.Show(errorMessage, "ZintNet Barcode Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    UpdateMenus();
                }
            }
        }

        private void GetSymbologies()
        {
            symbologyComboBox.Items.AddRange(ZintNetLib.GetSymbolNames());
            symbologyComboBox.Sorted = true;
            symbologyComboBox.SelectedIndex = 0;
        }

        private void symbologyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            symbolID = ZintNetLib.GetSymbolId(symbologyComboBox.Text);
            SetControlsAndOptions();
        }

        private void SetBarcodeProperties()
        {
            // Common properties.
            if (compositeDataTextbox != null)
                compositeText = compositeDataTextbox.Text;

            if (supplementDataTextBox != null)
                supplementText = supplementDataTextBox.Text;

            // barcode.CompositeMode = getCompositeChecked(compositeGroupBox);
            barcode.Multiplier = Xvalue;
            barcode.TextMargin = textMargin;
            barcode.BarcodeColor = barcodeColor;
            barcode.BarcodeTextColor = textColor;
            barcode.Font = barcodeTextFont;
            barcode.Rotation = angle;
            barcode.BarcodeHeight = barHeight;
            barcode.TextVisible = showTextCheckBox.Checked;
            barcode.EncodingMode = encodingMode;
            barcode.ElementXDimension = 0.264583f;  // equals 1 pixel at 96 dpi

            // Symbol specific properties.
            // ITF14.
            if (symbolID == Symbology.ITF14)
                barcode.ITF14BearerStyle = itfBearerStyle;

            // Code 39.
            if (symbolID == Symbology.Code39 || symbolID == Symbology.Code39Extended || symbolID == Symbology.Code93 || symbolID == Symbology.LOGMARS)
            {
                if(symbolID != Symbology.Code93)
                    barcode.OptionalCheckDigit = optionalCheckDigitCheckBox.Checked;

                barcode.ShowCheckDigit = showCheckDigitCheckBox.Checked;
            }

            // DataMatrix Properties.
            if (symbolID == Symbology.DataMatrix)
            {
                barcode.DataMatrixSize = (DataMatrixSize)dmSizesComboBox.SelectedIndex;
                barcode.DataMatrixRectExtn = dmreCheckBox.Checked;
                barcode.DataMatrixSquare = squareOnlyCheckBox.Checked;
            }

            if (symbolID == Symbology.QRCode || symbolID == Symbology.MicroQRCode)
            {
                barcode.QRVersion = qrVersion;
                barcode.QRCodeErrorLevel = qrErrorLevel;
            }

            if (symbolID == Symbology.Aztec)
            {
                barcode.AztecSize = aztecVersion;
                barcode.AztecErrorLevel = aztecErrorLevel;
            }

            if (symbolID == Symbology.Code128)
            {
                if (encodingMode == EncodingMode.GS1)
                {
                    barcode.CompositeMode = compositeMode;
                    barcode.CompositeMessage = compositeText;
                }
            }

            if (barcode.IsGS1Databar())
            {
                barcode.CompositeMode = compositeMode;
                barcode.CompositeMessage = compositeText;
                if (symbolID == Symbology.DatabarExpandedStacked)
                {
                    barcode.DatabarExpandedSegments = expStackedSegementsComboBox.SelectedIndex * 2;
                }
            }

            if (barcode.IsEanUpc())
            {
                if (symbolID != Symbology.ISBN)
                {
                    barcode.CompositeMode = compositeMode;
                    barcode.CompositeMessage = compositeText;
                }

                barcode.SupplementMessage = supplementText;
            }

            if (symbolID == Symbology.PDF417 || symbolID == Symbology.PDF417Truncated || symbolID == Symbology.MicroPDF417)
            {
                barcode.PDF417Columns = pdfColumnsComboBox.SelectedIndex;
                barcode.PDF417ErrorLevel = pdfErrorLevelComboBox.SelectedIndex - 1;
                barcode.PDF417RowHeight = pdfRowHeightComboBox.SelectedIndex + 2;
            }

            if (symbolID == Symbology.DotCode)
            {
                barcode.ElementXDimension = 0.529166f;  // equals 2 pixels.
            }

            //barcode.I2of5tCheckType = I2of5CheckType.OPCC;
            //barcode.TextPosition = TextPosition.AboveBarcode;
            //barcode.TextAlignment = TextAlignment.Left;
            //barcode.ITF14BearerStyle = ITF14BearerStyle.HorizontalBars;
        }

        private void UpdateMenus()
        {
            printToolStripMenuItem.Enabled = barcode.IsValid;
            saveAsToolStripMenuItem.Enabled = barcode.IsValid;
        }

        void SetControlsAndOptions()
        {
            symbolPropertiesTabPage.Text = symbologyComboBox.Text;
            outputTextBox.Text = String.Empty;
            barHeightNumericUpDown.Enabled = true;
            textMarginNumericUpDown.Enabled = true;
            showTextCheckBox.Enabled = true;
            RemoveRunTimeControls();
            switch (symbolID)
            {
                case Symbology.DataMatrix:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddDataMatrixControls();
                    break;

                case Symbology.QRCode:
                case Symbology.MicroQRCode:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddQRAztecControls();
                    break;

                case Symbology.Aztec:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddQRAztecControls();
                    break;

                case Symbology.AztecRunes:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    break;

                case Symbology.EAN13:
                case Symbology.EAN8:
                case Symbology.UPCA:
                case Symbology.UPCE:
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddCompositeControls();
                    AddSupplimentDataControls();
                    cccRadioButton.Enabled = false;
                    break;

                case Symbology.ISBN:
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddSupplimentDataControls();
                    break;

                case Symbology.DatabarExpanded:
                case Symbology.DatabarExpandedStacked:
                case Symbology.DatabarLimited:
                case Symbology.DatabarOmni:
                case Symbology.DatabarOmniStacked:
                case Symbology.DatabarStacked:
                case Symbology.DatabarTruncated:
                    AddCompositeControls();
                    if (symbolID == Symbology.DatabarExpandedStacked)
                        AddExpStackedControls();

                    cccRadioButton.Enabled = false;
                    barHeightNumericUpDown.Enabled = false;
                    break;

                case Symbology.Code128:
                    AddModeControls();
                    AddCompositeControls();
                    break;

                case Symbology.PDF417:
                case Symbology.PDF417Truncated:
                case Symbology.MicroPDF417:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddModeControls();
                    gs1RadioButton.Enabled = false;
                    AddPDFControls();
                    break;

                case Symbology.Code39:
                case Symbology.Code39Extended:
                case Symbology.LOGMARS:
                case Symbology.Code93:
                    AddCode39Controls();
                    if (symbolID == Symbology.Code39)
                    {
                        AddModeControls();
                        gs1RadioButton.Enabled = false;
                    }
                    break;

                case Symbology.ITF14:
                    barHeightNumericUpDown.Enabled = true;
                    textMarginNumericUpDown.Enabled = true;
                    showTextCheckBox.Enabled = true;
                    AddITF14Controls();
                    break;

                case Symbology.CodablockF:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    break;

                case Symbology.DotCode:
                    barHeightNumericUpDown.Enabled = false;
                    textMarginNumericUpDown.Enabled = false;
                    showTextCheckBox.Enabled = false;
                    AddModeControls();
                    hibcRadioButton.Enabled = false;
                    break;
            }
        }

        #region Save As Image
        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToImage(outputFile + ".png", ImageFormat.Png);
        }

        private void bMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToImage(outputFile + ".bmp", ImageFormat.Bmp);
        }

        private void gIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToImage(outputFile + ".gif", ImageFormat.Gif);
        }

        private void tIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToImage(outputFile + ".tif", ImageFormat.Tiff);
        }

        /// <summary>
        /// Creates and saves an image of the barcode.
        /// </summary>
        /// <param name="fileName">save path and filename</param>
        /// <param name="imageFormat">image format to save as</param>
        private void SaveToImage(string fileName, ImageFormat imageFormat)
        {
            Rectangle section = Rectangle.Empty;
            Size symbolSize;
            Bitmap newBitmap = null;
            try
            {
                using (Bitmap bitmap = new Bitmap(10000, 10000))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.White);
                        barcode.ElementXDimension = 0.264583f;  // 0.264583mm = 1 pixel (96dpi screen resolution)
                        barcode.DrawBarcode(graphics, new PointF(3.0f, 3.0f));
                        symbolSize = barcode.SymbolDimensions(graphics);
                        section.Width = symbolSize.Width + 20;
                        section.Height = symbolSize.Height + 20;
                        newBitmap = CopyBitMapSection(bitmap, section);
                        newBitmap.Save(fileName, imageFormat);
                    }
                }
            }

            catch (Exception ex)
            {
                throw new ZintNetDLLException("", ex);
            }

            finally
            {
                if (newBitmap != null)
                    newBitmap.Dispose();
            }
        }

        private Bitmap CopyBitMapSection(Bitmap sourceBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bitmap = new Bitmap(section.Width, section.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Draw the specified section of the source bitmap to the new one
                graphics.DrawImage(sourceBitmap, 0, 0, section, GraphicsUnit.Pixel);
            }
            return bitmap;
        }

        #endregion

        private void XvaluenumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Xvalue = (float)XvaluenumericUpDown.Value;
            imagePanel.Invalidate();
        }

        private void barcodeColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = this.barcodeColorButton.BackColor;
                cd.ShowDialog();
                this.barcodeColorButton.BackColor = cd.Color;
                barcodeColor = cd.Color;
            }

            imagePanel.Invalidate();
        }

        private void textColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = this.textColorButton.BackColor;
                cd.ShowDialog();
                textColorButton.BackColor = cd.Color;
                textColor = cd.Color;
            }

            imagePanel.Invalidate();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            barcodeData = barcodeDataTextBox.Text;
            imagePanel.Invalidate();
        }

        private void barcodeDataTextBox_TextChanged(object sender, EventArgs e)
        {
            generateButton.Enabled = !string.IsNullOrEmpty(this.barcodeDataTextBox.Text);
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = barcodeTextFont;
                fd.ShowDialog();
                barcodeTextFont = fd.Font;
            }

            imagePanel.Invalidate();
        }

        private void textMarginNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (barcode != null)
            {
                textMargin = (float)textMarginNumericUpDown.Value;
                imagePanel.Invalidate();
            }
        }

        private void barHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (barcode != null)
            {
                barHeight = (float)barHeightNumericUpDown.Value;
                imagePanel.Invalidate();
            }
        }

        private void showTextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        private void showCheckDigitCheckBox_CheckedChange(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        private void optionalCheckDigitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        /*       private CompositeMode getCompositeChecked(Control control)
               {
                   CompositeMode mode = CompositeMode.CCA;
                   try
                   {
                       Control.ControlCollection controlCollection = control.Controls;
                       for (int i = 0; i < controlCollection.Count; i++)
                       {
                           RadioButton radioButton = controlCollection[i] as RadioButton;
                           if (radioButton.Checked)
                           {
                               if (radioButton.Text == "CCC")
                                   mode = CompositeMode.CCC;

                               else if (radioButton.Text == "CCB")
                                   mode = CompositeMode.CCB;

                               else
                                   mode = CompositeMode.CCA;
                           }
                       }
                   }

                   catch
                   {
                       mode = CompositeMode.CCA;
                   }

                   return mode;
               }*/

        /*private EncodingMode getModeChecked(Control control)
        {
            EncodingMode mode = EncodingMode.Standard;
            try
            {
                Control.ControlCollection controlCollection = control.Controls;
                for (int i = 0; i < controlCollection.Count; i++)
                {
                    RadioButton radioButton = controlCollection[i] as RadioButton;
                    if (radioButton.Checked)
                    {
                        if (radioButton.Text == "HIBC")
                            mode = EncodingMode.HIBC;

                        else if (radioButton.Text == "GS1")
                            mode = EncodingMode.GS1;

                        else
                            mode = EncodingMode.Standard;
                    }
                }
            }

            catch
            {
                mode = EncodingMode.Standard;
            }

            return mode;
        }*/

        #region Data Matrix Controls Events
        private void dmSizesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        private void squareOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        private void dmreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }
        #endregion

        #region QRcode and Aztec Controls Events
        private void qrAztecAutoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (qrAztecAutoRadioButton.Checked)
            {
                qrAztecSizesComboBox.Enabled = false;
                qrAztecErrorComboBox.Enabled = false;
                qrVersion = 0;
                qrErrorLevel = QRCodeErrorLevel.Low;
                aztecVersion = 0;
                aztecErrorLevel = qrAztecErrorComboBox.SelectedIndex + 1;
                imagePanel.Invalidate();
            }
        }

        private void qrAztecSizeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (qrAztecSizeRadioButton.Checked)
            {
                qrAztecSizesComboBox.Enabled = true;
                qrAztecErrorComboBox.Enabled = false;
                qrVersion = qrAztecSizesComboBox.SelectedIndex + 1;
                qrErrorLevel = QRCodeErrorLevel.Low;
                aztecVersion = qrAztecSizesComboBox.SelectedIndex + 1;
                aztecErrorLevel = -1;
                imagePanel.Invalidate();
            }
        }

        private void qrAztecErrorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (qrAztecErrorRadioButton.Checked)
            {
                qrAztecErrorComboBox.Enabled = true;
                qrAztecSizesComboBox.Enabled = false;
                qrVersion = 0;
                qrErrorLevel = (QRCodeErrorLevel)qrAztecErrorComboBox.SelectedIndex;
                aztecVersion = 0;
                aztecErrorLevel = qrAztecErrorComboBox.SelectedIndex + 1;
                imagePanel.Invalidate();
            }
        }

        private void qrAztecSizesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qrVersion = qrAztecSizesComboBox.SelectedIndex + 1;
            qrErrorLevel = QRCodeErrorLevel.Low;
            aztecVersion = qrAztecSizesComboBox.SelectedIndex + 1;
            aztecErrorLevel = -1;
            imagePanel.Invalidate();
        }

        private void qrAztecErrorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qrVersion = 0;
            qrErrorLevel = (QRCodeErrorLevel)qrAztecErrorComboBox.SelectedIndex;
            aztecVersion = 0;
            aztecErrorLevel = qrAztecErrorComboBox.SelectedIndex + 1;
            imagePanel.Invalidate();
        }

        #endregion

        #region Mode Controls Events
        private void standardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (standardRadioButton.Checked)
            {
                encodingMode = EncodingMode.Standard;
                imagePanel.Invalidate();
            }
        }

        private void gs1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (gs1RadioButton.Checked)
            {
                if (symbolID == Symbology.Code128)
                {
                    compositeGroupBox.Enabled = true;
                    compositeDataTextbox.Enabled = true;
                }

                encodingMode = EncodingMode.GS1;
                imagePanel.Invalidate();
            }

            else if (compositeGroupBox != null)
            {
                compositeGroupBox.Enabled = false;
                compositeDataTextbox.Enabled = false;
            }
        }

        private void hibcRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (hibcRadioButton.Checked)
            {
                encodingMode = EncodingMode.HIBC;
                imagePanel.Invalidate();
            }
        }

        #endregion

        #region Composite Controls Events
        private void ccaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ccaRadioButton.Checked)
            {
                compositeMode = CompositeMode.CCA;
                imagePanel.Invalidate();
            }
        }

        private void ccbRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ccbRadioButton.Checked)
            {
                compositeMode = CompositeMode.CCB;
                imagePanel.Invalidate();
            }
        }

        private void cccRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (cccRadioButton.Checked)
            {
                compositeMode = CompositeMode.CCC;
                imagePanel.Invalidate();
            }
        }

        #endregion

        #region PDF417 Control Events
        private void pdfColumnsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        private void pdfErrorLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        private void pdfRowHeightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }
        #endregion



        private void expStackedSegementsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            imagePanel.Invalidate();
        }

        #region ITF14 Controls Events
        private void noneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (noneRadioButton.Checked)
            {
                itfBearerStyle = ITF14BearerStyle.None;
                imagePanel.Invalidate();
            }
        }

        private void horizonalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (horizonalRadioButton.Checked)
            {
                itfBearerStyle = ITF14BearerStyle.Horizonal;
                imagePanel.Invalidate();
            }
        }

        private void rectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rectangleRadioButton.Checked)
            {
                itfBearerStyle = ITF14BearerStyle.Rectangle;
                imagePanel.Invalidate();
            }
        }

        #endregion
    }
}



