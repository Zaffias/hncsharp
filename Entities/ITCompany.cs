namespace HNProject.Entities;
public class ITCompany
{
    public List<ProjectTeam> ProjectTeams{get; set;}

    public ITCompany(){
        ProjectTeams = new List<ProjectTeam>();
    }
}