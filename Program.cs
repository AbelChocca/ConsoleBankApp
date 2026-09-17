using ConsoleBankingApp.Models;
using ConsoleBankingApp.Services;

namespace ConsoleBankingApp;

internal class Program
{
    static void Main(string[] args)
    {
        IAccountService accountService = new AccountService();

        BankAccount account1 = new("001");
        BankAccount account2 = new("002");

        accountService.Deposit(account1, 1000m);

        accountService.Transfer(
            account1,
            account2,
            250m
        );

        Console.WriteLine($"Account 1: {account1.Balance}");
        Console.WriteLine($"Account 2: {account2.Balance}");
    }
}