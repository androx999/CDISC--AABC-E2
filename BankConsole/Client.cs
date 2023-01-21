namespace BankConsole;

public class Client : User, IPerson
{
    public char TaxRegine {get; set;}

    public Client() {}
    public Client(int ID, string Name, string Email, decimal Balance, char TaxRegine) : base(ID, Name, Email, Balance)
    {
            this.TaxRegine =  TaxRegine;
            SetBalance(Balance);
    }
    public override void SetBalance(decimal amount)
    {
        base.SetBalance(amount);

        if(TaxRegine.Equals('M'))
            Balance += (amount * 0.02m);
    }

     public override string ShowData()
    {
        return base.ShowData() + $", Régimen Fiscal: {this.TaxRegine}";
    }

    public string GetName()
    {
        return Name;
    }

    public string GetCountry()
    {
       throw new NotImplementedException();
    }
}