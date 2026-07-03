namespace Banking
{
    partial class BankingMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            panel = new Panel();
            GetDiagram = new Button();
            WatchLogs = new Button();
            WholeBalance = new Label();
            ClearBtn = new Button();
            NewBankName = new TextBox();
            AddNewBank = new Button();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(GetDiagram);
            panel.Controls.Add(WatchLogs);
            panel.Controls.Add(WholeBalance);
            panel.Controls.Add(ClearBtn);
            panel.Controls.Add(NewBankName);
            panel.Controls.Add(AddNewBank);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(785, 433);
            panel.TabIndex = 0;
            // 
            // GetDiagram
            // 
            GetDiagram.Location = new Point(206, 18);
            GetDiagram.Name = "GetDiagram";
            GetDiagram.Size = new Size(125, 67);
            GetDiagram.TabIndex = 1;
            GetDiagram.Text = "Диаграма средств";
            GetDiagram.UseVisualStyleBackColor = true;
            GetDiagram.Click += GetDiagram_Click;
            // 
            // WatchLogs
            // 
            WatchLogs.Location = new Point(587, 18);
            WatchLogs.Name = "WatchLogs";
            WatchLogs.Size = new Size(151, 48);
            WatchLogs.TabIndex = 1;
            WatchLogs.Text = "История";
            WatchLogs.UseVisualStyleBackColor = true;
            WatchLogs.Click += WatchLogs_Click;
            // 
            // WholeBalance
            // 
            WholeBalance.AutoSize = true;
            WholeBalance.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            WholeBalance.Location = new Point(49, 29);
            WholeBalance.Name = "WholeBalance";
            WholeBalance.Size = new Size(99, 46);
            WholeBalance.TabIndex = 1;
            WholeBalance.Text = "$0,00";
            // 
            // ClearBtn
            // 
            ClearBtn.Location = new Point(587, 72);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(151, 47);
            ClearBtn.TabIndex = 1;
            ClearBtn.Text = "Очистить данные";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // NewBankName
            // 
            NewBankName.Location = new Point(380, 29);
            NewBankName.Name = "NewBankName";
            NewBankName.Size = new Size(125, 27);
            NewBankName.TabIndex = 29;
            NewBankName.TextChanged += NewBankName_TextChanged;
            NewBankName.KeyDown += NewBankName_KeyDown;
            // 
            // AddNewBank
            // 
            AddNewBank.Enabled = false;
            AddNewBank.Location = new Point(352, 72);
            AddNewBank.Name = "AddNewBank";
            AddNewBank.Size = new Size(180, 47);
            AddNewBank.TabIndex = 28;
            AddNewBank.Text = "Добавить банк";
            AddNewBank.UseVisualStyleBackColor = true;
            AddNewBank.Click += AddNewBank_Click;
            // 
            // BankingMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 433);
            Controls.Add(panel);
            Name = "BankingMain";
            Text = "Banking";
            Load += BankingMain_Load;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        public Panel panel;
        private Button AddNewBank;
        private TextBox NewBankName;
        private Button ClearBtn;
        public Label WholeBalance;
        private Button WatchLogs;
        private Button GetDiagram;
    }
}