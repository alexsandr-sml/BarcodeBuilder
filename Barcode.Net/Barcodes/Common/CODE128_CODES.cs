﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode.Net.Barcodes.Common
{
    public static class CODE128_CODES
    {
        public static readonly Dictionary<int, Code128Element> Codes = new Dictionary<int, Code128Element>()
        {
            { 000, new Code128Element() { Id = 000, A = " ",  B = " ",  C = "00", Encoding = "11011001100" } },
            { 001, new Code128Element() { Id = 001, A = "!",  B = "!",  C = "01", Encoding = "11001101100" } },
            { 002, new Code128Element() { Id = 002, A = "\"", B = "\"", C = "02", Encoding = "11001100110" } },
            { 003, new Code128Element() { Id = 003, A = "#",  B = "#",  C = "03", Encoding = "10010011000" } },
            { 004, new Code128Element() { Id = 004, A = "$",  B = "$",  C = "04", Encoding = "10010001100" } },
            { 005, new Code128Element() { Id = 005, A = "%",  B = "%",  C = "05", Encoding = "10001001100" } },
            { 006, new Code128Element() { Id = 006, A = "&",  B = "&",  C = "06", Encoding = "10011001000" } },
            { 007, new Code128Element() { Id = 007, A = "'",  B = "'",  C = "07", Encoding = "10011000100" } },
            { 008, new Code128Element() { Id = 008, A = "(",  B = "(",  C = "08", Encoding = "10001100100" } },
            { 009, new Code128Element() { Id = 009, A = ")",  B = ")",  C = "09", Encoding = "11001001000" } },
            { 010, new Code128Element() { Id = 010, A = "*",  B = "*",  C = "10", Encoding = "11001000100" } },
            { 011, new Code128Element() { Id = 011, A = "+",  B = "+",  C = "11", Encoding = "11000100100" } },
            { 012, new Code128Element() { Id = 012, A = ",",  B = ",",  C = "12", Encoding = "10110011100" } },
            { 013, new Code128Element() { Id = 013, A = "-",  B = "-",  C = "13", Encoding = "10011011100" } },
            { 014, new Code128Element() { Id = 014, A = ".",  B = ".",  C = "14", Encoding = "10011001110" } },
            { 015, new Code128Element() { Id = 015, A = "/",  B = "/",  C = "15", Encoding = "10111001100" } },
            { 016, new Code128Element() { Id = 016, A = "0",  B = "0",  C = "16", Encoding = "10011101100" } },
            { 017, new Code128Element() { Id = 017, A = "1",  B = "1",  C = "17", Encoding = "10011100110" } },
            { 018, new Code128Element() { Id = 018, A = "2",  B = "2",  C = "18", Encoding = "11001110010" } },
            { 019, new Code128Element() { Id = 019, A = "3",  B = "3",  C = "19", Encoding = "11001011100" } },
            { 020, new Code128Element() { Id = 020, A = "4",  B = "4",  C = "20", Encoding = "11001001110" } },
            { 021, new Code128Element() { Id = 021, A = "5",  B = "5",  C = "21", Encoding = "11011100100" } },
            { 022, new Code128Element() { Id = 022, A = "6",  B = "6",  C = "22", Encoding = "11001110100" } },
            { 023, new Code128Element() { Id = 023, A = "7",  B = "7",  C = "23", Encoding = "11101101110" } },
            { 024, new Code128Element() { Id = 024, A = "8",  B = "8",  C = "24", Encoding = "11101001100" } },
            { 025, new Code128Element() { Id = 025, A = "9",  B = "9",  C = "25", Encoding = "11100101100" } },
            { 026, new Code128Element() { Id = 026, A = ":",  B = ":",  C = "26", Encoding = "11100100110" } },
            { 027, new Code128Element() { Id = 027, A = ";",  B = ";",  C = "27", Encoding = "11101100100" } },
            { 028, new Code128Element() { Id = 028, A = "<",  B = "<",  C = "28", Encoding = "11100110100" } },
            { 029, new Code128Element() { Id = 029, A = "=",  B = "=",  C = "29", Encoding = "11100110010" } },
            { 030, new Code128Element() { Id = 030, A = ">",  B = ">",  C = "30", Encoding = "11011011000" } },
            { 031, new Code128Element() { Id = 031, A = "?",  B = "?",  C = "31", Encoding = "11011000110" } },
            { 032, new Code128Element() { Id = 032, A = "@",  B = "@",  C = "32", Encoding = "11000110110" } },
            { 033, new Code128Element() { Id = 033, A = "A",  B = "A",  C = "33", Encoding = "10100011000" } },
            { 034, new Code128Element() { Id = 034, A = "B",  B = "B",  C = "34", Encoding = "10001011000" } },
            { 035, new Code128Element() { Id = 035, A = "C",  B = "C",  C = "35", Encoding = "10001000110" } },
            { 036, new Code128Element() { Id = 036, A = "D",  B = "D",  C = "36", Encoding = "10110001000" } },
            { 037, new Code128Element() { Id = 037, A = "E",  B = "E",  C = "37", Encoding = "10001101000" } },
            { 038, new Code128Element() { Id = 038, A = "F",  B = "F",  C = "38", Encoding = "10001100010" } },
            { 039, new Code128Element() { Id = 039, A = "G",  B = "G",  C = "39", Encoding = "11010001000" } },
            { 040, new Code128Element() { Id = 040, A = "H",  B = "H",  C = "40", Encoding = "11000101000" } },
            { 041, new Code128Element() { Id = 041, A = "I",  B = "I",  C = "41", Encoding = "11000100010" } },
            { 042, new Code128Element() { Id = 042, A = "J",  B = "J",  C = "42", Encoding = "10110111000" } },
            { 043, new Code128Element() { Id = 043, A = "K",  B = "K",  C = "43", Encoding = "10110001110" } },
            { 044, new Code128Element() { Id = 044, A = "L",  B = "L",  C = "44", Encoding = "10001101110" } },
            { 045, new Code128Element() { Id = 045, A = "M",  B = "M",  C = "45", Encoding = "10111011000" } },
            { 046, new Code128Element() { Id = 046, A = "N",  B = "N",  C = "46", Encoding = "10111000110" } },
            { 047, new Code128Element() { Id = 047, A = "O",  B = "O",  C = "47", Encoding = "10001110110" } },
            { 048, new Code128Element() { Id = 048, A = "P",  B = "P",  C = "48", Encoding = "11101110110" } },
            { 049, new Code128Element() { Id = 049, A = "Q",  B = "Q",  C = "49", Encoding = "11010001110" } },
            { 050, new Code128Element() { Id = 050, A = "R",  B = "R",  C = "50", Encoding = "11000101110" } },
            { 051, new Code128Element() { Id = 051, A = "S",  B = "S",  C = "51", Encoding = "11011101000" } },
            { 052, new Code128Element() { Id = 052, A = "T",  B = "T",  C = "52", Encoding = "11011100010" } },
            { 053, new Code128Element() { Id = 053, A = "U",  B = "U",  C = "53", Encoding = "11011101110" } },
            { 054, new Code128Element() { Id = 054, A = "V",  B = "V",  C = "54", Encoding = "11101011000" } },
            { 055, new Code128Element() { Id = 055, A = "W",  B = "W",  C = "55", Encoding = "11101000110" } },
            { 056, new Code128Element() { Id = 056, A = "X",  B = "X",  C = "56", Encoding = "11100010110" } },
            { 057, new Code128Element() { Id = 057, A = "Y",  B = "Y",  C = "57", Encoding = "11101101000" } },
            { 058, new Code128Element() { Id = 058, A = "Z",  B = "Z",  C = "58", Encoding = "11101100010" } },
            { 059, new Code128Element() { Id = 059, A = "[",  B = "[",  C = "59", Encoding = "11100011010" } },
            { 060, new Code128Element() { Id = 060, A = "\\", B = "\\", C = "60", Encoding = "11101111010" } },
            { 061, new Code128Element() { Id = 061, A = "]",  B = "]",  C = "61", Encoding = "11001000010" } },
            { 062, new Code128Element() { Id = 062, A = "^",  B = "^",  C = "62", Encoding = "11110001010" } },
            { 063, new Code128Element() { Id = 063, A = "_",  B = "_",  C = "63", Encoding = "10100110000" } },
            { 064, new Code128Element() { Id = 064, A = "\0", B = "`",  C = "64", Encoding = "10100001100" } },
            { 065, new Code128Element() { Id = 065, A = $"{Convert.ToChar(001)}",  B = "a",  C = "65", Encoding = "10010110000" } },
            { 066, new Code128Element() { Id = 066, A = $"{Convert.ToChar(002)}",  B = "b",  C = "66", Encoding = "10010000110" } },
            { 067, new Code128Element() { Id = 067, A = $"{Convert.ToChar(003)}",  B = "c",  C = "67", Encoding = "10000101100" } },
            { 068, new Code128Element() { Id = 068, A = $"{Convert.ToChar(004)}",  B = "d",  C = "68", Encoding = "10000100110" } },
            { 069, new Code128Element() { Id = 069, A = $"{Convert.ToChar(005)}",  B = "e",  C = "69", Encoding = "10110010000" } },
            { 070, new Code128Element() { Id = 070, A = $"{Convert.ToChar(006)}",  B = "f",  C = "70", Encoding = "10110000100" } },
            { 071, new Code128Element() { Id = 071, A = $"{Convert.ToChar(007)}",  B = "g",  C = "71", Encoding = "10011010000" } },
            { 072, new Code128Element() { Id = 072, A = $"{Convert.ToChar(008)}",  B = "h",  C = "72", Encoding = "10011000010" } },
            { 073, new Code128Element() { Id = 073, A = $"{Convert.ToChar(009)}",  B = "i",  C = "73", Encoding = "10000110100" } },
            { 074, new Code128Element() { Id = 074, A = $"{Convert.ToChar(010)}",  B = "j",  C = "74", Encoding = "10000110010" } },
            { 075, new Code128Element() { Id = 075, A = $"{Convert.ToChar(011)}",  B = "k",  C = "75", Encoding = "11000010010" } },
            { 076, new Code128Element() { Id = 076, A = $"{Convert.ToChar(012)}",  B = "l",  C = "76", Encoding = "11001010000" } },
            { 077, new Code128Element() { Id = 077, A = $"{Convert.ToChar(013)}",  B = "m",  C = "77", Encoding = "11110111010" } },
            { 078, new Code128Element() { Id = 078, A = $"{Convert.ToChar(014)}",  B = "n",  C = "78", Encoding = "11000010100" } },
            { 079, new Code128Element() { Id = 079, A = $"{Convert.ToChar(015)}",  B = "o",  C = "79", Encoding = "10001111010" } },
            { 080, new Code128Element() { Id = 080, A = $"{Convert.ToChar(016)}",  B = "p",  C = "80", Encoding = "10100111100" } },
            { 081, new Code128Element() { Id = 081, A = $"{Convert.ToChar(017)}",  B = "q",  C = "81", Encoding = "10010111100" } },
            { 082, new Code128Element() { Id = 082, A = $"{Convert.ToChar(018)}",  B = "r",  C = "82", Encoding = "10010011110" } },
            { 083, new Code128Element() { Id = 083, A = $"{Convert.ToChar(019)}",  B = "s",  C = "83", Encoding = "10111100100" } },
            { 084, new Code128Element() { Id = 084, A = $"{Convert.ToChar(020)}",  B = "t",  C = "84", Encoding = "10011110100" } },
            { 085, new Code128Element() { Id = 085, A = $"{Convert.ToChar(021)}",  B = "u",  C = "85", Encoding = "10011110010" } },
            { 086, new Code128Element() { Id = 086, A = $"{Convert.ToChar(022)}",  B = "v",  C = "86", Encoding = "11110100100" } },
            { 087, new Code128Element() { Id = 087, A = $"{Convert.ToChar(023)}",  B = "w",  C = "87", Encoding = "11110010100" } },
            { 088, new Code128Element() { Id = 088, A = $"{Convert.ToChar(024)}",  B = "x",  C = "88", Encoding = "11110010010" } },
            { 089, new Code128Element() { Id = 089, A = $"{Convert.ToChar(025)}",  B = "y",  C = "89", Encoding = "11011011110" } },
            { 090, new Code128Element() { Id = 090, A = $"{Convert.ToChar(026)}",  B = "z",  C = "90", Encoding = "11011110110" } },
            { 091, new Code128Element() { Id = 091, A = $"{Convert.ToChar(027)}",  B = "{",  C = "91", Encoding = "11110110110" } },
            { 092, new Code128Element() { Id = 092, A = $"{Convert.ToChar(028)}",  B = "|",  C = "92", Encoding = "10101111000" } },
            { 093, new Code128Element() { Id = 093, A = $"{Convert.ToChar(029)}",  B = "}",  C = "93", Encoding = "10100011110" } },
            { 094, new Code128Element() { Id = 094, A = $"{Convert.ToChar(030)}",  B = "~",  C = "94", Encoding = "10001011110" } },

            { 095, new Code128Element() { Id = 095, A = $"{Convert.ToChar(031)}",  B = $"{Convert.ToChar(127)}",  C = "95", Encoding = "10111101000" } },
            { 096, new Code128Element() { Id = 096, A = $"{Convert.ToChar(202)}",  B = $"{Convert.ToChar(202)}",  C = "96", Encoding = "10111100010" } }, //FNC3
            { 097, new Code128Element() { Id = 097, A = $"{Convert.ToChar(201)}",  B = $"{Convert.ToChar(201)}",  C = "97", Encoding = "11110101000" } }, //FNC2
            { 098, new Code128Element() { Id = 098, A = $"SHIFT",  B = $"SHIFT",  C = "98", Encoding = "11110100010" } },
            { 099, new Code128Element() { Id = 099, A = $"CODE_C",  B = $"CODE_C",  C = "99", Encoding = "10111011110" } },
            { 100, new Code128Element() { Id = 100, A = $"CODE_B",  B = $"{Convert.ToChar(203)}",  C = "CODE_B", Encoding = "10111101110" } }, //FNC4
            { 101, new Code128Element() { Id = 101, A = $"{Convert.ToChar(203)}",  B = $"CODE_A",  C = "CODE_A", Encoding = "11101011110" } }, //FNC4
            { 102, new Code128Element() { Id = 102, A = $"{Convert.ToChar(200)}",  B = $"{Convert.ToChar(200)}",  C = $"{Convert.ToChar(200)}", Encoding = "11110101110" } }, //FNC1
            { 103, new Code128Element() { Id = 103, A = $"START_A",  B = $"START_A",  C = "START_A", Encoding = "11010000100" } },
            { 104, new Code128Element() { Id = 104, A = $"START_B",  B = $"START_B",  C = "START_B", Encoding = "11010010000" } },
            { 105, new Code128Element() { Id = 105, A = $"START_C",  B = $"START_C",  C = "START_C", Encoding = "11010011100" } },
            { 106, new Code128Element() { Id = 106, A = $"STOP",  B = $"STOP",  C = "STOP", Encoding = "11000111010" } },
            { 107, new Code128Element() { Id = 107, A = $"TERM",  B = $"TERM",  C = "TERM", Encoding = "11" } },
            { 108, new Code128Element() { Id = 108, A = $"WhiteZone",  B = $"WhiteZone",  C = "WhiteZone", Encoding = "0000000000" } }
        };

        public static readonly Dictionary<string, int> ACodes = new Dictionary<string, int>()
        {
            { " ",  000 },
            { "!",  001 },
            { "\"", 002 },
            { "#",  003 },
            { "$",  004 },
            { "%",  005 },
            { "&",  006 },
            { "'",  007 },
            { "(",  008 },
            { ")",  009 },
            { "*",  010 },
            { "+",  011 },
            { ",",  012 },
            { "-",  013 },
            { ".",  014 },
            { "/",  015 },
            { "0",  016 },
            { "1",  017 },
            { "2",  018 },
            { "3",  019 },
            { "4",  020 },
            { "5",  021 },
            { "6",  022 },
            { "7",  023 },
            { "8",  024 },
            { "9",  025 },
            { ":",  026 },
            { ";",  027 },
            { "<",  028 },
            { "=",  029 },
            { ">",  030 },
            { "?",  031 },
            { "@",  032 },
            { "A",  033 },
            { "B",  034 },
            { "C",  035 },
            { "D",  036 },
            { "E",  037 },
            { "F",  038 },
            { "G",  039 },
            { "H",  040 },
            { "I",  041 },
            { "J",  042 },
            { "K",  043 },
            { "L",  044 },
            { "M",  045 },
            { "N",  046 },
            { "O",  047 },
            { "P",  048 },
            { "Q",  049 },
            { "R",  050 },
            { "S",  051 },
            { "T",  052 },
            { "U",  053 },
            { "V",  054 },
            { "W",  055 },
            { "X",  056 },
            { "Y",  057 },
            { "Z",  058 },
            { "[",  059 },
            { "\\", 060 },
            { "]",  061 },
            { "^",  062 },
            { "_",  063 },
            { "\0", 064 },
            { $"{Convert.ToChar(001)}", 065 },
            { $"{Convert.ToChar(002)}", 066 },
            { $"{Convert.ToChar(003)}", 067 },
            { $"{Convert.ToChar(004)}", 068 },
            { $"{Convert.ToChar(005)}", 069 },
            { $"{Convert.ToChar(006)}", 070 },
            { $"{Convert.ToChar(007)}", 071 },
            { $"{Convert.ToChar(008)}", 072 },
            { $"{Convert.ToChar(009)}", 073 },
            { $"{Convert.ToChar(010)}", 074 },
            { $"{Convert.ToChar(011)}", 075 },
            { $"{Convert.ToChar(012)}", 076 },
            { $"{Convert.ToChar(013)}", 077 },
            { $"{Convert.ToChar(014)}", 078 },
            { $"{Convert.ToChar(015)}", 079 },
            { $"{Convert.ToChar(016)}", 080 },
            { $"{Convert.ToChar(017)}", 081 },
            { $"{Convert.ToChar(018)}", 082 },
            { $"{Convert.ToChar(019)}", 083 },
            { $"{Convert.ToChar(020)}", 084 },
            { $"{Convert.ToChar(021)}", 085 },
            { $"{Convert.ToChar(022)}", 086 },
            { $"{Convert.ToChar(023)}", 087 },
            { $"{Convert.ToChar(024)}", 088 },
            { $"{Convert.ToChar(025)}", 089 },
            { $"{Convert.ToChar(026)}", 090 },
            { $"{Convert.ToChar(027)}", 091 },
            { $"{Convert.ToChar(028)}", 092 },
            { $"{Convert.ToChar(029)}", 093 },
            { $"{Convert.ToChar(030)}", 094 },
            { $"{Convert.ToChar(031)}", 095 },
            { $"{Convert.ToChar(202)}", 096 }, //FNC3
            { $"{Convert.ToChar(201)}", 097 }, //FNC2
            { "SHIFT", 098 },
            { "CODE_C", 099 },
            { "CODE_B", 100 }, //FNC4
            { $"{Convert.ToChar(203)}", 101 }, //FNC4
            { $"{Convert.ToChar(200)}", 102 }, //FNC1
            { "START_A", 103 },
            { "START_B", 104 },
            { "START_C", 105 },
            { "STOP", 106 },
            { "TERM", 107 },
            { "WhiteZone", 108 }
        };

        public static readonly Dictionary<string, int> BCodes = new Dictionary<string, int>()
        {
            { " ",  000 },
            { "!",  001 },
            { "\"", 002 }, 
            { "#",  003 },
            { "$",  004 },
            { "%",  005 },
            { "&",  006 },
            { "'",  007 },
            { "(",  008 },
            { ")",  009 },
            { "*",  010 },
            { "+",  011 },
            { ",",  012 },
            { "-",  013 },
            { ".",  014 },
            { "/",  015 },
            { "0",  016 },
            { "1",  017 },
            { "2",  018 },
            { "3",  019 },
            { "4",  020 },
            { "5",  021 },
            { "6",  022 },
            { "7",  023 },
            { "8",  024 },
            { "9",  025 },
            { ":",  026 },
            { ";",  027 },
            { "<",  028 },
            { "=",  029 },
            { ">",  030 },
            { "?",  031 },
            { "@",  032 },
            { "A",  033 },
            { "B",  034 },
            { "C",  035 },
            { "D",  036 },
            { "E",  037 },
            { "F",  038 },
            { "G",  039 },
            { "H",  040 },
            { "I",  041 },
            { "J",  042 },
            { "K",  043 },
            { "L",  044 },
            { "M",  045 },
            { "N",  046 },
            { "O",  047 },
            { "P",  048 },
            { "Q",  049 },
            { "R",  050 },
            { "S",  051 },
            { "T",  052 },
            { "U",  053 },
            { "V",  054 },
            { "W",  055 },
            { "X",  056 },
            { "Y",  057 },
            { "Z",  058 },
            { "[",  059 },
            { "\\", 060 },
            { "]",  061 },
            { "^",  062 },
            { "_",  063 },
            { "\0", 064 },
            { "a",  065 },
            { "b",  066 },
            { "c",  067 },
            { "d",  068 },
            { "e",  069 },
            { "f",  070 },
            { "g",  071 },
            { "h",  072 },
            { "i",  073 },
            { "j",  074 },
            { "k",  075 },
            { "l",  076 },
            { "m",  077 },
            { "n",  078 },
            { "o",  079 },
            { "p",  080 },
            { "q",  081 },
            { "r",  082 },
            { "s",  083 },
            { "t",  084 },
            { "u",  085 },
            { "v",  086 },
            { "w",  087 },
            { "x",  088 },
            { "y",  089 },
            { "z",  090 },
            { "{",  091 },
            { "|",  092 },
            { "}",  093 },
            { "~",  094 },
            { $"{Convert.ToChar(127)}", 095 },
            { $"{Convert.ToChar(202)}", 096 }, //FNC3
            { $"{Convert.ToChar(201)}", 097 }, //FNC2
            { "SHIFT", 098 },
            { "CODE_C", 099 },
            { $"{Convert.ToChar(203)}", 100 }, //FNC4
            { "CODE_A", 101 }, //FNC4
            { $"{Convert.ToChar(200)}", 102 }, //FNC1
            { "START_A", 103 },
            { "START_B", 104 },
            { "START_C", 105 },
            { "STOP", 106 },
            { "TERM", 107 },
            { "WhiteZone", 108 }
        };

        public static readonly Dictionary<string, int> CCodes = new Dictionary<string, int>()
        {
            { "00", 000 },
            { "01", 001 },
            { "02", 002 },
            { "03", 003 },
            { "04", 004 },
            { "05", 005 },
            { "06", 006 },
            { "07", 007 },
            { "08", 008 },
            { "09", 009 },
            { "10", 010 },
            { "11", 011 },
            { "12", 012 },
            { "13", 013 },
            { "14", 014 },
            { "15", 015 },
            { "16", 016 },
            { "17", 017 },
            { "18", 018 },
            { "19", 019 },
            { "20", 020 },
            { "21", 021 },
            { "22", 022 },
            { "23", 023 },
            { "24", 024 },
            { "25", 025 },
            { "26", 026 },
            { "27", 027 },
            { "28", 028 },
            { "29", 029 },
            { "30", 030 },
            { "31", 031 },
            { "32", 032 },
            { "33", 033 },
            { "34", 034 },
            { "35", 035 },
            { "36", 036 },
            { "37", 037 },
            { "38", 038 },
            { "39", 039 },
            { "40", 040 },
            { "41", 041 },
            { "42", 042 },
            { "43", 043 },
            { "44", 044 },
            { "45", 045 },
            { "46", 046 },
            { "47", 047 },
            { "48", 048 },
            { "49", 049 },
            { "50", 050 },
            { "51", 051 },
            { "52", 052 },
            { "53", 053 },
            { "54", 054 },
            { "55", 055 },
            { "56", 056 },
            { "57", 057 },
            { "58", 058 },
            { "59", 059 },
            { "60", 060 },
            { "61", 061 },
            { "62", 062 },
            { "63", 063 },
            { "64", 064 },
            { "65", 065 },
            { "66", 066 },
            { "67", 067 },
            { "68", 068 },
            { "69", 069 },
            { "70", 070 },
            { "71", 071 },
            { "72", 072 },
            { "73", 073 },
            { "74", 074 },
            { "75", 075 },
            { "76", 076 },
            { "77", 077 },
            { "78", 078 },
            { "79", 079 },
            { "80", 080 },
            { "81", 081 },
            { "82", 082 },
            { "83", 083 },
            { "84", 084 },
            { "85", 085 },
            { "86", 086 },
            { "87", 087 },
            { "88", 088 },
            { "89", 089 },
            { "90", 090 },
            { "91", 091 },
            { "92", 092 },
            { "93", 093 },
            { "94", 094 },
            { "95", 095 },
            { "96", 096 },
            { "97", 097 },
            { "98", 098 },
            { "99", 099 },
            { "CODE_B", 100 }, //FNC4
            { "CODE_A", 101 }, //FNC4
            { $"{Convert.ToChar(200)}", 102 }, //FNC1
            { "START_A", 103 },
            { "START_B", 104 },
            { "START_C", 105 },
            { "STOP", 106 },
            { "TERM", 107 },
            { "WhiteZone", 108 }
        };

        public static readonly Dictionary<int, string> Encoding = new Dictionary<int, string>()
        {
            { 000, "11011001100" },
            { 001, "11001101100" },
            { 002, "11001100110" },
            { 003, "10010011000" },
            { 004, "10010001100" },
            { 005, "10001001100" },
            { 006, "10011001000" },
            { 007, "10011000100" },
            { 008, "10001100100" },
            { 009, "11001001000" },
            { 010, "11001000100" },
            { 011, "11000100100" },
            { 012, "10110011100" },
            { 013, "10011011100" },
            { 014, "10011001110" },
            { 015, "10111001100" },
            { 016, "10011101100" },
            { 017, "10011100110" },
            { 018, "11001110010" },
            { 019, "11001011100" },
            { 020, "11001001110" },
            { 022, "11001110100" },
            { 023, "11101101110" },
            { 024, "11101001100" },
            { 025, "11100101100" },
            { 026, "11100100110" },
            { 027, "11101100100" },
            { 028, "11100110100" },
            { 029, "11100110010" },
            { 030, "11011011000" },
            { 031, "11011000110" },
            { 032, "11000110110" },
            { 033, "10100011000" },
            { 034, "10001011000" },
            { 035, "10001000110" },
            { 036, "10110001000" },
            { 037, "10001101000" },
            { 038, "10001100010" },
            { 039, "11010001000" },
            { 040, "11000101000" },
            { 041, "11000100010" },
            { 042, "10110111000" },
            { 043, "10110001110" },
            { 044, "10001101110" },
            { 045, "10111011000" },
            { 046, "10111000110" },
            { 047, "10001110110" },
            { 048, "11101110110" },
            { 049, "11010001110" },
            { 050, "11000101110" },
            { 051, "11011101000" },
            { 052, "11011100010" },
            { 053, "11011101110" },
            { 054, "11101011000" },
            { 055, "11101000110" },
            { 056, "11100010110" },
            { 057, "11101101000" },
            { 058, "11101100010" },
            { 059, "11100011010" },
            { 060, "11101111010" },
            { 061, "11001000010" },
            { 062, "11110001010" },
            { 063, "10100110000" },
            { 064, "10100001100" },
            { 065, "10010110000" },
            { 066, "10010000110" },
            { 067, "10000101100" },
            { 068, "10000100110" },
            { 069, "10110010000" },
            { 070, "10110000100" },
            { 071, "10011010000" },
            { 072, "10011000010" },
            { 073, "10000110100" },
            { 074, "10000110010" },
            { 075, "11000010010" },
            { 076, "11001010000" },
            { 077, "11110111010" },
            { 078, "11000010100" },
            { 079, "10001111010" },
            { 080, "10100111100" },
            { 081, "10010111100" },
            { 082, "10010011110" },
            { 083, "10111100100" },
            { 084, "10011110100" },
            { 085, "10011110010" },
            { 086, "11110100100" },
            { 087, "11110010100" },
            { 088, "11110010010" },
            { 089, "11011011110" },
            { 090, "11011110110" },
            { 091, "11110110110" },
            { 092, "10101111000" },
            { 093, "10100011110" },
            { 094, "10001011110" },
            { 095, "10111101000" },
            { 096, "10111100010" }, //FNC3
            { 097, "11110101000" }, //FNC2
            { 098, "11110100010" },
            { 099, "10111011110" },
            { 100, "10111101110" }, //FNC4
            { 101, "11101011110" }, //FNC4
            { 102, "11110101110" }, //FNC1
            { 103, "11010000100" }, //START_A
            { 104, "11010010000" }, //START_B
            { 105, "11010011100" }, //START_C
            { 106, "11000111010" }, //STOP
            { 107, "11" }, //TERM
            { 108, "0000000000" } //WhiteZone
        };
    }
}
