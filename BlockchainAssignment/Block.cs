using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
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
        private int difficulty;
        //seconds that it should take to mine block
        private int mineSeconds = 5;
        //minors address
        private string minerAdd;
        //rewards and fees of the block
        private float rBlock = 0, fBlock = 0;
        //merkle root of block
        private string merkleRoot;
        //variables for threading
        int nonce1 = 0, nonce2 = 100000;
        string hash1, hash2;
        bool thread1complete = false, thread2complete = false;
        //variable for adaptive diff
        TimeSpan mineTime;

        //constructor for a block
        public Block(int prevIndex, String prevHash, int prevDiff, TimeSpan mineTime, List<Transaction> tList, String miner, bool useThreading)
        {
            this.createDate = DateTime.Now;
            this.index = prevIndex + 1;
            this.previousHash = prevHash;
            this.difficulty = AdjustDifficulty(mineTime, prevDiff);
            this.transList = tList;
            this.minerAdd = miner;
            foreach (Transaction t in tList)
            {
                this.rBlock += (float)GetReward(t);
                this.fBlock += t.GetFee();
            }
            if (transList.Count != 0)
            {
                Transaction trans = new Transaction("Mine Rewards", "", miner, (rBlock + fBlock), 0);
                this.transList.Add(trans);
            }
            this.merkleRoot = GenMerkleRoot(transList);
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            DateTime mineTimeStart = DateTime.Now;
            if (useThreading)
            {
                this.hash = MineThreading();
                //Console.WriteLine("With Threading:\n");
            }
            else
            {
                this.hash = Mine();
                //Console.WriteLine("Without Threading:\n");
            }
            DateTime mineTimeEnd = DateTime.Now;
            this.mineTime = mineTimeEnd - mineTimeStart;
            //stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            //TimeSpan ts = stopWatch.Elapsed;

            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime + "\n");
        }

        internal TimeSpan GetTime()
        {
            return this.mineTime;
        }

        //constructor for the genesis block
        public Block()
        {
            this.createDate = DateTime.Now;
            this.index = 0;
            this.previousHash = String.Empty;
            this.difficulty = 1;
            DateTime mineTimeStart = DateTime.Now;
            this.hash = Mine();
            DateTime mineTimeEnd = DateTime.Now;
            this.mineTime = mineTimeEnd - mineTimeStart;
        }

        internal int GetIndex()
        {
            return index;
        }

        internal int GetDiff()
        {
            return difficulty;
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
        internal String CreateHash(int tNonce)
        {
            SHA256 hasher = SHA256Managed.Create();
            String input = index.ToString() + createDate.ToString() + previousHash + tNonce + difficulty + rBlock + fBlock + merkleRoot;
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            String hash = string.Empty;
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);
            return hash;
        }

        internal String CreateHash()
        {
            SHA256 hasher = SHA256Managed.Create();
            String input = index.ToString() + createDate.ToString() + previousHash + nonce + difficulty + rBlock + fBlock + merkleRoot;
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

        private string MineThreading()
        {
            thread1complete = false;
            thread2complete = false;

            nonce1 = 0;
            nonce2 = 100000;

            Thread thread1 = new Thread(MineThread1);
            Thread thread2 = new Thread(MineThread2);

            thread1.Start();
            thread2.Start();

            while (thread1.IsAlive || thread2.IsAlive)
            {
                Thread.Sleep(1);
            }

            if (thread1complete)
            {
                this.nonce = nonce1;
                return hash1;
            }
            else
            {
                this.nonce = nonce2;
                return hash2;
            }

        }

        private void MineThread2()
        {
            string hashDiff = new string('0', difficulty);
            string hash = CreateHash(nonce2);
            while (!hash.StartsWith(hashDiff) && !thread1complete)
            {
                this.nonce2++;
                hash = CreateHash(nonce2);
            }
            hash2 = hash;
            if (!thread1complete)
            {
                thread2complete = true;
            }
            // Console.WriteLine("2 Complete");
            // Console.WriteLine(hash2);
            // Console.WriteLine(nonce2);
        }

        private void MineThread1()
        {
            string hashDiff = new string('0', difficulty);
            string hasher = CreateHash(nonce1);
            while (!hasher.StartsWith(hashDiff) && !thread2complete)
            {
                this.nonce1++;
                hasher = CreateHash(nonce2);
            }
            hash1 = hasher;
            if (!thread2complete)
            {
                thread1complete = true;
            }
            //Console.WriteLine("1 Complete");
            //Console.WriteLine(hash1);
            //Console.WriteLine(nonce1);
        }

        public double GetReward(Transaction t)
        {
            float paid = t.GetAmount();
            double reward = (9 * paid) / ((Math.Log(paid) + 14) * 18);
            reward = reward * 12;
            if (Double.IsNaN(reward)) reward = 0;
            reward = Math.Round(reward, 3);
            return 1 + reward;
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
            string reHash = CreateHash(nonce);
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

        private int AdjustDifficulty(TimeSpan prevTime, int prevDiff)
        {
            int difficulty1 = prevDiff;
            //time how long it takes to generate blocks
            TimeSpan time = prevTime;

            Console.WriteLine($"Time to mine block {time}");
            if (time < TimeSpan.FromSeconds(mineSeconds))
            {
                difficulty1++;
                Console.WriteLine("Mining Too Easy\nDifficulty Increased to " + difficulty1);
            }

            if (time > TimeSpan.FromSeconds(mineSeconds))
            {
                difficulty1--;
                Console.WriteLine("Mining Too Hard\nDifficulty Decreased to " + difficulty1);
            }

            if (difficulty1 < 0)
            {
                difficulty1 = 0;
            }

            if (difficulty1 > 6)
            {
                difficulty1 = 6;
                Console.WriteLine("Max Dificulty of 6 Reached");
            }

            return difficulty1;
        }
    }
}
