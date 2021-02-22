using BlockChainHandler.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PeerToPeerSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.EventHandler;

namespace PeerToPeerSimulator.Network
{
    public class NetworkSimulator
    {
        #region Props
        private List<Peer> Peers { get; set; }

        private BlockChain BlockChain { get; set; }

        private ILogger<NetworkSimulator> Logger { get; set; }
        #endregion

        #region Ctor
        public NetworkSimulator(BlockChain blockChain, ILogger<NetworkSimulator> logger)
        {
            Peers = new List<Peer>();
            BlockChain = blockChain;
            Logger = logger;
        }
        #endregion

        #region Methods

        public Peer AddPeer(int computingPower)
        {
            
            //var peer = new Peer(computingPower, BlockChain.GetCopy());
            var peer = new Peer(computingPower, BlockChain);

            Peers.Add(peer);

            EventHub.Publish_NewPeerConected(new BlockChainEventArgs(peer, peer));
            Logger.LogInformation($"New Peer Connected :{peer.ToString()} Peers Count:{Peers.Count}");
            return peer;
        }

        public void RemovePeer(Guid address)
        {
            var peer = Peers.Where(p => p.Address == address).FirstOrDefault();
            if (peer != null)
            {
                Peers.Remove(peer);
                EventHub.Publish_PeerLeaved(new BlockChainEventArgs(peer, peer));
            }
        }

        public List<Peer> GetPeers() {

            return Peers;
        }

       
        #endregion
    }
}
