using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainHandler.Models
{
    public class Transaction
    {
        #region Props
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public double Amount { get; set; }

        public readonly DateTime TimeStamp;

        #endregion
        #region Ctor
        public Transaction()
        {

        }
        public Transaction(string fromAddress,string toAddress, double amount)
        {
            FromAddress = FromAddress;
            ToAddress = toAddress;
            Amount = amount;
            TimeStamp = DateTime.Now;
        }
        #endregion

        #region Methods

        
        #endregion

    }
}
