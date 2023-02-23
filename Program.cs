using HNProject.Helpers;
using HNProject.Entities;
using HNProject.Enums;
using System.Reflection;

internal class Program
{
    static void Main(string[] args){

        // The dummy it company.
        //
        ITCompany dummy = DummyITCompany.GenerateITCompany();
        bool done = false;
        while(!done)
        {
            try{
                // Tries to load the file where the data is located.
                // If no file is provided a new one will be automatically created.
                ITCompany itCompany = JsonIo.JSONtoITCompany("./itcompany.json");
                // Reads user input
                Console.WriteLine("\nWhat would you like to do?\n0.Exit \n1.Report\n2.Update\n3.Add employee\n4.Add team");
                var inputString = Console.ReadLine();
                if(inputString != null){
                    int option = int.Parse(inputString);
                    if(Enum.IsDefined(typeof(ConsoleOptions), option))
                    {
                        switch(option){
                            // Output the IT Company.
                            case (int)ConsoleOptions.REPORT:   
                                Reporter.Report(itCompany);
                                break;
                            // Exits the program
                            case (int)ConsoleOptions.EXIT:
                                done = true;
                                break;
                            // Adds one day to the working count of employees
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
                            // Adds a new employee to an  already defined team.
                            // The teams can be defined in the JSON.
                            case (int)ConsoleOptions.ADDEMPLOYEE:
                                Console.WriteLine("Select the team you want to add the programmer to:\n");
                                int index = 1;
                                foreach(var projectTeam in itCompany.ProjectTeams)
                                {
                                    Console.WriteLine($"{index}.{projectTeam.ProjectName}");
                                    index++;
                                }
                                int addOption = int.Parse(Console.ReadLine());
                                if(Enumerable.Range(1, itCompany.ProjectTeams.Count).Contains(addOption))
                                {
                                    ProjectTeam selectedTeam = itCompany.ProjectTeams[addOption - 1];
                                    ITCompany.AddProgrammer(selectedTeam);
                                    JsonIo.ITCompanyToJSON("./itcompany.json", itCompany);
                                    Console.WriteLine("***CREATED NEW EMPLOYEE***");
                                }
                                else
                                {
                                    throw new Exception("You must choose an existing group");
                                }
                                break;
                                case (int)ConsoleOptions.ADDTEAM:
                                    ITCompany.AddProjectTeam(itCompany);
                                    JsonIo.ITCompanyToJSON("./itcompany.json", itCompany);
                                    break;
                        }
                    }
                    else throw new Exception("That option does not exist");
                }
                    else throw new Exception("You must choose an option");
            }catch(FileNotFoundException e)
            {
                // Creates a new itcompany.json if it didn't exist.
                Console.WriteLine(e.Message);
                Console.WriteLine("Creating new file with dummy properties...");
                JsonIo.ITCompanyToJSON("./itcompany.json", dummy);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
