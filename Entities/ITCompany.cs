namespace HNProject.Entities;
public class ITCompany
{
    public List<ProjectTeam> ProjectTeams{get; set;}

    public ITCompany(){
        ProjectTeams = new List<ProjectTeam>();
    }

    /// Static method that adds a programmer to a team passed by reference.
    public static void AddProgrammer(ProjectTeam projectTeam)
    {
        Console.WriteLine("Insert the programmer first name:");
        string? firstName = Console.ReadLine().Trim();
        if(firstName == null || firstName.Any(x => !char.IsLetter(x)) || firstName.Length == 0)
            throw new FormatException("Formatting was incorrect, a name can only consist of letters");

        Console.WriteLine("Insert the programmer last name:");
        string? lastName = Console.ReadLine().Trim();
        if(lastName == null || lastName.Any(x => !char.IsLetter(x)) || lastName.Length == 0)
            throw new FormatException("Formatting was incorrect, a name can only consist of letters");
        
        Console.WriteLine("Insert the programmer activity:");
        string? activity = Console.ReadLine().Trim();
        if(activity == null || activity.Length == 0)
            throw new FormatException("You must introduce an activity");
        
        DateTime startDate = DateTime.Now;
        
        Console.WriteLine("Insert the programmer payment per hour:");
        float payment = float.Parse(Console.ReadLine());
        
        Console.WriteLine("Insert the end date in the following format YYYY-MM-dd (it has to be a date after today.):");
        
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        
        projectTeam.AddProgrammer(new ProgrammerInCharge{FirstName = firstName, LastName = lastName, Activity = activity, StartDate = startDate, EndDate = endDate, PaymentPerDay = payment, WorkedDays = 0});
        Console.WriteLine("***CREATED NEW EMPLOYEE***");
    }

    /// Creates a new project team on the IT Company referenced on the parameter
    public static void AddProjectTeam(ITCompany itCompany)
    {
        bool halfPayed = false;
        Console.WriteLine("What is the name of the project?");
        string? projectName = Console.ReadLine().Trim();
        if(projectName == null || projectName.Length == 0)
            throw new FormatException("You must introduce a project name");
        
        Console.WriteLine("Is the project half payed? (y/n)");
        string? answer = Console.ReadLine().Trim().ToLower();
        if (answer != "y" && answer != "n")
            throw new FormatException("The answer must be y or n");
        if(answer == "y")
            halfPayed = true;
        itCompany.ProjectTeams.Add(new ProjectTeam{ProjectName = projectName, HalfPayed = halfPayed});
        Console.WriteLine("****YAY! New project created****");
    }

    /// Returns the selected team and the index of where is located on the list
    public static Tuple<ProjectTeam, int> SelectTeam(string message, ITCompany itCompany)
    {
        Console.WriteLine(message);
        int index = 1;
        foreach(var projectTeam in itCompany.ProjectTeams)
        {
            Console.WriteLine($"{index}.{projectTeam.ProjectName}");
            index++;
        }
        int addOption = int.Parse(Console.ReadLine());
        if(Enumerable.Range(1, itCompany.ProjectTeams.Count).Contains(addOption))
        {
            return Tuple.Create(itCompany.ProjectTeams[addOption - 1], addOption);
        }
        else
        {
            throw new Exception("You must choose an existing group");
        }
    }

    public static void DeleteTeam(Tuple<ProjectTeam, int> projectTeam, ITCompany itCompany)
    {
        itCompany.ProjectTeams.RemoveAt(projectTeam.Item2 - 1);
        Console.WriteLine($"***TEAM DELETED***");
    } 
}


