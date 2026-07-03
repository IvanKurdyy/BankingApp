using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Banking
{
    public partial class LogHistory : Form
    {
        private readonly BankingMain mainform;
        private List<Bank> banks;
        public LogHistory(BankingMain mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            this.banks = mainform.banks;
            this.Text = "История операций";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var bankBox = new List<object>();
            bankBox.Add("All");
            bankBox.AddRange(banks.Cast<object>());
            Banks.DataSource = bankBox;
            var operations = Enum.GetValues(typeof(Operation));
            var statuses = Enum.GetValues(typeof(Status));

            OperationTypes.DataSource = operations;
            OpStatuses.DataSource = statuses;

            // Установка начальных значений дат
            FromTime.Value = DateTime.Today.AddDays(-365);
            UntilTime.Value = DateTime.Now;
            FromTime.Format = DateTimePickerFormat.Custom;
            FromTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            UntilTime.Format = DateTimePickerFormat.Custom;
            UntilTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            // Первоначальная загрузка
            RefreshLogs();

        }

        private void RefreshLogs()
        {
            LogWindow.Clear();
            string bankName = null;
            if (Banks.SelectedItem is Bank selectedBank)
            {
                bankName = selectedBank.BankName;
            }
            foreach (LogEntry entry in LogStorage.GetLogsBySeveral((int?)IDRoller.Value, bankName, (Operation?)OperationTypes.SelectedValue, FromTime.Value, UntilTime.Value, (Status?)OpStatuses.SelectedValue, OpSum.Value))
            {
                LogWindow.AppendText(entry.ToString());
            }
        }
        private void Banks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Banks.SelectedItem != "All")
            {
                IDRoller.Maximum = ((Bank?)Banks.SelectedItem).GetNumClients();
            }
            else
            {
                IDRoller.Maximum = banks.Select(bank => bank.GetNumClients()).Max();
            }
            RefreshLogs();
        }

        private void IDRoller_ValueChanged(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void OperationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLogs();
        }
        private void FromTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void UntilTime_ValueChanged(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void OpStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void OpSum_ValueChanged(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFilters_Click(object sender, EventArgs e)
        {
            IDRoller.Value = 0;
            Banks.SelectedItem = "All";
            OpStatuses.SelectedItem = Status.All;
            OperationTypes.SelectedItem = Operation.All;
            OpSum.Value = 0;
            UntilTime.Value = DateTime.Now;
        }

        private void CLearAllLogs_Click(object sender, EventArgs e)
        {
            LogStorage.Clear();
            RefreshLogs();
        }
    }
}
