namespace HNProject.Helpers;

using HNProject.Entities;


public class Reporter{

   public static void Report(ITCompany itCompany){

      int programmers = 0;
      foreach(var projectTeam in itCompany.ProjectTeams){
         foreach(var programmerIncharge in projectTeam.ProgrammersInCharge){
            programmers += programmerIncharge.Employees.Count;
            // We count the programmer in charge as a programmer too, so we increment programmers for every iteration over the programmersInCharge of a team
            programmers++;
         }
      }
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("IT-COMPANY report:\n\nIT Company is currently composed of {0} project teams and {1} programmers\n", itCompany.ProjectTeams.Count, programmers);

      // TODO:I dont know how to do the month thing.
      Console.WriteLine("PROJECT TEAMS DETAILS:\n");

      // I decided to nest the programmers inside of the programmer in charge, this could lead to iterating a bit more, but for reasons of organization I decided to keep it this way.
      // This should not be a problem in a real world enviroment reading from a database.
      foreach(var projectTeam in itCompany.ProjectTeams){
         Console.BackgroundColor = ConsoleColor.Blue;
         Console.ForegroundColor = ConsoleColor.White;
         Console.Write("Project team - {0}:", projectTeam.ProjectName);
         Console.ResetColor();
         Console.WriteLine();
         foreach(var programmerInCharge in projectTeam.ProgrammersInCharge){
            Console.WriteLine("- {0} {1} - In charge of {2} from {3} to {4} (duration: {5} days.), this month placeholder, costing a total of {6}$", 
               programmerInCharge.LastName, programmerInCharge.FirstName, programmerInCharge.Activity, 
               programmerInCharge.StartDate.ToString("MM/dd/yyyy"), programmerInCharge.EndDate.ToString("MM/dd/yyyy"), programmerInCharge.GetInterval().TotalDays, programmerInCharge.Payment); 
            foreach(var employee in programmerInCharge.Employees){
                           Console.WriteLine("- {0} {1} - In charge of {2} from {3} to {4} (duration: {5} days.), this month placeholder, costing a total of {6}$", 
               employee.LastName, employee.FirstName, employee.Activity, employee.StartDate.ToString("MM/dd/yyyy"), employee.EndDate.ToString("MM/dd/yyyy"), employee.GetInterval().TotalDays, employee.Payment);
            }
         }
      }
   }
}