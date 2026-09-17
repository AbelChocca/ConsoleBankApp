using ConsoleBankingApp.Models;
namespace ConsoleBankingApp.Services;

public class AccountService : IAccountService
{
    public void Deposit(BankAccount account, decimal amount)
    {
        account.Deposit(amount);
    }

    public void Withdraw(BankAccount account, decimal amount)
    {
        account.Withdraw(amount);
    }

    public void Transfer(
        BankAccount source,
        BankAccount destination,
        decimal amount
    )
    {
        source.TransferOut(amount);
        destination.TransferIn(amount);
    }

    
}