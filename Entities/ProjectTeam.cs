namespace HNProject.Entities;
using HNProject.Interfaces;
using HNProject.Helpers;
public class ProjectTeam
{
    public enum TypeOfTeamEnum
    {
        FullPayed,
        HalfPayed
    }
    public List<ProgrammerInCharge> ProgrammersInCharge{get; set;}
    public string? ProjectName{get; set;}
    public ProjectTeam()
    {
        ProgrammersInCharge = new List<ProgrammerInCharge>();
    }
    public ProjectTeam(string projectName)
    {
        ProgrammersInCharge = new List<ProgrammerInCharge>();
        ProjectName = projectName;
    }
    public TypeOfTeamEnum TypeOfTeam{get; set;}

}