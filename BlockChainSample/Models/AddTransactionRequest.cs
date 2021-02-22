using BlockChainHandler.Models;
using PeerToPeerSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainSample.Models
{
    public class AddTransactionRequest
    {
        public string SenderAddress { get; set; }
        public List<Transaction> Transactions { get; set; }


    }
}
