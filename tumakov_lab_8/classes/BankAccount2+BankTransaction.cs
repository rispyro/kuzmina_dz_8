using System;
using System.Collections.Generic;

namespace tumakov_lab_8
{
    /// <summary>
    /// класс для представления банковских транзакций
    /// </summary>
    internal class BankTransaction
    {
        /// <summary>
        /// дата и время транзакции
        /// </summary>
        public readonly DateTime TransactionDateTime;
        /// <summary>
        /// сумма транзакции
        /// </summary>
        public readonly decimal Amount;
        /// <summary>
        /// конструктор для транзакций
        /// </summary>
        /// <param name="amount"></param>
        public BankTransaction(decimal amount)
        {
            TransactionDateTime = DateTime.Now;
            Amount = amount;
        }
    }
    /// <summary>
    /// класс банковского счета
    /// </summary>
    internal class BankAccount2
    {
        /// <summary>
        /// номер счета
        /// </summary>
        private Guid accountNumber;
        /// <summary>
        /// баланс
        /// </summary>
        private decimal balance;
        /// <summary>
        /// тип банковского счета
        /// </summary>
        private AccountType type;
        /// <summary>
        /// очередь транзакций
        /// </summary>
        private Queue<BankTransaction> transactions = new Queue<BankTransaction>();
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public BankAccount2() : this(0, AccountType.Current) { }
        /// <summary>
        /// конструктор для баланса
        /// </summary>
        /// <param name="initialBalance"></param>
        public BankAccount2(decimal initialBalance) : this(initialBalance, AccountType.Current) { }
        /// <summary>
        /// конструктор для типа счета
        /// </summary>
        /// <param name="accountType"></param>
        public BankAccount2(AccountType accountType) : this(0, accountType) { }
        /// <summary>
        /// конструктор для баланса и типа счета
        /// </summary>
        /// <param name="initialBalance"></param>
        /// <param name="accountType"></param>
        public BankAccount2(decimal initialBalance, AccountType accountType)
        {
            accountNumber = GenerateAccountNumber();
            balance = initialBalance;
            type = accountType;
        }
        /// <summary>
        /// метод для генерации уникального номера счета
        /// </summary>
        /// <returns></returns>
        private Guid GenerateAccountNumber()
        {
            return Guid.NewGuid();
        }
        /// <summary>
        /// метод для снятия со счета
        /// </summary>
        /// <param name="amount"></param>
        public void CheckOut(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                transactions.Enqueue(new BankTransaction(-amount));
            }
            else
            {
                Console.WriteLine("Недостаточно средств для снятия.");
            }
        }
        /// <summary>
        /// метод для пополнения счета
        /// </summary>
        /// <param name="amount"></param>
        public void CheckIn(decimal amount)
        {
            balance += amount;
            transactions.Enqueue(new BankTransaction(amount));
        }
        /// <summary>
        /// метод для получения информации о счете
        /// </summary>
        /// <returns></returns>
        public string AccountDetails()
        {
            return $"Номер счета: {accountNumber}\nБаланс: {balance} руб.\nТип счета: {type}";
        }
        /// <summary>
        /// метод для перевода средств между счетами
        /// </summary>
        /// <param name="destinationAccount"></param>
        /// <param name="transferAmount"></param>
        public void TransferTo(BankAccount2 destinationAccount, decimal transferAmount)
        {
            if (balance >= transferAmount)
            {
                CheckOut(transferAmount);
                destinationAccount.CheckIn(transferAmount);
            }
            else
            {
                Console.WriteLine("Недостаточно средств для перевода.");
            }
        }
        /// <summary>
        /// метод, возвращающий все транзакции, связанные с данным счетом
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankTransaction> GetTransactions()
        {
            foreach (var transaction in transactions)
            {
                yield return transaction;
            }
        }

        /// <summary>
        /// Новый публичный метод для получения текущего баланса
        /// </summary>
        /// <returns></returns>
        public decimal GetBalance()
        {
            return balance;
        }
    }
}
