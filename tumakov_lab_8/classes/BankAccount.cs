using System;
namespace tumakov_lab_8
{
    /// <summary>
    /// Класс Счёт в банке
    /// </summary>
    internal class BankAccount
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        private Guid accountNumber;

        /// <summary>
        /// Баланс
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        private AccountType type;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BankAccount() : this(0, AccountType.Current) { }

        /// <summary>
        /// Конструктор для баланса
        /// </summary>
        /// <param name="initialBalance">Начальный баланс</param>
        public BankAccount(decimal initialBalance) : this(initialBalance, AccountType.Current) { }

        /// <summary>
        /// Конструктор для типа счета
        /// </summary>
        /// <param name="accountType">Тип счета</param>
        public BankAccount(AccountType accountType) : this(0, accountType) { }

        /// <summary>
        /// Конструктор для баланса и типа счета
        /// </summary>
        /// <param name="initialBalance">Начальный баланс</param>
        /// <param name="accountType">Тип счета</param>
        public BankAccount(decimal initialBalance, AccountType accountType)
        {
            accountNumber = GenerateAccountNumber();
            balance = initialBalance;
            type = accountType;
        }

        /// <summary>
        /// Метод для генерации уникального номера счета
        /// </summary>
        /// <returns>Уникальный идентификатор счета</returns>
        private Guid GenerateAccountNumber()
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="amount">Сумма для снятия</param>
        public void CheckOut(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств для снятия.");
            }
        }

        /// <summary>
        /// Метод для пополнения счета
        /// </summary>
        /// <param name="amount">Сумма для пополнения</param>
        public void CheckIn(decimal amount)
        {
            balance += amount;
        }

        /// <summary>
        /// Метод для получения информации о счете
        /// </summary>
        /// <returns>Информация о счете</returns>
        public string AccountDetails()
        {
            return $"Номер счета: {accountNumber}\nБаланс: {balance} руб.\nТип счета: {type}";
        }

        /// <summary>
        /// Метод для перевода средств между счетами
        /// </summary>
        /// <param name="destinationAccount">Счет-получатель</param>
        /// <param name="transferAmount">Сумма перевода</param>
        public void TransferTo(BankAccount destinationAccount, decimal transferAmount)
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
    }
}
