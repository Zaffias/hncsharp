namespace HNProject.Entities;
using HNProject.Interfaces;
using HNProject.Helpers;
public class ProjectTeam
{
    public enum TypeOfTeamEnum{
        FullPayed,
        HalfPayed
    }
    public List<ProgrammerInCharge> ProgrammersInCharge = new();
    public TypeOfTeamEnum TypeOfTeam{get; set;}

    public ProjectTeam(){}
}