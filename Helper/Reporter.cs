namespace HNProject.Helpers;

using HNProject.Entities;
using HNProject.Interfaces;

public class Reporter: IReporter{
   public void Report(ProjectTeam projectTeam){
    var programmers = projectTeam.ProgrammerInCharges;
   }
}