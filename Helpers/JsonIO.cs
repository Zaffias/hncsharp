namespace HNProject.Helpers;
using System.Text.Json;
using HNProject.Entities;

/// Helper class to wrap the System.Text.Json api provided by .NET
public class JsonIo{

    private static string _getJSONFileContent(string path){
        string text = File.ReadAllText(path);
        if(text.Length == 0)
            throw new Exception("Couldn't read the file, is the path correct and has the file content?");
        return text;
        
    }
    public static ITCompany JSONtoITCompany(string path){
        ITCompany? itCompany = JsonSerializer.Deserialize<ITCompany>(_getJSONFileContent(path));
        if(itCompany == null || itCompany.ProjectTeams.Count == 0){
            throw new Exception("Couldn't deserialize the JSON file, check if the formatting is correct");
        }
        return itCompany;
    }

    public static  void ITCompanyToJSON(string fileName, ITCompany itCompany){
        using FileStream createStream = File.Create(fileName);
        JsonSerializer.Serialize(createStream, itCompany, new JsonSerializerOptions {WriteIndented = true});
        createStream.Close();
    }
}