using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        //list of blocks in the chain
        List<Block> Blocks = new List<Block>();
        //list if transactions yet to be added to the chain
        List<Transaction> TransactionPool = new List<Transaction>();

        //blockchain constrcutor
        public Blockchain()
        {
            //creating the genesis block
            Blocks.Add(new Block());
        }

        //create a new block and return the information of the new block
        public string NewBlock(String miner)
        {
            int lastBlock = Blocks.Count - 1;
            int count = 0;
            if (TransactionPool.Count > 5)
            {
                count = 5;
            }
            else
            {
                count = TransactionPool.Count();
            }
            List<Transaction> blockTrans = TransactionPool.GetRange(0, count);
            foreach (Transaction t in blockTrans)
            {
                TransactionPool.Remove(t);
            }
            Blocks.Add(new Block(lastBlock, Blocks[lastBlock].GetHash(), blockTrans, miner));
            return GetBlockTrans(lastBlock + 1);
        }

        //returns a string for all information in a block
        public String GetBlock(int index)
        {
            string blockInfo = Blocks[index].GetInfo();
            string[] info = blockInfo.Split(',');
            float totReward = float.Parse(info[7]) + float.Parse(info[8]);
            string Output = $"Block Index: {info[0]}        Timestamp: {info[1]}\nHash: {info[2]}\nPrevious Hash: {info[3]}\nDifficulty: {info[4]}\nNonce: {info[5]}\n" +
                $"Reward:{info[7]}  Fees:{info[8]}\nTotal Reward:{totReward}\nMiner: {info[9]}\nTransactions: {info[6]}\nMerkle Root: {info[10]}\n";
            return Output;
        }

        public String GetBlockTrans(int index)
        {
            List<Transaction> tList = Blocks[index].GetTrans();
            string Output = GetBlock(index);
            foreach (Transaction t in tList)
            {
                Output += $"\n{t.GetTransactionInfo()}\n";
            }
            return Output;
        }

        //add a transaction to the transaction pool
        public void AddTransaction(Transaction t)
        {
            TransactionPool.Add(t);
        }

        public string AllBlocks()
        {
            string allBlocks = "";
            for (int i = 0; i < Blocks.Count; i++)
            {
                allBlocks = allBlocks + GetBlock(i) + "\n";
            }
            return allBlocks;
        }

        public string GetTPool()
        {
            string output = $"Transactions in pool: {TransactionPool.Count()}\n";

            foreach (Transaction t in TransactionPool)
            {
                output += $"\n{t.GetTransactionInfo()}\n";
            }
            return output;
        }

        public string ValidateChain()
        {
            if (Blocks.Count == 1)
            {
                if (Blocks[0].ValHash())
                {
                    return "Blockchain Valid";
                }
                else
                {
                    return "Blockchain Invalid";
                }
            }


            string prevHash = "";

            foreach (Block b in Blocks)
            {
                if (prevHash == b.GetPrevHash() && b.ValHash() && b.ValMerkle())
                {
                    prevHash = b.GetHash();
                }
                else
                {
                    return "Blockchain Invalid";
                }
            }

            return "Blockchain Valid";
        }

        internal double GetBalance(string address)
        {
            double bal = 0;

            foreach (Block b in Blocks)
            {
                foreach (Transaction t in b.GetTrans())
                {
                    if (t.GetRecAdd() == address)
                    {
                        bal += t.GetAmount();
                    }
                    if (t.GetSendAdd() == address)
                    {
                        bal -= (t.GetAmount() + t.GetFee());
                    }
                }
            }

            foreach (Transaction t in TransactionPool)
            {
                if (t.GetRecAdd() == address)
                {
                    bal += t.GetAmount();
                }
                if (t.GetSendAdd() == address)
                {
                    bal -= (t.GetAmount() + t.GetFee());
                }
            }

            return bal;
        }
    }
}
