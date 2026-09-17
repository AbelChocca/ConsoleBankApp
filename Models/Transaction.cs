namespace ConsoleBankingApp.Models;

using ConsoleBankingApp.Types;

public class Transaction
{
    public Guid Id {get;}
    public decimal Amount { get;}
    public TransactionType Type {get;}
    public DateTime CreatedAt {get;}

    public Transaction(decimal amount, TransactionType type)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }
}