using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.EventHandler
{
    public static class EventHub
    {

        #region Props
        public static event Action<BlockChainEventArgs> NewBlockAdded;

        public static event Action<BlockChainEventArgs> SyncChain;

        public static event Action<BlockChainEventArgs> MinigRequest;

        public static event Action<BlockChainEventArgs> MiningFinished;

        public static event Action<BlockChainEventArgs> NewPeerConected;

        public static event Action<BlockChainEventArgs> PeerLeaved;
        #endregion
        #region Methods
        public static void Puplish_MiningFinished(BlockChainEventArgs args)
        {
            MiningFinished(args);
        }

        public static void Publish_NewPeerConected(BlockChainEventArgs args)
        {
            if (NewPeerConected!=null)
            {
                NewPeerConected(args);
            }
        }

        public static void Publish_PeerLeaved(BlockChainEventArgs args)
        {
            PeerLeaved(args);
        }

        public static void Publish_MinigRequest(BlockChainEventArgs args) {

            MinigRequest(args);
        }
        #endregion
    }
}
