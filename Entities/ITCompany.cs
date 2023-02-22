namespace HNProject.Entities;
public class ITCompany
{
    public List<ProjectTeam> ProjectTeams{get; set;}

    public ITCompany(){
        ProjectTeams = new List<ProjectTeam>();
    }

    public static void AddProgrammer(ProjectTeam projectTeam)
    {
        Console.WriteLine("Insert the programmer first name");
        string? firstName = Console.ReadLine();
        if(firstName == null || firstName.Any(x => !char.IsLetter(x)))
            throw new FormatException("You must introduce a first name");

        Console.WriteLine("Insert the programmer last name");
        string? lastName = Console.ReadLine();
        if(lastName == null || lastName.Any(x => !char.IsLetter(x)))
            throw new FormatException("You must introduce a last name");
        
        Console.WriteLine("Insert the programmer Activity");
        string? activity = Console.ReadLine();
        if(activity == null || activity.Any(x => !char.IsLetter(x)))
            throw new FormatException("You must introduce a last name");
        
        DateTime startDate = DateTime.Now;
        
        Console.WriteLine("Insert the programmer payment per hour");
        float payment = float.Parse(Console.ReadLine());
        
        Console.WriteLine("Insert the end date in the following format YYYY-MM-dd");
        
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        
        projectTeam.ProgrammersInCharge.Add(new ProgrammerInCharge{FirstName = firstName, LastName = lastName, Activity = activity, StartDate = startDate, EndDate = endDate, PaymentPerDay = payment, WorkedDays = 0});
    }
}