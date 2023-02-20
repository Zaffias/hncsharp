namespace HNProject.Entities;

public class ProjectTeam
{
    public enum TypeOfTeamEnum{
        FullPayed,
        HalfPayed
    }
    public List<ProgrammerInCharge> ProgrammerInCharges = new();
    public TypeOfTeamEnum TypeOfTeam{get; set;}
}