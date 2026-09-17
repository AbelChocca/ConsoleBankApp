using ConsoleBankingApp.Types;

namespace ConsoleBankingApp.Models;

public class BankAccount
{
    private readonly List<Transaction> _transactions = [];
    public Guid Id { get;}
    public string AccountNumber {get;}
    public decimal Balance {get; private set; }

    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    public BankAccount(string accountNumber)
    {
        if (string.IsNullOrWhiteSpace(accountNumber)) 
            throw new ArgumentException("El numero de cuenta es requerido");

        Id = Guid.NewGuid();
        AccountNumber = accountNumber;
        Balance = 0m;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("La cantidad de deposito debe ser mayor a 0.");

        Balance += amount;  

        _transactions.Add(
            new Transaction(amount, TransactionType.Deposit)
        );      
    }

    public void Withdraw(decimal amount)
    {
        if (amount<=0) 
            throw new ArgumentException("La cantidad debe ser mayor a 0.");

        if (amount > Balance)
            throw new InvalidOperationException("Insuficientes fondos.");

        Balance -= amount;

        _transactions.Add(
            new Transaction(amount, TransactionType.Withdrawal)
        );
    }

    public void TransferOut(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds.");

        Balance -= amount;

        _transactions.Add(
            new Transaction(amount, TransactionType.TransferOut)
        );
    }

    public void TransferIn(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Balance += amount;

        _transactions.Add(
            new Transaction(amount, TransactionType.TransferIn)
        );
    }

    public IEnumerable<Transaction> GetDeposits()
    {
        return _transactions
            .Where(t => t.Type == TransactionType.Deposit);
    }

    public IEnumerable<Transaction> GetWithdrawals()
    {
        return _transactions
            .Where(t => t.Type == TransactionType.Withdrawal);
    }

    public IEnumerable<Transaction> GetRecentTransactions(int topK = 5)
    {
        return _transactions
            .OrderByDescending(t => t.CreatedAt)
            .Take(topK);
            
    }

    public IEnumerable<Transaction> GetTransactionsGreaterThan(decimal amount)
    {
        return _transactions
            .Where(t => t.Amount > amount)
            .OrderByDescending(t => t.Amount);
    }

    public decimal GetTotalDeposits()
    {
        return _transactions
            .Where(t => t.Type == TransactionType.Deposit)
            .Sum(t => t.Amount);
    }

    public bool HasLargeTransactions(decimal threshold)
    {
        return _transactions
            .Any(t => t.Amount >= threshold);
    }

    public Transaction? GetLastTransaction()
    {
        return _transactions
            .OrderByDescending(t => t.CreatedAt)
            .FirstOrDefault();
    }

    public void PrintRecentTransactions(int topK = 5)
    {
        foreach(Transaction transaction in GetRecentTransactions(topK))
        {
            Console.WriteLine($"{transaction.Type} - {transaction.Amount} - {transaction.CreatedAt}");
        }
    }
}