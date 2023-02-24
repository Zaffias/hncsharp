using HNProject.Helpers;
using HNProject.Entities;
using HNProject.Enums;
using System.Text.Json;
internal class Program
{
    static void Main(string[] args){

        // Creates a dummy ITcompany that will be loaded if no itcompany.json is located in the root directory.
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
                Console.WriteLine("\nWhat would you like to do?\n0.Exit \n1.Report\n2.Update\n3.Add employee\n4.Add team\n5.Delete team");
                var inputString = Console.ReadLine();
                if(inputString != null){
                    int option = int.Parse(inputString);
                    if(Enum.IsDefined(typeof(ConsoleOptions), option))
                    {
                        switch(option){
                            // Output the IT Company
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
                            case (int)ConsoleOptions.ADDEMPLOYEE:
                            {
                                Tuple<ProjectTeam, int> selectedTeam = ITCompany.SelectTeam("Select which team the employee will be added\n", itCompany);
                                ITCompany.AddProgrammer(selectedTeam.Item1);
                                JsonIo.ITCompanyToJSON("./itcompany.json", itCompany);
                                break;
                            }
                            // Creates a new project team.
                            case (int)ConsoleOptions.ADDTEAM:
                                ITCompany.AddProjectTeam(itCompany);
                                JsonIo.ITCompanyToJSON("./itcompany.json", itCompany);
                                break;
                            // Deletes an existing project team.
                            case (int)ConsoleOptions.DELETE:
                            {
                                Tuple<ProjectTeam, int> selectedTeam = ITCompany.SelectTeam("Select which team you want to delete\n", itCompany);
                                ITCompany.DeleteTeam(selectedTeam, itCompany);
                                JsonIo.ITCompanyToJSON("./itcompany.json", itCompany);
                                break;
                            }
                        }
                    }
                    else throw new Exception("That option does not exist");
                }
                else throw new Exception("You must choose an option");
            }
            catch(FileNotFoundException e)
            {
                // Creates a new itcompany.json if it didn't exist.
                Console.WriteLine(e.Message);
                Console.WriteLine("Creating new file with dummy properties...");
                JsonIo.ITCompanyToJSON("./itcompany.json", dummy);
            }
            // Regenerates the dummy if the JSON is malformed
            catch(JsonException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Creating new file with dummy properties...");
                File.Delete("./itcompany.json");
                JsonIo.ITCompanyToJSON("./itcompany.json", dummy);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
