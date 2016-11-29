using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RPSLS_WCF
{
    public class RPSLSService : IRPSLSService
    {
        private readonly Dictionary<Symbol, List<Symbol>> _beats;

        public RPSLSService()
        {
            _beats = new Dictionary<Symbol, List<Symbol>>()
            {
                {Symbol.ROCK, new List<Symbol>() {Symbol.SCISSORS, Symbol.LIZARD}},
                {Symbol.PAPER, new List<Symbol>() {Symbol.ROCK, Symbol.SPOCK}},
                {Symbol.SCISSORS, new List<Symbol>() {Symbol.PAPER, Symbol.LIZARD}},
                {Symbol.LIZARD, new List<Symbol>() {Symbol.PAPER, Symbol.SPOCK}},
                {Symbol.SPOCK, new List<Symbol>() {Symbol.SCISSORS, Symbol.ROCK}}
            };
        }

        public Result SendMove(string name, Symbol symbol)
        {
            var values = (Symbol[])Enum.GetValues(typeof(Symbol));
            var computerSymbol = values[new Random().Next(0, values.Length)];
            var winner = "draw";
            if (_beats[symbol].Contains(computerSymbol))
            {
                winner = name;
            } else if (_beats[computerSymbol].Contains(symbol))
            {
                winner = "computer";
            }
            return new Result() {UserSymbol = symbol, ComputerSymbol = computerSymbol, Winner = winner, GameTime = new DateTime()};
        }
    }
}
