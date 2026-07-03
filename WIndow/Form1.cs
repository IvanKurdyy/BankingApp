using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Collections.Generic;
using System.Linq;
namespace Banking
{
    public partial class BankingMain : Form
    {
        public List<Bank> banks;
        private List<BankGroup> bankGroups = new List<BankGroup>();

        public BankingMain()
        {
            InitializeComponent();
            banks = DataSaver.Load();
            LogStorage.LoadFromFile();

            for (int i = 0; i < banks.Count; i++)
            {
                ShowBankOnScreen(banks[i], i);
            }
            if (banks.Count > 0) { UpdateWholeBalance(); }


            this.FormClosing += (s, e) => DataSaver.Save(banks);
        }

        private void BankingMain_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }
        public void UpdateBankDisplay(int bankIndex, string newWatch = null, string newTotalSum = null)
        {

            if (bankIndex >= 0 && bankIndex < bankGroups.Count)
            {
                bankGroups[bankIndex].UpdateBankData(newWatch, newTotalSum);
            }
            UpdateWholeBalance();
        }

        private void ShowBankOnScreen(Bank bank, int index)
        {
            BankGroup group = new BankGroup(banks, index, this);
            group.BankName.Text = bank.GetBankName();

            bankGroups.Add(group);
            panel.Controls.Add(group.AddClient);
            panel.Controls.Add(group.IDRoller);
            panel.Controls.Add(group.UserID);
            panel.Controls.Add(group.Watch);
            panel.Controls.Add(group.BankName);
            panel.Controls.Add(group.TotalBankSum);
        }

        public void UpdateWholeBalance()
        {
            decimal total = 0;
            if (banks == null)
            {
                WholeBalance.Text = "$0,00";
                return;
            }
            foreach (var bank in banks)
            {
                total += bank.GetAllBalance().Sum();
            }
            WholeBalance.Text = $"${total:F2}";
        }
        private void AddNewBank_Click(object sender, EventArgs e)
        {
            Bank NewBank = new Bank(NewBankName.Text);
            banks.Add(NewBank);

            ShowBankOnScreen(NewBank, banks.Count - 1);

            NewBankName.Clear();
            AddNewBank.Enabled = false;
        }

        private bool isValidBankName(string bankName)
        {
            return !banks.Select(bank => bank.GetBankName()).Contains(bankName) && bankName != "";
        }
        private void NewBankName_TextChanged(object sender, EventArgs e)
        {
            if (isValidBankName(NewBankName.Text))
            {
                AddNewBank.Enabled = true;
            }
            else
            {
                AddNewBank.Enabled = false;
            }
        }
        private void NewBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isValidBankName(NewBankName.Text))
            {
                AddNewBank_Click(sender, e);

                // Отменяем звуковой сигнал при нажатии Enter
                e.SuppressKeyPress = true;
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            banks.Clear();
            bankGroups.Clear();
            LogStorage.Clear();
            UpdateWholeBalance();
            panel.Controls.Clear();
            panel.Controls.Add(ClearBtn);
            panel.Controls.Add(NewBankName);
            panel.Controls.Add(AddNewBank);
            panel.Controls.Add(WholeBalance);
            panel.Controls.Add(WatchLogs);
            panel.Controls.Add(GetDiagram);
        }

        private void WatchLogs_Click(object sender, EventArgs e)
        {
            LogHistory logs = new LogHistory(this);
            logs.ShowDialog();
        }
        private void GetDiagram_Click(object sender, EventArgs e)
        {
            Diagram diagram = new Diagram(this);
            diagram.ShowDialog();
        }
    }
}
