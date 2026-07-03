using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Banking
{
    public enum Operation
    {
        All,
        Deposit,
        Withdraw,
        Transfer
    }
    public enum Status
    {
        All,
        Success,
        Error
    }
    public partial class CurrentID : Form
    {
        private int CBIndex;
        private int id;
        private List<Bank> BankList;
        public string newWatch;
        public string newTotalSum;

        private int? _receiverBankIndex = null;  // Индекс банка-получателя
        private int? _receiverId = null;

        public string ReceiverNewWatch { get; private set; }
        public string ReceiverNewTotalSum { get; private set; }
        public int? ReceiverBankIndex { get; private set; }

        private readonly BankingMain mainform;
        public CurrentID(int CBIndex, int id, BankingMain mainform)
        {
            InitializeComponent();
            this.CBIndex = CBIndex;
            this.id = id;
            this.BankList = mainform.banks;
            this.Text = $"Bank {bank.GetBankName()}: ID{id:D3}";
            this.mainform = mainform;
        }

        public Bank bank
        {
            get { return BankList[CBIndex]; }
        }

        public void CurrentID_Load(object sender, EventArgs e)
        {
            Balance.Text = $"${bank.GetBalance(id - 1):F2}";
            BankName.Text = bank.GetBankName();
            UserID.Text = $"ID: {id:D3}";
            BankBox.DataSource = BankList;
            BankBox.SelectedIndex = CBIndex;
            foreach (LogEntry log in LogStorage.GetLogsByClient(id, bank.GetBankName()))
            {
                OpStatus.AppendText(log.ToString());
            }
            OpStatus.ScrollToCaret();
            if (OpStatus.Text != string.Empty)
            {
                ClearLogs.Enabled = true;
            }
        }
        public void CurrentID_FormOnClosing(object sender, FormClosingEventArgs e)
        {
            // Обновляем данные отправителя (как и раньше)
            newWatch = Balance.Text;
            newTotalSum = $"${bank.GetAllBalance().Sum():F2}";

            // ДОБАВЛЯЕМ: обновляем данные получателя, если был перевод
            if (_receiverBankIndex.HasValue && _receiverId.HasValue)
            {
                Bank receiverBank = BankList[_receiverBankIndex.Value];
                ReceiverNewWatch = $"${receiverBank.GetBalance(_receiverId.Value - 1):F2}";
                ReceiverNewTotalSum = $"${receiverBank.GetAllBalance().Sum():F2}";
                ReceiverBankIndex = _receiverBankIndex.Value;
            }
        }
        public string Message(Operation op, int id, Status status, Bank BankReceiver = null)
        {
            if (op == Operation.Transfer)
            {
                if (status == Status.Success)
                {
                    return $"[{DateTime.Now}]\n{op} {bank.GetBankName()} ID{id:D3} -> {BankReceiver.GetBankName()} ID{(int)ReceiverID.Value:D3} успешно:\n-${TransferSum.Value:F2}\n";
                }
                return $"[{DateTime.Now}]\n{op} {bank.GetBankName()} ID{id:D3} -> {BankReceiver.GetBankName()} ID{(int)ReceiverID.Value:D3}: ${TransferSum.Value}\nНедостаточно средств\n";
            }
            if (status == Status.Success)
            {
                return $"[{DateTime.Now}]\n{op} {bank.GetBankName()} ID{id:D3} успешно:\n+${DWSum.Value:F2}\n";
            }
            return $"[{DateTime.Now}]\n{op} {bank.GetBankName()} ID{id:D3}: ${DWSum.Value}\nНедостаточно средств\n";

        }
        private void Deposit_Click(object sender, EventArgs e)
        {
            Status operation = bank.Deposit(id, DWSum.Value);
            Balance.Text = $"${bank.GetBalance(id - 1):F2}";
            string message = Message(Operation.Deposit, id, operation);
            OpStatus.AppendText(message);
            OpStatus.ScrollToCaret();
            OpStatus.AppendText("---------------\n");

            LogStorage.AddLog(new LogEntry
            {
                Timestamp = DateTime.Now,
                BankName = bank.GetBankName(),
                ClientId = id,
                OperationType = Operation.Deposit,
                Amount = DWSum.Value,
                status = operation,
                Details = message
            });
            ClearLogs.Enabled = true;
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            Status operation = bank.Withdraw(id, DWSum.Value);
            Balance.Text = $"${bank.GetBalance(id - 1):F2}";
            string message = Message(Operation.Withdraw, id, operation);
            OpStatus.AppendText(message);
            OpStatus.ScrollToCaret();
            OpStatus.AppendText("---------------\n");
            LogStorage.AddLog(new LogEntry
            {
                Timestamp = DateTime.Now,
                BankName = bank.GetBankName(),
                ClientId = id,
                OperationType = Operation.Withdraw,
                Amount = DWSum.Value,
                status = operation,
                Details = message
            });
            ClearLogs.Enabled = true;
        }
        private void Transfer_Click(object sender, EventArgs e)
        {
            Bank? BankReceiver = (Bank?)BankBox.SelectedItem;
            int receiverBankIndex = BankBox.Items.IndexOf(BankBox.SelectedItem);
            int receiverId = (int)ReceiverID.Value;

            Status operation = bank.Transfer(id, receiverId, TransferSum.Value, BankReceiver);
            
            if (operation == Status.Success)
            {
                // Сохраняем информацию о получателе для отображения в BankingMain
                _receiverBankIndex = receiverBankIndex;
                _receiverId = receiverId;
            }
            Balance.Text = $"${bank.GetBalance(id - 1):F2}";
            string message = Message(Operation.Transfer, id, operation, BankReceiver);
            OpStatus.AppendText(message);
            OpStatus.ScrollToCaret();
            OpStatus.AppendText("---------------\n");
            
            LogStorage.AddLog(new LogEntry
            {
                Timestamp = DateTime.Now,
                BankName = bank.GetBankName(),
                ClientId = id,
                OperationType = Operation.Transfer,
                Amount = TransferSum.Value,
                status = operation,
                Details = message
            });
            ClearLogs.Enabled = true;
        }

        private void DWSum_ValueChanged(object sender, EventArgs e)
        {
            DWSum.Value = Math.Round(DWSum.Value, 2);
            if (DWSum.Value >= 1)
            {
                Deposit.Enabled = true;
                Withdraw.Enabled = true;
            }
            else
            {
                Deposit.Enabled = false;
                Withdraw.Enabled = false;
            }
        }
        private bool isValidTransfer()
        {
            if (BankBox.SelectedItem == bank)
            {
                return ReceiverID.Value != id && ReceiverID.Value > 0 && TransferSum.Value >= 1;
            }
            else
            {
                return TransferSum.Value >= 1 && ReceiverID.Value > 0 && BankBox.SelectedItem != null;
            }
        }
        private void BankBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isValidTransfer())
            {
                Transfer.Enabled = true;

            }
            else
            {
                Transfer.Enabled = false;
            }
            Bank? BankReceiver = (Bank?)BankBox.SelectedItem;
            ReceiverID.Maximum = BankReceiver.GetNumClients();
        }

        private void TransferSum_ValueChanged(object sender, EventArgs e)
        {
            TransferSum.Value = Math.Round(TransferSum.Value, 2);
            if (isValidTransfer())
            {
                Transfer.Enabled = true;
            }
            else
            {
                Transfer.Enabled = false;
            }
        }

        private void ReceiverID_ValueChanged(object sender, EventArgs e)
        {
            if (isValidTransfer())
            {
                Transfer.Enabled = true;
            }
            else
            {
                Transfer.Enabled = false;
            }
        }

        private void BackToMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AllSum_Click(object sender, EventArgs e)
        {
            DWSum.Value = bank.GetBalance(id - 1);
            DWSum.Refresh();
        }

        private void AllSumTransfer_Click(object sender, EventArgs e)
        {
            TransferSum.Value = bank.GetBalance(id - 1);
            TransferSum.Refresh();
        }

        private void ClearLogs_Click(object sender, EventArgs e)
        {

            OpStatus.ResetText();
            LogStorage.ClearLogsByClient(id, bank.GetBankName());
            ClearLogs.Enabled = false;
        }
    }
}
