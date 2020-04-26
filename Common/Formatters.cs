//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pumpet.net@gmail.com
//  Git: https://github.com/Pumpet/Robin
//  Copyright (C) Alex Rozanov, 2020 
//

using System;

namespace Common {
    public class BoolFormatter : ICustomFormatter, IFormatProvider {
        public object GetFormat(Type formatType) {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider) {
            if (arg == null)
                return string.Empty;
            bool value = (bool)arg;
            string res;
            switch (format ?? string.Empty) {
                case "YesNo":
                    res = value ? "Yes" : "No";
                    break;
                case "OnOff":
                    res = value ? "On" : "Off";
                    break;
                case "YesNoRus":
                    res = value ? "Да" : "Нет";
                    break;
                case "Mark":
                    res = value ? "√" : "";
                    break;
                default:
                    res = value.ToString();
                    break;
            }
            return res;
        }
    }
}
