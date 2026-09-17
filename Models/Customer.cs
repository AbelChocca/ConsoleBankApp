namespace ConsoleBankingApp.Models;

public class Customer
{
    public Guid Id {get;}
    public string Name {get;}
    public string DocumentNumber {get;}

    public Customer(string name, string documentNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre es requerido.");

        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new ArgumentException("El numero de documento es requerido.");

        Id = Guid.NewGuid();
        Name = name;
        DocumentNumber = documentNumber;
    }
}