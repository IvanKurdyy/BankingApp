using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Banking
{
    [Serializable]
    public class Bank
    {
        public List<decimal> Balance; 
        public string BankName;

        public Bank()
        {
            Balance = new List<decimal>();
        }
        public Bank(string BankName = "Новый банк") : this()
        {
            this.Balance = new List<decimal>();
            this.BankName = BankName;
        }

        public override string ToString()
        {
            return BankName;
        }
        public string GetBankName()
        {
            return BankName;
        }
        // Публичный метод для получения баланса по индексу
        public decimal GetBalance(int id)
        {
            return Balance[id];
        }

        public List<decimal> GetAllBalance()
        {
            return Balance;
        }
        // Публичный метод для получения кол-ва клиентов
        public int GetNumClients()
        {
            return Balance.Count;
        }
        
        // Метод для добавления в конец нового клиента
        public void AddNewClient(decimal balance)
        {
            Balance.Add(balance);
        }

        // Операции Перевода, Пополнения и Снятия средств с учетом условий на индексы счёта и их баланс
        public Status Transfer(int account1, int account2, decimal money, Bank BankTo)
        {
            if (money <= Balance[account1 - 1])
            {
                Balance[account1 - 1] -= money;
                BankTo.Balance[account2 - 1] += money;

                return Status.Success;
            }

            return Status.Error;
        }

        public Status Deposit(int account, decimal money)
        {
            Balance[account - 1] += money;

            return Status.Success;
        }

        public Status Withdraw(int account, decimal money)
        {
            if (money <= Balance[account - 1])
            {
                Balance[account - 1] -= money;

                return Status.Success;
            }

            return Status.Error;

        }
    }
    public struct BankGroup
    {
        public Button AddClient;
        public Button Watch;
        public Label UserID;
        public Label BankName;
        public NumericUpDown IDRoller;
        public Label TotalBankSum;

        public List<Bank> banks;
        public int bankIndex;

        public const int yOffset = 70;

        public BankingMain mainform;

        public BankGroup(List<Bank> banks,int bankIndex,BankingMain mainform)
        {
            this.banks = banks;
            this.bankIndex = bankIndex;
            this.mainform = mainform;
            
            AddClient = new Button();
            Watch = new Button();
            UserID = new Label();
            IDRoller = new NumericUpDown();
            BankName = new Label();
            TotalBankSum = new Label();
            ((System.ComponentModel.ISupportInitialize)IDRoller).BeginInit();


            AddClient.Location = new Point(598, 90+60+bankIndex*yOffset);
            AddClient.Name = "AddClient"+$"{bankIndex+1}";
            AddClient.Size = new Size(144, 50);
            AddClient.TabIndex = 0;
            AddClient.Text = "Создать счёт";
            AddClient.UseVisualStyleBackColor = true;
            AddClient.Click += AddClient_Click;

            Watch.Enabled = false;
            Watch.Location = new Point(300, 90+60+bankIndex*yOffset);
            Watch.Name = "Watch" + $"{bankIndex + 1}";
            Watch.Size = new Size(120, 50);
            Watch.TabIndex = 23;
            Watch.Text = "$";
            Watch.UseVisualStyleBackColor = true;
            Watch.Click += Watch_Click;

            IDRoller.Location = new Point(458, 104+60+bankIndex*yOffset);
            IDRoller.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            IDRoller.Name = "IDRoller" + $"{bankIndex + 1}";
            IDRoller.Size = new Size(104, 27);
            IDRoller.TabIndex = 19;
            IDRoller.ValueChanged += IDRoller_ValueChanged;

            BankName.AutoSize = true;
            BankName.Location = new Point(55, 106+60+bankIndex*yOffset);
            BankName.Name = "BankName" + $"{bankIndex + 1}";
            BankName.Size = new Size(34, 20);
            BankName.TabIndex = 16;

            UserID.AutoSize = true;
            UserID.Location = new Point(125, 104+60+bankIndex*yOffset);
            UserID.Name = "UserID" + $"{bankIndex + 1}";
            UserID.Size = new Size(17, 20);
            UserID.TabIndex = 12;
            UserID.Text = "0";

            TotalBankSum.AutoSize = true;
            TotalBankSum.Location = new Point(206, 104+60+bankIndex*yOffset);
            TotalBankSum.Name = "TotalBankSum";
            TotalBankSum.Size = new Size(50, 20);
            TotalBankSum.TabIndex = 30;
            TotalBankSum.Text = $"${banks[bankIndex].GetAllBalance().Sum():F2}";
            int clientCount = banks[bankIndex].GetNumClients();
            UserID.Text = clientCount.ToString();
            IDRoller.Maximum = clientCount;

            ((System.ComponentModel.ISupportInitialize)IDRoller).EndInit();

        }
        public void UpdateBankData(string newWatchText = null, string newTotalSumText = null)
        {
            if (newWatchText != null)
            {
                // Обновляем текст на кнопке Watch, но проверяем ID
                int currentId = (int)IDRoller.Value;
                if (currentId > 0)
                {
                    Watch.Text = $"${banks[bankIndex].GetBalance(currentId-1):F2}" ;
                }
            }

            if (newTotalSumText != null)
            {
                TotalBankSum.Text = newTotalSumText;
            }
        }
        public void AddClient_Click(object sender, EventArgs e)
        {
            banks[bankIndex].AddNewClient(0);
            int idCount = banks[bankIndex].GetNumClients();
            UserID.Text = $"{idCount}";
            IDRoller.Maximum = idCount;
        }
        private void IDRoller_ValueChanged(object sender, EventArgs e)
        {
            int id = (int)IDRoller.Value;
            if (id == 0)
            {
                Watch.Enabled = false;
                Watch.Text = "$";
            }
            else
            {
                Watch.Enabled = true;
                Watch.Text = $"${banks[bankIndex].GetBalance(id - 1):F2}";
            }
        }

        private void Watch_Click(object sender, EventArgs e)
        {
            int UID = (int)IDRoller.Value;
            if (UID != 0)
            {
                // КОПИРУЕМ ЗНАЧЕНИЯ В ЛОКАЛЬНЫЕ ПЕРЕМЕННЫЕ
                int currentBankIndex = this.bankIndex;  // Копируем значение
                int currentId = UID;
                var currentBanks = this.banks;  // Копируем ссылку на список
                BankingMain mainForm = mainform;
                CurrentID UserInfo = new CurrentID(currentBankIndex, currentId,mainform);

                UserInfo.FormClosed += (s, args) => {

                    mainForm.UpdateBankDisplay(currentBankIndex, UserInfo.newWatch, UserInfo.newTotalSum);
                    if (UserInfo.ReceiverBankIndex.HasValue)
                    {
                        mainForm.UpdateBankDisplay(
                        UserInfo.ReceiverBankIndex.Value,
                        UserInfo.ReceiverNewWatch,
                        UserInfo.ReceiverNewTotalSum
                        );
                    }
                };

                UserInfo.ShowDialog();
            }
        }

    }
}
