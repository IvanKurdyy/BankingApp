namespace Banking
{
    partial class CurrentID
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
            BankName = new Label();
            label1 = new Label();
            ReceiverID = new NumericUpDown();
            TransferSum = new NumericUpDown();
            Receiver = new Label();
            Sum = new Label();
            BankBox = new ComboBox();
            Transfer = new Button();
            label3 = new Label();
            DWSum = new NumericUpDown();
            label4 = new Label();
            Deposit = new Button();
            Withdraw = new Button();
            DepositNWithdraw = new Label();
            Balance = new Label();
            UserID = new Label();
            BackToMain = new Button();
            label2 = new Label();
            OpLog = new Label();
            OpStatus = new RichTextBox();
            AllSum = new Button();
            AllSumTransfer = new Button();
            ClearLogs = new Button();
            ((System.ComponentModel.ISupportInitialize)ReceiverID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TransferSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DWSum).BeginInit();
            SuspendLayout();
            // 
            // BankName
            // 
            BankName.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BankName.Location = new Point(66, 4);
            BankName.Name = "BankName";
            BankName.Size = new Size(192, 54);
            BankName.TabIndex = 5;
            BankName.Text = "Bank";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(675, 297);
            label1.Name = "label1";
            label1.Size = new Size(119, 30);
            label1.TabIndex = 6;
            label1.Text = "Перевод";
            // 
            // ReceiverID
            // 
            ReceiverID.Location = new Point(708, 400);
            ReceiverID.Name = "ReceiverID";
            ReceiverID.Size = new Size(202, 27);
            ReceiverID.TabIndex = 7;
            ReceiverID.ValueChanged += ReceiverID_ValueChanged;
            // 
            // TransferSum
            // 
            TransferSum.DecimalPlaces = 2;
            TransferSum.Location = new Point(708, 438);
            TransferSum.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            TransferSum.Name = "TransferSum";
            TransferSum.Size = new Size(119, 27);
            TransferSum.TabIndex = 8;
            TransferSum.ThousandsSeparator = true;
            TransferSum.ValueChanged += TransferSum_ValueChanged;
            // 
            // Receiver
            // 
            Receiver.AutoSize = true;
            Receiver.Location = new Point(580, 405);
            Receiver.Name = "Receiver";
            Receiver.Size = new Size(109, 20);
            Receiver.TabIndex = 9;
            Receiver.Text = "ID Получателя";
            // 
            // Sum
            // 
            Sum.AutoSize = true;
            Sum.Location = new Point(607, 438);
            Sum.Name = "Sum";
            Sum.Size = new Size(55, 20);
            Sum.TabIndex = 10;
            Sum.Text = "Сумма";
            // 
            // BankBox
            // 
            BankBox.FormattingEnabled = true;
            BankBox.Location = new Point(708, 364);
            BankBox.Name = "BankBox";
            BankBox.Size = new Size(202, 28);
            BankBox.TabIndex = 11;
            BankBox.SelectedIndexChanged += BankBox_SelectedIndexChanged;
            // 
            // Transfer
            // 
            Transfer.Enabled = false;
            Transfer.Location = new Point(580, 486);
            Transfer.Name = "Transfer";
            Transfer.Size = new Size(330, 75);
            Transfer.TabIndex = 12;
            Transfer.Text = "Перевести";
            Transfer.UseVisualStyleBackColor = true;
            Transfer.Click += Transfer_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(573, 115);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 15;
            label3.Text = "Сумма";
            // 
            // DWSum
            // 
            DWSum.DecimalPlaces = 2;
            DWSum.Location = new Point(675, 113);
            DWSum.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            DWSum.Name = "DWSum";
            DWSum.Size = new Size(119, 27);
            DWSum.TabIndex = 14;
            DWSum.ThousandsSeparator = true;
            DWSum.ValueChanged += DWSum_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(566, 367);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 16;
            label4.Text = "Банк Получателя";
            // 
            // Deposit
            // 
            Deposit.Enabled = false;
            Deposit.Location = new Point(573, 176);
            Deposit.Name = "Deposit";
            Deposit.Size = new Size(149, 91);
            Deposit.TabIndex = 17;
            Deposit.Text = "Пополнить";
            Deposit.UseVisualStyleBackColor = true;
            Deposit.Click += Deposit_Click;
            // 
            // Withdraw
            // 
            Withdraw.Enabled = false;
            Withdraw.Location = new Point(761, 174);
            Withdraw.Name = "Withdraw";
            Withdraw.Size = new Size(149, 94);
            Withdraw.TabIndex = 18;
            Withdraw.Text = "Снять";
            Withdraw.UseVisualStyleBackColor = true;
            Withdraw.Click += Withdraw_Click;
            // 
            // DepositNWithdraw
            // 
            DepositNWithdraw.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            DepositNWithdraw.Location = new Point(631, 46);
            DepositNWithdraw.Name = "DepositNWithdraw";
            DepositNWithdraw.Size = new Size(247, 30);
            DepositNWithdraw.TabIndex = 19;
            DepositNWithdraw.Text = "Пополнение и снятие";
            // 
            // Balance
            // 
            Balance.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Balance.Location = new Point(121, 127);
            Balance.Name = "Balance";
            Balance.Size = new Size(348, 70);
            Balance.TabIndex = 20;
            Balance.Text = "$";
            // 
            // UserID
            // 
            UserID.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserID.Location = new Point(159, 89);
            UserID.Name = "UserID";
            UserID.Size = new Size(125, 22);
            UserID.TabIndex = 21;
            UserID.Text = "ID: ";
            // 
            // BackToMain
            // 
            BackToMain.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BackToMain.ImageAlign = ContentAlignment.TopLeft;
            BackToMain.Location = new Point(-1, 0);
            BackToMain.Name = "BackToMain";
            BackToMain.Size = new Size(51, 58);
            BackToMain.TabIndex = 22;
            BackToMain.Text = "<";
            BackToMain.UseVisualStyleBackColor = true;
            BackToMain.Click += BackToMain_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(66, 82);
            label2.Name = "label2";
            label2.Size = new Size(87, 31);
            label2.TabIndex = 23;
            label2.Text = "Баланс";
            // 
            // OpLog
            // 
            OpLog.AutoSize = true;
            OpLog.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OpLog.Location = new Point(24, 226);
            OpLog.Name = "OpLog";
            OpLog.Size = new Size(270, 41);
            OpLog.TabIndex = 24;
            OpLog.Text = "Статусы операций";
            // 
            // OpStatus
            // 
            OpStatus.BackColor = SystemColors.InactiveCaption;
            OpStatus.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OpStatus.Location = new Point(24, 274);
            OpStatus.Name = "OpStatus";
            OpStatus.ReadOnly = true;
            OpStatus.Size = new Size(511, 296);
            OpStatus.TabIndex = 25;
            OpStatus.Text = "";
            // 
            // AllSum
            // 
            AllSum.Location = new Point(800, 113);
            AllSum.Name = "AllSum";
            AllSum.Size = new Size(94, 29);
            AllSum.TabIndex = 26;
            AllSum.Text = "Вся сумма";
            AllSum.UseVisualStyleBackColor = true;
            AllSum.Click += AllSum_Click;
            // 
            // AllSumTransfer
            // 
            AllSumTransfer.Location = new Point(833, 438);
            AllSumTransfer.Name = "AllSumTransfer";
            AllSumTransfer.Size = new Size(94, 29);
            AllSumTransfer.TabIndex = 27;
            AllSumTransfer.Text = "Вся сумма";
            AllSumTransfer.UseVisualStyleBackColor = true;
            AllSumTransfer.Click += AllSumTransfer_Click;
            // 
            // ClearLogs
            // 
            ClearLogs.Enabled = false;
            ClearLogs.Location = new Point(441, 239);
            ClearLogs.Name = "ClearLogs";
            ClearLogs.Size = new Size(94, 29);
            ClearLogs.TabIndex = 28;
            ClearLogs.Text = "Очистить";
            ClearLogs.UseVisualStyleBackColor = true;
            ClearLogs.Click += ClearLogs_Click;
            // 
            // CurrentID
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 593);
            Controls.Add(ClearLogs);
            Controls.Add(AllSumTransfer);
            Controls.Add(AllSum);
            Controls.Add(OpStatus);
            Controls.Add(OpLog);
            Controls.Add(label2);
            Controls.Add(BackToMain);
            Controls.Add(UserID);
            Controls.Add(Balance);
            Controls.Add(DepositNWithdraw);
            Controls.Add(Withdraw);
            Controls.Add(Deposit);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(DWSum);
            Controls.Add(Transfer);
            Controls.Add(BankBox);
            Controls.Add(Sum);
            Controls.Add(Receiver);
            Controls.Add(TransferSum);
            Controls.Add(ReceiverID);
            Controls.Add(label1);
            Controls.Add(BankName);
            Name = "CurrentID";
            Text = "name";
            FormClosing += CurrentID_FormOnClosing;
            Load += CurrentID_Load;
            ((System.ComponentModel.ISupportInitialize)ReceiverID).EndInit();
            ((System.ComponentModel.ISupportInitialize)TransferSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)DWSum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label BankName;
        private Label label1;
        private NumericUpDown ReceiverID;
        private NumericUpDown TransferSum;
        private Label Receiver;
        private Label Sum;
        private ComboBox BankBox;
        private Button Transfer;
        private Label label3;
        private NumericUpDown DWSum;
        private Label label4;
        private Button Deposit;
        private Button Withdraw;
        private Label DepositNWithdraw;
        private Label Balance;
        private Label UserID;
        private Button BackToMain;
        private Label label2;
        private Label OpLog;
        private RichTextBox OpStatus;
        private Button AllSum;
        private Button AllSumTransfer;
        private Button ClearLogs;
    }
}