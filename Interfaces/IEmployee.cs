namespace HNProject.Interfaces;

public interface IEmployee
{
    public string? Activity{get; set;}
    public DateTime StartDate{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public float PaymentPerDay{get; set;}
    public int WorkedDays{get; set;}
    TimeSpan GetInterval();
}