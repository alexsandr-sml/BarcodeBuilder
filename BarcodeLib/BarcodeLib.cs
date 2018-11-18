namespace BarcodeLib
{
    using Enums;
    using Symbologies;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;

    /// <summary>
    /// Generates a barcode image of a specified symbology from a string of data.
    /// </summary>
    public class Barcode : IDisposable
    {
        private IBarcode ibarcode = new Blank();
        private string Raw_Data = "";
        private string Encoded_Value = "";
        private string _Country_Assigning_Manufacturer_Code = "N/A";
        private BARCODE_TYPE Encoded_Type = BARCODE_TYPE.UNSPECIFIED;
        private Image _Encoded_Image = null;
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.White;
        private int _Width = 300;
        private int _Height = 150;
        private ImageFormat _ImageFormat = ImageFormat.Jpeg;
        private Font _LabelFont = new Font("Times", 10, FontStyle.Bold);
        private LABEL_POSITIONS _LabelPosition = LABEL_POSITIONS.BOTTOMCENTER;
        private RotateFlipType _RotateFlipType = RotateFlipType.RotateNoneFlipNone;

        /// <summary>
        /// Default constructor.  Does not populate the raw data.  MUST be done via the RawData property before encoding.
        /// </summary>
        public Barcode()
        {
        }

        /// <summary>
        /// Constructor. Populates the raw data. No whitespace will be added before or after the barcode.
        /// </summary>
        /// <param name="data">String to be encoded.</param>
        public Barcode(string data)
        {
            Raw_Data = data;
        }

        public Barcode(string data, BARCODE_TYPE iType)
        {
            Raw_Data = data;
            Encoded_Type = iType;
        }

        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        public string RawData
        {
            get
            {
                return Raw_Data;
            }

            set
            {
                Raw_Data = value;
            }
        }

        /// <summary>
        /// Gets the encoded value.
        /// </summary>
        public string EncodedValue
        {
            get
            {
                return Encoded_Value;
            }
        }

        /// <summary>
        /// Gets the Country that assigned the Manufacturer Code.
        /// </summary>
        public string Country_Assigning_Manufacturer_Code
        {
            get
            {
                return _Country_Assigning_Manufacturer_Code;
            }
        }

        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        public BARCODE_TYPE EncodedType
        {
            set
            {
                Encoded_Type = value;
            }

            get
            {
                return Encoded_Type;
            }
        }

        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        public Image EncodedImage
        {
            get
            {
                return _Encoded_Image;
            }
        }

        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return _ForeColor;
            }

            set
            {
                _ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }

            set
            {
                _BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the label font. (Default is Microsoft Sans Serif, 10pt, Bold)
        /// </summary>
        public Font LabelFont
        {
            get
            {
                return _LabelFont;
            }

            set
            {
                _LabelFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the location of the label in relation to the barcode. (BOTTOMCENTER is default)
        /// </summary>
        public LABEL_POSITIONS LabelPosition
        {
            get
            {
                return _LabelPosition;
            }

            set
            {
                _LabelPosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the degree in which to rotate/flip the image.(No action is default)
        /// </summary>
        public RotateFlipType RotateFlipType
        {
            get
            {
                return _RotateFlipType;
            }

            set
            {
                _RotateFlipType = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the image to be drawn. (Default is 300 pixels)
        /// </summary>
        public int Width
        {
            get
            {
                return _Width;
            }

            set
            {
                _Width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the image to be drawn. (Default is 150 pixels)
        /// </summary>
        public int Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
            }
        }

        /// <summary>
        ///   If non-null, sets the width of a bar. <see cref="Width"/> is ignored and calculated automatically.
        /// </summary>
        public int? BarWidth { get; set; }

        /// <summary>
        ///   If non-null, <see cref="Height"/> is ignored and set to <see cref="Width"/> divided by this value rounded down.
        /// </summary>
        /// <remarks><para>
        ///   As longer barcodes may be more difficult to align a scanner gun with,
        ///   growing the height based on the width automatically allows the gun to be rotated the
        ///   same amount regardless of how wide the barcode is. A recommended value is 2.
        ///   </para><para>
        ///   This value is applied to <see cref="Height"/> after after <see cref="Width"/> has been
        ///   calculated. So it is safe to use in conjunction with <see cref="BarWidth"/>.
        /// </para></remarks>
        /// 
        public double? AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets whether a label should be drawn below the image. (Default is false)
        /// </summary>
        public bool IncludeLabel { get; set; }

        /// <summary>
        /// Alternate label to be displayed.  (IncludeLabel must be set to true as well)
        /// </summary>
        public string AlternateLabel { get; set; }

        /// <summary>
        /// Gets or sets the amount of time in milliseconds that it took to encode and draw the barcode.
        /// </summary>
        public double EncodingTime { get; set; }

        /// <summary>
        /// Gets or sets the image format to use when encoding and returning images. (Jpeg is default)
        /// </summary>
        public ImageFormat ImageFormat
        {
            get
            {
                return _ImageFormat;
            }

            set
            {
                _ImageFormat = value;
            }
        }

        /// <summary>
        /// Gets the list of errors encountered.
        /// </summary>
        public List<string> Errors
        {
            get
            {
                return ibarcode.Errors;
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the barcode inside the image. (Not for Postnet or ITF-14)
        /// </summary>
        public ALIGNMENT_POSITION Alignment { get; set; }//Alignment

        /// <summary>
        /// Gets a byte array representation of the encoded image. (Used for Crystal Reports)
        /// </summary>
        public byte[] Encoded_Image_Bytes
        {
            get
            {
                if (_Encoded_Image == null)
                    return null;

                using (MemoryStream ms = new MemoryStream())
                {
                    _Encoded_Image.Save(ms, _ImageFormat);
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(BARCODE_TYPE iType, string StringToEncode, int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return Encode(iType, StringToEncode);
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(BARCODE_TYPE iType, string StringToEncode, Color ForeColor, Color BackColor, int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return Encode(iType, StringToEncode, ForeColor, BackColor);
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(BARCODE_TYPE iType, string StringToEncode, Color ForeColor, Color BackColor)
        {
            this.BackColor = BackColor;
            this.ForeColor = ForeColor;
            return Encode(iType, StringToEncode);
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(BARCODE_TYPE iType, string StringToEncode)
        {
            Raw_Data = StringToEncode;
            return Encode(iType);
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        internal Image Encode(BARCODE_TYPE iType)
        {
            Encoded_Type = iType;
            return Encode();
        }

        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.
        /// </summary>
        internal Image Encode()
        {
            ibarcode.Errors.Clear();
            DateTime dtStartTime = DateTime.Now;
            //make sure there is something to encode
            if (Raw_Data.Trim() == "")
                throw new Exception("EENCODE-1: Input data not allowed to be blank.");

            if (EncodedType == BARCODE_TYPE.UNSPECIFIED)
                throw new Exception("EENCODE-2: Symbology type not allowed to be unspecified.");

            Encoded_Value = "";
            _Country_Assigning_Manufacturer_Code = "N/A";

            switch (Encoded_Type)
            {
                case BARCODE_TYPE.UCC12:
                case BARCODE_TYPE.UPCA: //Encode_UPCA();
                    ibarcode = new UPCA(Raw_Data);
                    break;
                case BARCODE_TYPE.UCC13:
                case BARCODE_TYPE.EAN13: //Encode_EAN13();
                    ibarcode = new EAN13(Raw_Data);
                    break;
                case BARCODE_TYPE.Interleaved2of5: //Encode_Interleaved2of5();
                    ibarcode = new Interleaved2of5(Raw_Data);
                    break;
                case BARCODE_TYPE.Industrial2of5:
                case BARCODE_TYPE.Standard2of5: //Encode_Standard2of5();
                    ibarcode = new Standard2of5(Raw_Data);
                    break;
                case BARCODE_TYPE.LOGMARS:
                case BARCODE_TYPE.CODE39: //Encode_Code39();
                    ibarcode = new Code39(Raw_Data);
                    break;
                case BARCODE_TYPE.CODE39Extended:
                    ibarcode = new Code39(Raw_Data, true);
                    break;
                case BARCODE_TYPE.CODE39_Mod43:
                    ibarcode = new Code39(Raw_Data, false, true);
                    break;
                case BARCODE_TYPE.Codabar: //Encode_Codabar();
                    ibarcode = new Codabar(Raw_Data);
                    break;
                case BARCODE_TYPE.PostNet: //Encode_PostNet();
                    ibarcode = new Postnet(Raw_Data);
                    break;
                case BARCODE_TYPE.ISBN:
                case BARCODE_TYPE.BOOKLAND: //Encode_ISBN_Bookland();
                    ibarcode = new ISBN(Raw_Data);
                    break;
                case BARCODE_TYPE.JAN13: //Encode_JAN13();
                    ibarcode = new JAN13(Raw_Data);
                    break;
                case BARCODE_TYPE.UPC_SUPPLEMENTAL_2DIGIT: //Encode_UPCSupplemental_2();
                    ibarcode = new UPCSupplement2(Raw_Data);
                    break;
                case BARCODE_TYPE.MSI_Mod10:
                case BARCODE_TYPE.MSI_2Mod10:
                case BARCODE_TYPE.MSI_Mod11:
                case BARCODE_TYPE.MSI_Mod11_Mod10:
                case BARCODE_TYPE.Modified_Plessey: //Encode_MSI();
                    ibarcode = new MSI(Raw_Data, Encoded_Type);
                    break;
                case BARCODE_TYPE.UPC_SUPPLEMENTAL_5DIGIT: //Encode_UPCSupplemental_5();
                    ibarcode = new UPCSupplement5(Raw_Data);
                    break;
                case BARCODE_TYPE.UPCE: //Encode_UPCE();
                    ibarcode = new UPCE(Raw_Data);
                    break;
                case BARCODE_TYPE.EAN8: //Encode_EAN8();
                    ibarcode = new EAN8(Raw_Data);
                    break;
                case BARCODE_TYPE.USD8:
                case BARCODE_TYPE.CODE11: //Encode_Code11();
                    ibarcode = new Code11(Raw_Data);
                    break;
                case BARCODE_TYPE.CODE128: //Encode_Code128();
                    ibarcode = new Code128(Raw_Data);
                    break;
                case BARCODE_TYPE.CODE128A:
                    ibarcode = new Code128(Raw_Data, Code128.CODE128_TYPES.A);
                    break;
                case BARCODE_TYPE.CODE128B:
                    ibarcode = new Code128(Raw_Data, Code128.CODE128_TYPES.B);
                    break;
                case BARCODE_TYPE.CODE128C:
                    ibarcode = new Code128(Raw_Data, Code128.CODE128_TYPES.C);
                    break;
                case BARCODE_TYPE.ITF14:
                    ibarcode = new ITF14(Raw_Data);
                    break;
                case BARCODE_TYPE.CODE93:
                    ibarcode = new Code93(Raw_Data);
                    break;
                case BARCODE_TYPE.TELEPEN:
                    ibarcode = new Telepen(Raw_Data);
                    break;
                case BARCODE_TYPE.FIM:
                    ibarcode = new FIM(Raw_Data);
                    break;
                case BARCODE_TYPE.PHARMACODE:
                    ibarcode = new Pharmacode(Raw_Data);
                    break;
                default:
                    throw new Exception("EENCODE-2: Unsupported encoding type specified.");
            }

            Encoded_Value = ibarcode.Encoded_Value;
            Raw_Data = ibarcode.RawData;
            _Encoded_Image = Generate_Image();
            EncodedImage.RotateFlip(RotateFlipType);
            EncodingTime = (DateTime.Now - dtStartTime).TotalMilliseconds;

            return EncodedImage;
        }

        /// <summary>
        /// Gets a bitmap representation of the encoded data.
        /// </summary>
        /// <returns>Bitmap of encoded value.</returns>
        private Bitmap Generate_Image()
        {
            if (Encoded_Value == "")
                throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");
            Bitmap b = null;
            DateTime dtStartTime = DateTime.Now;
            switch (Encoded_Type)
            {
                case BARCODE_TYPE.ITF14:
                    {
                        // Automatically calculate the Width if applicable. Quite confusing with this
                        // barcode type, and it seems this method overestimates the minimum width. But
                        // at least it�s deterministic and doesn�t produce too small of a value.
                        if (BarWidth.HasValue)
                        {
                            // Width = (BarWidth * EncodedValue.Length) + bearerwidth + iquietzone
                            // Width = (BarWidth * EncodedValue.Length) + 2*Width/12.05 + 2*Width/20
                            // Width - 2*Width/12.05 - 2*Width/20 = BarWidth * EncodedValue.Length
                            // Width = (BarWidth * EncodedValue.Length)/(1 - 2/12.05 - 2/20)
                            // Width = (BarWidth * EncodedValue.Length)/((241 - 40 - 24.1)/241)
                            // Width = BarWidth * EncodedValue.Length / 176.9 * 241
                            // Rounding error? + 1
                            Width = (int)(241 / 176.9 * Encoded_Value.Length * BarWidth.Value + 1);
                        }
                        Height = (int?)(Width / AspectRatio) ?? Height;

                        int ILHeight = Height;
                        if (IncludeLabel)
                        {
                            ILHeight -= LabelFont.Height;
                        }

                        b = new Bitmap(Width, Height);

                        int bearerwidth = (int)((b.Width) / 12.05);
                        int iquietzone = Convert.ToInt32(b.Width * 0.05);
                        int iBarWidth = (b.Width - (bearerwidth * 2) - (iquietzone * 2)) / Encoded_Value.Length;
                        int shiftAdjustment = ((b.Width - (bearerwidth * 2) - (iquietzone * 2)) % Encoded_Value.Length) / 2;

                        if (iBarWidth <= 0 || iquietzone <= 0)
                            throw new Exception("EGENERATE_IMAGE-3: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel or quiet zone determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;
                        using (Graphics g = Graphics.FromImage(b))
                        {
                            //fill background
                            g.Clear(BackColor);

                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            using (Pen pen = new Pen(ForeColor, iBarWidth))
                            {
                                pen.Alignment = PenAlignment.Right;
                                while (pos < Encoded_Value.Length)
                                {
                                    //draw the appropriate color line vertically
                                    if (Encoded_Value[pos] == '1')
                                        g.DrawLine(pen, new Point((pos * iBarWidth) + shiftAdjustment + bearerwidth + iquietzone, 0), new Point((pos * iBarWidth) + shiftAdjustment + bearerwidth + iquietzone, Height));
                                    pos++;
                                }

                                //bearer bars
                                pen.Width = (float)ILHeight / 8;
                                pen.Color = ForeColor;
                                pen.Alignment = PenAlignment.Center;
                                g.DrawLine(pen, new Point(0, 0), new Point(b.Width, 0));//top
                                g.DrawLine(pen, new Point(0, ILHeight), new Point(b.Width, ILHeight));//bottom
                                g.DrawLine(pen, new Point(0, 0), new Point(0, ILHeight));//left
                                g.DrawLine(pen, new Point(b.Width, 0), new Point(b.Width, ILHeight));//right
                            }
                        }

                        if (IncludeLabel)
                            Label_ITF14((Image)b);
                        break;
                    }
                default:
                    {
                        // Automatically calculate Width if applicable.
                        Width = BarWidth * Encoded_Value.Length ?? Width;
                        // Automatically calculate Height if applicable.
                        Height = (int?)(Width / AspectRatio) ?? Height;

                        int ILHeight = Height;
                        int topLableAdjustment = 0;

                        if (IncludeLabel)
                        {
                            // Shift drawing down if top label.
                            if ((LabelPosition & (LABEL_POSITIONS.TOPCENTER | LABEL_POSITIONS.TOPLEFT | LABEL_POSITIONS.TOPRIGHT)) > 0)
                                topLableAdjustment = LabelFont.Height;

                            ILHeight -= LabelFont.Height;
                        }

                        b = new Bitmap(Width, Height);
                        int iBarWidth = Width / Encoded_Value.Length;
                        int shiftAdjustment = 0;
                        int iBarWidthModifier = 1;

                        if (Encoded_Type == BARCODE_TYPE.PostNet)
                            iBarWidthModifier = 2;

                        //set alignment
                        switch (Alignment)
                        {
                            case ALIGNMENT_POSITION.CENTER:
                                shiftAdjustment = (Width % Encoded_Value.Length) / 2;
                                break;
                            case ALIGNMENT_POSITION.LEFT:
                                shiftAdjustment = 0;
                                break;
                            case ALIGNMENT_POSITION.RIGHT:
                                shiftAdjustment = (Width % Encoded_Value.Length);
                                break;
                            default:
                                shiftAdjustment = (Width % Encoded_Value.Length) / 2;
                                break;
                        }

                        if (iBarWidth <= 0)
                            throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");

                        //draw image
                        int pos = 0;
                        int halfBarWidth = (int)(iBarWidth * 0.5);
                        using (Graphics g = Graphics.FromImage(b))
                        {
                            //clears the image and colors the entire background
                            g.Clear(BackColor);
                            //lines are fBarWidth wide so draw the appropriate color line vertically
                            using (Pen backpen = new Pen(BackColor, iBarWidth / iBarWidthModifier))
                            {
                                using (Pen pen = new Pen(ForeColor, iBarWidth / iBarWidthModifier))
                                {
                                    while (pos < Encoded_Value.Length)
                                    {
                                        if (Encoded_Type == BARCODE_TYPE.PostNet)
                                        {
                                            //draw half bars in postnet
                                            if (Encoded_Value[pos] == '0')
                                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLableAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, (ILHeight / 2) + topLableAdjustment));
                                            else
                                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLableAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, topLableAdjustment));
                                        }
                                        else
                                        {
                                            if (Encoded_Value[pos] == '1')
                                                g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, topLableAdjustment), new Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, ILHeight + topLableAdjustment));
                                        }
                                        pos++;
                                    }
                                }
                            }
                        }
                        if (IncludeLabel)
                        {
                            Label_Generic((Image)b);
                        }
                        break;
                    }
            }

            _Encoded_Image = (Image)b;
            EncodingTime += ((TimeSpan)(DateTime.Now - dtStartTime)).TotalMilliseconds;
            return b;
        }

        /// <summary>
        /// Gets the bytes that represent the image.
        /// </summary>
        /// <param name="savetype">File type to put the data in before returning the bytes.</param>
        /// <returns>Bytes representing the encoded image.</returns>
        public byte[] GetImageData(SAVE_TYPES savetype)
        {
            if (_Encoded_Image == null)
                return null;

            byte[] imageData = null;
            try
            {
                //Save the image to a memory stream so that we can get a byte array!      
                using (MemoryStream ms = new MemoryStream())
                {
                    SaveImage(ms, savetype);
                    imageData = ms.ToArray();
                    ms.Flush();
                    ms.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EGETIMAGEDATA-1: Could not retrieve image data. " + ex.Message);
            }
            return imageData;
        }

        /// <summary>
        /// Saves an encoded image to a specified file and type.
        /// </summary>
        /// <param name="Filename">Filename to save to.</param>
        /// <param name="FileType">Format to use.</param>
        public void SaveImage(string Filename, SAVE_TYPES FileType)
        {
            if (_Encoded_Image == null)
                return;
            try
            {
                ImageFormat imageformat;
                switch (FileType)
                {
                    case SAVE_TYPES.BMP:
                        imageformat = ImageFormat.Bmp;
                        break;
                    case SAVE_TYPES.GIF:
                        imageformat = ImageFormat.Gif;
                        break;
                    case SAVE_TYPES.JPG:
                        imageformat = ImageFormat.Jpeg;
                        break;
                    case SAVE_TYPES.PNG:
                        imageformat = ImageFormat.Png;
                        break;
                    case SAVE_TYPES.TIFF:
                        imageformat = ImageFormat.Tiff;
                        break;
                    default:
                        imageformat = ImageFormat;
                        break;
                }
                ((Bitmap)_Encoded_Image).Save(Filename, imageformat);
            }
            catch (Exception ex)
            {
                throw new Exception("ESAVEIMAGE-1: Could not save image.\n\n=======================\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Saves an encoded image to a specified stream.
        /// </summary>
        /// <param name="stream">Stream to write image to.</param>
        /// <param name="FileType">Format to use.</param>
        public void SaveImage(Stream stream, SAVE_TYPES FileType)
        {
            if (_Encoded_Image == null)
                return;
            try
            {
                ImageFormat imageformat;
                switch (FileType)
                {
                    case SAVE_TYPES.BMP:
                        imageformat = ImageFormat.Bmp;
                        break;
                    case SAVE_TYPES.GIF:
                        imageformat = ImageFormat.Gif;
                        break;
                    case SAVE_TYPES.JPG:
                        imageformat = ImageFormat.Jpeg;
                        break;
                    case SAVE_TYPES.PNG:
                        imageformat = ImageFormat.Png;
                        break;
                    case SAVE_TYPES.TIFF:
                        imageformat = ImageFormat.Tiff;
                        break;
                    default:
                        imageformat = ImageFormat;
                        break;
                }
                ((Bitmap)_Encoded_Image).Save(stream, imageformat);
            }
            catch (Exception ex)
            {
                throw new Exception("ESAVEIMAGE-2: Could not save image.\n\n=======================\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Returns the size of the EncodedImage in real world coordinates (millimeters or inches).
        /// </summary>
        /// <param name="Metric">Millimeters if true, otherwise Inches.</param>
        /// <returns></returns>
        public ImageSize GetSizeOfImage(bool Metric)
        {
            double Width = 0;
            double Height = 0;
            if (EncodedImage != null && EncodedImage.Width > 0 && EncodedImage.Height > 0)
            {
                double MillimetersPerInch = 25.4;
                using (var g = Graphics.FromImage(EncodedImage))
                {
                    Width = EncodedImage.Width / g.DpiX;
                    Height = EncodedImage.Height / g.DpiY;
                    if (Metric)
                    {
                        Width *= MillimetersPerInch;
                        Height *= MillimetersPerInch;
                    }
                }
            }

            return new ImageSize(Width, Height, Metric);
        }

        private Image Label_ITF14(Image img)
        {
            try
            {
                Font font = LabelFont;
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(img, (float)0, (float)0);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    //color a white box at the bottom of the barcode to hold the string of data
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, img.Height - (font.Height - 2), img.Width, font.Height));

                    //draw datastring under the barcode image
                    StringFormat f = new StringFormat();
                    f.Alignment = StringAlignment.Center;
                    g.DrawString(AlternateLabel == null ? RawData : AlternateLabel, font, new SolidBrush(ForeColor), (float)(img.Width / 2), img.Height - font.Height + 1, f);

                    Pen pen = new Pen(ForeColor, (float)img.Height / 16);
                    pen.Alignment = PenAlignment.Inset;
                    g.DrawLine(pen, new Point(0, img.Height - font.Height - 2), new Point(img.Width, img.Height - font.Height - 2));//bottom

                    g.Save();
                }
                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("ELABEL_ITF14-1: " + ex.Message);
            }
        }

        private Image Label_Generic(Image img)
        {
            try
            {
                Font font = LabelFont;
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(img, (float)0, (float)0);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    StringFormat f = new StringFormat();
                    f.Alignment = StringAlignment.Near;
                    f.LineAlignment = StringAlignment.Near;
                    int LabelX = 0;
                    int LabelY = 0;

                    switch (LabelPosition)
                    {
                        case LABEL_POSITIONS.BOTTOMCENTER:
                            LabelX = img.Width / 2;
                            LabelY = img.Height - (font.Height);
                            f.Alignment = StringAlignment.Center;
                            break;
                        case LABEL_POSITIONS.BOTTOMLEFT:
                            LabelX = 0;
                            LabelY = img.Height - (font.Height);
                            f.Alignment = StringAlignment.Near;
                            break;
                        case LABEL_POSITIONS.BOTTOMRIGHT:
                            LabelX = img.Width;
                            LabelY = img.Height - (font.Height);
                            f.Alignment = StringAlignment.Far;
                            break;
                        case LABEL_POSITIONS.TOPCENTER:
                            LabelX = img.Width / 2;
                            LabelY = 0;
                            f.Alignment = StringAlignment.Center;
                            break;
                        case LABEL_POSITIONS.TOPLEFT:
                            LabelX = img.Width;
                            LabelY = 0;
                            f.Alignment = StringAlignment.Near;
                            break;
                        case LABEL_POSITIONS.TOPRIGHT:
                            LabelX = img.Width;
                            LabelY = 0;
                            f.Alignment = StringAlignment.Far;
                            break;
                    }

                    //color a background color box at the bottom of the barcode to hold the string of data
                    g.FillRectangle(new SolidBrush(BackColor), new RectangleF((float)0, (float)LabelY, (float)img.Width, (float)font.Height));
                    //draw datastring under the barcode image
                    g.DrawString(AlternateLabel == null ? RawData : AlternateLabel, font, new SolidBrush(ForeColor), new RectangleF((float)0, (float)LabelY, (float)img.Width, (float)font.Height), f);
                    g.Save();
                }
                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("ELABEL_GENERIC-1: " + ex.Message);
            }
        }

        /// <summary>
        /// Draws Label for UPC-A barcodes (NOT COMPLETE)
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private Image Label_UPCA(Image img)
        {
            try
            {
                int iBarWidth = Width / Encoded_Value.Length;
                int shiftAdjustment = 0;
                //set alignment
                switch (Alignment)
                {
                    case ALIGNMENT_POSITION.CENTER:
                        shiftAdjustment = (Width % Encoded_Value.Length) / 2;
                        break;
                    case ALIGNMENT_POSITION.LEFT:
                        shiftAdjustment = 0;
                        break;
                    case ALIGNMENT_POSITION.RIGHT:
                        shiftAdjustment = (Width % Encoded_Value.Length);
                        break;
                    default:
                        shiftAdjustment = (Width % Encoded_Value.Length) / 2;
                        break;
                }

                Font font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, ((Byte)(0))); ;
                using (var g = Graphics.FromImage(img))
                {
                    g.DrawImage(img, (float)0, (float)0);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    //draw datastring under the barcode image
                    RectangleF rect = new RectangleF((iBarWidth * 3) + shiftAdjustment, this.Height - (int)(this.Height * 0.1), (iBarWidth * 43), (int)(this.Height * 0.1));
                    g.FillRectangle(new SolidBrush(Color.Yellow), rect.X, rect.Y, rect.Width, rect.Height);
                    g.DrawString(this.RawData.Substring(1, 5), font, new SolidBrush(this.ForeColor), rect.X, rect.Y);
                    g.Save();
                }
                return img;
            }
            catch (Exception ex)
            {
                throw new Exception("ELABEL_UPCA-1: " + ex.Message);
            }
        }

        public void Dispose()
        {
        }
    }
}