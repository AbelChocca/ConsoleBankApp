using ConsoleBankingApp.Models;

namespace ConsoleBankingApp.Services;

public interface IAccountService
{
    void Deposit(BankAccount account, decimal amount);

    void Withdraw(BankAccount account, decimal amount);

    void Transfer(
        BankAccount source,
        BankAccount destination,
        decimal amount
    );
}