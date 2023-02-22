namespace HNProject.Entities;
using HNProject.Interfaces;

public class ProgrammerInCharge: IEmployee
{
    private DateTime endDate;
    public string? Activity{get; set;}
    public DateTime StartDate{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public float Payment{get; set;}
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
}