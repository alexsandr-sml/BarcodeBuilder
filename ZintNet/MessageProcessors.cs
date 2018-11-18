/* MessageProcessors.cs - Pre processors for the barcode data to be encoded */

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
using System.Globalization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZintNet
{
    /// <summary>
    /// Performs preprocessing checks of the barcode data.
    /// </summary>
    internal static class MessagePreProcessor
    {
        /// <summary>
        /// Check that the message format conforms with the HIBC stardard
        /// </summary>
        /// <param name="message">input message</param>
        /// <returns>character array holding the message</returns>

        public static char[] HIBCParser(string message)
        {
            if (message.Length > 110)
                throw new InvalidDataLengthException("HIBC: Input data too long.");

            foreach (char c in message)
            {
                if (CharacterSets.Code39Set.IndexOf(c) == -1)
                    throw new InvalidDataException("HIBC: Invalid data in input.");
            }

            // First character must be a HIBC Supplier Labeling flag.
            if (message[0] != '+')
                message = "+" + message;

            return message.ToCharArray();
        }

        /// <summary>
        /// Checks for valid characters and the correct formation of the AI's.
        /// </summary>
        /// <param name="message">input message</param>
        /// <returns>character array holding the message</returns>

        public static char[] AIParser(string message)
        {
            char[] barcodeData;
            StringBuilder bcData = new StringBuilder();
            bool invalidData;
            string aiString;
            int[] aiValue = new int[100];
            int[] aiLocation = new int[100];
            int[] dataLocation = new int[100];
            int[] dataLength = new int[100];
            int inputLength = message.Length;

            // Detect extended ASCII characters.
            for (int i = 0; i < inputLength; i++)
            {
                if (message[i] >= 128)
                    throw new InvalidDataException("GS1: Extended ASCII characters are not supported.");

                if (message[i] < 32)
                    throw new InvalidDataException("GS1: Control characters are not supported.");
            }

            // GS1 must start with an AI.
            if (message[0] != '[')
                throw new InvalidDataFormatException("GS1: Format must start with an Application Identifier.");

            int bracketLevel = 0;
            int maxBracketLevel = 0;
            int aiLength = 0;
            int maxAILength = 0;
            int minAILength = 5;
            int j = 0;
            invalidData = false;

            // Check the bracket formatting and inputLength of AI's.
            for (int i = 0; i < inputLength; i++)
            {
                aiLength += j;
                if (j == 1 && message[i] != ']' && (message[i] < '0' || message[i] > '9'))
                    invalidData = true;

                if (message[i] == '[')
                {
                    bracketLevel++;
                    j = 1;
                }

                if (message[i] == ']')
                {
                    bracketLevel--;
                    if (aiLength < minAILength)
                        minAILength = aiLength;

                    j = 0;
                    aiLength = 0;
                }

                if (bracketLevel > maxBracketLevel)
                    maxBracketLevel = bracketLevel;

                if (aiLength > maxAILength)
                    maxAILength = aiLength;
            }

            minAILength--;

            if (bracketLevel != 0 || maxBracketLevel > 1)	// AI brackets not formatted correctly.
                throw new InvalidDataFormatException("GS1: Invalid Application Identifier formatting.");

            if (maxAILength > 4 || minAILength <= 1)	// AI is too long or too short.
                throw new InvalidDataFormatException("GS1: Invalid length for an Application Identifier.");

            if (invalidData == true)	// Non-numeric data in AI.
                throw new InvalidDataFormatException("GS1: Non-numeric data in Application Identifier.");

            // Find the number of AI's in the message.
            int aiCount = 0;
            for (int i = 1; i < inputLength; i++)
            {
                if (message[i - 1] == '[')
                {
                    aiString = String.Empty;
                    aiLocation[aiCount] = i;
                    j = 0;
                    do
                    {
                        aiString += message[i + j];
                        j++;
                    }
                    while (aiString[j - 1] != ']');

                    aiString = aiString.Substring(0, j - 1);
                    aiValue[aiCount] = int.Parse(aiString, CultureInfo.CurrentCulture);
                    aiCount++;
                }
            }

            for (int i = 0; i < aiCount; i++)
            {
                dataLocation[i] = aiLocation[i] + 3;
                if (aiValue[i] >= 100)
                    dataLocation[i]++;

                if (aiValue[i] >= 1000)
                    dataLocation[i]++;

                dataLength[i] = 0;
                do
                    dataLength[i]++;
                while ((dataLocation[i] + dataLength[i] - 1) < inputLength &&
                    message[dataLocation[i] + dataLength[i] - 1] != '[');

                dataLength[i]--;
            }

            for (int i = 0; i < aiCount; i++)
            {
                if (dataLength[i] == 0)	// No data for given AI.
                    throw new InvalidDataFormatException("GS1: No data field for AI.");
            }

            int errorValue = 0;
            aiString = String.Empty;
            for (int i = 0; i < aiCount; i++)
            {
                switch (aiValue[i])
                {
                    case 0:
                        if (dataLength[i] != 18)
                            errorValue = 1;

                        break;

                    case 1:
                    case 2:
                    case 3:
                        if (dataLength[i] != 14)
                            errorValue = 1;

                        break;

                    case 4:
                        if (dataLength[i] != 16)
                            errorValue = 1;

                        break;

                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        if (dataLength[i] != 6)
                            errorValue = 1;
                        break;

                    case 20:
                        if (dataLength[i] != 2)
                            errorValue = 1;
                        break;

                    case 21:
                        if (dataLength[i] > 20)
                            errorValue = 1;
                        break;

                    case 22:
                        if (dataLength[i] > 29)
                            errorValue = 1;
                        break;

                    case 23:
                    case 24:
                    case 25:
                    case 39:
                    case 40:
                    case 41:
                    case 42:
                    case 70:
                    case 80:
                    case 81:
                        errorValue = 2;
                        break;

                    case 90:
                    case 91:
                    case 92:
                    case 93:
                    case 94:
                    case 95:
                    case 96:
                    case 97:
                    case 98:
                    case 99:
                        if (dataLength[i] > 30)
                            errorValue = 1;
                        break;
                }

                if ((aiValue[i] >= 100 && aiValue[i] <= 179)
                    || (aiValue[i] >= 1000 && aiValue[i] <= 1799)
                    || (aiValue[i] >= 200 && aiValue[i] <= 229)
                    || (aiValue[i] >= 2000 && aiValue[i] <= 2299)
                    || (aiValue[i] >= 300 && aiValue[i] <= 309)
                    || (aiValue[i] >= 3000 && aiValue[i] <= 3099)
                    || (aiValue[i] >= 31 && aiValue[i] <= 36)
                    || (aiValue[i] >= 310 && aiValue[i] <= 369))
                    errorValue = 2;

                if (aiValue[i] >= 3100 && aiValue[i] <= 3699)
                {
                    if (dataLength[i] != 6)
                        errorValue = 1;
                }

                if ((aiValue[i] >= 370 && aiValue[i] <= 379) || (aiValue[i] >= 3700 && aiValue[i] <= 3799))
                    errorValue = 2;

                if (aiValue[i] >= 410 && aiValue[i] <= 415)
                {
                    if (dataLength[i] != 13)
                        errorValue = 1;
                }

                if ((aiValue[i] >= 4100 && aiValue[i] <= 4199)
                    || (aiValue[i] >= 700 && aiValue[i] <= 703)
                    || (aiValue[i] >= 800 && aiValue[i] <= 810)
                    || (aiValue[i] >= 900 && aiValue[i] <= 999)
                    || (aiValue[i] >= 9000 && aiValue[i] <= 9999))
                    errorValue = 2;

                if (errorValue < 4 && errorValue > 0)
                    aiString = String.Format(CultureInfo.CurrentCulture, "{0:d2}", aiValue[i]);     // Error has just been detected: capture AI.

                if (errorValue == 1)
                    throw new InvalidDataFormatException("GS1: Invalid data length for AI[" + aiString + "].");

                if (errorValue == 2)
                    throw new InvalidDataFormatException("GS1: Invalid AI value[" + aiString + "].");
            }

            // Resolve AI data.
            int lastAI = 0;
            bool aiLatch = true;

            for (int i = 0; i < inputLength; i++)
            {
                if (message[i] != '[' && message[i] != ']')
                    bcData.Append(message[i]);

                if (message[i] == '[')
                {
                    // Start of an AI string.
                    if (aiLatch == false)
                        //sb.Append(Convert.ToChar(232));
                        bcData.Append("[");

                    aiString = message.Substring(i + 1, 2);
                    lastAI = int.Parse(aiString, CultureInfo.CurrentCulture);
                    aiLatch = false;
                    // The following values from GS-1 General Specification version 8.0 issue 2, May 2008
                    // figure 5.4.8.2.1 - 1 Element Strings with Pre-Defined Length Using Application Identifiers.
                    if ((lastAI >= 0 && lastAI <= 4)
                        || (lastAI >= 11 && lastAI <= 20)
                        || lastAI == 23	 // Legacy support - see 5.3.8.2.2.
                        || (lastAI >= 31 && lastAI <= 36)
                        || lastAI == 41)
                        aiLatch = true;
                }
                // The ']' character is simply dropped from the input.
            }

            // The character '[' in the returned string refers to the FNC1 character.
            return barcodeData = bcData.ToString().ToCharArray();
        }


        /// <summary>
        /// Processes the barcode message and process any 'tilde' values.
        /// </summary>
        /// <remarks>
        /// Takes the message string and copies it to the barcode character array, processing any 'tilde' values.
        /// 1 digit decimal values ~@ to ~'
        /// Or 3 digit decimal values from ~000 to ~255
        /// Suitable for symbols that accept values 0 to 255
        /// </remarks>
        /// <param name="message">barcode message string</param>
        /// <returns>character array holding the message</returns>
        public static char[] TildeParser(string message)
        {
            int inputLength = message.Length;
            StringBuilder bcData = new StringBuilder();

            for (int i = 0; i < inputLength; i++)
            {
                // Has a tilde command fllowed by a single character in the range @ to '.
                // eg. ~M
                if (message[i] == '~' && i != (inputLength - 1))
                {
                    // Look ahead one character and test it's in the range "@ to '".
                    // If it is, translate to decimal "000 to 031".
                    int nextChar = (int)(message[i + 1]);
                    if (nextChar > 63 && nextChar < 97)
                    {
                        bcData.Append((char)(nextChar - 64));
                        i++;
                        continue;
                    }

                    // Maybe a 3 character tilde command.
                    else if (i < (inputLength - 3))
                    {
                        // Look ahead 3 characters, try to translate to an integer value.
                        // If sucessful add the ascii value to the message array.
                        // Else treat each character as individual values.
                        int asciiValue;
                        string asciiString = message.Substring(i + 1, 3);
                        if (int.TryParse(asciiString, out asciiValue))
                        {
                            if (asciiValue < 256)
                            {
                                bcData.Append((char)asciiValue);
                                i += 3;
                            }

                            else   // Added 30/03/2017
                                throw new InvalidDataException("Tilde value in input data not valid.");
                        }

                        continue;
                    }
                }

                char c = message[i];
                if (c == (char)(13))
                {
                    bcData.Append(c);
                    bcData.Append((char)10);
                    i++;
                }

                else
                    bcData.Append(c);
            }

            return bcData.ToString().ToCharArray();
        }

        /// <summary>
        /// Returns the message without any preprocessing or checks.
        /// </summary>
        /// <param name="message">input message</param>
        /// <returns>character array holding the message</returns>
        public static char[] MessageParser(string message)
        {
            return message.ToCharArray();
        }

        /// <summary>
        /// Passes an input message of numeric values only.
        /// </summary>
        /// <param name="message">input message</param>
        /// <returns>character array holding the message</returns>
        public static char[] NumericOnlyParser(string message)
        {
            foreach (char c in message)
            {
                if (!char.IsDigit(c))
                    throw new InvalidDataException("Numeric only data expected.");
            }

            return message.ToCharArray();
        }
    }
}