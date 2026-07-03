namespace CourseWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint[] balance1 = { 10, 100, 20, 50, 30 };
            uint[] balance2 = { 20, 40, 80, 560, 13423, 134, 2323 };
            uint[] balance3 = { 134, 245, 356356, 24524, 23252, 23424,23,23,2,34,543,35,35 };
            Bank bank1 = new Bank(balance1,BankName:"Сбер",Messager: false);
            Bank bank2 = new Bank(balance2,BankName: "Т-Банк");
            Bank bank3 = new Bank(balance3,BankName: "Альфа");

            // Сообщения выводятся при включенном месседжере (default - вкл)

            bank3.Transfer(3, 2, 900); // перевод с 3го на 2ой счёт
            bank2.Deposit(4, 1000); // пополнение 4го счёта
            bank1.Withdraw(2, 30); // снятие со 2го счёта
            bank1.Transfer(6, 1, 30); // ошибка: 6го счёта нет
            bank1.AddNewClient(80); // добавляем новый счёт (в конец) 
            bank1.Transfer(6, 1, 30); // теперь ошибки нет
            bank2.Transfer(2, 1, 60); // ошибка: недостаточно средств
            bank3.Transfer(11, 1, 50); // сообщение не выведется - отключили месседжер, MessagerOn() для включения

            // Просмотр балансов каждого клиента (без доступа к редактированию)
            for (int i = 0; i < bank1.GetNumClients(); i++)
            {
                Console.Write($"{bank1.GetBalance(i)} ");
            }
            Console.Write("\n");
            for (int i = 0; i < bank2.GetNumClients(); i++)
            {
                Console.Write($"{bank2.GetBalance(i)} ");
            }
            Console.Write("\n");
            for (int i = 0; i < bank3.GetNumClients(); i++)
            {
                Console.Write($"{bank3.GetBalance(i)} ");
            }
        }
    }
}
