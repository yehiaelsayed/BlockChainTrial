using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainHandler.Interfaces;
using BlockChainSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeerToPeerSimulator.Network;

namespace BlockChainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockChainController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BlockChainController> _logger;
        private readonly IBlockChainService _blockChainService;
        private readonly NetworkSimulator _networkSimulator;
        public BlockChainController(ILogger<BlockChainController> logger, IBlockChainService blockChainService, NetworkSimulator networkSimulator)
        {

            _logger = logger;
            _blockChainService = blockChainService;
            _networkSimulator = networkSimulator;
        }

        [HttpPost, Route("~/network/AddPeer")]
        public ActionResult AddPeer(AddPeerRequest peer)
        {
            var NewPeer = _networkSimulator.AddPeer(peer.computingPower);


            return Ok(NewPeer);
        }
        [HttpGet, Route("~/network/peers")]
        public ActionResult GetPeers()
        {
            var peers = _networkSimulator.GetPeers();

            return Ok(peers);
        }

        [HttpPost, Route("AddTransactions")]
        public ActionResult AddTransactions(AddTransactionRequest data)
        {

            _blockChainService.AddNewTransactions(data.Transactions, data.SenderAddress);

            return Ok();
        }

        [HttpGet, Route("GetChain")]
        public ActionResult GetChain()
        {
            var chain=_blockChainService.GetChain();

            return Ok(chain);
        }


        
    }
}
