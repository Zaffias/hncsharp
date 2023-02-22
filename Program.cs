﻿using HNProject.Helpers;
using HNProject.Entities;
using HNProject.Enums;
using HNProject.Interfaces;
using System.IO;
using System.Text.Json;
using System.Text.Encodings;

internal class Program
{
    static void Main(string[] args){

        ITCompany dummy = DummyITCompany.GenerateITCompany();
        
        bool done = false;
        
        while(!done){
            try{
                Console.WriteLine("\nWhat would you like to do?\n0.Exit \n1. Report\n");
                var inputString = Console.ReadLine();
                if(inputString != null){
                    int option = int.Parse(inputString);
                    if(Enum.IsDefined(typeof(ConsoleOptions), option))
                    {
                        switch(option){
                            case (int)ConsoleOptions.REPORT:
                            ITCompany itCompany = JsonIo.JSONtoITCompany("./ITcompany.json");
                            Reporter.Report(itCompany);
                            // JsonIo.ITCompanyToJSON("./itcompany.json", dummy);
                                break;
                            case (int)ConsoleOptions.EXIT:
                                done = true;
                                break;
                        }
                    }
                    else throw new Exception("That option does not exist");
                }
                else throw new Exception("You must choose an option");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
        
    }
}
