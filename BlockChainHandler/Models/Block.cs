using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainHandler.Models
{
    public class Block
    {
        #region Props
        private DateTime TimeStamp { get; set; }
        public string PreviousBlockHash { get; set; }
        private List<Transaction> Data { get; set; }
        public string Hash { get; set; }
        private long Nonce { get; set; }
        #endregion

        #region ctor
        public Block(List<Transaction> data, string previousBlockHash)
        {
            TimeStamp = DateTime.Now;
            Data = data;
            PreviousBlockHash = previousBlockHash;
            Hash = "";
        }
        #endregion

        #region Methods


        public void Mining(int proofOfWorkDifficulty)
        {
            var proofOfWorkStr = new string('0', proofOfWorkDifficulty);

            do
            {

                Hash = CalculateHash();
                Nonce++;

            } while (Hash.Substring(0, proofOfWorkDifficulty) != proofOfWorkStr);

            TimeStamp = DateTime.Now;
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            string rawData = PreviousBlockHash + TimeStamp.ToString() + JsonConvert.SerializeObject(Data) + Nonce;
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { Hash, PreviousBlockHash, TimeStamp });
        }
        #endregion
    }
}
