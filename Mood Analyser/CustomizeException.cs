﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analyser
{
    public class CustomizeException: Exception
    {
        MyException Exception;
        public enum MyException
        {
            NULL_ARGUMENT, EMPTY_INPUT_MRSSAGE
        }

        public CustomizeException(MyException exception,string message) : base(message)
        {
            this.Exception = exception;
        }
    }
}