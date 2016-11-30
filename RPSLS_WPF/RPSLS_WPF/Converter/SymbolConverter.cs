﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using RPSLS_WPF.RPSLSService;

namespace RPSLS_WPF.Converter { 
    public class SymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var symbol = (Symbol)value;
            var txt = "";
            switch (symbol)
            {
                case Symbol.ROCK:
                    txt = "rock";
                    break;
                case Symbol.PAPER:
                    txt = "paper";
                    break;
                case Symbol.SCISSORS:
                    txt = "scissors";
                    break;
                case Symbol.LIZARD:
                    txt = "lizard";
                    break;
                case Symbol.SPOCK:
                    txt = "spock";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return txt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}