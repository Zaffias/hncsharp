namespace HNProject.Entities;
using HNProject.Interfaces;
using HNProject.Helpers;
public class ProjectTeam
{
    private bool _halfPayed = false;
    public bool HalfPayed{get => _halfPayed; set => _halfPayed = value;}
    public List<ProgrammerInCharge> ProgrammersInCharge{get; set;}
    public string? ProjectName{get; set;}
    public ProjectTeam()
    {
        ProgrammersInCharge = new List<ProgrammerInCharge>();
    }
}