namespace HNProject.Helpers;
using HNProject.Entities;
public class DummyITCompany{
    public static ITCompany GenerateITCompany(){

        // In case there is not JSON file to read this dummy ITCompany will kick in, creating a hardcoded ITCompany to serve has a guide on how the json has to be formatted
        
        ITCompany company = new ITCompany();
        ProjectTeam team = new ProjectTeam();
        ProgrammerInCharge manager = new ProgrammerInCharge { FirstName = "John", LastName = "Doe", Activity = "Project management", Period = new DateTime(2022, 2, 22), Payment = 1000.0f };
        team.ProgrammersInCharge.Add(manager);
        Employee programmer1 = new Employee { FirstName = "Alice", LastName = "Smith", Activity = "Web development", Period = new DateTime(2022, 2, 22), Payment = 500.0f };
        Employee programmer2 = new Employee { FirstName = "Bob", LastName = "Johnson", Activity = "Mobile development", Period = new DateTime(2022, 2, 22), Payment = 600.0f };
        manager.Employees.Add(programmer1);
        manager.Employees.Add(programmer2);
        company.ProjectTeams.Add(team);
        return company;
    }

}