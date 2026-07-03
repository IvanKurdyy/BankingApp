namespace CourseWork
{
    struct Bank
    {
        // Задаем поля
        private uint[] Balance; 
        private bool Messager;
        private string BankName;

        // Конструктор
        public Bank(uint[] Balance,bool Messager = true,string BankName = "Новый банк")
        {
            this.Balance = Balance;
            this.Messager = Messager;
            this.BankName = BankName;
        }


        // Свойство для внутреннего пользования (без set - только для чтения)
        private int N
        {
            get { return GetNumClients(); }
        }

        // Публичный метод для получения баланса по индексу
        public uint GetBalance(int id)
        {
            return Balance[id];
        }
        // Публичный метод для получения кол-ва клиентов
        public int GetNumClients()
        {
            return Balance.Length;
        }
        
        // Методы для вкл/выкл логов
        public void MessagerOff()
        {
            Messager = false;
        }
        public void MessagerOn()
        {
            Messager = true;
        }
        // Метод для добавления в конец нового клиента
        public void AddNewClient(uint balance)
        {
            Balance = Balance.Append(balance).ToArray();
        }
        // Метод для создания лога по проведенной операции и кода возврата (используется шаблонная строка)
        private bool CallMessager(bool status, int from = 0,int to = 0,string hint = "Успешно")
        {
            if (Messager)
            {
                Console.WriteLine($"{BankName} | ID {from:D3}/{to:D3} | {status} - {hint}");
            }
            return status;
                
        }

        // Операции Перевода, Пополнения и Снятия средств с учетом условий на индексы счёта и их баланс
        public bool Transfer(int account1, int account2, uint money)
        {
            if (account1 - 1 < N && 0 <= account1 - 1 && account2 - 1 < N && account2 >= 0)
            {
                if (money <= Balance[account1 - 1])
                {
                    Balance[account1 - 1] -= money;
                    Balance[account2 - 1] += money;

                    return CallMessager(true, from: account1, to: account2);
                }

                return CallMessager(false, from: account1, to: account2,hint: "Недостаточно средств");

            }
            return CallMessager(false,from: account1, to: account2,hint: "Неверные ID");
        }

        public bool Deposit(int account, uint money)
        {
            if (0 <= account - 1 && account - 1 < N)
            {
                Balance[account - 1] += money;

                return CallMessager(true, from: 0,to: account);
            }

            return CallMessager(false, from: 0, to: account,hint: "Неверный ID");
        }

        public bool Withdraw(int account, uint money)
        {
            if (0 <= account - 1 && account - 1 < N)
            {
                if (money <= Balance[account - 1])
                {
                    Balance[account - 1] -= money;

                    return CallMessager(true, from: account,to: 0);
                }

                return CallMessager(false, from: account, to: 0, hint: "Недостаточно средств");
            }

            return CallMessager(false, from: account,to: 0,hint: "Неверный ID");
        }
    }
}
