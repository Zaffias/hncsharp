namespace HNProject.Entities;
using HNProject.Interfaces;

public class ProgrammerInCharge: IEmployee
{
    
    private int _workedDays;
    private DateTime endDate;
    public string? Activity{get; set;}
    public DateTime StartDate{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public float PaymentPerDay{get; set;} 
    public int  WorkedDays{
        get => _workedDays; 
        set => _workedDays = value;
    }
    
    public ProgrammerInCharge()
    {
        if(FirstName == null)
        {
            FirstName = "I have no name :(";
        }
        if(LastName == null)
        {
            LastName = "I have no surname :(";
        }
        
    }
    public DateTime EndDate
    {
        get{return endDate;}
        set{
            if(value < StartDate)
            {
                throw new Exception("EndDate must be after StartDate");
            }
            endDate = value;
        }
    }

    public TimeSpan GetInterval()
    {
        return EndDate - StartDate;
    }

    public float TotalCost()
    {
        return PaymentPerDay * WorkedDays;
    }
}