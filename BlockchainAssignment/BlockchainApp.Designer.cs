namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.btn_GetBlock = new System.Windows.Forms.Button();
            this.txt_BlockIndex = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Btn_CheckBalance = new System.Windows.Forms.Button();
            this.btn_ValidateWallet = new System.Windows.Forms.Button();
            this.btn_GenWallet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PrivKey = new System.Windows.Forms.TextBox();
            this.txt_PubKey = new System.Windows.Forms.TextBox();
            this.Btn_ValidateChain = new System.Windows.Forms.Button();
            this.btn_PendTrans = new System.Windows.Forms.Button();
            this.txt_ReceiverKey = new System.Windows.Forms.TextBox();
            this.txt_MinerKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Fee = new System.Windows.Forms.TextBox();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.btn_NewBlock = new System.Windows.Forms.Button();
            this.btn_CreateTransaction = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btn_AllBlocks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.outputBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputBox.Location = new System.Drawing.Point(16, 15);
            this.outputBox.Margin = new System.Windows.Forms.Padding(4);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(875, 386);
            this.outputBox.TabIndex = 0;
            this.outputBox.Text = "";
            // 
            // btn_GetBlock
            // 
            this.btn_GetBlock.Location = new System.Drawing.Point(14, 453);
            this.btn_GetBlock.Name = "btn_GetBlock";
            this.btn_GetBlock.Size = new System.Drawing.Size(88, 23);
            this.btn_GetBlock.TabIndex = 1;
            this.btn_GetBlock.Text = "Get Block";
            this.btn_GetBlock.UseVisualStyleBackColor = true;
            this.btn_GetBlock.Click += new System.EventHandler(this.Btn_GetBlock_Click);
            // 
            // txt_BlockIndex
            // 
            this.txt_BlockIndex.Location = new System.Drawing.Point(62, 431);
            this.txt_BlockIndex.Name = "txt_BlockIndex";
            this.txt_BlockIndex.Size = new System.Drawing.Size(36, 22);
            this.txt_BlockIndex.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(20, 434);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(39, 15);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Index:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(16, 408);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(132, 23);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "BLOCKS";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(245, 408);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(167, 23);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "WALLETS";
            // 
            // Btn_CheckBalance
            // 
            this.Btn_CheckBalance.Location = new System.Drawing.Point(477, 434);
            this.Btn_CheckBalance.Name = "Btn_CheckBalance";
            this.Btn_CheckBalance.Size = new System.Drawing.Size(125, 24);
            this.Btn_CheckBalance.TabIndex = 27;
            this.Btn_CheckBalance.Text = "Check Balance";
            this.Btn_CheckBalance.UseVisualStyleBackColor = true;
            this.Btn_CheckBalance.Click += new System.EventHandler(this.Btn_CheckBalance_Click);
            // 
            // btn_ValidateWallet
            // 
            this.btn_ValidateWallet.Location = new System.Drawing.Point(361, 434);
            this.btn_ValidateWallet.Name = "btn_ValidateWallet";
            this.btn_ValidateWallet.Size = new System.Drawing.Size(110, 23);
            this.btn_ValidateWallet.TabIndex = 12;
            this.btn_ValidateWallet.Text = "Validate Wallet";
            this.btn_ValidateWallet.UseVisualStyleBackColor = true;
            this.btn_ValidateWallet.Click += new System.EventHandler(this.Btn_ValidateWallet_Click);
            // 
            // btn_GenWallet
            // 
            this.btn_GenWallet.Location = new System.Drawing.Point(245, 435);
            this.btn_GenWallet.Name = "btn_GenWallet";
            this.btn_GenWallet.Size = new System.Drawing.Size(110, 23);
            this.btn_GenWallet.TabIndex = 5;
            this.btn_GenWallet.Text = "New Wallet";
            this.btn_GenWallet.UseVisualStyleBackColor = true;
            this.btn_GenWallet.Click += new System.EventHandler(this.Btn_GenWallet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Public Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Private Key";
            // 
            // txt_PrivKey
            // 
            this.txt_PrivKey.Location = new System.Drawing.Point(336, 488);
            this.txt_PrivKey.Multiline = true;
            this.txt_PrivKey.Name = "txt_PrivKey";
            this.txt_PrivKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_PrivKey.Size = new System.Drawing.Size(463, 22);
            this.txt_PrivKey.TabIndex = 10;
            // 
            // txt_PubKey
            // 
            this.txt_PubKey.Location = new System.Drawing.Point(336, 463);
            this.txt_PubKey.Multiline = true;
            this.txt_PubKey.Name = "txt_PubKey";
            this.txt_PubKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_PubKey.Size = new System.Drawing.Size(463, 22);
            this.txt_PubKey.TabIndex = 9;
            // 
            // Btn_ValidateChain
            // 
            this.Btn_ValidateChain.Location = new System.Drawing.Point(808, 408);
            this.Btn_ValidateChain.Name = "Btn_ValidateChain";
            this.Btn_ValidateChain.Size = new System.Drawing.Size(101, 47);
            this.Btn_ValidateChain.TabIndex = 26;
            this.Btn_ValidateChain.Text = "Validate Blockchain";
            this.Btn_ValidateChain.UseVisualStyleBackColor = true;
            this.Btn_ValidateChain.Click += new System.EventHandler(this.Btn_ValidateChain_Click);
            // 
            // btn_PendTrans
            // 
            this.btn_PendTrans.Location = new System.Drawing.Point(808, 537);
            this.btn_PendTrans.Name = "btn_PendTrans";
            this.btn_PendTrans.Size = new System.Drawing.Size(101, 47);
            this.btn_PendTrans.TabIndex = 23;
            this.btn_PendTrans.Text = "Get Pending Transactions";
            this.btn_PendTrans.UseVisualStyleBackColor = true;
            this.btn_PendTrans.Click += new System.EventHandler(this.btn_PendTrans_Click);
            // 
            // txt_ReceiverKey
            // 
            this.txt_ReceiverKey.Location = new System.Drawing.Point(339, 564);
            this.txt_ReceiverKey.Multiline = true;
            this.txt_ReceiverKey.Name = "txt_ReceiverKey";
            this.txt_ReceiverKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_ReceiverKey.Size = new System.Drawing.Size(463, 22);
            this.txt_ReceiverKey.TabIndex = 20;
            // 
            // txt_MinerKey
            // 
            this.txt_MinerKey.Location = new System.Drawing.Point(339, 540);
            this.txt_MinerKey.Multiline = true;
            this.txt_MinerKey.Name = "txt_MinerKey";
            this.txt_MinerKey.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_MinerKey.Size = new System.Drawing.Size(463, 22);
            this.txt_MinerKey.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Receiver Key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Miner Key";
            // 
            // txt_Fee
            // 
            this.txt_Fee.Location = new System.Drawing.Point(182, 565);
            this.txt_Fee.Name = "txt_Fee";
            this.txt_Fee.Size = new System.Drawing.Size(52, 22);
            this.txt_Fee.TabIndex = 17;
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(182, 540);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.Size = new System.Drawing.Size(52, 22);
            this.txt_Amount.TabIndex = 15;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(127, 543);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(51, 15);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "Amount:";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(127, 568);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(39, 15);
            this.textBox7.TabIndex = 18;
            this.textBox7.Text = "Fee:";
            // 
            // btn_NewBlock
            // 
            this.btn_NewBlock.Location = new System.Drawing.Point(108, 431);
            this.btn_NewBlock.Name = "btn_NewBlock";
            this.btn_NewBlock.Size = new System.Drawing.Size(88, 45);
            this.btn_NewBlock.TabIndex = 21;
            this.btn_NewBlock.Text = "Create New Block";
            this.btn_NewBlock.UseVisualStyleBackColor = true;
            this.btn_NewBlock.Click += new System.EventHandler(this.Btn_NewBlock_Click);
            // 
            // btn_CreateTransaction
            // 
            this.btn_CreateTransaction.Location = new System.Drawing.Point(14, 540);
            this.btn_CreateTransaction.Name = "btn_CreateTransaction";
            this.btn_CreateTransaction.Size = new System.Drawing.Size(101, 47);
            this.btn_CreateTransaction.TabIndex = 14;
            this.btn_CreateTransaction.Text = "Create Transaction";
            this.btn_CreateTransaction.UseVisualStyleBackColor = true;
            this.btn_CreateTransaction.Click += new System.EventHandler(this.Btn_CreateTransaction_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(12, 511);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(166, 23);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "TRANSACTIONS";
            // 
            // btn_AllBlocks
            // 
            this.btn_AllBlocks.Location = new System.Drawing.Point(14, 477);
            this.btn_AllBlocks.Name = "btn_AllBlocks";
            this.btn_AllBlocks.Size = new System.Drawing.Size(88, 34);
            this.btn_AllBlocks.TabIndex = 22;
            this.btn_AllBlocks.Text = "All Blocks";
            this.btn_AllBlocks.UseVisualStyleBackColor = true;
            this.btn_AllBlocks.Click += new System.EventHandler(this.btn_AllBlocks_Click);
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(910, 592);
            this.Controls.Add(this.Btn_CheckBalance);
            this.Controls.Add(this.Btn_ValidateChain);
            this.Controls.Add(this.txt_MinerKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_PendTrans);
            this.Controls.Add(this.btn_AllBlocks);
            this.Controls.Add(this.btn_NewBlock);
            this.Controls.Add(this.txt_ReceiverKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.txt_Fee);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.txt_Amount);
            this.Controls.Add(this.btn_CreateTransaction);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btn_ValidateWallet);
            this.Controls.Add(this.txt_PrivKey);
            this.Controls.Add(this.txt_PubKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btn_GenWallet);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txt_BlockIndex);
            this.Controls.Add(this.btn_GetBlock);
            this.Controls.Add(this.outputBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Button btn_GetBlock;
        private System.Windows.Forms.TextBox txt_BlockIndex;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Btn_CheckBalance;
        private System.Windows.Forms.Button btn_ValidateWallet;
        private System.Windows.Forms.Button btn_GenWallet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PrivKey;
        private System.Windows.Forms.TextBox txt_PubKey;
        private System.Windows.Forms.Button Btn_ValidateChain;
        private System.Windows.Forms.Button btn_PendTrans;
        private System.Windows.Forms.TextBox txt_ReceiverKey;
        private System.Windows.Forms.TextBox txt_MinerKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Fee;
        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button btn_NewBlock;
        private System.Windows.Forms.Button btn_CreateTransaction;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btn_AllBlocks;
    }
}

