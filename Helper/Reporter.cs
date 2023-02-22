namespace HNProject.Helpers;

using HNProject.Entities;
using HNProject.Interfaces;

public class Reporter{

   public static void Report(ProjectTeam projectTeam){
      var programmersInCharge = projectTeam.ProgrammersInCharge;

      Console.WriteLine("IT-COMPANY report:\n\nIT Company is currently composed of {0} programmers", programmersInCharge.Count);
   }
}