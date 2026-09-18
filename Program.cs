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
        accountService.Deposit(account2, 500m);

        accountService.Transfer(
            account1,
            account2,
            250m
        );

        accountService.Transfer(
            account2,
            account1,
            100m
        );

        accountService.Withdraw(account1, 50m);

        accountService.Deposit(account1, 300m);

        accountService.Transfer(
            account1,
            account2,
            200m
        );

        Console.WriteLine("=== BALANCES ===");
        Console.WriteLine($"Account 1: {account1.Balance}");
        Console.WriteLine($"Account 2: {account2.Balance}");

        Console.WriteLine();

        Console.WriteLine("=== RECENT TRANSACTIONS - ACCOUNT 1 ===");

        account1.PrintRecentTransactions(10);

        Console.WriteLine();

        Console.WriteLine("=== RECENT TRANSACTIONS - ACCOUNT 2 ===");

        account2.PrintRecentTransactions(10);

        Console.WriteLine("=== RECENT NOTIFICATIONS - ACCOUNT 1 ===");

        account1.PrintRecentNotifications(10);

        Console.WriteLine("=== RECENT NOTIFICATIONS - ACCOUNT 2 ===");

        account2.PrintRecentNotifications(10);
    }
}