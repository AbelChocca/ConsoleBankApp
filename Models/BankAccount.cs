namespace ConsoleBankingApp.Models;

public class BankAccount
{
    public Guid Id { get;}
    public string AccountNumber {get;}
    public decimal Balance {get; private set; }

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
    }

    public void Withdraw(decimal amount)
    {
        if (amount<=0) 
            throw new ArgumentException("La cantidad debe ser mayor a 0.");

        if (amount > Balance)
            throw new InvalidOperationException("Insuficientes fondos.");

        Balance -= amount;
    }
}