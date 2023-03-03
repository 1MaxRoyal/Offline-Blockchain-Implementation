using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        //creating a blockchain
        Blockchain chain;
        public BlockchainApp()
        {
            InitializeComponent();
            chain = new Blockchain();
            UpdateOutput("New Blockchain Initialised!");
        }

        //function to easily change display
        public void UpdateOutput(String text)
        {
            outputBox.Text = text;
        }

        //on form load
        private void Form1_Load(object sender, EventArgs e)
        {
            combo_mining.SelectedIndex = 1;
        }

        //when get block button is clicked
        private void Btn_GetBlock_Click(object sender, EventArgs e)
        {
            try
            {
                //display block info 
                UpdateOutput(chain.GetBlockTrans(Int32.Parse(txt_BlockIndex.Text)));
            }
            catch (Exception ex)
            {
                UpdateOutput("Block Doesnt Exist");
            }
            //using a try-catch to display an error message for anything that is entered into getblock that isnt a valid block
        }

        //generate a new wallet on button click
        private void Btn_GenWallet_Click(object sender, EventArgs e)
        {
            String privKey;
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out privKey);
            String publicKey = myNewWallet.publicID;
            txt_PubKey.Text = publicKey;
            txt_PrivKey.Text = privKey;
        }

        //validate button click function
        private void Btn_ValidateWallet_Click(object sender, EventArgs e)
        {
            //if wallet is valid
            if (Wallet.Wallet.ValidatePrivateKey(txt_PrivKey.Text, txt_PubKey.Text))
            {
                UpdateOutput("Keys Are Valid!");
            }
            else
            {
                //if wallet isnt valid
                UpdateOutput("Keys Are NOT Valid!");
            }

        }

        //create a new transaction
        private void Btn_CreateTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                //create and display tranasction
                if (Wallet.Wallet.ValidatePrivateKey(txt_PrivKey.Text, txt_PubKey.Text))
                {
                    if (chain.GetBalance(txt_PubKey.Text) >= Double.Parse(txt_Fee.Text) + Double.Parse(txt_Amount.Text))
                    {
                        Transaction transaction = new Transaction(txt_PubKey.Text, txt_PrivKey.Text, txt_ReceiverKey.Text, float.Parse(txt_Amount.Text), float.Parse(txt_Fee.Text));
                        UpdateOutput(transaction.GetTransactionInfo());
                        //add tranasction to tranastion pool
                        chain.AddTransaction(transaction);
                    }
                    else
                    {
                        UpdateOutput("Cannot Afford Transaction\n" +
                            $"Balance: {chain.GetBalance(txt_PubKey.Text)} SwagCoins\n" +
                            $"Transaction Cost: { Double.Parse(txt_Fee.Text) + Double.Parse(txt_Amount.Text)} SwagCoins");
                    }               
                }
                else
                {
                    UpdateOutput("Private Key does not match. No Transaction Has Happened!");
                }
            }
            catch (Exception ex)
            {
                UpdateOutput("Transaction is Invalid!");
            }
            //use of try-catch to display error message and prevent crash in any scneraio when the transaction isnt valid
        }

        private void Btn_NewBlock_Click(object sender, EventArgs e)
        {
            // UpdateOutput(cb_Thread.Checked.ToString());
            if (combo_mining.SelectedIndex == 3 && txt_MinerKey.Text == "")
            {
                combo_mining.SelectedIndex = 1;
            }
            UpdateOutput(chain.NewBlock(txt_MinerKey.Text, cb_Thread.Checked, combo_mining.SelectedItem.ToString()));
        }

        private void btn_AllBlocks_Click(object sender, EventArgs e)
        {
            UpdateOutput(chain.AllBlocks());
        }

        private void btn_PendTrans_Click(object sender, EventArgs e)
        {
            UpdateOutput(chain.GetTPool());
        }

        private void Btn_ValidateChain_Click(object sender, EventArgs e)
        {
            UpdateOutput(chain.ValidateChain());
        }

        private void Btn_CheckBalance_Click(object sender, EventArgs e)
        {
            string output = $"{txt_PubKey.Text}\nBalance: {chain.GetBalance(txt_PubKey.Text)} SwagCoins\n{chain.GetAddTrans(txt_PubKey.Text)}";
            UpdateOutput(output);
        }

        private void btn_ValidateBlock_Click(object sender, EventArgs e)
        {
            try
            {
                //display block info 
                UpdateOutput(chain.ValidateBlock(Int32.Parse(txt_BlockIndex.Text)));
            }
            catch (Exception ex)
            {
                UpdateOutput("Block Doesnt Exist");
            }
            //using a try-catch to display an error message for anything that is entered into getblock that isnt a valid block
        }

    }
}
