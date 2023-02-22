namespace HNProject.Helpers;
using HNProject.Entities;
public class DummyITCompany{
    public static ITCompany GenerateITCompany(){

        // In case there is not JSON file to read this dummy ITCompany will kick in, creating a hardcoded ITCompany to serve has a guide on how the json has to be formatted

        ITCompany company = new ITCompany();
        ProjectTeam team1 = new ProjectTeam{ProjectName = "Web Development"};
        ProjectTeam team2 = new ProjectTeam{ProjectName = "Mobile Development"};
        ProgrammerInCharge programmer1 = new ProgrammerInCharge { FirstName = "Morpheus", LastName = "Sleeping", Activity = "Frontend", StartDate = new DateTime(2022, 2, 22), PaymentPerDay = 40.0f, EndDate = new DateTime(2022, 3, 22), WorkedDays = 20 };
        ProgrammerInCharge programmer2 = new ProgrammerInCharge { FirstName = "Neo", LastName = "Believer", Activity = "Backend", StartDate = new DateTime(2022, 2, 22), PaymentPerDay = 25.0f, EndDate = new DateTime(2022, 3, 22), WorkedDays = 20 };
        team1.ProgrammersInCharge.Add(programmer1);
        team1.ProgrammersInCharge.Add(programmer2);
        ProgrammerInCharge programmer3 = new ProgrammerInCharge { FirstName = "Doggo", LastName = "Smith", Activity = "Frontend", StartDate = new DateTime(2022, 2, 22), PaymentPerDay = 68.0f, EndDate = new DateTime(2022, 3, 22), WorkedDays = 20 };
        ProgrammerInCharge programmer4 = new ProgrammerInCharge { FirstName = "Agent", LastName = "Johnson", Activity = "Backend", StartDate = new DateTime(2022, 2, 22), PaymentPerDay = 45.0f, EndDate = new DateTime(2022, 3, 22), WorkedDays = 20 };
        team2.ProgrammersInCharge.Add(programmer3);
        team2.ProgrammersInCharge.Add(programmer4);
        company.ProjectTeams.Add(team1);
        company.ProjectTeams.Add(team2);
        return company;
    }
}