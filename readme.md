## Execution

To run the application use `dotnet run` on the directory where Chsarpconsole.csproj is.


## Usage

A `itcompany.json` is needed to load the program.
If the file  `itcompany.json` does not exist a new one will be created automatically using dummy data.
The application has a basic CLI interface, you can select up to 3 options:

#### Report

This will read the file `itcompany.json` located in the root directory and generate a report based on the example given, this report will be printed on the STDOUT. 

#### Update

Adds one more day to the working days of the employees.

#### Exit

Exits the program.