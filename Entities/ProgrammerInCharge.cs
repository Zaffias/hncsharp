namespace HNProject.Entities;
using HNProject.Interfaces;

public class ProgrammerInCharge: IEmployee
{
    public List<Employee> Employees {get; set;} = new();

    
    public ProgrammerInCharge(List<Employee> employees)
    {
        Employees = employees;
    }

    //Empty constructor in case there are no employees managed by the programmer in charge.
    public ProgrammerInCharge(){}

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
}