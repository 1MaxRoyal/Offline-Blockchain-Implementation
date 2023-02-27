using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlockchainAssignment
{
    class Block
    {
        //data that is stored within every block
        private DateTime createDate;
        private int index, nonce = 0;
        private String hash, previousHash;
        private List<Transaction> transList = new List<Transaction>();
        //difficulty of a block
        private int difficulty = 4;
        //minors address
        private string minerAdd;
        //rewards and fees of the block
        private float rBlock = 0, fBlock = 0;
        //merkle root of block
        private string merkleRoot;

        //constructor for a block
        public Block(int prevIndex, String prevHash, List<Transaction> tList, String miner)
        {
            this.createDate = DateTime.Now;
            this.index = prevIndex + 1;
            this.previousHash = prevHash;
            this.transList = tList;
            this.minerAdd = miner;
            foreach (Transaction t in tList)
            {
                this.rBlock += GetReward(t);
                this.fBlock += t.GetFee();
            }
            Transaction trans = new Transaction("Mine Rewards", "", miner, (rBlock + fBlock), 0);
            this.transList.Add(trans);
            this.merkleRoot = GenMerkleRoot(transList);
            this.hash = Mine();
        }

        //constructor for the genesis block
        public Block()
        {
            this.createDate = DateTime.Now;
            this.index = 0;
            this.previousHash = String.Empty;
            this.hash = Mine();
        }

        internal int GetIndex()
        {
            return index;
        }

        internal string GetPrevHash()
        {
            return previousHash;
        }

        public string GetHash()
        {
            return hash;
        }

        //return a string of al info stored in the block
        public String GetInfo()
        {
            string blockInfo = String.Empty;
            blockInfo = index + "," + createDate + "," + hash + "," + previousHash + "," + difficulty + "," + nonce + "," + transList.Count + "," +
                rBlock + "," + fBlock + "," + minerAdd + "," + merkleRoot;
            return blockInfo;
        }

        public List<Transaction> GetTrans()
        {
            return transList;
        }

        //provided code to create a hash for the block using SHA256
        internal String CreateHash()
        {
            SHA256 hasher = SHA256Managed.Create();
            String input = index.ToString() + createDate.ToString() + previousHash + nonce + difficulty + rBlock;
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            String hash = string.Empty;
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);
            return hash;
        }

        private String Mine()
        {
            string hashDiff = new string('0', difficulty);
            string hash = CreateHash();
            while (!hash.StartsWith(hashDiff))
            {
                this.nonce++;
                hash = CreateHash();
            }
            return hash;
        }

        public float GetReward(Transaction t)
        {
            float paid = t.GetAmount();
            float fee = t.GetFee();

            // percent of transaction to reward
            float rewardPercent = 0.5f;
            // weights to calculate reward
            float rW1 = 0, rW2 = 14f, rW3 = 18f;

            if (fee !=0) rW1 = (paid / (fee * rW2));
            float reward = (float)(((paid * (rewardPercent / 100)) + rW3) / ((rW1 + rW2) * rW3));
            if (Double.IsNaN(reward)) reward = 0;
            return 1 + reward + fee;
        }

        internal bool ValMerkle()
        {
            string reMerkle = GenMerkleRoot(transList);
            if (reMerkle == "")
            {
                return true;
            }
            return reMerkle.Equals(merkleRoot);
        }

        internal bool ValHash()
        {
            string reHash = CreateHash();
            return reHash.Equals(hash);
        }

        public static string GenMerkleRoot(List<Transaction> tList)
        {
            List<String> hashes = new List<string>();
            foreach (Transaction t in tList)
            {
                hashes.Add(t.GetHash());
            }

            if (hashes.Count == 0) // No transactions
            {
                return "";
            }
            if (hashes.Count == 1)
            {
                return HashCode.HashTools.CombineHash(hashes[0], hashes[0]);
            }
            while (hashes.Count != 1)
            {
                List<String> merkleLeaves = new List<String>();

                for (int i = 0; i < hashes.Count; i += 2)
                {
                    if (i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.CombineHash(hashes[i], hashes[i]));
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.CombineHash(hashes[i], hashes[i + 1]));
                    }
                }
                hashes = merkleLeaves;
            }
            return hashes[0];
        }
    }
}
