namespace HNProject.Helpers;
using System.Text.Json;
using HNProject.Entities;
public class JsonIo{

    private static string _getJSONFileContent(string path){
        return File.ReadAllText(path);
    }
    public static ProjectTeam JSONtoProjectTeam(string path){
        ProjectTeam? projectTeam = JsonSerializer.Deserialize<ProjectTeam>(_getJSONFileContent(path));
        if(projectTeam == null){
            throw new Exception("Couldn't deserialize the json file, check if the formatting is correct");
        }
        return projectTeam;
    }

    public static async void ProjectTeamToJSON(string fileName, ProjectTeam projectTeam){
        using FileStream createStream = File.Create(fileName);
        await JsonSerializer.SerializeAsync(createStream, projectTeam);
        await createStream.DisposeAsync();
    }
}