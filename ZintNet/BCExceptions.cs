/* BCExceptions.cs - Exception handlers for ZintNet */

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
using System.Runtime.Serialization;
using System.Linq;
using System.Text;

namespace ZintNet
{
    [Serializable]
    public class ZintNetDLLException : System.Exception
    {
        private static string baseMessage = "ZintNet DLL error.";
        /// <summary>
        /// An exception occurred generating the barcode.
        /// </summary>
        public ZintNetDLLException()
            : base()
        { }

        /// <summary>
        /// An exception occurred generating the barcode.
        /// </summary>
        /// <param name="message">message.</param>
        public ZintNetDLLException(string message)
            : base(baseMessage + Environment.NewLine + message)
        { }

        /// <summary>
        /// An exception occurred generating the barcode.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">inner exception.</param>
        public ZintNetDLLException(string message, Exception innerException)
            : base(baseMessage + Environment.NewLine + message, innerException)
        { }

        /// <summary>
        /// An exception occurred generating the barcode.
        /// </summary>
        /// <param name="info">serialization info.</param>
        /// <param name="context">streaming context.</param>
        protected ZintNetDLLException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }

	[Serializable]
	public class InvalidDataException : System.Exception
	{
	private	static string baseMessage  = "Invalid data found in the barcode message.";
	
		public InvalidDataException()
			: base( baseMessage )
		{}

		public InvalidDataException( string message ) 
			: base( baseMessage + Environment.NewLine + message )
		{}

		public InvalidDataException( string message, Exception innerException) 
			: base( baseMessage + Environment.NewLine + message, innerException )
		{}

	protected InvalidDataException( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{}
	}

    [Serializable]
    public class InvalidSymbolSizeException : System.Exception
    {
        private static string baseMessage = "Invalid symbol size.";

        public InvalidSymbolSizeException()
            : base(baseMessage)
        { }

        public InvalidSymbolSizeException(string message)
            : base(baseMessage + Environment.NewLine + message)
        { }

        public InvalidSymbolSizeException(string message, Exception innerException)
            : base(baseMessage + Environment.NewLine + message, innerException)
        { }

        protected InvalidSymbolSizeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }

	[Serializable]
	public class InvalidDataLengthException : System.Exception
	{
	    public InvalidDataLengthException()
			: base()
		{} 

	    public InvalidDataLengthException( string message ) 
			: base( message )
		{}

		public InvalidDataLengthException( string message, Exception innerException ) 
			: base( message, innerException )
		{}

	protected InvalidDataLengthException( SerializationInfo info, StreamingContext context ) :
			 base( info, context )
		{}
	}

	[Serializable]
	public class InvalidDataFormatException : System.Exception
	{
	private	static string baseMessage = "Data format error in the barcode message.";

	    public InvalidDataFormatException()
			: base( baseMessage )
		{} 

		public InvalidDataFormatException( string message ) 
			: base( baseMessage + Environment.NewLine + message )
		{}

		public InvalidDataFormatException( string message, Exception innerException ) 
			: base( baseMessage + Environment.NewLine + message, innerException )
		{}

	    protected InvalidDataFormatException( SerializationInfo info, StreamingContext context )
            : base( info, context )
		{}
	}

    [Serializable]
    public class ErrorCorrectionLevelException : System.Exception
    {
        private static string mbaseMessage = "Error correction level not supported.";

        public ErrorCorrectionLevelException()
            : base(mbaseMessage)
        { }

        public ErrorCorrectionLevelException(string message)
            : base(mbaseMessage + Environment.NewLine + message)
        { }

        public ErrorCorrectionLevelException(string message, Exception innerException)
            : base(mbaseMessage + Environment.NewLine + message, innerException)
        { }

        protected ErrorCorrectionLevelException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }

    [Serializable]
    public class DataEncodingException : System.Exception
    {
        private static string baseMessage = "Error encoding barcode data.";

        public DataEncodingException()
            : base(baseMessage)
        { }

        public DataEncodingException(string message)
            : base(baseMessage + Environment.NewLine + message)
        { }

        public DataEncodingException(string message, Exception innerException)
            : base(baseMessage + Environment.NewLine + message, innerException)
        { }

        protected DataEncodingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }

    [Serializable]
    public class UnknownSymbolException : System.Exception
    {
        private static string baseMessage = "Unsupported or unknown symbol: ";

        public UnknownSymbolException()
            : base(baseMessage)
        { }

        public UnknownSymbolException(string message)
            : base(baseMessage + message)
        { }

        public UnknownSymbolException(string message, Exception innerException)
            : base(baseMessage + Environment.NewLine + message, innerException)
        { }

        protected UnknownSymbolException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}