using System;
using tumakov_lab_8;

namespace tumakov_lab_8
{
    /// <summary>
    /// Перечислимый тип данных, отображающий виды банковского счета
    /// </summary>
    enum AccountType { Current, Saving };

    class Program
    {
        static void Main()
        {
            Task1();
            Task2();
        }
        static void Task1()
        {
            Console.WriteLine("Упражнение 9.1");
            BankAccount account1 = new BankAccount(1234567.89m, AccountType.Saving);
            BankAccount account2 = new BankAccount(1.90m, AccountType.Current);

            Console.WriteLine(account1.AccountDetails());
            Console.WriteLine(account2.AccountDetails());

            Console.Write("Введите сумму для перевода: ");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal transferAmount))
            {
                account1.TransferTo(account2, transferAmount);
            }
            else
            {
                Console.WriteLine("Некорректный ввод суммы.");
            }

            Console.WriteLine("\nПосле перевода:");
            Console.WriteLine(account1.AccountDetails());
            Console.WriteLine(account2.AccountDetails());
        }
        static void Task2()
        {
            Console.WriteLine("\nУпражнение 9.2");
            BankAccount2 account3 = new BankAccount2(1234567.89m, AccountType.Saving);

            bool continueProgram = true;
            while (continueProgram)
            {
                Console.WriteLine(account3.AccountDetails());
                Console.WriteLine("Выберите действие:\n1. Положить деньги\n2. Снять деньги\n3. Выход");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте снова.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите сумму для пополнения: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account3.CheckIn(depositAmount);
                            Console.WriteLine($"Ваш баланс после пополнения: {account3.GetBalance()}");
                        }
                        else
                        {
                            Console.WriteLine("Некорректная сумма!");
                        }
                        break;
                    case 2:
                        Console.Write("Введите сумму для снятия: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                        {
                            account3.CheckOut(withdrawalAmount);
                            Console.WriteLine($"Ваш баланс после снятия: {account3.GetBalance()}");
                        }
                        else
                        {
                            Console.WriteLine("Некорректная сумма!");
                        }
                        break;
                    case 3:
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}