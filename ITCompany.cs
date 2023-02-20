using HNProject.Entities;
using System.IO;
using System.Text.Json;
using System.Text.Encodings;
internal class ITCompany
{
    static void Main(string[] args){
        string path = "./ITcompany.json";
        Employee employee = new();
        employee.Activity = "Espabila";
        employee.FirstName = "pepe";
        employee.LastName = "XD";
        employee.Period = new();
        employee.PaymentType = Employee.EmployeePayment.FullPaid;
        employee.Payment = 2;
        List<Employee> employees = new();
        employees.Add(employee);
        ProgrammerInCharge jefaso = new(employees);
        

        string jsonObject = JsonSerializer.Serialize<ProgrammerInCharge>(jefaso);
        if(!File.Exists(path))
        {
            FileStream sw = File.Create(path);
        }else{
            File.WriteAllText(path, jsonObject);
        }
    }
}
