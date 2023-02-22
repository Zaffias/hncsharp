namespace HNProject.Entities;
using HNProject.Interfaces;

public class ProgrammerInCharge: Employee
{
    public List<Employee> Employees {get; set;}

    public ProgrammerInCharge(){
        Employees = new List<Employee>();
    }
}