﻿using Safety_app.Validation.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safety_app.Validation
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}