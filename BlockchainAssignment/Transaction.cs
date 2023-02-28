using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlockchainAssignment
{
    class Transaction
    {
        //data needed to process a transaction
        private String hash, signature, senderAddress, recipientAddress;
        private DateTime timeStamp;
        private float amount, fee;

        //constructor for a transaction
        public Transaction(String senderAddress, String senderPrivKey, String recipientAddress, float amount, float fee)
        {
            this.senderAddress = senderAddress;
            this.recipientAddress = recipientAddress;
            this.timeStamp = DateTime.Now;
            this.amount = amount;
            this.fee = fee;
            this.hash = CreateHash();
            this.signature = Wallet.Wallet.CreateSignature(senderAddress, senderPrivKey, hash);
        }

        public float GetAmount()
        {
            return amount;
        }

        public float GetFee()
        {
            return fee;
        }

        //provided code to create a hash for the block using SHA256
        private String CreateHash()
        {
            SHA256 hasher = SHA256Managed.Create();
            String input = recipientAddress.ToString() + senderAddress.ToString() + amount + fee + timeStamp;
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            String hash = string.Empty;
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);
            return hash;
        }

        //returns a list of all info in a transaction so that it can be displayed
        public String GetTransactionInfo()
        {
            return $"Transaction Hash: {hash}\nSignature: {signature}\nTimeStamp: {timeStamp}\nTransferred Amount: {amount} SwagCoins" +
                $"\nFees Payed: {fee}\nSender Address: {senderAddress}\nReceiver Address: {recipientAddress}\n";
        }

        internal string GetRecAdd()
        {
            return recipientAddress;
        }

        internal string GetSendAdd()
        {
            return senderAddress;
        }

        internal string GetHash()
        {
            return hash;
        }
    }
}
