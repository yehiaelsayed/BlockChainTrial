using BlockChainHandler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainHandler.Interfaces
{
    public interface IBlockChainService
    {
        void AddNewTransactions(List<Transaction> transactions, string SenderAddress);

        List<Block> GetChain();
    }
}
