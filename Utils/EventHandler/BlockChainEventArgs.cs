using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.EventHandler
{
    public class BlockChainEventArgs
    {
        #region Props
        public object Sender { get; set; }
        public object Data { get; set; }
        #endregion

        #region Ctor
        public BlockChainEventArgs(object sender, object data)
        {
            Sender = sender;
            Data = data;
        }
        #endregion

    }
}
