using HNProject.Helpers;
using HNProject.Entities;
using HNProject.Enums;


internal class Program
{
    static void Main(string[] args){

        ITCompany dummy = DummyITCompany.GenerateITCompany();
        bool done = false;
        while(!done)
        {
            try{
                ITCompany itCompany = JsonIo.JSONtoITCompany("./itcompany.json");
                Console.WriteLine("\nWhat would you like to do?\n0.Exit \n1.Report\n2.Update\n");
                var inputString = Console.ReadLine();
                if(inputString != null){
                    int option = int.Parse(inputString);
                    if(Enum.IsDefined(typeof(ConsoleOptions), option))
                    {
                        switch(option){
                            case (int)ConsoleOptions.REPORT:   
                                Reporter.Report(itCompany);
                                break;
                            case (int)ConsoleOptions.EXIT:
                                done = true;
                                break;
                            case (int)ConsoleOptions.UPDATE:
                                foreach(var projectTeam in itCompany.ProjectTeams)
                                {
                                    foreach(var programmerInCharge in projectTeam.ProgrammersInCharge)
                                    {
                                        programmerInCharge.WorkedDays++;
                                    }
                                }
                                JsonIo.ITCompanyToJSON("./itcompany.json", itCompany);
                                Console.WriteLine("Updated succesfully");
                                break;
                        }
                    }
                    else throw new Exception("That option does not exist");
                }
                    else throw new Exception("You must choose an option");
            }catch(Exception e){
                Console.WriteLine(e.Message);
                // -2147024894 is the code that filenotfound error generates.
                if(e.HResult == -2147024894){
                    Console.WriteLine("Creating new file with dummy properties...");
                    JsonIo.ITCompanyToJSON("./itcompany.json", dummy);
                }
            }
        }
    }
}
