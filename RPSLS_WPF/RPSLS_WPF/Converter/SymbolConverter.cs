using System;
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
                    txt = "Rock";
                    break;
                case Symbol.PAPER:
                    txt = "Paper";
                    break;
                case Symbol.SCISSORS:
                    txt = "Scissors";
                    break;
                case Symbol.LIZARD:
                    txt = "Lizard";
                    break;
                case Symbol.SPOCK:
                    txt = "Spock";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return txt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            Symbol s;
            switch (text)
            {
                case "rock":
                    s = Symbol.ROCK;
                    break;
                case "paper":
                    s = Symbol.PAPER;
                    break;
                case "scissors":
                    s = Symbol.SCISSORS;
                    break;
                case "lizard":
                    s = Symbol.LIZARD;
                    break;
                case "spock":
                    s = Symbol.SPOCK;
                    break;
                default: throw new InvalidEnumArgumentException();
            }
            return s;
        }
    }
}