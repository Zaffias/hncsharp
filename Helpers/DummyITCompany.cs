namespace HNProject.Helpers;
using HNProject.Entities;
public class DummyITCompany{
    public static ITCompany GenerateITCompany(){

        // In case there is not JSON file to read this dummy ITCompany will kick in, creating a hardcoded ITCompany to serve has a guide on how the json has to be formatted

        ITCompany company = new ITCompany();
        ProjectTeam team1 = new ProjectTeam{ProjectName = "Web Development"};
        ProjectTeam team2 = new ProjectTeam{ProjectName = "Mobile Development"};
        ProgrammerInCharge manager = new ProgrammerInCharge { FirstName = "John", LastName = "Doe", Activity = "Project management", StartDate = new DateTime(2022, 2, 22), Payment = 1000.0f, EndDate = new DateTime(2022, 3, 22) };
        ProgrammerInCharge programmer1 = new ProgrammerInCharge { FirstName = "Morpheus", LastName = "Sleeping", Activity = "Frontend", StartDate = new DateTime(2022, 2, 22), Payment = 500.0f, EndDate = new DateTime(2022, 3, 22) };
        ProgrammerInCharge programmer2 = new ProgrammerInCharge { FirstName = "Neo", LastName = "Believer", Activity = "Backend", StartDate = new DateTime(2022, 2, 22), Payment = 600.0f, EndDate = new DateTime(2022, 3, 22) };
        team1.ProgrammersInCharge.Add(manager);
        team1.ProgrammersInCharge.Add(programmer1);
        team1.ProgrammersInCharge.Add(programmer2);
        ProgrammerInCharge manager2 = new ProgrammerInCharge { FirstName = "Cat", LastName = "Whiskers", Activity = "Project management", StartDate = new DateTime(2022, 2, 22), Payment = 1000.0f, EndDate = new DateTime(2022, 3, 22) };
        ProgrammerInCharge programmer3 = new ProgrammerInCharge { FirstName = "Doggo", LastName = "Smith", Activity = "Frontend", StartDate = new DateTime(2022, 2, 22), Payment = 500.0f, EndDate = new DateTime(2022, 3, 22) };
        ProgrammerInCharge programmer4 = new ProgrammerInCharge { FirstName = "Agent", LastName = "Johnson", Activity = "Backend", StartDate = new DateTime(2022, 2, 22), Payment = 600.0f, EndDate = new DateTime(2022, 3, 22) };
        team2.ProgrammersInCharge.Add(manager2);
        team2.ProgrammersInCharge.Add(programmer3);
        team2.ProgrammersInCharge.Add(programmer4);
        company.ProjectTeams.Add(team1);
        company.ProjectTeams.Add(team2);
        return company;
    }
}