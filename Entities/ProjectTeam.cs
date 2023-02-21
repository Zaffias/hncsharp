namespace HNProject.Entities;
using HNProject.Interfaces;
using HNProject.Helpers;
public class ProjectTeam
{
    private IReporter _reporter;
    public enum TypeOfTeamEnum{
        FullPayed,
        HalfPayed
    }
    public List<ProgrammerInCharge> ProgrammerInCharges = new();
    public TypeOfTeamEnum TypeOfTeam{get; set;}
    public ProjectTeam(Reporter reporter){
        
    }
    public ProjectTeam(){

    }
}