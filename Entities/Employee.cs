namespace HNProject.Entities;

using HNProject.Interfaces;


public class Employee: IEmployee
{

    public string? Activity{get; set;}
    public DateTime? Period{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public float Payment{get; set;}
    public Employee(string firstName, string lastName, float payment){
        FirstName = firstName;
        LastName = lastName;
        Payment = payment;
    }
}