namespace HNProject.Helpers;

using HNProject.Entities;


public class Reporter{

   public static void Report(ITCompany itCompany){

      int programmers = 0;
      foreach(var projectTeam in itCompany.ProjectTeams){
         programmers += projectTeam.ProgrammersInCharge.Count;
      }
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("IT-COMPANY report:\n\nIT Company is currently composed of {0} project teams and {1} programmers\n", itCompany.ProjectTeams.Count, programmers);

      // TODO:I dont know how to do the month thing.
      Console.WriteLine("PROJECT TEAMS DETAILS:\n");
      foreach(var projectTeam in itCompany.ProjectTeams){
         Console.BackgroundColor = ConsoleColor.Blue;
         Console.ForegroundColor = ConsoleColor.White;
         Console.Write("Project team - {0}:", projectTeam.ProjectName);
         Console.ResetColor();
         Console.WriteLine();
         foreach(var programmerInCharge in projectTeam.ProgrammersInCharge){
            Console.WriteLine("- {0} {1} - In charge of {2} from {3} to {4} (duration: {5} days.), has worked a total of {7} hours, costing a total of {6}$", 
               programmerInCharge.LastName, programmerInCharge.FirstName, programmerInCharge.Activity, 
               programmerInCharge.StartDate.ToString("MM/dd/yyyy"), programmerInCharge.EndDate.ToString("MM/dd/yyyy"), ((int)programmerInCharge.GetInterval().TotalDays), programmerInCharge.TotalCost(), programmerInCharge.WorkedDays); 

         }
      }
      
   }
}