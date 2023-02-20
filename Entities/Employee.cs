namespace HNProject.Entities;

using HNProject.Interfaces;


public class Employee: IEmployee
{
    public enum EmployeePayment
    {
        FullPaid,
        HalfPaid
    }
    public string? Activity{get; set;}
    public DateTime? Period{get; set;}
    public EmployeePayment PaymentType{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public float Payment{get; set;} 
}