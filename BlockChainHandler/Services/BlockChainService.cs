using BlockChainHandler.Interfaces;
using BlockChainHandler.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EventHandler;

namespace BlockChainHandler.Services
{
    public class BlockChainService : IBlockChainService
    {

        private readonly ILogger<BlockChainService> _logger;
        private BlockChain BlockChain;
        public BlockChainService(BlockChain blockChain, ILogger<BlockChainService> logger)
        {
            _logger = logger;
            BlockChain = blockChain;
        }

        public void AddNewTransactions(List<Transaction> transactions, string SenderAddress)
        {
            EventHub.Publish_MinigRequest(new BlockChainEventArgs(SenderAddress, transactions));
        }

        public List<Block> GetChain()
        {
            return BlockChain.Chain;
        }
    }
}
