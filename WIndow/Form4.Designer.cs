namespace Banking
{
    partial class LogHistory
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
            Banks = new ComboBox();
            bankLabel = new Label();
            ClientLabel = new Label();
            IDRoller = new NumericUpDown();
            OperationLabel = new Label();
            OperationTypes = new ComboBox();
            FromTime = new DateTimePicker();
            UntilTime = new DateTimePicker();
            FromTimeLabel = new Label();
            UntilTimeLabel = new Label();
            LogWindow = new RichTextBox();
            OpStatuses = new ComboBox();
            ExitBtn = new Button();
            ClearFilters = new Button();
            OpSum = new NumericUpDown();
            CLearAllLogs = new Button();
            StatusLabel = new Label();
            SumLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)IDRoller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpSum).BeginInit();
            SuspendLayout();
            // 
            // Banks
            // 
            Banks.FormattingEnabled = true;
            Banks.Location = new Point(112, 40);
            Banks.Name = "Banks";
            Banks.Size = new Size(151, 28);
            Banks.TabIndex = 0;
            Banks.SelectedIndexChanged += Banks_SelectedIndexChanged;
            // 
            // bankLabel
            // 
            bankLabel.AutoSize = true;
            bankLabel.Location = new Point(162, 9);
            bankLabel.Name = "bankLabel";
            bankLabel.Size = new Size(42, 20);
            bankLabel.TabIndex = 1;
            bankLabel.Text = "Банк";
            // 
            // ClientLabel
            // 
            ClientLabel.AutoSize = true;
            ClientLabel.Location = new Point(348, 9);
            ClientLabel.Name = "ClientLabel";
            ClientLabel.Size = new Size(24, 20);
            ClientLabel.TabIndex = 3;
            ClientLabel.Text = "ID";
            // 
            // IDRoller
            // 
            IDRoller.Location = new Point(286, 41);
            IDRoller.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            IDRoller.Name = "IDRoller";
            IDRoller.Size = new Size(150, 27);
            IDRoller.TabIndex = 4;
            IDRoller.ValueChanged += IDRoller_ValueChanged;
            // 
            // OperationLabel
            // 
            OperationLabel.AutoSize = true;
            OperationLabel.Location = new Point(134, 82);
            OperationLabel.Name = "OperationLabel";
            OperationLabel.Size = new Size(109, 20);
            OperationLabel.TabIndex = 5;
            OperationLabel.Text = "Тип операции";
            // 
            // OperationTypes
            // 
            OperationTypes.FormattingEnabled = true;
            OperationTypes.Location = new Point(112, 114);
            OperationTypes.Name = "OperationTypes";
            OperationTypes.Size = new Size(151, 28);
            OperationTypes.TabIndex = 6;
            OperationTypes.SelectedIndexChanged += OperationTypes_SelectedIndexChanged;
            // 
            // FromTime
            // 
            FromTime.Location = new Point(726, 20);
            FromTime.Name = "FromTime";
            FromTime.Size = new Size(250, 27);
            FromTime.TabIndex = 7;
            FromTime.ValueChanged += FromTime_ValueChanged;
            // 
            // UntilTime
            // 
            UntilTime.Location = new Point(726, 53);
            UntilTime.Name = "UntilTime";
            UntilTime.Size = new Size(250, 27);
            UntilTime.TabIndex = 8;
            UntilTime.ValueChanged += UntilTime_ValueChanged;
            // 
            // FromTimeLabel
            // 
            FromTimeLabel.AutoSize = true;
            FromTimeLabel.Location = new Point(664, 25);
            FromTimeLabel.Name = "FromTimeLabel";
            FromTimeLabel.RightToLeft = RightToLeft.No;
            FromTimeLabel.Size = new Size(52, 20);
            FromTimeLabel.TabIndex = 9;
            FromTimeLabel.Text = "После";
            // 
            // UntilTimeLabel
            // 
            UntilTimeLabel.AutoSize = true;
            UntilTimeLabel.Location = new Point(677, 60);
            UntilTimeLabel.Name = "UntilTimeLabel";
            UntilTimeLabel.Size = new Size(28, 20);
            UntilTimeLabel.TabIndex = 10;
            UntilTimeLabel.Text = "До";
            // 
            // LogWindow
            // 
            LogWindow.BackColor = SystemColors.ActiveCaption;
            LogWindow.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LogWindow.Location = new Point(28, 190);
            LogWindow.Name = "LogWindow";
            LogWindow.ReadOnly = true;
            LogWindow.Size = new Size(938, 308);
            LogWindow.TabIndex = 11;
            LogWindow.Text = "";
            // 
            // OpStatuses
            // 
            OpStatuses.FormattingEnabled = true;
            OpStatuses.Location = new Point(286, 112);
            OpStatuses.Name = "OpStatuses";
            OpStatuses.Size = new Size(150, 28);
            OpStatuses.TabIndex = 12;
            OpStatuses.SelectedIndexChanged += OpStatuses_SelectedIndexChanged;
            // 
            // ExitBtn
            // 
            ExitBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ExitBtn.Location = new Point(-1, -6);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(65, 53);
            ExitBtn.TabIndex = 13;
            ExitBtn.Text = "<";
            ExitBtn.UseVisualStyleBackColor = true;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // ClearFilters
            // 
            ClearFilters.Location = new Point(617, 136);
            ClearFilters.Name = "ClearFilters";
            ClearFilters.Size = new Size(167, 48);
            ClearFilters.TabIndex = 14;
            ClearFilters.Text = "Сбросить фильтры";
            ClearFilters.UseVisualStyleBackColor = true;
            ClearFilters.Click += ClearFilters_Click;
            // 
            // OpSum
            // 
            OpSum.Location = new Point(458, 40);
            OpSum.Name = "OpSum";
            OpSum.Size = new Size(150, 27);
            OpSum.TabIndex = 15;
            OpSum.ValueChanged += OpSum_ValueChanged;
            // 
            // CLearAllLogs
            // 
            CLearAllLogs.Location = new Point(799, 136);
            CLearAllLogs.Name = "CLearAllLogs";
            CLearAllLogs.Size = new Size(167, 48);
            CLearAllLogs.TabIndex = 16;
            CLearAllLogs.Text = "Очистить";
            CLearAllLogs.UseVisualStyleBackColor = true;
            CLearAllLogs.Click += CLearAllLogs_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(334, 82);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(52, 20);
            StatusLabel.TabIndex = 17;
            StatusLabel.Text = "Статус";
            // 
            // SumLabel
            // 
            SumLabel.AutoSize = true;
            SumLabel.Location = new Point(495, 10);
            SumLabel.Name = "SumLabel";
            SumLabel.Size = new Size(55, 20);
            SumLabel.TabIndex = 18;
            SumLabel.Text = "Сумма";
            // 
            // LogHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 521);
            Controls.Add(SumLabel);
            Controls.Add(StatusLabel);
            Controls.Add(CLearAllLogs);
            Controls.Add(OpSum);
            Controls.Add(ClearFilters);
            Controls.Add(ExitBtn);
            Controls.Add(OpStatuses);
            Controls.Add(LogWindow);
            Controls.Add(UntilTimeLabel);
            Controls.Add(FromTimeLabel);
            Controls.Add(UntilTime);
            Controls.Add(FromTime);
            Controls.Add(OperationTypes);
            Controls.Add(OperationLabel);
            Controls.Add(IDRoller);
            Controls.Add(ClientLabel);
            Controls.Add(bankLabel);
            Controls.Add(Banks);
            Name = "LogHistory";
            Text = "Form3";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)IDRoller).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpSum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox Banks;
        private Label bankLabel;
        private Label ClientLabel;
        private NumericUpDown IDRoller;
        private Label OperationLabel;
        private ComboBox OperationTypes;
        private DateTimePicker FromTime;
        private DateTimePicker UntilTime;
        private Label FromTimeLabel;
        private Label UntilTimeLabel;
        private RichTextBox LogWindow;
        private ComboBox OpStatuses;
        private Button ExitBtn;
        private Button ClearFilters;
        private NumericUpDown OpSum;
        private Button CLearAllLogs;
        private Label StatusLabel;
        private Label SumLabel;
    }
}