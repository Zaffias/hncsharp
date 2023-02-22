namespace HNProject.Helpers;
using System.Text.Json;
using HNProject.Entities;
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

    public static async void ITCompanyToJSON(string fileName, ITCompany itCompany){
        using FileStream createStream = File.Create(fileName);
        await JsonSerializer.SerializeAsync(createStream, itCompany, new JsonSerializerOptions {WriteIndented = true});
        await createStream.DisposeAsync();
    }
}