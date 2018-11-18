/* BCEnums.cs - Enumerations for ZintNet */

/*
    Copyright (C) 2013-2016 Milton Neal <milton200954@gmail.com>

    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions
    are met:

    1. Redistributions of source code must retain the above copyright
       notice, this list of conditions and the following disclaimer.
    2. Redistributions in binary form must reproduce the above copyright
       notice, this list of conditions and the following disclaimer in the
       documentation and/or other materials provided with the distribution.
    3. Neither the name of the project nor the names of its contributors
       may be used to endorse or promote products derived from this software
       without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
    ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
    ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
    FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
    DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
    OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
    HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
    LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
    OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
    SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZintNet
{
    /// <summary>
    /// Enumeration of Symbol ID's
    /// </summary>
	public enum Symbology : int
	{
        CodeOne = 0,
		Code39,
		Code39Extended,
        LOGMARS,
        Code32,
        PharmaZentralNummer,
        Pharmacode,
        Pharmacode2Track, 
		Code93,
        ChannelCode,
        Telepen,
        TelepenNumeric,
		Code128,
        EAN14,
        SSCC18,
		Standard2of5,
		Interleaved2of5,
        Matrix2of5,
        IATA2of5,
        DataLogic2of5,
		ITF14,
        DeutschePostIdentCode,
        DeutshePostLeitCode,
		Codabar,
		MSIPlessey,
        UKPlessey,
		Code11,
		ISBN,
		EAN13,
		EAN8,
		UPCA,
		UPCE,
        DatabarOmni,
        DatabarOmniStacked,
        DatabarStacked,
        DatabarTruncated,
        DatabarLimited,
        DatabarExpanded,
        DatabarExpandedStacked,
        DataMatrix,
        QRCode,
        MicroQRCode,
        Aztec,
        AztecRunes,
        MaxiCode,
        PDF417,
        PDF417Truncated,
        MicroPDF417,
        AusPostStandard,
        AusPostReplyPaid,
        AusPostRedirect,
        AusPostRouting,
        USPS,
        PostNet,
        Planet,
        KoreaPost,
        FIM,
        RoyalMail,
        KixCode,
        DaftCode,
        Flattermarken,
        JapanPost,
        CodablockF,
        Code16K,
        DotCode,
        GridMatrix,
        Code49,
        HanXin,
        Invalid = -1
	}

	public enum TextPosition
	{
		UnderBarcode = 0,
		AboveBarcode
	}

	public enum TextAlignment
	{
		Center = 0, 
		Left, 
		Right,
		Stretch
	}

    public enum ITF14BearerStyle
    {
        None = 0,
        Horizonal,
        Rectangle
    }

    public enum AusPostEncoding
    {
        Numeric = 0,
        Character,
        Custom
    }

	public enum MSICheckDigitType
	{
        None = 0,
		Mod10,
        Mod10Mod10,
		Mod11,
        Mod11Mod10
	}

	public enum I2of5CheckDigitType
	{
		USS = 0,
		OPCC
		
	}

    public enum QRCodeErrorLevel
    {
        Low = 0,
        Medium,
        Quartile,
        High
    }

    public enum EncodingMode
    {
        Standard = 0,
        GS1,
        HIBC
    }

    public enum CompositeMode
    {
        CCA = 0,
        CCB,
        CCC
    }

    public enum MaxicodeMode
    {
        Mode2 = 0,
        Mode3,
        Mode4,
        Mode5,
        Mode6
    }

    public enum DataMatrixSize : int
    {
        Automatic = 0,
        DM10X10,
        DM12X12,
        DM14X14,
        DM16X16,
        DM18X18,
        DM20X20,
        DM22X22,
        DM24X24,
        DM26X26,
        DM32X32,
        DM36X36,
        DM40X40,
        DM44X44,
        DM48X48,
        DM52X52,
        DM64X64,
        DM72X72,
        DM80X80,
        DM88X88,
        DM96X96,
        DM104X104,
        DM120X120,
        DM132X132,
        DM144X144,
        DM8X18,
        DM8X32,
        DM12X26,
        DM12X36,
        DM16X36,
        DM16X48,
        DM8X48,
        DM8X64,
        DM12X64,
        DM16X64,
        DM24X32,
        DM24X40,
        DM24X48,
        DM24X64,
        DM26X32,
        DM26X40,
        DM26X48,
        DM26X64,
    }
}