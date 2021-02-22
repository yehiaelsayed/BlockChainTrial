using BlockChainHandler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.EventHandler;

namespace PeerToPeerSimulator.Models
{
    public class Peer
    {
        #region Props

        private int computingPower;
        public int ComputingPower
        {
            get { return computingPower; }
            set
            {
                if (value <= 10) { computingPower = value; } else { computingPower = 10; }
            }
        }
        public Guid Address { get; set; }

        
        private BlockChain BlockChain { get; set; }

        #endregion Props

        #region Ctor

        public Peer(int computingPower,BlockChain blockChainCopy)
        {
            ComputingPower = computingPower;
            Address = Guid.NewGuid();
            EventHub.MinigRequest += Handle_MinigRequest;
            EventHub.MiningFinished += Handle_MiningFinished;
            BlockChain = blockChainCopy;
        }

        #endregion

        #region Methods

        private void Handle_MinigRequest(BlockChainEventArgs args)
        {
            MiningBlock(args);
        }

        private async void MiningBlock(BlockChainEventArgs args)
        {
            var sender = (args.Sender as string);
            var transactions = (args.Data as List<Transaction>);
            if (sender != null && transactions != null)
            {
                if (sender != this.Address.ToString())
                {
                    BlockChain.AddToTransactionPool(transactions);
                    BlockChain.MineBlock(this.Address.ToString());

                    await Task.Delay(TimeSpan.FromSeconds(10 - computingPower));

                    EventHub.Puplish_MiningFinished(new BlockChainEventArgs(this.Address.ToString(), BlockChain.Chain));
                }
            }
        }
        private void Handle_MiningFinished(BlockChainEventArgs args)
        {
            var sender = (args.Sender as string);
            var newChain = (args.Data as List<Block>);
            if (sender != null && newChain != null)
            {
                if (sender != this.Address.ToString())
                {
                    BlockChain.RefeshChain(newChain);
                }
            }
        }

        public override string ToString()
        {
            return $"[Address: {Address.ToString()}, ComputingPower: {computingPower}]";
        }

        #endregion
    }
}
