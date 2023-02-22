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

    /// This methods is necessary to manage the programmer salary based on the type of team.
    /// So instead of adding programmers to the list via List.Add() we have to use this method.
    public void AddProgrammer(ProgrammerInCharge programmer)
    {
        if(HalfPayed)
        {
            programmer.PaymentPerDay /= 2;
        }
        ProgrammersInCharge.Add(programmer);
    }
}