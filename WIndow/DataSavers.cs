using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Banking
{
    // Класс для хранения одной записи лога
    public struct LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string BankName { get; set; }
        public int ClientId { get; set; }
        public Operation OperationType { get; set; } // Deposit, Withdraw, Transfer
        public decimal Amount { get; set; }
        public Status status { get; set; }

        public string Details { get; set; } // Полный текст из OpStatus

        public override string ToString()
        {
            return Details + "---------------\n";
        }
    }

    // Статический класс для хранения всех логов
    public static class LogStorage
    {
        public static List<LogEntry> AllLogs { get; private set; } = new List<LogEntry>();

        // Сохранять логи в файл при добавлении
        public static void AddLog(LogEntry entry)
        {
            AllLogs.Add(entry);
            SaveToFile();
        }

        public static void Clear()
        {
            AllLogs.Clear();
            SaveToFile();
        }
        
        private static void SaveToFile()
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(AllLogs);
                File.WriteAllText("logs.json", json);
            }
            catch { }
        }

        // Загружать логи при старте программы
        public static void LoadFromFile()
        {
            try
            {
                if (File.Exists("logs.json"))
                {
                    string json = File.ReadAllText("logs.json");
                    AllLogs = System.Text.Json.JsonSerializer.Deserialize<List<LogEntry>>(json)
                             ?? new List<LogEntry>();
                }
            }
            catch { }
        }
        public static void ClearLogsByClient(int clientId, string bankName)
        {
            AllLogs.RemoveAll(log => log.ClientId == clientId && log.BankName == bankName);
            SaveToFile();
        }

        public static void ClearLogsByBank(string bankName)
        {
            AllLogs.RemoveAll(log => log.BankName == bankName);
            SaveToFile();
        }
        public static IEnumerable<LogEntry> GetLogsByBank(string bankName)
        {
            return AllLogs.Where(log => log.BankName == bankName);
        }

        public static IEnumerable<LogEntry> GetLogsByClient(int clientId,string bankName)
        {
            return AllLogs.Where(log => log.ClientId == clientId && log.BankName == bankName);
        }

        public static IEnumerable<LogEntry> GetLogsBySeveral(
    int? clientId = null,           
    string? bankName = null,
    Operation? operationType = null, 
    DateTime? from = null,
    DateTime? to = null,
    Status? status = null,
    decimal? amount = null)
        {
            IEnumerable<LogEntry> query = AllLogs;

            // Фильтр по клиенту (если указан)
            if (clientId.HasValue && clientId > 0)
                query = query.Where(log => log.ClientId == clientId.Value);

            // Фильтр по банку (если указан)
            if (!string.IsNullOrEmpty(bankName))
                query = query.Where(log => log.BankName == bankName);

            // Фильтр по операции (если указана)
            if (operationType.HasValue && operationType != Operation.All)
                query = query.Where(log => log.OperationType == operationType.Value);

            // Фильтр по дате "от" (если указана)
            if (from.HasValue)
                query = query.Where(log => log.Timestamp >= from.Value);

            // Фильтр по дате "до" (если указана)
            if (to.HasValue)
                query = query.Where(log => log.Timestamp <= to.Value);

            // Фильтр по статусу (если указан)
            if (status.HasValue && status != Status.All)
                query = query.Where(log => log.status == status.Value);

            if (amount.HasValue && amount != 0)
            {
                query = query.Where(log => log.Amount == amount.Value);
            }
            return query.OrderByDescending(log => log.Timestamp); // сортировка
        }
    }

    public static class DataSaver
    {
        private static readonly string FilePath = "bank_data.json";

        // Сохранить данные
        public static void Save(List<Bank> banks)
        {
            try
            {
                // Превращаем список банков в текст (JSON)
                string json = JsonConvert.SerializeObject(banks, Formatting.Indented);

                // Сохраняем в файл
                File.WriteAllText(FilePath, json);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузить данные
        public static List<Bank> Load()
        {
            // Если файла нет - возвращаем пустой список
            if (!File.Exists(FilePath))
            {
                return new List<Bank>();
            }

            // Читаем текст из файла
            string json = File.ReadAllText(FilePath);

            // Превращаем текст обратно в список банков
            List<Bank> banks = JsonConvert.DeserializeObject<List<Bank>>(json);

            // Если ничего не получилось - возвращаем пустой список
            return banks ?? new List<Bank>();
        }
    }
}