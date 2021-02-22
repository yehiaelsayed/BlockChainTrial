using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChainHandler.Models
{
    public class BlockChain
    {
        #region Props
        private readonly int ProofOfWorkDifficulty;
        private readonly double MiningReward;
        private List<Transaction> PendingTransactions;
        public List<Block> Chain { get; private set; }
        #endregion

        #region Ctor
        public BlockChain(int proofOfWorkDifficulty, int miningReward)
        {
            ProofOfWorkDifficulty = proofOfWorkDifficulty;
            MiningReward = miningReward;
            PendingTransactions = new List<Transaction>();
            Chain = new List<Block> { CreateGenesisBlock() };
        }
        #endregion

        #region Methods

        public void MineBlock(string minerAddress)
        {
            Transaction minerRewardTransaction = new Transaction(null, minerAddress, MiningReward);
            AddToTransactionPool(minerRewardTransaction);
            var lastBlockHash = Chain.Last().Hash;

            Block block = new Block(PendingTransactions, lastBlockHash);
            block.Mining(ProofOfWorkDifficulty);
            Chain.Add(block);
            PendingTransactions = new List<Transaction>();
        }

        private bool IsValidChain(List<Block> chain)
        {
            bool isValid = false;
            for (int i = 1; i < chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];
                if (currentBlock.Hash != currentBlock.CalculateHash() || currentBlock.PreviousBlockHash != previousBlock.Hash)
                {
                    isValid = false;
                    break;
                }

            }
            return isValid;
        }

        public bool ValidateChain()
        {
            return IsValidChain(Chain);
        }
        public void RefeshChain(List<Block> newChain)
        {
            if (IsValidChain(newChain) && newChain.Count > Chain.Count)
            {
                Chain = newChain;
            }
        }
        public void AddToTransactionPool(List<Transaction> transactions)
        {
            PendingTransactions.AddRange(transactions);

        }
        public void AddToTransactionPool(Transaction transaction)
        {
            PendingTransactions.Add(transaction);
        }

        private Block CreateGenesisBlock()
        {
            var transactions = new List<Transaction> { new Transaction("", "", 0) };
            var block = new Block(transactions, "0");
            block.Mining(1);
            return block;
        }

        public BlockChain GetCopy()
        {
            // not best practice but it is just a quic way to get deep copy from the object
            return JsonConvert.DeserializeObject<BlockChain>(JsonConvert.SerializeObject(this));
        }
        #endregion

    }
}
