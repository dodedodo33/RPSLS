using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RPSLS_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRPLSPSService" in both code and config file together.
    [ServiceContract]
    public interface IRPSLSService
    {
        [OperationContract]
        Result SendMove(string name, Symbol symbol);
    }

    public enum Symbol
    {
        ROCK,
        PAPER,
        SCISSORS,
        LIZARD,
        SPOCK
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Result
    {
        [DataMember]
        public Symbol UserSymbol { get; set; }

        [DataMember]
        public Symbol ComputerSymbol { get; set; }

        [DataMember]
        public DateTime GameTime { get; set; }

        [DataMember]
        public string Winner { get; set; }
    }
}