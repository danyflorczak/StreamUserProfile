using System;
using System.Net.Http;
using Newtonsoft.Json;

class SteamAPI {
    static void Main(string[] args) {
        string steamId = "76561198209273776";
        string apiKey = "EF5C8E2B08A10F7FF30BFBC4A595C2BB";
        string url = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={apiKey}&include_appinfo=true&steamid={steamId}&format=json";
        UserProfile profile = new UserProfile();
        profile.SteamId = steamId;
        profile.Games = new List<Game>();


        using (HttpClient client = new HttpClient()) {
            var json = client.GetStringAsync(url).Result;
            if (json == null) {
                Console.WriteLine("Error getting data");
                return;
            }
            dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("dupa");
            if (result?.response?.games == null)
            {
                Console.WriteLine("Error getting games data");
                return;
            }

        // Narazie to nie dziala bo get game details jest jakies zjebane
        //     foreach (var game in result.response.games) {
        //     Game gameProfile = new Game();
        //     gameProfile.Name = game.name;
        //     gameProfile.Playtime = game.playtime_forever;
        //     gameProfile.Genre = GetGameDetails(game.appid);
        //     profile.Games.Add(gameProfile);
        // }

            foreach (var game in result.response.games) {
                Console.WriteLine((string)Convert.ToString(game.name));
                Console.WriteLine((string)Convert.ToString(game.appid));
            }
        }
    }

    private static string GetGameDetails(int appId) {
    string gameDetailsUrl = $"http://store.steampowered.com/api/appdetails?appids={appId}";
    using (HttpClient client = new HttpClient()) {
        var json = client.GetStringAsync(gameDetailsUrl).Result;
        if (json == null) {
            return "Error getting data";
        }
        dynamic result = JsonConvert.DeserializeObject(json) ?? throw new ArgumentException("dupa");
        if (result?.response?.genres == null)
        {
            return "Error getting game details data";
        }
        return result.response.genres[0].description;
    }
}

    class UserProfile {
    public string? SteamId { get; set; }
    public List<Game>? Games { get; set; }
    public int TotalPlaytime { get; set; }
    }

    class Game {
    public string? Name { get; set; }
    public int Playtime { get; set; }
    public int RequiredAge { get; set; }
    public string? Genre {get;set;}
    }

}